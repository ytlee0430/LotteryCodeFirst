using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lottery.Repository.Entities;
using Lottery.Repository.Interfaces;

namespace Lottery.Repository.Context
{
    public class PowerLotteryContext : ContextBase<PowerLotteryRecord>
    {
        public PowerLotteryContext() : base(new LotteryDb())
        {
        }

        public DateTime GetMaxDate()
        {
            return _database.Set<PowerLotteryRecord>().Max(b => b.Date);
        }
    }
}