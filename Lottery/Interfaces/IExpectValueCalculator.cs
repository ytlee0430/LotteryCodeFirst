using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Lottery.Entities;
using Lottery.Interfaces.Analyzer;

namespace Lottery.Interfaces
{
    public interface IExpectValueCalculator
    {
        Task<Tuple<double, double>> CalculateExpectValue(List<LotteryRecord> data, IAnalyzer analyzer, int expectValueCount, int period, int variableTwo);
    }
}
