using Lottery.Enums;

namespace Lottery.Interfaces.Controller
{
    public interface ILotteryFormController
    {
        void BtnInitialSimulate();
        void UpdateData(LottoType type);
        string AnalyzeData(LottoType lottoType, AnalyzeType analyzeType, int variableOne, int variableTwo);
        string CalculateExpectValue(LottoType lottoType, AnalyzeType analyzeType, int variableOne, int expectValueCount,
            int variableEndValue, int variableTwo);
    }
}