using System;

namespace Lottery.Repository.Interfaces
{
    public interface ILotteryRecord
    {
        int First { get; set; }

        int Second { get; set; }

        int Third { get; set; }

        int Fourth { get; set; }

        int Fifth { get; set; }

        int Sixth { get; set; }

        int Special { get; set; }

        DateTime Date { get; set; }
    }
}