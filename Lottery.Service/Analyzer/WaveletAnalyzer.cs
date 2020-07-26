using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lottery.Entities;
using Lottery.Interfaces.Analyzer;
using WaveletLibrary;

namespace Lottery.Service.Analyzer
{
    public class WaveletAnalyzer : IAnalyzer
    {
        public async Task<List<AnalyzeResult>> Analyze(List<LotteryRecord> records, int period, int variableTwo)
        {
            return await Task.Run(() =>
            {
                records = records.OrderByDescending(r => r.ID).Take(period).OrderBy(o => o.ID).ToList();
                var result = new List<AnalyzeResult>();

                var dataMatrix = new Matrix(new double[,] { { 1, 0 }, { 0, 0 }, { 1, 0 }, { 0, 0 }, { 1, 0 }, { 0, 0 }, { 1, 0 }, { 0, 0 } });
                var transform = new WaveletTransform(new HaarLift(), 1);
                dataMatrix = transform.DoForward(dataMatrix);


                return result;
            });
        }
    }
}
