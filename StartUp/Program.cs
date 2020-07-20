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
using Lottery.Interfaces.Controller;
using Lottery.Interfaces.Services;
using Lottery.Interfaces.Views;
using Lottery.Repository.Context;
using Lottery.Repository.Entities;
using Lottery.Service;
using Lottery.Service.Analyzer;
using Lottery.Service.AutoMapper;
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
            services.AddScoped<IAnalyzer, AverageAnalyzer>();
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
                     default:
                         throw new ArgumentOutOfRangeException(nameof(analyzeType), analyzeType, null);
                 }
             });



            services.AddScoped<BigLotteryContext>();
            services.AddScoped<PowerLotteryContext>();
            services.AddScoped<SimulateLotteryContext>();
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<RecordProfile>();
            });
            var mapper = new Mapper(configuration);
            services.AddSingleton<IMapper>(mapper);

            var inMemory = new InMemory();
            inMemory.BigLotteryRecords = mapper.Map<List<LotteryRecord>>(new BigLotteryContext().GetAll().ToList());
            inMemory.PowerLotteryRecords = mapper.Map<List<LotteryRecord>>(new PowerLotteryContext().GetAll().ToList());
            inMemory.SimulateLotteryRecords = mapper.Map<List<LotteryRecord>>(new SimulateLotteryContext().GetAll().ToList());
            services.AddSingleton<IInMemory>(inMemory);

            ServiceProvider = services.BuildServiceProvider();

            Application.Run((Form)ServiceProvider.GetService(typeof(ILotteryForm)));
        }
    }
}