using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Lottery.Entities
{
    public class AnalyzeResult
    {
        public int Number { get; set; }

        public double Point { get; set; }

        public bool IsSpecial { get; set; }


        public bool IsShoot(LotteryRecord record)
        {
            if (IsSpecial)
                return false;
            return record.First == Number || record.Second == Number || record.Third == Number ||
                   record.Fourth == Number || record.Fifth == Number || record.Sixth == Number;
        }

        public bool IsShootSpecial(LotteryRecord record)
        {
            if (IsSpecial)
                return record.Special == Number;
            return false;
        }
    }
}
