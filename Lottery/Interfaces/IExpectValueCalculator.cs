using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Lottery.Entities;
using Lottery.Interfaces.Analyzer;

namespace Lottery.Interfaces
{
    public interface IExpectValueCalculator
    {
        Task CalculateExpectValue(List<LotteryRecord> data, IAnalyzer analyzer, int expectValueCount, int period,
            int variableTwo,
            SortedDictionary<int, double> resultDic, SortedDictionary<int, double> specialResultDic);
    }
}
