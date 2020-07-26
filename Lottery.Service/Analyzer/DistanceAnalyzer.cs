using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lottery.Entities;
using Lottery.Interfaces.Analyzer;

namespace Lottery.Service.Analyzer
{
    public class DistanceAnalyzer : IAnalyzer
    {
        public async Task<List<AnalyzeResult>> Analyze(List<LotteryRecord> records, int period, int variableTwo)
        {
            return await Task.Run(() =>
            {
                records = records.OrderByDescending(r => r.ID).Take(period).OrderBy(o => o.ID).ToList();

                var result = new List<AnalyzeResult>();
                var maxNumber = records.Max(r => r.Sixth);
                var maxNumberSp = records.Max(r => r.Special);

                var listModels = records.ToDictionary(m => m.ID, m => new LotteryListRecord
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

                Dictionary<int, Dictionary<DistanceModel, int>> timeDataTable = new Dictionary<int, Dictionary<DistanceModel, int>>();
                Dictionary<int, Dictionary<DistanceModel, int>> timeSPDataTable = new Dictionary<int, Dictionary<DistanceModel, int>>();

                CreateDistanceTableSpeedVer(listModels, timeDataTable, timeSPDataTable, maxNumber, maxNumberSp);

                CalculatePointSpeedVer(listModels, timeDataTable, timeSPDataTable, result);
                return result.OrderByDescending(r => r.Point).ThenBy(r => r.Number).ToList();
            });
        }

        private void CalculatePointSpeedVer(Dictionary<int, LotteryListRecord> listModel, Dictionary<int, Dictionary<DistanceModel, int>> timeDataTable, Dictionary<int, Dictionary<DistanceModel, int>> timeToSPdataTable, List<AnalyzeResult> result)
        {

            int firstIndex = listModel.OrderBy(p => p.Key).First().Key;
            int lastIndex = listModel.OrderByDescending(p => p.Key).First().Key;
            Dictionary<int, int>
                normalResultTable = new Dictionary<int, int>(),
                spResultTable = new Dictionary<int, int>();

            for (int timeIndex = firstIndex + 1; timeIndex <= lastIndex; timeIndex++)
            {
                int distance = lastIndex - timeIndex + 1;

                var preposCountTable = timeDataTable[distance];

                foreach (var num in listModel[timeIndex].NormalList)
                {
                    foreach (var prePosCount in preposCountTable.Where(pair => pair.Key.PreNumber == num && pair.Value != 0))
                    {
                        int posNumber = prePosCount.Key.PosNumber;
                        if (!normalResultTable.ContainsKey(posNumber))
                            normalResultTable.Add(posNumber, prePosCount.Value);
                        else
                            normalResultTable[posNumber] += prePosCount.Value;
                    }
                }

                preposCountTable = timeToSPdataTable[distance];
                var numSP = listModel[timeIndex].Sp;
                foreach (var prePosCount in preposCountTable.Where(pair => pair.Key.PreNumber == numSP))
                {
                    int posNumber = prePosCount.Key.PosNumber;
                    if (!spResultTable.ContainsKey(posNumber))
                        spResultTable.Add(posNumber, prePosCount.Value);
                    else
                        spResultTable[posNumber] += prePosCount.Value;
                }
            }

            result.AddRange(normalResultTable.Select(p => new AnalyzeResult { IsSpecial = false, Number = p.Key, Point = p.Value }));
            result.AddRange(spResultTable.Select(p => new AnalyzeResult { IsSpecial = true, Number = p.Key, Point = p.Value }));
        }



        private void CreateDistanceTableSpeedVer(Dictionary<int, LotteryListRecord> listModels,
            Dictionary<int, Dictionary<DistanceModel, int>> timeDataTable, Dictionary<int, Dictionary<DistanceModel, int>> timeToSPdataTable,
            int maxNumber, int maxNumberSP)
        {
            List<int> numberList = new List<int>();
            for (int i = 1; i <= maxNumber; i++)
                numberList.Add(i);

            List<int> spNumberList = new List<int>();
            for (int i = 1; i <= maxNumberSP; i++)
                spNumberList.Add(i);

            for (int i = 1; i < listModels.Count; i++)
            {
                timeDataTable.Add(i, new Dictionary<DistanceModel, int>());
                timeToSPdataTable.Add(i, new Dictionary<DistanceModel, int>());

                foreach (var preNum in numberList)
                    foreach (var posNum in numberList)
                        timeDataTable[i].Add(new DistanceModel { PreNumber = preNum, PosNumber = posNum }, 0);

                foreach (var preNum in spNumberList)
                    foreach (var posNum in spNumberList)
                        timeToSPdataTable[i].Add(new DistanceModel { PreNumber = preNum, PosNumber = posNum }, 0);
            }

            int firstIndex = listModels.OrderBy(p => p.Key).First().Key;
            int lastIndex = listModels.OrderByDescending(p => p.Key).First().Key;

            for (int posIndex = firstIndex + 1; posIndex <= lastIndex; posIndex++)
                for (int preIndex = firstIndex; preIndex < posIndex; preIndex++)
                {
                    int distance = posIndex - preIndex;

                    foreach (int preNum in listModels[preIndex].NormalList)
                    {
                        foreach (int posNum in listModels[posIndex].NormalList)
                        {
                            timeDataTable[distance][new DistanceModel { PreNumber = preNum, PosNumber = posNum }]++;
                        }
                    }

                    DistanceModel codeSp = new DistanceModel
                    {
                        PreNumber = listModels[preIndex].Sp,
                        PosNumber = listModels[posIndex].Sp
                    };
                    timeToSPdataTable[distance][codeSp]++;
                }
        }
    }
    public class DistanceModel
    {
        public int PreNumber { get; set; }
        public int PosNumber { get; set; }

        public override int GetHashCode()
        {
            int hashCode = PreNumber * 100 + PosNumber;
            return hashCode;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is DistanceModel))
                return false;

            DistanceModel model = (DistanceModel)obj;

            return PreNumber == model.PreNumber && this.PosNumber == model.PosNumber;
        }

        public static bool operator ==(DistanceModel model1, DistanceModel model2)
        {
            return model1.Equals(model2);
        }

        public static bool operator !=(DistanceModel model1, DistanceModel model2)
        {
            return !model1.Equals(model2);
        }
    }
}
