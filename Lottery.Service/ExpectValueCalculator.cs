using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Lottery.Entities;
using Lottery.Interfaces;
using Lottery.Interfaces.Analyzer;

namespace Lottery.Service
{
    public class ExpectValueCalculator : IExpectValueCalculator
    {
        public async Task<Tuple<double, double>> CalculateExpectValue(List<LotteryRecord> data, IAnalyzer analyzer, int expectValueCount, int period,int variableTwo)
        {
            double sumShootCount = 0;
            double sumSpecialShootCount = 0;
            for (var i = 1; i <= expectValueCount; i++)
            {
                var currentAnswer = data[data.Count - i];
                data.RemoveAt(data.Count - i);
                var result = await analyzer.Analyze(data, period, variableTwo);
                var normalResult = result.Where(a => !a.IsSpecial).Take(6);
                var specialResult =  result.Where(a => a.IsSpecial).Take(1);

                sumShootCount += normalResult.Count(r => r.IsShoot(currentAnswer));
                sumSpecialShootCount += specialResult.Count(r => r.IsShootSpecial(currentAnswer));
            }

            return new Tuple<double, double>(sumShootCount / expectValueCount, sumSpecialShootCount / expectValueCount);
        }
    }
}
