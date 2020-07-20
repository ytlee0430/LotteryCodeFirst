using System;
using System.Collections.Generic;
using Lottery.Entities;
using Lottery.Interfaces.Analyzer;

namespace Lottery.Interfaces
{
    public interface IExpectValueCalculator
    {
        Tuple<double, double> CalculateExpectValue(List<LotteryRecord> data, IAnalyzer analyzer, int expectValueCount, int variableOne);
    }
}
