using System;
using System.Windows.Forms;
using AutoMapper;
using Lottery.Controller;
using Lottery.Interfaces.Controller;
using Lottery.Interfaces.Services;
using Lottery.Interfaces.Views;
using Lottery.Repository.Context;
using Lottery.Repository.Entities;
using Lottery.Service;
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
            services.AddScoped<BigLotteryContext>();
            services.AddScoped<PowerLotteryContext>();
            services.AddScoped<SimulateLotteryContext>();
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<RecordProfile>();
            });
            services.AddSingleton<IMapper>(new Mapper(configuration));
            ServiceProvider = services.BuildServiceProvider();

            Application.Run((Form)ServiceProvider.GetService(typeof(ILotteryForm)));
        }
    }
}