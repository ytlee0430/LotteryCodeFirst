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
        public async Task CalculateExpectValue(List<LotteryRecord> data, IAnalyzer analyzer, int expectValueCount, int period, int variableTwo,
            SortedDictionary<int, double> resultDic, SortedDictionary<int, double> specialResultDic)
        {
            var indexes = new List<int>();
            for (var i = 1; i <= expectValueCount; i++)
                indexes.Add(i);

            var shootCount = new ShootCount();

            await Task.WhenAll(indexes.Select(i => CountShoot(i, data, analyzer, period, variableTwo, shootCount)));


            resultDic.Add(period, (double)shootCount.Normal.Sum() / expectValueCount);
            specialResultDic.Add(period, (double)shootCount.Special.Sum() / expectValueCount);
        }

        private async Task CountShoot(int index, List<LotteryRecord> data, IAnalyzer analyzer, int period, int variableTwo, ShootCount shootCount)
        {
            var currentAnswer = data[data.Count - index];
            var analyzeData = data.Where(d => d.ID < currentAnswer.ID).ToList();
            var result = await analyzer.Analyze(analyzeData, period, variableTwo);
            var normalResult = result.Where(a => !a.IsSpecial).Take(6);
            var specialResult = result.Where(a => a.IsSpecial).Take(1);

            var currentShot = normalResult.Count(r => r.IsShoot(currentAnswer));
            var currentSpecialShot = specialResult.Count(r => r.IsShootSpecial(currentAnswer));

            if (currentShot == 6 && currentSpecialShot == 1)
                MessageBox.Show("Bingo!");

            shootCount.Normal.Add(currentShot); ;
            shootCount.Special.Add(currentSpecialShot);
        }

        private class ShootCount
        {
            public List<int> Normal { get; set; } = new List<int>();
            public List<int> Special { get; set; } = new List<int>();
        }
    }
}
