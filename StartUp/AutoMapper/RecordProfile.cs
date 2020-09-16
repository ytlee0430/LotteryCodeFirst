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
            CreateMap<LotteryRecord, PowerLotteryRecordSequence>();
            CreateMap<LotteryRecord, FiveThreeNineLotteryRecord>();
            CreateMap<LotteryRecord, SimulateLotteryRecord>();

            CreateMap<BigLotteryRecord, LotteryRecord>().ForMember(dest => dest.MaxNumber,
                opt => opt.MapFrom(src => 49)).ForMember(dest => dest.MaxSpecialNumber,
                opt => opt.MapFrom(src => 49));
            CreateMap<PowerLotteryRecord, LotteryRecord>().ForMember(dest => dest.MaxNumber,
                opt => opt.MapFrom(src => 38)).ForMember(dest => dest.MaxSpecialNumber,
                opt => opt.MapFrom(src => 8));
            CreateMap<FiveThreeNineLotteryRecord, LotteryRecord>().ForMember(dest => dest.MaxNumber,
                opt => opt.MapFrom(src => 39)).ForMember(dest => dest.MaxSpecialNumber,
                opt => opt.MapFrom(src => 0));
            CreateMap<PowerLotteryRecordSequence, LotteryRecord>().ForMember(dest => dest.MaxNumber,
                opt => opt.MapFrom(src => 49)).ForMember(dest => dest.MaxSpecialNumber,
                opt => opt.MapFrom(src => 8));
            CreateMap<SimulateLotteryRecord, LotteryRecord>().ForMember(dest => dest.MaxNumber,
                opt => opt.MapFrom(src => 49)).ForMember(dest => dest.MaxSpecialNumber,
                opt => opt.MapFrom(src => 49));
        }
    }
}