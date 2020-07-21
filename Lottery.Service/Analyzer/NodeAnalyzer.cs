using System.Collections.Generic;
using System.Threading.Tasks;
using Lottery.Entities;
using Lottery.Interfaces.Analyzer;

namespace Lottery.Service.Analyzer
{
    public class NodeAnalyzer : IAnalyzer
    {
        public async Task<List<AnalyzeResult>> Analyze(List<LotteryRecord> records, int period, int variableTwo)
        {
            var analyzeNodes= new List<AnalyzeResult>();

            return analyzeNodes;
        }
    }
}
