using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lottery.Repository.Entities;
using Lottery.Repository.Interfaces;

namespace Lottery.Repository.Context
{
    public class FiveThreeNineLotteryContext : ContextBase<FiveThreeNineLotteryRecord>
    {
        public FiveThreeNineLotteryContext() : base(new LotteryDb())
        {
        }

        public DateTime GetMaxDate()
        {
            if (!_database.Set<FiveThreeNineLotteryRecord>().Any())
                return DateTime.MinValue;
            return _database.Set<FiveThreeNineLotteryRecord>().Max(b => b.Date);
        }
    }
}