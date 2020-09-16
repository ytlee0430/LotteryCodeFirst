using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lottery.Entities;
using Lottery.Interfaces.Analyzer;

namespace Lottery.Service.Analyzer
{
    public class RandomAnalyzer : IAnalyzer
    {
        private Random _random = new Random();
        public async Task<List<AnalyzeResult>> Analyze(List<LotteryRecord> records, int period, int variableTwo)
        {
            var first = records.FirstOrDefault();
            var maxNumber = first.MaxNumber;
            var maxNumberSp = first.MaxSpecialNumber;

            List<int> resultNumbers = new List<int>();
            var result = new List<AnalyzeResult>();
            for (int i = 1; i <= maxNumber; i++)
            {
                result.Add(new AnalyzeResult
                {
                    IsSpecial = false,
                    Number = i,
                    Point = _random.Next(1, 100)
                });
            }

            for (int i = 1; i <= maxNumberSp; i++)
            {
                result.Add(new AnalyzeResult
                {
                    IsSpecial = true,
                    Number = i,
                    Point = _random.Next(1, 100)
                });
            }
            return result.OrderByDescending(r => r.Point).ThenBy(r => r.Number).ToList();
        }
    }
}
