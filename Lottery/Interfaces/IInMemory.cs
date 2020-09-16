using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lottery.Entities;
using Lottery.Enums;

namespace Lottery.Interfaces
{
    public interface IInMemory
    {
        List<LotteryRecord> GetRecords(LottoType lottoType);
        List<LotteryRecord> BigLotteryRecords { get; set; }
        List<LotteryRecord> FivThreeNineLotteryRecords { get; set; }
        List<LotteryRecord> PowerLotteryRecords { get; set; }
        List<LotteryRecord> PowerLotterySequenceRecords { get; set; }
        List<LotteryRecord> SimulateLotteryRecords { get; set; }
    }
}
