using System;
using System.Collections.Generic;

namespace Lottery.Entities
{
    public class LotteryListRecord
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public List<int> NormalList { get; set; }
        public int Sp { get; set; }
    }
}
