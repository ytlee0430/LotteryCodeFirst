using System;
using System.ComponentModel.DataAnnotations;
using Lottery.Repository.Interfaces;

namespace Lottery.Repository.Entities
{
    public class SimulateLotteryRecord : IEntity, ILotteryRecord
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public int First { get; set; }

        [Required]
        public int Second { get; set; }

        [Required]
        public int Third { get; set; }

        [Required]
        public int Fourth { get; set; }

        [Required]
        public int Fifth { get; set; }

        [Required]
        public int Sixth { get; set; }

        [Required]
        public int Special { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}