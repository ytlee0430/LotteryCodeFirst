using Lottery.Interfaces.BonusCalculator;

namespace Lottery.Service.BonusCalculator
{
    public class PowerLotteryCalculator : IBonusCalculator
    {
        public int CalculateBonus(int shootCount, bool shootSpecial, int selectCount)
        {
            switch (shootCount)
            {
                case 1:
                    return shootSpecial ? 100 : 0;
                case 2:
                    return shootSpecial ? 200 : 0;
                case 3:
                    return shootSpecial ? 400 : 100;
                case 4:
                    return shootSpecial ? 4000 : 800;
                case 5:
                    return shootSpecial ? 150000 : 20000;
                case 6:
                    return shootSpecial ? 200000000 : 5000000;
            }
            return 0;
        }

        private int CalculateBonus(int shootCount, bool shootSpecial)
        {
            switch (shootCount)
            {
                case 1:
                    return shootSpecial ? 100 : 0;
                case 2:
                    return shootSpecial ? 200 : 0;
                case 3:
                    return shootSpecial ? 400 : 100;
                case 4:
                    return shootSpecial ? 4000 : 800;
                case 5:
                    return shootSpecial ? 150000 : 20000;
                case 6:
                    return shootSpecial ? 200000000 : 5000000;
            }
            return 0;
        }

    }
}
