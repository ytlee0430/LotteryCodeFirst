using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Lottery.Repository.Entities;
using Lottery.Repository.Interfaces;

namespace Lottery.Repository
{
    public class LotteryDb : DbContext, IDatabaseContext
    {
        public LotteryDb()
            : base("name=LotteryDB")
        {
            this.Configuration.LazyLoadingEnabled = true;
        }

        public DbSet<BigLotteryRecord> BigLotteryRecord { get; set; }
        public DbSet<PowerLotteryRecord> PowerLotteryRecord { get; set; }
        public DbSet<SimulateLotteryRecord> SimulateLotteryRecord { get; set; }
        public DbSet<FiveThreeNineLotteryRecord> FiveThreeNineLotteryRecord { get; set; }
        public DbSet<PowerLotteryRecordSequence> PowerLotteryRecordSequence { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var typesToRegister = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(type => !string.IsNullOrEmpty(type.Namespace)
                               && type.BaseType != null
                               && type.BaseType.IsGenericType
                               && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>)
                );

            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}