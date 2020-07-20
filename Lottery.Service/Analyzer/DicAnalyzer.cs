using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Lottery.Entities;
using Lottery.Interfaces.Analyzer;

namespace Lottery.Service.Analyzer
{
    public class DicAnalyzer : IAnalyzer
    {
        List<AnalyzeResult> IAnalyzer.Analyze(List<LotteryRecord> records, int variableOne)
        {
            var scoreDic = new Dictionary<int,Dictionary<int,Dictionary<int,int>>>();
            return new List<AnalyzeResult>();
        }
    }
}
