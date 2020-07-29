using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lottery.Enums;

namespace Lottery.Interfaces.BonusCalculator
{
    public delegate IBonusCalculator BonusCalculatorResolver(LottoType lottoType);
}
