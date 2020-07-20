using System;
using System.Collections.Generic;
using System.Linq;

namespace Lottery.Entities
{
    public class LotteryRecord
    {
        public int ID { get; set; }

        public int First { get; set; }

        public int Second { get; set; }

        public int Third { get; set; }

        public int Fourth { get; set; }

        public int Fifth { get; set; }

        public int Sixth { get; set; }

        public int Special { get; set; }

        public DateTime Date { get; set; }
    }

}