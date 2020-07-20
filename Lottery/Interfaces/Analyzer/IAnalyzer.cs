using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lottery.Entities;

namespace Lottery.Interfaces.Analyzer
{
    public interface IAnalyzer
    {
        List<AnalyzeResult> Analyze(List<LotteryRecord> records, int variableOne, int variableTwo);
    }
}
