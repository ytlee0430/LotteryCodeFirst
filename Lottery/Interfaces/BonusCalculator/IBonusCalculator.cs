using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottery.Interfaces.BonusCalculator
{
    public interface IBonusCalculator
    {
        int CalculateBonus(int shootCount, bool shootSpecial,int selectCount);
    }
}
