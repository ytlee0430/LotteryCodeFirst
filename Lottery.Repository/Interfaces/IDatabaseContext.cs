using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lottery.Repository.Entities;

namespace Lottery.Repository.Interfaces
{
    public interface IDatabaseContext
    {
        DbSet<BigLotteryRecord> BigLotteryRecord { get; set; }
        DbSet<PowerLotteryRecord> PowerLotteryRecord { get; set; }

        DbSet<T> Set<T>() where T : class;

        DbEntityEntry<T> Entry<T>(T entity) where T : class;

        int SaveChanges();
    }
}