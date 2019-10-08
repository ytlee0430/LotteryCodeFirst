using Lottery.Enums;

namespace Lottery.Interfaces.Controller
{
    public interface ILotteryFormController
    {
        void BtnInitialSimulate();

        void UpdateData(LottoType type);
    }
}