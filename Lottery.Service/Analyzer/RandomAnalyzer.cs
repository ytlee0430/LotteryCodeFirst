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
            int maxNum = records.Max(r => r.Sixth);
            List<int> resultNumbers = new List<int>();

            while (resultNumbers.Count < 6)
            {
                var randomNum = _random.Next(1, maxNum + 1);
                if (!resultNumbers.Contains(randomNum))
                {
                    resultNumbers.Add(randomNum);
                }
            }

            int maxSpecial = records.Max(r => r.Special);


            return new List<AnalyzeResult>
            {
                new AnalyzeResult
                {
                    Number = resultNumbers[0],Point = 100
                },
                new AnalyzeResult
                {
                    Number = resultNumbers[1],Point = 100
                },
                new AnalyzeResult
                {
                    Number = resultNumbers[2],Point = 100
                },
                new AnalyzeResult
                {
                    Number = resultNumbers[3],Point = 100
                },
                new AnalyzeResult
                {
                    Number = resultNumbers[4],Point = 100
                },
                new AnalyzeResult
                {
                    Number = resultNumbers[5],Point = 100
                },
                new AnalyzeResult
                {
                    Number = _random.Next(1,maxSpecial+1),Point = 100,IsSpecial = true
                }
            };
        }
    }
}
