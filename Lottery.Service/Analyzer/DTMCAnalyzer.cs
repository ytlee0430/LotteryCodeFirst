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
            var result = new List<AnalyzeResult>();
            records = records.OrderByDescending(r => r.ID).Take(period).OrderBy(o => o.ID).ToList();
            var maxNumber = records.Max(r => r.Sixth);
            
            


            
            return result.OrderByDescending(r => r.Point).ThenBy(r => r.Number).ToList();
        }
    }
}
