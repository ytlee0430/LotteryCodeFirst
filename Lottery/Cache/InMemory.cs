using System;
using System.Collections.Generic;
using Lottery.Entities;
using Lottery.Enums;
using Lottery.Interfaces;

namespace Lottery.Cache
{
    public class InMemory : IInMemory
    {
        public List<LotteryRecord> GetRecords(LottoType lottoType)
        {
            switch (lottoType)
            {
                case LottoType.BigLotto:
                    return BigLotteryRecords;
                case LottoType.PowerLottery:
                    return PowerLotteryRecords;
                case LottoType.Simulate:
                    return SimulateLotteryRecords;
                default:
                    throw new ArgumentOutOfRangeException(nameof(lottoType), lottoType, null);
            }
        }

        public List<LotteryRecord> BigLotteryRecords { get; set; }
        public List<LotteryRecord> PowerLotteryRecords { get; set; }
        public List<LotteryRecord> SimulateLotteryRecords { get; set; }
    }
}
