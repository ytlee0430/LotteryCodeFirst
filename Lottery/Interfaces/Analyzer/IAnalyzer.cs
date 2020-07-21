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
        Task<List<AnalyzeResult>> Analyze(List<LotteryRecord> records, int period, int variableTwo);
    }
}
