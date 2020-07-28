using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lottery.Entities;
using Lottery.Interfaces;
using Lottery.Interfaces.Analyzer;

namespace Lottery.Service
{
    public class ExpectValueCalculator : IExpectValueCalculator
    {

        private object _lock = new object();

        public async Task CalculateExpectValue(List<LotteryRecord> data, IAnalyzer analyzer, int expectValueCount,
            int period, int variableTwo,
            SortedDictionary<int, double> resultDic, SortedDictionary<int, double> specialResultDic, int selectCount,
            bool showBingo, Action callback, SortedDictionary<int, double> shootIndexDic)
        {
            var indexes = new List<int>();
            var shootCount = new ShootCount();
            for (var i = 1; i <= expectValueCount; i++)
                indexes.Add(i);

            await Task.WhenAll(indexes.Select(i =>
                CountShoot(i, data, analyzer, period, variableTwo, shootCount, selectCount, showBingo)));

            lock (_lock)
            {
                resultDic.Add(period, (double)shootCount.Normal / expectValueCount);
                specialResultDic.Add(period, (double)shootCount.Special / expectValueCount);
                shootIndexDic.Add(period, (double)shootCount.ShootAllIndex / expectValueCount);
                callback();
            }
        }

        private async Task CountShoot(int index, List<LotteryRecord> data, IAnalyzer analyzer, int period, int variableTwo, ShootCount shootCount, int selectCount, bool showBingo)
        {
            var currentAnswer = data[data.Count - index];
            var analyzeData = data.Where(d => d.ID < currentAnswer.ID).ToList();
            var result = await analyzer.Analyze(analyzeData, period, variableTwo);
            var normalResult = result.Where(a => !a.IsSpecial).ToList();
            var specialResult = result.Where(a => a.IsSpecial).ToList();

            var count = 0;
            var shootIndex = 0;
            for (int i = 0; i < normalResult.Count; i++)
            {
                if (!normalResult[i].IsShoot(currentAnswer)) continue;
                count++;
                if (count != 6) continue;
                shootIndex = i;
                break;
            }

            var currentShot = normalResult.Take(selectCount).Count(r => r.IsShoot(currentAnswer));
            var currentSpecialShot = specialResult.Take(1).Count(r => r.IsShootSpecial(currentAnswer));

            if (showBingo && currentShot >= 6)
                MessageBox.Show("Bingo!");

            lock (_lock)
            {
                shootCount.Normal += (currentShot);
                shootCount.Special += (currentSpecialShot);
                shootCount.ShootAllIndex += shootIndex;
            }
        }

        private class ShootCount
        {
            public int Normal { get; set; } = 0;
            public int Special { get; set; } = 0;
            public int ShootAllIndex { get; set; } = 0;
        }
    }
}
