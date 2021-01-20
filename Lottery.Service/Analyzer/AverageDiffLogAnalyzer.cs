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
    public class AverageDiffLogAnalyzer : IAnalyzer
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

            var theoryInterval = records.First().MaxNumber / 6.0 / 2.0;

            var diff = first - firstSample;
            var s = diff < 0 ? -1 : 1;
            diff = Math.Abs(diff) + 1;
            diff = s * theoryInterval * Math.Log(diff, theoryInterval);
            result.Add(new AnalyzeResult
            {
                Number = (int)Math.Round(first + diff),
                Point = 10
            });
            diff = second - secondSample;
            s = diff < 0 ? -1 : 1;
            diff = Math.Abs(diff) + 1;
            diff = s * theoryInterval * Math.Log(diff, theoryInterval);

            result.Add(new AnalyzeResult
            {
                Number = (int)Math.Round(second + diff),
                Point = 10
            });
            diff = third - thirdSample;
            s = diff < 0 ? -1 : 1;
            diff = Math.Abs(diff) + 1;
            diff = s * theoryInterval * Math.Log(diff, theoryInterval);

            result.Add(new AnalyzeResult
            {
                Number = (int)Math.Round(third + diff),
                Point = 10
            });
            diff = fourth - fourthSample;
            s = diff < 0 ? -1 : 1;
            diff = Math.Abs(diff) + 1;
            diff = s * theoryInterval * Math.Log(diff, theoryInterval);

            result.Add(new AnalyzeResult
            {
                Number = (int)Math.Round(fourth + diff),
                Point = 10
            });
            diff = fifth - fifthSample;
            s = diff < 0 ? -1 : 1;
            diff = Math.Abs(diff) + 1;
            diff = s * theoryInterval * Math.Log(diff, theoryInterval);

            result.Add(new AnalyzeResult
            {
                Number = (int)Math.Round(fifth + diff),
                Point = 10
            });
            diff = sixth - sixthSample;
            s = diff < 0 ? -1 : 1;
            diff = Math.Abs(diff) + 1;
            diff = s * theoryInterval * Math.Log(diff, theoryInterval);

            result.Add(new AnalyzeResult
            {
                Number = (int)Math.Round(sixth + diff),
                Point = 10
            });

            theoryInterval = records.First().MaxSpecialNumber / 2.0;
            diff = special - specialSample;
            s = diff < 0 ? -1 : 1;
            diff = Math.Abs(diff) + 1;
            diff = s * theoryInterval * Math.Log(diff, theoryInterval);

            result.Add(new AnalyzeResult
            {
                Number = (int)Math.Round(special + diff),
                Point = 10,
                IsSpecial = true
            });
            return result;
        }
    }
}
