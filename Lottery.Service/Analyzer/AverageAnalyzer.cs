using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lottery.Entities;
using Lottery.Interfaces.Analyzer;

namespace Lottery.Service.Analyzer
{
    public class AverageAnalyzer : IAnalyzer
    {
        public async Task<List<AnalyzeResult>> Analyze(List<LotteryRecord> records, int period, int variableTwo)
        {
            List<AnalyzeResult> result = new List<AnalyzeResult>();

            var maxPeriod = records.Count;
            double first = 0.0, second = 0.0, third = 0.0, fourth = 0.0, fifth = 0.0, sixth = 0.0, special = 0.0;

            for (var i = maxPeriod - period; i < maxPeriod; i++)
            {
                first += records[i].First;
                second += records[i].Second;
                third += records[i].Third;
                fourth += records[i].Fourth;
                fifth += records[i].Fifth;
                sixth += records[i].Sixth;
                special += records[i].Special;
            }

            first /= (double)period;
            second /= (double)period;
            third /= (double)period;
            fourth /= (double)period;
            fifth /= (double)period;
            sixth /= (double)period;
            special /= (double)period;

            for (int i = 1; i <= (int)Math.Max(sixth, special) + 1; i++)
            {
                if ((Math.Abs(i - first) < 1))
                {
                    result.Add(new AnalyzeResult
                    {
                        Number = i,
                        Point = 10 - (int)(Math.Abs(i - first) * 10)
                    });
                }

                if ((Math.Abs(i - second) < 1))
                {
                    result.Add(new AnalyzeResult
                    {
                        Number = i,
                        Point = 10 - (int)(Math.Abs(i - second) * 10)
                    });
                }

                if ((Math.Abs(i - third) < 1))
                {
                    result.Add(new AnalyzeResult
                    {
                        Number = i,
                        Point = 10 - (int)(Math.Abs(i - third) * 10)
                    });
                }

                if ((Math.Abs(i - fourth) < 1))
                {
                    result.Add(new AnalyzeResult
                    {
                        Number = i,
                        Point = 10 - (int)(Math.Abs(i - fourth) * 10)
                    });
                }

                if ((Math.Abs(i - fifth) < 1))
                {
                    result.Add(new AnalyzeResult
                    {
                        Number = i,
                        Point = 10 - (int)(Math.Abs(i - fifth) * 10)
                    });
                }


                if ((Math.Abs(i - sixth) < 1))
                {
                    result.Add(new AnalyzeResult
                    {
                        Number = i,
                        Point = 10 - (int)(Math.Abs(i - sixth) * 10)
                    });
                }

                if ((Math.Abs(i - special) < 1))
                {
                    result.Add(new AnalyzeResult
                    {
                        Number = i,
                        Point = 10 - (int)(Math.Abs(i - special) * 10),
                        IsSpecial = true
                    });
                }
            }
            return result.OrderByDescending(r => r.Point).ThenBy(r => r.Number).ToList();
        }
    }
}
