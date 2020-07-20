using System;
using System.Collections.Generic;
using System.Linq;
using Lottery.Entities;
using Lottery.Interfaces;
using Lottery.Interfaces.Analyzer;

namespace Lottery.Service
{
    public class ExpectValueCalculator : IExpectValueCalculator
    {
        public Tuple<double, double> CalculateExpectValue(List<LotteryRecord> data, IAnalyzer analyzer, int expectValueCount, int variableOne,int variableTwo)
        {
            double sumShootCount = 0;
            double sumSpecialShootCount = 0;
            for (int i = 1; i <= expectValueCount; i++)
            {
                var currentAnswer = data[data.Count - i];
                data.RemoveAt(data.Count - i);
                var result = analyzer.Analyze(data, variableOne, variableTwo);
                var currentResult = result.Where(a => !a.IsSpecial).Take(6);
                var currentSpecialResult = result.Where(a => a.IsSpecial).Take(1);

                sumShootCount += currentResult.Count(r => r.IsShoot(currentAnswer));
                sumSpecialShootCount += currentSpecialResult.Count(r => r.IsShootSpecial(currentAnswer));
            }

            return new Tuple<double, double>(sumShootCount / expectValueCount, sumSpecialShootCount / expectValueCount);
        }
    }
}
