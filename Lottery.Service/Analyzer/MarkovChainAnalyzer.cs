using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using Lottery.Entities;
using Lottery.Interfaces.Analyzer;

namespace Lottery.Service.Analyzer
{
    public class MarkovChainAnalyzer : IAnalyzer
    {
        public async Task<List<AnalyzeResult>> Analyze(List<LotteryRecord> records, int period, int variableTwo)
        {
            var result = new List<AnalyzeResult>();
            records = records.OrderByDescending(r => r.ID).Take(period).OrderBy(o => o.ID).ToList();
            var maxNumber = records.Max(r => r.Sixth);
            var transposeArray = new Dictionary<int, Dictionary<int, int>>();
            result = await AnalyzeNormal(records, period, maxNumber, transposeArray);

            maxNumber = records.Max(r => r.Special);
            transposeArray = new Dictionary<int, Dictionary<int, int>>();
            await InitialTransposeArray(transposeArray, maxNumber);
            for (int i = 0; i < period - 1; i++)
                SetupSpecialTransposeArray(records, i, transposeArray);
            var currentSpecial = records.Last().Special;
            result.AddRange(transposeArray[currentSpecial].Select(p => new AnalyzeResult { IsSpecial = true, Number = p.Key, Point = p.Value }));

            return result.OrderByDescending(r => r.Point).ThenBy(r => r.Number).ToList();
        }

        private async Task InitialTransposeArray(Dictionary<int, Dictionary<int, int>> transposeArray, int maxNumber)
        {
            for (int number = 1; number <= maxNumber; number++)
            {
                var insertDic = new Dictionary<int, int>();
                for (int innerNumber = 1; innerNumber <= maxNumber; innerNumber++)
                    insertDic[innerNumber] = 0;
                transposeArray[number] = insertDic;
            }
        }

        private async Task<List<AnalyzeResult>> AnalyzeNormal(List<LotteryRecord> records, int period, int maxNumber, Dictionary<int, Dictionary<int, int>> transposeArray)
        {
            await InitialTransposeArray(transposeArray, maxNumber);

            for (int i = 0; i < period - 1; i++)
                await SetupNormalTransposeArray(records, i, transposeArray);

            var currentPeriod = records.Last();

            var scoreDic = transposeArray[currentPeriod.First].ToDictionary(p => p.Key, p => p.Value);
            foreach (var pair in transposeArray[currentPeriod.Second])
                scoreDic[pair.Key] += pair.Value;
            foreach (var pair in transposeArray[currentPeriod.Third])
                scoreDic[pair.Key] += pair.Value;
            foreach (var pair in transposeArray[currentPeriod.Fourth])
                scoreDic[pair.Key] += pair.Value;
            foreach (var pair in transposeArray[currentPeriod.Fifth])
                scoreDic[pair.Key] += pair.Value;
            foreach (var pair in transposeArray[currentPeriod.Sixth])
                scoreDic[pair.Key] += pair.Value;

            return scoreDic.OrderByDescending(p => p.Value).Select(p => new AnalyzeResult
            {
                Number = p.Key,
                Point = p.Value
            }).ToList();
        }

        private async Task SetupNormalTransposeArray(List<LotteryRecord> records, int index, Dictionary<int, Dictionary<int, int>> transposeArray)
        {
            var priorPeriod = records[index];
            var currentPeriod = records[index + 1];
            transposeArray[priorPeriod.First][currentPeriod.First]++;
            transposeArray[priorPeriod.First][currentPeriod.Second]++;
            transposeArray[priorPeriod.First][currentPeriod.Third]++;
            transposeArray[priorPeriod.First][currentPeriod.Fourth]++;
            transposeArray[priorPeriod.First][currentPeriod.Fifth]++;
            transposeArray[priorPeriod.First][currentPeriod.Sixth]++;

            transposeArray[priorPeriod.Second][currentPeriod.First]++;
            transposeArray[priorPeriod.Second][currentPeriod.Second]++;
            transposeArray[priorPeriod.Second][currentPeriod.Third]++;
            transposeArray[priorPeriod.Second][currentPeriod.Fourth]++;
            transposeArray[priorPeriod.Second][currentPeriod.Fifth]++;
            transposeArray[priorPeriod.Second][currentPeriod.Sixth]++;

            transposeArray[priorPeriod.Third][currentPeriod.First]++;
            transposeArray[priorPeriod.Third][currentPeriod.Second]++;
            transposeArray[priorPeriod.Third][currentPeriod.Third]++;
            transposeArray[priorPeriod.Third][currentPeriod.Fourth]++;
            transposeArray[priorPeriod.Third][currentPeriod.Fifth]++;
            transposeArray[priorPeriod.Third][currentPeriod.Sixth]++;

            transposeArray[priorPeriod.Fourth][currentPeriod.First]++;
            transposeArray[priorPeriod.Fourth][currentPeriod.Second]++;
            transposeArray[priorPeriod.Fourth][currentPeriod.Third]++;
            transposeArray[priorPeriod.Fourth][currentPeriod.Fourth]++;
            transposeArray[priorPeriod.Fourth][currentPeriod.Fifth]++;
            transposeArray[priorPeriod.Fourth][currentPeriod.Sixth]++;

            transposeArray[priorPeriod.Fifth][currentPeriod.First]++;
            transposeArray[priorPeriod.Fifth][currentPeriod.Second]++;
            transposeArray[priorPeriod.Fifth][currentPeriod.Third]++;
            transposeArray[priorPeriod.Fifth][currentPeriod.Fourth]++;
            transposeArray[priorPeriod.Fifth][currentPeriod.Fifth]++;
            transposeArray[priorPeriod.Fifth][currentPeriod.Sixth]++;

            transposeArray[priorPeriod.Sixth][currentPeriod.First]++;
            transposeArray[priorPeriod.Sixth][currentPeriod.Second]++;
            transposeArray[priorPeriod.Sixth][currentPeriod.Third]++;
            transposeArray[priorPeriod.Sixth][currentPeriod.Fourth]++;
            transposeArray[priorPeriod.Sixth][currentPeriod.Fifth]++;
            transposeArray[priorPeriod.Sixth][currentPeriod.Sixth]++;
        }

        private void SetupSpecialTransposeArray(List<LotteryRecord> records, int index, Dictionary<int, Dictionary<int, int>> transposeArray)
        {
            var priorPeriod = records[index];
            var currentPeriod = records[index + 1];
            transposeArray[priorPeriod.Special][currentPeriod.Special]++;
        }
    }
}
