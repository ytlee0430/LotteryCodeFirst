using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Lottery.Entities;
using Lottery.Interfaces.Analyzer;

namespace Lottery.Service.Analyzer
{
    public class NodeAnalyzer : IAnalyzer
    {
        public List<AnalyzeResult> Analyze(List<LotteryRecord> records, int variableOne)
        {
            var analyzeNodes= new List<AnalyzeResult>();

            return analyzeNodes;
        }
    }
}
