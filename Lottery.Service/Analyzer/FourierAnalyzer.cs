using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AForge.Math;
using Lottery.Entities;
using Lottery.Interfaces.Analyzer;

namespace Lottery.Service.Analyzer
{
    public class FourierAnalyzer : IAnalyzer
    {
        public async Task<List<AnalyzeResult>> Analyze(List<LotteryRecord> records, int period, int variableTwo)
        {
            return await Task.Run(() =>
            {
                records = records.OrderByDescending(r => r.ID).Take(period).OrderBy(o => o.ID).ToList();

                int samplingCount = records.Count;
                var result = new List<AnalyzeResult>();
                if ((samplingCount & (samplingCount - 1)) != 0)
                    return result;

                Dictionary<int, List<Complex>> timeToNumTable = new Dictionary<int, List<Complex>>();
                Dictionary<int, List<Complex>> timeToSpNumTable = new Dictionary<int, List<Complex>>();
                var maxNumber = records.Max(r => r.Sixth);
                var maxNumberSp = records.Max(r => r.Special);

                InitialFFTTable(records, timeToNumTable, timeToSpNumTable, maxNumber, maxNumberSp);

                Dictionary<int, int> numberToCycleTable = new Dictionary<int, int>();
                Dictionary<int, int> numberSpToCycleTable = new Dictionary<int, int>();


                CalculateCycle(numberToCycleTable, timeToNumTable, maxNumber, samplingCount);
                CalculateCycle(numberSpToCycleTable, timeToSpNumTable, maxNumberSp, samplingCount);

                Dictionary<int, LotteryListRecord> listModels = new Dictionary<int, LotteryListRecord>();

                foreach (var m in records)
                {
                    listModels.Add(m.ID, new LotteryListRecord
                    {
                        ID = m.ID,
                        Date = m.Date,
                        Sp = m.Special,
                        NormalList = new List<int>
                    {
                        m.First,
                        m.Second,
                        m.Third,
                        m.Fourth,
                        m.Fifth,
                        m.Sixth
                    }
                    });
                }

                CalculateCyclePoint(numberToCycleTable, numberSpToCycleTable, listModels, result, samplingCount);
                return result;
            });
        }
        private void CalculateCycle(Dictionary<int, int> nresultTable, Dictionary<int, List<Complex>> timeToNumTable, int numbers, int samplingCount)
        {
            for (int num = 1; num <= numbers; num++)
            {
                var data = timeToNumTable[num].Skip(timeToNumTable[num].Count - samplingCount).ToArray();
                FourierTransform.FFT(data, FourierTransform.Direction.Forward);
                Dictionary<int, double> resultTable = new Dictionary<int, double>();
                for (double i = 1; i < samplingCount / 2; i++)
                {
                    int cycle = (int)Math.Round(samplingCount / (i + 1), 0);
                    var result = Math.Pow(data[(int)i].Re, 2) + Math.Pow(data[(int)i].Im, 2);
                    if (resultTable.ContainsKey(cycle))
                        resultTable[cycle] = Math.Max(resultTable[cycle], result);
                    else
                        resultTable.Add(cycle, result);
                }
                resultTable = resultTable.OrderByDescending(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
                nresultTable.Add(num, resultTable.First().Key);
            }
        }

        private void CalculateCyclePoint(
            Dictionary<int, int> numberToCycleTable,
            Dictionary<int, int> spNumberToCycleTable,
            Dictionary<int, LotteryListRecord> listModels,
            List<AnalyzeResult> result,
            int samplingCount)
        {
            int currentTime = listModels.Last().Key;
            int extensionTime = 0;
            Dictionary<int, double> numberToPointTable = new Dictionary<int, double>();
            Dictionary<int, double> spNumberToPointTable = new Dictionary<int, double>();

            while (numberToPointTable.Count < 25)
            {
                int point = samplingCount - (int)Math.Pow(2, extensionTime);
                if (point <= 0) break;
                foreach (var pair in numberToCycleTable)
                {
                    int target = currentTime - pair.Value + 1;
                    LotteryListRecord tmpList;
                    if (listModels.TryGetValue(target - extensionTime, out tmpList) && tmpList.NormalList.Contains(pair.Key))
                    {
                        if (numberToPointTable.ContainsKey(pair.Key))
                            numberToPointTable[pair.Key] += point;
                        else
                            numberToPointTable.Add(pair.Key, point);
                    }

                    if (listModels.TryGetValue(target + extensionTime, out tmpList) && tmpList.NormalList.Contains(pair.Key))
                    {
                        if (numberToPointTable.ContainsKey(pair.Key))
                            numberToPointTable[pair.Key] += point;
                        else
                            numberToPointTable.Add(pair.Key, point);
                    }
                }
                extensionTime++;
            }

            extensionTime = 0;
            while (!spNumberToPointTable.Any())
            {
                int point = samplingCount - (int)Math.Pow(2, extensionTime);
                if (point <= 0) break;
                foreach (var pair in spNumberToCycleTable)
                {
                    int target = currentTime - pair.Value + 1;

                    if (listModels.TryGetValue(target - extensionTime, out var value) && value.Sp == pair.Key)
                    {
                        if (spNumberToPointTable.ContainsKey(pair.Key))
                            spNumberToPointTable[pair.Key] += point;
                        else
                            spNumberToPointTable.Add(pair.Key, point);
                    }

                    if (listModels.TryGetValue(target + extensionTime, out value) && value.Sp == pair.Key)
                    {
                        if (spNumberToPointTable.ContainsKey(pair.Key))
                            spNumberToPointTable[pair.Key] += point;
                        else
                            spNumberToPointTable.Add(pair.Key, point);
                    }
                }
                extensionTime++;
            }

            result.AddRange(numberToPointTable.Select(p => new AnalyzeResult { IsSpecial = false, Number = p.Key, Point = p.Value }));
            result.AddRange(spNumberToPointTable.Select(p => new AnalyzeResult { IsSpecial = true, Number = p.Key, Point = p.Value }));
        }


        private void InitialFFTTable(List<LotteryRecord> models,
            Dictionary<int, List<Complex>> timeToNumTable, Dictionary<int, List<Complex>> timeToSpNumTable,
            int maxNumber, int MaxNumberSp)
        {
            for (int i = 1; i <= maxNumber; i++)
                timeToNumTable.Add(i, new List<Complex>());
            for (int i = 1; i <= MaxNumberSp; i++)
                timeToSpNumTable.Add(i, new List<Complex>());

            foreach (var model in models)
            {
                for (int i = 1; i <= maxNumber; i++)
                {
                    if (model.First == i || model.Second == i || model.Third == i || model.Fourth == i
                        || model.Fifth == i || model.Sixth == i)
                        timeToNumTable[i].Add(new Complex(1, 0));
                    else
                        timeToNumTable[i].Add(new Complex(0, 0));
                }

                for (int i = 1; i <= MaxNumberSp; i++)
                {
                    timeToSpNumTable[i].Add(i == model.Special ? new Complex(1, 0) : new Complex(0, 0));
                }
            }
        }
    }
}
