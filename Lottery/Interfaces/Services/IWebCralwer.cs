using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lottery.Entities;
using Lottery.Enums;

namespace Lottery.Interfaces.Services
{
    public interface IWebCralwer
    {
        LottoType LotteryType { get; set; }
        bool Ready { get; }

        void UpdateData();

        void InitialWeb();
    }
}