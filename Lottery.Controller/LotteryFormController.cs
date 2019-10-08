using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Lottery.Enums;
using Lottery.Interfaces.Controller;
using Lottery.Interfaces.Services;

namespace Lottery.Controller
{
    public class LotteryFormController : ILotteryFormController
    {
        private readonly ICreateRecordService _createRecordService;
        private readonly IWebCralwer _webCralwer;

        public LotteryFormController(ICreateRecordService createRecordService, IWebCralwer webCralwer)
        {
            _createRecordService = createRecordService;
            _webCralwer = webCralwer;
        }

        public void BtnInitialSimulate()
        {
            _createRecordService.BtnInitialSimulate();
        }

        public async void UpdateData(LottoType type)
        {
            _webCralwer.LotteryType = type;
            _webCralwer.InitialWeb();
            var task = new Task(() =>
            {
                while (!_webCralwer.Ready)
                    Thread.Sleep(10);
            });
            task.Start();
            await task;
            _webCralwer.UpdateData();
        }
    }
}