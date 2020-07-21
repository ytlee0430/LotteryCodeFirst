using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lottery.Entities;
using Lottery.Interfaces.Analyzer;

namespace Lottery.Service.Analyzer
{
    public class FixedFirstSixthAnalyzer : IAnalyzer
    {
        private List<AnalyzeResult> Result => new List<AnalyzeResult>
        {
            new AnalyzeResult
            {
                Number = 1,Point = 100
            },
            new AnalyzeResult
            {
                Number = 2,Point = 100
            },
            new AnalyzeResult
            {
                Number = 3,Point = 100
            },
            new AnalyzeResult
            {
                Number = 4,Point = 100
            },
            new AnalyzeResult
            {
                Number = 5,Point = 100
            },
            new AnalyzeResult
            {
                Number = 6,Point = 100
            },
            new AnalyzeResult
            {
                Number = 1,Point = 100,IsSpecial = true
            }
        };
        public async Task<List<AnalyzeResult>> Analyze(List<LotteryRecord> records, int period, int variableTwo)
        {
            return Result;
        }
    }
}
