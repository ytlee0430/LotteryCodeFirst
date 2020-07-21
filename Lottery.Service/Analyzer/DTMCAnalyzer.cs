using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lottery.Entities;
using Lottery.Interfaces.Analyzer;

namespace Lottery.Service.Analyzer
{
    public class DTMCAnalyzer : IAnalyzer
    {
        public async Task<List<AnalyzeResult>> Analyze(List<LotteryRecord> records, int period, int variableTwo)
        {
            List<AnalyzeResult> result = new List<AnalyzeResult>();
            return result.OrderByDescending(r => r.Point).ThenBy(r => r.Number).ToList();
        }
    }
}
