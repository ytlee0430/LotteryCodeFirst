using System;
using System.Collections.Generic;
using AutoMapper;
using Lottery.Entities;
using Lottery.Interfaces.Services;
using Lottery.Repository.Context;
using Lottery.Repository.Entities;

namespace Lottery.Service
{
    public class CreateRecordService : ICreateRecordService
    {
        private readonly SimulateLotteryContext _simulateLotteryContext;
        private readonly IMapper _mapper;

        public CreateRecordService(SimulateLotteryContext simulateLotteryContext, IMapper mapper)
        {
            _simulateLotteryContext = simulateLotteryContext;
            _mapper = mapper;
        }

        public void BtnInitialSimulate()
        {
            var list = new List<LotteryRecord>();
            for (var i = 0; i < 1000; i++)
            {
                var startIndex = (i % 7) * 7 + 1;
                list.Add(new LotteryRecord
                {
                    First = startIndex,
                    Second = startIndex + 1,
                    Third = startIndex + 2,
                    Fourth = startIndex + 3,
                    Fifth = startIndex + 4,
                    Sixth = startIndex + 5,
                    Special = startIndex + 6,
                    Date = new DateTime(1990, 12, 14).AddDays(i)
                });
            }

            _simulateLotteryContext.Add(_mapper.Map<List<SimulateLotteryRecord>>(list));
        }
    }
}