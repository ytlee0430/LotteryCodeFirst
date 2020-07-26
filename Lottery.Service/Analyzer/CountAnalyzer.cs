
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
            return await Task.Run(() =>
            {
                records = records.OrderByDescending(r => r.ID).Take(period).OrderBy(o => o.ID).ToList();
                var result = new List<AnalyzeResult>();

                var normals = new Dictionary<int,int>();
                var specials = new Dictionary<int,int>();
                foreach (var record in records)
                {
                    if (!normals.TryGetValue(record.First, out var times))
                        normals.Add(record.First, 1);
                    else
                        normals[record.First]++;

                    if (!normals.TryGetValue(record.Second, out times))
                        normals.Add(record.Second, 1);
                    else
                        normals[record.Second]++;

                    if (!normals.TryGetValue(record.Third, out times))
                        normals.Add(record.Third, 1);
                    else
                        normals[record.Third]++;

                    if (!normals.TryGetValue(record.Fourth, out times))
                        normals.Add(record.Fourth, 1);
                    else
                        normals[record.Fourth]++;

                    if (!normals.TryGetValue(record.Fifth, out times))
                        normals.Add(record.Fifth, 1);
                    else
                        normals[record.Fifth]++;

                    if (!normals.TryGetValue(record.Sixth, out times))
                        normals.Add(record.Sixth, 1);
                    else
                        normals[record.Sixth]++;

                    if (!specials.TryGetValue(record.Special, out times))
                        specials.Add(record.Special, 1);
                    else
                        specials[record.Special]++;
                }

                result.AddRange(normals.OrderByDescending(n => n.Value).Select(n => new AnalyzeResult { IsSpecial = false, Number = n.Key, Point = n.Value }));
                result.AddRange(specials.OrderByDescending(n => n.Value).Select(n => new AnalyzeResult { IsSpecial = true, Number = n.Key, Point = n.Value }));
                return result;
            });
        }
    }
}
