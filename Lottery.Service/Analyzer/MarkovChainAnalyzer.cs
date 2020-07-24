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
            var stochasticMatrix = new Dictionary<int, Dictionary<int, int>>();

            var maxNumberSp = records.Max(r => r.Special);
            var stochasticMatrixSp = new Dictionary<int, Dictionary<int, int>>();

            var tasks = new List<Task>
            {
                AnalyzeNormal(records, period, maxNumber, stochasticMatrix, result),
                AnalyzSpecial(records, period, maxNumberSp, stochasticMatrixSp, result)
            };
            await Task.WhenAll(tasks);
            return result.OrderByDescending(r => r.Point).ThenBy(r => r.Number).ToList();
        }

        protected async Task InitialStochasticMatrix(Dictionary<int, Dictionary<int, int>> stochasticMatrix, int maxNumber)
        {
            for (int number = 1; number <= maxNumber; number++)
            {
                var insertDic = new Dictionary<int, int>();
                for (int innerNumber = 1; innerNumber <= maxNumber; innerNumber++)
                    insertDic[innerNumber] = 0;
                stochasticMatrix[number] = insertDic;
            }
        }

        protected async Task AnalyzSpecial(List<LotteryRecord> records, int period, int maxNumber,
            Dictionary<int, Dictionary<int, int>> stochasticMatrix, List<AnalyzeResult> results)
        {
            await InitialStochasticMatrix(stochasticMatrix, maxNumber);
            for (int i = 0; i < period - 1; i++)
                SetupSpecialTStochasticMatrix(records, i, stochasticMatrix);
            var currentSpecial = records.Last().Special;
            results.AddRange(stochasticMatrix[currentSpecial].Select(p => new AnalyzeResult { IsSpecial = true, Number = p.Key, Point = p.Value }));
        }

        protected async Task AnalyzeNormal(List<LotteryRecord> records, int period, int maxNumber, Dictionary<int, Dictionary<int, int>> stochasticMatrix, List<AnalyzeResult> results)
        {
            await InitialStochasticMatrix(stochasticMatrix, maxNumber);

            for (int i = 0; i < period - 1; i++)
                await SetupNormalStochasticMatrix(records, i, stochasticMatrix);

            var currentPeriod = records.Last();

            var scoreDic = stochasticMatrix[currentPeriod.First].ToDictionary(p => p.Key, p => p.Value);
            foreach (var pair in stochasticMatrix[currentPeriod.Second])
                scoreDic[pair.Key] += pair.Value;
            foreach (var pair in stochasticMatrix[currentPeriod.Third])
                scoreDic[pair.Key] += pair.Value;
            foreach (var pair in stochasticMatrix[currentPeriod.Fourth])
                scoreDic[pair.Key] += pair.Value;
            foreach (var pair in stochasticMatrix[currentPeriod.Fifth])
                scoreDic[pair.Key] += pair.Value;
            foreach (var pair in stochasticMatrix[currentPeriod.Sixth])
                scoreDic[pair.Key] += pair.Value;

            results.AddRange(scoreDic.OrderByDescending(p => p.Value).Select(p => new AnalyzeResult
            {
                Number = p.Key,
                Point = p.Value
            }));
        }

        protected async Task SetupNormalStochasticMatrix(List<LotteryRecord> records, int index, Dictionary<int, Dictionary<int, int>> stochasticMatrix)
        {
            var priorPeriod = records[index];
            var currentPeriod = records[index + 1];
            stochasticMatrix[priorPeriod.First][currentPeriod.First]++;
            stochasticMatrix[priorPeriod.First][currentPeriod.Second]++;
            stochasticMatrix[priorPeriod.First][currentPeriod.Third]++;
            stochasticMatrix[priorPeriod.First][currentPeriod.Fourth]++;
            stochasticMatrix[priorPeriod.First][currentPeriod.Fifth]++;
            stochasticMatrix[priorPeriod.First][currentPeriod.Sixth]++;

            stochasticMatrix[priorPeriod.Second][currentPeriod.First]++;
            stochasticMatrix[priorPeriod.Second][currentPeriod.Second]++;
            stochasticMatrix[priorPeriod.Second][currentPeriod.Third]++;
            stochasticMatrix[priorPeriod.Second][currentPeriod.Fourth]++;
            stochasticMatrix[priorPeriod.Second][currentPeriod.Fifth]++;
            stochasticMatrix[priorPeriod.Second][currentPeriod.Sixth]++;

            stochasticMatrix[priorPeriod.Third][currentPeriod.First]++;
            stochasticMatrix[priorPeriod.Third][currentPeriod.Second]++;
            stochasticMatrix[priorPeriod.Third][currentPeriod.Third]++;
            stochasticMatrix[priorPeriod.Third][currentPeriod.Fourth]++;
            stochasticMatrix[priorPeriod.Third][currentPeriod.Fifth]++;
            stochasticMatrix[priorPeriod.Third][currentPeriod.Sixth]++;

            stochasticMatrix[priorPeriod.Fourth][currentPeriod.First]++;
            stochasticMatrix[priorPeriod.Fourth][currentPeriod.Second]++;
            stochasticMatrix[priorPeriod.Fourth][currentPeriod.Third]++;
            stochasticMatrix[priorPeriod.Fourth][currentPeriod.Fourth]++;
            stochasticMatrix[priorPeriod.Fourth][currentPeriod.Fifth]++;
            stochasticMatrix[priorPeriod.Fourth][currentPeriod.Sixth]++;

            stochasticMatrix[priorPeriod.Fifth][currentPeriod.First]++;
            stochasticMatrix[priorPeriod.Fifth][currentPeriod.Second]++;
            stochasticMatrix[priorPeriod.Fifth][currentPeriod.Third]++;
            stochasticMatrix[priorPeriod.Fifth][currentPeriod.Fourth]++;
            stochasticMatrix[priorPeriod.Fifth][currentPeriod.Fifth]++;
            stochasticMatrix[priorPeriod.Fifth][currentPeriod.Sixth]++;

            stochasticMatrix[priorPeriod.Sixth][currentPeriod.First]++;
            stochasticMatrix[priorPeriod.Sixth][currentPeriod.Second]++;
            stochasticMatrix[priorPeriod.Sixth][currentPeriod.Third]++;
            stochasticMatrix[priorPeriod.Sixth][currentPeriod.Fourth]++;
            stochasticMatrix[priorPeriod.Sixth][currentPeriod.Fifth]++;
            stochasticMatrix[priorPeriod.Sixth][currentPeriod.Sixth]++;
        }

        protected void SetupSpecialTStochasticMatrix(List<LotteryRecord> records, int index, Dictionary<int, Dictionary<int, int>> stochasticMatrix)
        {
            var priorPeriod = records[index];
            var currentPeriod = records[index + 1];
            stochasticMatrix[priorPeriod.Special][currentPeriod.Special]++;
        }
    }
}
