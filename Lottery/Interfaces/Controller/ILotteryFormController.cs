using System;
using System.Threading.Tasks;
using Lottery.Enums;

namespace Lottery.Interfaces.Controller
{
    public interface ILotteryFormController
    {
        void BtnInitialSimulate();
        void UpdateData(LottoType type, Action callBack);
        Task<string> AnalyzeData(LottoType lottoType, AnalyzeType analyzeType, int variableOne, int variableTwo);
        Task<string> CalculateExpectValue(LottoType lottoType, AnalyzeType analyzeType, int period, int expectValueCount,
            int periodEnd, int variableTwo, int selectCount, bool showBingo, Action callBack);
    }
}