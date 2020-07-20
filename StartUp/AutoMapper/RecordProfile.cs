using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Lottery.Entities;
using Lottery.Repository.Entities;

namespace Lottery.Service.AutoMapper
{
    public class RecordProfile : Profile
    {
        public RecordProfile()
        {
            CreateMap<LotteryRecord, BigLotteryRecord>();
            CreateMap<LotteryRecord, PowerLotteryRecord>();
            CreateMap<LotteryRecord, SimulateLotteryRecord>();

            CreateMap<BigLotteryRecord, LotteryRecord>();
            CreateMap<PowerLotteryRecord, LotteryRecord>();
            CreateMap<SimulateLotteryRecord, LotteryRecord>();
        }
    }
}