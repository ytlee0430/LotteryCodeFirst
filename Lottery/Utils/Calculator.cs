using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lottery.Enums;

namespace Lottery.Utils
{
    public static class Calculator
    {
        public static int Combination(int baseNumber, int selectNumber)
        {
            if (selectNumber > baseNumber / 2)
                selectNumber = baseNumber - selectNumber;

            if (baseNumber < selectNumber || baseNumber == 0 || selectNumber == 0)
                return 1;
            int value = 1;
            for (int i = baseNumber; i > baseNumber - selectNumber; i--)
                value *= i;

            for (int i = 1; i <= selectNumber; i++)
                value /= i;

            return value;
        }

       
    }
}
