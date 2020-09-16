using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lottery.Repository.Entities;
using Lottery.Repository.Interfaces;

namespace Lottery.Repository.Context
{
    public class PowerLotterySequenceContext : ContextBase<PowerLotteryRecordSequence>
    {
        public PowerLotterySequenceContext() : base(new LotteryDb())
        {
        }

        public DateTime GetMaxDate()
        {
            if (!_database.Set<PowerLotteryRecordSequence>().Any())
                return DateTime.MinValue;
            return _database.Set<PowerLotteryRecordSequence>().Max(b => b.Date);
        }
    }
}