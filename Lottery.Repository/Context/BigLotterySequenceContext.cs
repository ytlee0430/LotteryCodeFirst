using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lottery.Repository.Entities;
using Lottery.Repository.Interfaces;

namespace Lottery.Repository.Context
{
    public class BigLotterySequenceContext : ContextBase<BigLotteryRecordSequence>
    {
        public BigLotterySequenceContext() : base(new LotteryDb())
        {
        }

        public DateTime GetMaxDate()
        {
            if (!_database.Set<BigLotteryRecordSequence>().Any())
            {
                return DateTime.MinValue;
            }
            return _database.Set<BigLotteryRecordSequence>().Max(b => b.Date);
        }
    }
}