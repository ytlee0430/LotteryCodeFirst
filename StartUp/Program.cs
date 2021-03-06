﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AutoMapper;
using Lottery.Cache;
using Lottery.Controller;
using Lottery.Entities;
using Lottery.Enums;
using Lottery.Interfaces;
using Lottery.Interfaces.Analyzer;
using Lottery.Interfaces.BonusCalculator;
using Lottery.Interfaces.Controller;
using Lottery.Interfaces.Services;
using Lottery.Interfaces.Views;
using Lottery.Repository.Context;
using Lottery.Repository.Entities;
using Lottery.Service;
using Lottery.Service.Analyzer;
using Lottery.Service.AutoMapper;
using Lottery.Service.BonusCalculator;
using Lottery.Service.Web;
using Lottery.View;
using Microsoft.Extensions.DependencyInjection;

namespace StartUp
{
    internal static class Program
    {
        private static IServiceProvider ServiceProvider { get; set; }

        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var services = new ServiceCollection();
            services.AddScoped<IWebCralwer, WebCralwer>();
            services.AddScoped<ICreateRecordService, CreateRecordService>();
            services.AddScoped<ILotteryForm, LotteryFrom>();
            services.AddScoped<ILotteryFormController, LotteryFormController>();
            services.AddScoped<IExpectValueCalculator, ExpectValueCalculator>();
            services.AddScoped<AnalyzerResolver>(resolver => analyzeType =>
             {
                 switch (analyzeType)
                 {
                     case AnalyzeType.AverageOfRecent:
                         return new AverageAnalyzer();
                     case AnalyzeType.SpecialNumberRelated:
                         return new SpecialRelatedAnalyzer();
                     case AnalyzeType.Random:
                         return new RandomAnalyzer();
                     case AnalyzeType.FixedFirstSixth:
                         return new FixedFirstSixthAnalyzer();
                     case AnalyzeType.MarkovChain:
                         return new MarkovChainAnalyzer();
                     case AnalyzeType.DTMC:
                         return new DTMCAnalyzer();
                     case AnalyzeType.Distance:
                         return new DistanceAnalyzer();
                     case AnalyzeType.Fourier:
                         return new FourierAnalyzer();
                     case AnalyzeType.Egg:
                         return new EggAnalyzer();
                     case AnalyzeType.Count:
                         return new CountAnalyzer();
                     case AnalyzeType.Wavelet:
                         return new WaveletAnalyzer();
                     case AnalyzeType.SequenceOrder:
                         return new SequenceOrderAnalyzer();
                     case AnalyzeType.DateNumber:
                         return new DateNumberAnalyzer();
                     case AnalyzeType.Frequency:
                         return new FrequencyAnalyzer();
                     case AnalyzeType.SequenceFirst:
                         return new SequenceFirstAnalyzer();
                     case AnalyzeType.AverageDiffLog:
                         return new AverageDiffLogAnalyzer();
                     case AnalyzeType.AverageDiffMul:
                         return new AverageDiffMulAnalyzer();
                     case AnalyzeType.AverageDiff:
                         return new AverageDiffAnalyzer();
                     default:
                         throw new ArgumentOutOfRangeException(nameof(analyzeType), analyzeType, null);
                 }
             });

            services.AddScoped<BonusCalculatorResolver>(resolver => analyzeType =>
            {
                switch (analyzeType)
                {
                    case LottoType.PowerLottery:
                    case LottoType.PowerLotterySequence:
                        return new PowerLotteryCalculator();
                    case LottoType.BigLotto:
                    case LottoType.Simulate:
                    case LottoType.BigLottoSequence:
                        return new BigLotteryBonusCalculator();
                    case LottoType.FivThreeNine:
                    default:
                        throw new ArgumentOutOfRangeException(nameof(analyzeType), analyzeType, null);
                }
            });

            services.AddScoped<BigLotteryContext>();
            services.AddScoped<BigLotterySequenceContext>();
            services.AddScoped<PowerLotteryContext>();
            services.AddScoped<PowerLotterySequenceContext>();
            services.AddScoped<FiveThreeNineLotteryContext>();
            services.AddScoped<SimulateLotteryContext>();
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<RecordProfile>();
            });
            var mapper = new Mapper(configuration);
            services.AddSingleton<IMapper>(mapper);

            var inMemory = new InMemory
            {
                BigLotteryRecords = mapper.Map<List<LotteryRecord>>(new BigLotteryContext().GetAll().ToList()),
                PowerLotteryRecords = mapper.Map<List<LotteryRecord>>(new PowerLotteryContext().GetAll().ToList()),
                PowerLotterySequenceRecords = mapper.Map<List<LotteryRecord>>(new PowerLotterySequenceContext().GetAll().ToList()),
                BigLotterySequenceRecords = mapper.Map<List<LotteryRecord>>(new BigLotterySequenceContext().GetAll().ToList()),
                FivThreeNineLotteryRecords = mapper.Map<List<LotteryRecord>>(new FiveThreeNineLotteryContext().GetAll().ToList()),
                SimulateLotteryRecords = mapper.Map<List<LotteryRecord>>(new SimulateLotteryContext().GetAll().ToList())
            };
            services.AddSingleton<IInMemory>(inMemory);

            ServiceProvider = services.BuildServiceProvider();

            Application.Run((Form)ServiceProvider.GetService(typeof(ILotteryForm)));
        }
    }
}