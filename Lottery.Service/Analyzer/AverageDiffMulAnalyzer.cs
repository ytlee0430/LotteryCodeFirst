using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Lottery.Entities;
using Lottery.Interfaces.Analyzer;

namespace Lottery.Service.Analyzer
{
    public class AverageDiffMulAnalyzer : IAnalyzer
    {
        public async Task<List<AnalyzeResult>> Analyze(List<LotteryRecord> records, int period, int samplePeriod)
        {
            List<AnalyzeResult> result = new List<AnalyzeResult>();

            var maxPeriod = records.Count;
            double first = 0.0, second = 0.0, third = 0.0, fourth = 0.0, fifth = 0.0, sixth = 0.0, special = 0.0;
            double firstSample = 0.0, secondSample = 0.0, thirdSample = 0.0, fourthSample = 0.0, fifthSample = 0.0, sixthSample = 0.0, specialSample = 0.0;

            for (var i = maxPeriod - period; i < maxPeriod; i++)
            {
                first += records[i].First;
                second += records[i].Second;
                third += records[i].Third;
                fourth += records[i].Fourth;
                fifth += records[i].Fifth;
                sixth += records[i].Sixth;
                special += records[i].Special;
            }

            first /= (double)period;
            second /= (double)period;
            third /= (double)period;
            fourth /= (double)period;
            fifth /= (double)period;
            sixth /= (double)period;
            special /= (double)period;

            for (var i = maxPeriod - samplePeriod; i < maxPeriod; i++)
            {
                firstSample += records[i].First;
                secondSample += records[i].Second;
                thirdSample += records[i].Third;
                fourthSample += records[i].Fourth;
                fifthSample += records[i].Fifth;
                sixthSample += records[i].Sixth;
                specialSample += records[i].Special;
            }

            firstSample /= (double)samplePeriod;
            secondSample /= (double)samplePeriod;
            thirdSample /= (double)samplePeriod;
            fourthSample /= (double)samplePeriod;
            fifthSample /= (double)samplePeriod;
            sixthSample /= (double)samplePeriod;
            specialSample /= (double)samplePeriod;

            var min = 1;
            var max = records.First().MaxNumber;

            var diff = first - firstSample;
            diff *= samplePeriod;
            var re = first + diff;
            re = Math.Max(min, re);
            re = Math.Min(max, re);
            result.Add(new AnalyzeResult
            {
                Number = (int)Math.Round(re),
                Point = 10
            });

            diff = second - secondSample;
            diff *= samplePeriod;
            re = second + diff;
            re = Math.Max(min, re);
            re = Math.Min(max, re);
            result.Add(new AnalyzeResult
            {
                Number = (int)Math.Round(re),
                Point = 10
            });

            diff = third - thirdSample;
            diff *= samplePeriod;
            re = third + diff;
            re = Math.Max(min, re);
            re = Math.Min(max, re);
            result.Add(new AnalyzeResult
            {
                Number = (int)Math.Round(re),
                Point = 10
            });

            diff = fourth - fourthSample;
            diff *= samplePeriod;
            re = fourth + diff;
            re = Math.Max(min, re);
            re = Math.Min(max, re);
            result.Add(new AnalyzeResult
            {
                Number = (int)Math.Round(re),
                Point = 10
            });

            diff = fifth - fifthSample;
            diff *= samplePeriod;
            re = fifth + diff;
            re = Math.Max(min, re);
            re = Math.Min(max, re);
            result.Add(new AnalyzeResult
            {
                Number = (int)Math.Round(re),
                Point = 10
            });

            diff = sixth - sixthSample;
            diff *= samplePeriod;
            re = sixth + diff;
            re = Math.Max(min, re);
            re = Math.Min(max, re);
            result.Add(new AnalyzeResult
            {
                Number = (int)Math.Round(re),
                Point = 10
            });

            diff = special - specialSample;
            diff *= samplePeriod;
            re = diff + special;
            re = Math.Max(min, re);
            re = Math.Min(records.First().MaxSpecialNumber, re);
            result.Add(new AnalyzeResult
            {
                Number = (int)Math.Round(re),
                Point = 10,
                IsSpecial = true
            });
            return result;
        }
    }
}
