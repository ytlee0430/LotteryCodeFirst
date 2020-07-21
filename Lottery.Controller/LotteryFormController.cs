using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Lottery.Enums;
using Lottery.Interfaces;
using Lottery.Interfaces.Controller;
using Lottery.Interfaces.Services;
using Lottery.Service.Analyzer;

namespace Lottery.Controller
{
    public class LotteryFormController : ILotteryFormController
    {
        private readonly ICreateRecordService _createRecordService;
        private readonly IWebCralwer _webCralwer;
        private readonly AnalyzerResolver _analyzerResolver;
        private readonly IInMemory _inMemory;
        private readonly IExpectValueCalculator _expectValueCalculator;

        public LotteryFormController(ICreateRecordService createRecordService, IWebCralwer webCralwer, AnalyzerResolver
            analyzerResolver, IInMemory inMemory, IExpectValueCalculator expectValueCalculator)
        {
            _createRecordService = createRecordService;
            _webCralwer = webCralwer;
            _analyzerResolver = analyzerResolver;
            _inMemory = inMemory;
            _expectValueCalculator = expectValueCalculator;
        }

        public void BtnInitialSimulate()
        {
            _createRecordService.InitialSimulate();
        }

        public async void UpdateData(LottoType type)
        {
            _webCralwer.LotteryType = type;
            _webCralwer.InitialWeb();
            await new Task(() =>
            {
                while (!_webCralwer.Ready)
                    Thread.Sleep(10);
            });
            _webCralwer.UpdateData();
        }

        public async Task<string> AnalyzeData(LottoType lottoType, AnalyzeType analyzeType, int variableOne, int variableTwo)
        {
            var analyzer = _analyzerResolver(analyzeType);
            var data = _inMemory.GetRecords(lottoType);
            var results = await analyzer.Analyze(data, variableOne, variableTwo);

            StringBuilder sb = new StringBuilder();
            foreach (var result in results.Where(r => !r.IsSpecial).Take(10))
                sb.Append($"{result.Number:D2} : {result.Point} \r\n");
            sb.Append("\r\n Special Number: \r\n");
            foreach (var result in results.Where(r => r.IsSpecial).Take(5))
                sb.Append($"{result.Number:D2} : {result.Point} \r\n");

            return sb.ToString();
        }

        public async Task<string> CalculateExpectValue(LottoType lottoType, AnalyzeType analyzeType, int period,
            int expectValueCount, int variableEndValue, int variableTwo)
        {
            var analyzer = _analyzerResolver(analyzeType);
            var data = _inMemory.GetRecords(lottoType);

            var sb = new StringBuilder();
            var resultDic = new SortedDictionary<int, double>();
            var resultSpecialDic = new SortedDictionary<int, double>();
            for (var currentPeriod = period; currentPeriod <= variableEndValue; currentPeriod++)
            {
                var result = await _expectValueCalculator.CalculateExpectValue(data.ToList(), analyzer, expectValueCount, currentPeriod, variableTwo);
                resultDic.Add(currentPeriod, result.Item1);
                resultSpecialDic.Add(currentPeriod, result.Item2);
            }

            foreach (var pair in resultDic.OrderByDescending(p => p.Value).Take(5))
                sb.Append($"variable:{pair.Key:D3},Expect:{pair.Value:#0.000} \r\n");

            sb.Append("\r\n Special Number: \r\n");

            foreach (var pair in resultSpecialDic.OrderByDescending(p => p.Value).Take(5))
                sb.Append($"variable:{pair.Key:D3},Expect:{pair.Value:#0.000} \r\n");

            return sb.ToString();
        }
    }
}