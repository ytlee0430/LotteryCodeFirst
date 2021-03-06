﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lottery.Interfaces.BonusCalculator;
using Lottery.Utils;

namespace Lottery.Service.BonusCalculator
{
    public class BigLotteryBonusCalculator : IBonusCalculator
    {
        public int CalculateBonus(int shootCount, bool shootSpecial, int selectCount)
        {
            var bonus = 0;
            for (int currentShootCount = 1; currentShootCount <= shootCount; currentShootCount++)
            {
                var combination = Calculator.Combination(shootCount, currentShootCount) * Calculator.Combination(selectCount - shootCount, 6 - currentShootCount);
                bonus += CalculateBonus(currentShootCount, true) * combination;
                bonus += CalculateBonus(currentShootCount, false) * combination * 7;
            }
            return bonus;
        }


        public int CalculateBonus(int shootCount, bool shootSpecial)
        {
            switch (shootCount)
            {
                case 2:
                    return shootSpecial ? 400 : 0;
                case 3:
                    return shootSpecial ? 1000 : 400;
                case 4:
                    return shootSpecial ? 2000 : 15000;
                case 5:
                    return shootSpecial ? 1500000 : 50000;
                case 6:
                    return 100000000;
            }
            return 0;
        }
    }
}
