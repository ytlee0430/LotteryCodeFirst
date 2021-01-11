using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lottery.Entities;
using Lottery.Interfaces.Analyzer;

namespace Lottery.Service.Analyzer
{
    public class FrequencyAnalyzer : IAnalyzer
    {
        public async Task<List<AnalyzeResult>> Analyze(List<LotteryRecord> records, int period, int firstPeriod)
        {
            records = records.OrderByDescending(r => r.ID).Take(period).ToList();
            var first = records.FirstOrDefault();
            var maxNumber = first?.MaxNumber;
            var maxNumberSp = first?.MaxSpecialNumber;

            var firstDic = new Dictionary<int, int>();
            var secondDic = new Dictionary<int, int>();
            for (int i = 1; i <= maxNumber; i++)
                firstDic.Add(i, 0);
            for (int i = 1; i <= maxNumber; i++)
                secondDic.Add(i, 0);

            var firstSpDic = new Dictionary<int, int>();
            var secondSpDic = new Dictionary<int, int>();
            for (int i = 1; i <= maxNumberSp; i++)
                firstSpDic.Add(i, 0);
            for (int i = 1; i <= maxNumberSp; i++)
                secondSpDic.Add(i, 0);

            var normals = new Dictionary<int, int>();
            var specials = new Dictionary<int, int>();
            for (int i = 1; i <= maxNumber; i++)
                normals.Add(i, 0);

            for (int i = 1; i <= maxNumberSp; i++)
                specials.Add(i, 0);

            for (int i = 0; i < records.Count; i++)
            {
                var record = records[i];
                if (i <= firstPeriod)
                {
                    firstDic[record.First]++;
                    firstDic[record.Second]++;
                    firstDic[record.Third]++;
                    firstDic[record.Fourth]++;
                    firstDic[record.Fifth]++;
                    firstDic[record.Sixth]++;
                    firstSpDic[record.Special]++;
                }
                else
                {
                    secondDic[record.First]++;
                    secondDic[record.Second]++;
                    secondDic[record.Third]++;
                    secondDic[record.Fourth]++;
                    secondDic[record.Fifth]++;
                    secondDic[record.Sixth]++;
                    secondSpDic[record.Special]++;
                }
            }

            var score = maxNumber.Value;
            foreach (var pair in firstDic.OrderBy(f => f.Value).GroupBy(g => g.Value))
            {
                foreach (var keyValuePair in pair.ToList())
                    normals[keyValuePair.Key] += score;
                score -= pair.Count();
            }

            score = maxNumber.Value;
            foreach (var pair in secondDic.OrderByDescending(f => f.Value).GroupBy(g => g.Value))
            {
                foreach (var keyValuePair in pair.ToList())
                    normals[keyValuePair.Key] += score;
                score -= pair.Count();
            }

            score = maxNumberSp.Value;
            foreach (var pair in firstSpDic.OrderBy(d => d.Value).GroupBy(g => g.Value))
            {
                foreach (var keyValuePair in pair.ToList())
                    specials[keyValuePair.Key] += score;
                score -= pair.Count();
            }

            score = maxNumberSp.Value;
            foreach (var pair in secondSpDic.OrderByDescending(d => d.Value).GroupBy(g => g.Value))
            {
                foreach (var keyValuePair in pair.ToList())
                    specials[keyValuePair.Key] += score;
                score -= pair.Count();
            }

            var result = new List<AnalyzeResult>();
            result.AddRange(normals.OrderByDescending(n => n.Value).Select(n => new AnalyzeResult { IsSpecial = false, Number = n.Key, Point = n.Value }));
            result.AddRange(specials.OrderByDescending(n => n.Value).Select(n => new AnalyzeResult { IsSpecial = true, Number = n.Key, Point = n.Value }));
            return result;
        }
    }
}
