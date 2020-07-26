using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lottery.Entities;
using Lottery.Interfaces.Analyzer;

namespace Lottery.Service.Analyzer
{
    public class EggAnalyzer : IAnalyzer
    {
        public async Task<List<AnalyzeResult>> Analyze(List<LotteryRecord> records, int period, int variableTwo)
        {
            return await Task.Run(() =>
            {
                var result = new List<AnalyzeResult>();
                records = records.OrderByDescending(r => r.ID).ToList();
                var maxNumber = records.Max(r => r.Sixth);
                var maxNumberSp = records.Max(r => r.Special);

                var normals = new Dictionary<int, int>();
                var specials = new Dictionary<int, int>();

                var criticalId = 0;

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

                    if (normals.Count != maxNumber || specials.Count != maxNumberSp) continue;
                    criticalId = record.ID;
                    normals[record.First]--;
                    normals[record.Second]--;
                    normals[record.Third]--;
                    normals[record.Fourth]--;
                    normals[record.Fifth]--;
                    normals[record.Sixth]--;

                    specials[record.Special]--;
                    break;
                }



                result.AddRange(normals.Where(n => n.Value == 0).Select(n => new AnalyzeResult { IsSpecial = false, Number = n.Key, Point = n.Value }));
                int restCount = 6 - result.Count;
                result.AddRange(normals.OrderByDescending(n => n.Value).Take(restCount).Select(n => new AnalyzeResult { IsSpecial = false, Number = n.Key, Point = n.Value }));

                result.AddRange(specials.Where(n => n.Value == 0).Select(n => new AnalyzeResult { IsSpecial = true, Number = n.Key, Point = n.Value }));
                restCount = 6 - result.Count(r => r.IsSpecial);
                result.AddRange(specials.OrderByDescending(n => n.Value).Take(restCount).Select(n => new AnalyzeResult { IsSpecial = true, Number = n.Key, Point = n.Value }));
                return result.OrderByDescending(r => r.Point).ThenBy(r => r.Number).ToList();
            });
        }


    }
}
