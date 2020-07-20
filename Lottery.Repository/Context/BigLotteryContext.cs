using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lottery.Repository.Entities;
using Lottery.Repository.Interfaces;

namespace Lottery.Repository.Context
{
    public class BigLotteryContext : ContextBase<BigLotteryRecord>
    {
        public BigLotteryContext() : base(new LotteryDb())
        {
        }

        public DateTime GetMaxDate()
        {
            if (!_database.Set<BigLotteryRecord>().Any())
            {
                return DateTime.MinValue;
            }
            return _database.Set<BigLotteryRecord>().Max(b => b.Date);
        }
    }
}