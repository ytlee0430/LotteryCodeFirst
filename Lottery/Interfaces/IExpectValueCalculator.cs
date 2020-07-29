using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Lottery.Entities;
using Lottery.Interfaces.Analyzer;
using Lottery.Interfaces.BonusCalculator;

namespace Lottery.Interfaces
{
    public interface IExpectValueCalculator
    {
        Task CalculateExpectValue(List<LotteryRecord> toList, IAnalyzer analyzer,
            int expectValueCount, int currentPeriod, int variableTwo, SortedDictionary<int, double> resultDic,
            SortedDictionary<int, double> resultSpecialDic, int selectCount, bool showBingo, Action callBack,
            SortedDictionary<int, double> shootIndexDic, IBonusCalculator calculator);
    }
}
