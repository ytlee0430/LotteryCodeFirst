using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lottery.Entities;
using Lottery.Interfaces.Analyzer;

namespace Lottery.Service.Analyzer
{
    public class SpecialRelatedAnalyzer : IAnalyzer
    {
        public List<AnalyzeResult> Analyze(List<LotteryRecord> records, int period, int specialNumber)
        {
            records = records.Where(r => r.Special == specialNumber).OrderByDescending(r => r.ID).Take(period).ToList();

            var result = new SortedDictionary<int, int>();
            foreach (var record in records)
            {
                int value;
                if (result.TryGetValue(record.First, out value))
                    result[record.First]++;
                else
                    result[record.First] = 1;

                if (result.TryGetValue(record.Second, out value))
                    result[record.Second]++;
                else
                    result[record.Second] = 1;

                if (result.TryGetValue(record.Third, out value))
                    result[record.Third]++;
                else
                    result[record.Third] = 1;

                if (result.TryGetValue(record.Fourth, out value))
                    result[record.Fourth]++;
                else
                    result[record.Fourth] = 1;

                if (result.TryGetValue(record.Fifth, out value))
                    result[record.Fifth]++;
                else
                    result[record.Fifth] = 1;

                if (result.TryGetValue(record.Sixth, out value))
                    result[record.Sixth]++;
                else
                    result[record.Sixth] = 1;
            }

            return result.OrderByDescending(o => o.Value).Select(r => new AnalyzeResult
            {
                Number = r.Key,
                Point = r.Value
            }).ToList();
        }
    }
}
