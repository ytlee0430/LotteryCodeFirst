using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lottery.Repository.Entities;
using Lottery.Repository.Interfaces;

namespace Lottery.Repository.Context
{
    public class SimulateLotteryContext : ContextBase<SimulateLotteryRecord>
    {
        public SimulateLotteryContext() : base(new LotteryDb())
        {
        }
    }
}