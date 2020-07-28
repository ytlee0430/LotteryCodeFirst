
using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lottery.Entities;
using Lottery.Interfaces.Analyzer;

namespace Lottery.Service.Analyzer
{
    public class CountAnalyzer : IAnalyzer
    {
        public async Task<List<AnalyzeResult>> Analyze(List<LotteryRecord> records, int period, int variableTwo)
        {

            records = records.OrderByDescending(r => r.ID).Take(period).OrderBy(o => o.ID).ToList();
            var result = new List<AnalyzeResult>();
            var maxNumber = records.Max(r => r.Sixth);
            var maxNumberSp = records.Max(r => r.Special);

            var normals = new Dictionary<int, int>();
            var specials = new Dictionary<int, int>();

            for (int i = 1; i <= maxNumber; i++)
                normals.Add(i, 0);

            for (int i = 1; i <= maxNumberSp; i++)
                specials.Add(i, 0);

            foreach (var record in records)
            {
                normals[record.First]++;
                normals[record.Second]++;
                normals[record.Third]++;
                normals[record.Fourth]++;
                normals[record.Fifth]++;
                normals[record.Sixth]++;
                specials[record.Special]++;
            }

            result.AddRange(normals.OrderByDescending(n => n.Value).Select(n => new AnalyzeResult { IsSpecial = false, Number = n.Key, Point = n.Value }));
            result.AddRange(specials.OrderByDescending(n => n.Value).Select(n => new AnalyzeResult { IsSpecial = true, Number = n.Key, Point = n.Value }));
            return result;
        }
    }
}
