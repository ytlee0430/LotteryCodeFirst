using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Lottery.Enums;
using Lottery.Interfaces;
using Lottery.Interfaces.Analyzer;
using Lottery.Interfaces.BonusCalculator;
using Lottery.Interfaces.Controller;
using Lottery.Interfaces.Services;
using Lottery.Utils;

namespace Lottery.Controller
{
    public class LotteryFormController : ILotteryFormController
    {
        private readonly ICreateRecordService _createRecordService;
        private readonly IWebCralwer _webCralwer;
        private readonly AnalyzerResolver _analyzerResolver;
        private readonly BonusCalculatorResolver _bonusCalculatorResolver;
        private readonly IInMemory _inMemory;
        private readonly IExpectValueCalculator _expectValueCalculator;

        public LotteryFormController(ICreateRecordService createRecordService, IWebCralwer webCralwer, AnalyzerResolver
            analyzerResolver, IInMemory inMemory, IExpectValueCalculator expectValueCalculator, BonusCalculatorResolver bonusCalculatorResolver)
        {
            _createRecordService = createRecordService;
            _webCralwer = webCralwer;
            _analyzerResolver = analyzerResolver;
            _inMemory = inMemory;
            _expectValueCalculator = expectValueCalculator;
            _bonusCalculatorResolver = bonusCalculatorResolver;
        }

        public void BtnInitialSimulate()
        {
            _createRecordService.InitialSimulate();
        }

        public void UpdateData(LottoType type, Action callback)
        {
            _webCralwer.LotteryType = type;
            _webCralwer.SetCallbackFunction(callback);
            _webCralwer.InitialWebAndUpdate();
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
            int expectValueCount, int periodEnd, int variableTwo, int selectCount, bool showBingo, Action callBack)
        {
            var analyzer = _analyzerResolver(analyzeType);
            var calculator = _bonusCalculatorResolver(lottoType);
            var data = _inMemory.GetRecords(lottoType);

            var sw = new Stopwatch();
            sw.Start();

            var sb = new StringBuilder();
            var resultDic = new SortedDictionary<(int period, int variable2), double>();
            var resultSpecialDic = new SortedDictionary<(int period, int variable2), double>();
            var shootAllDic = new SortedDictionary<(int period, int variable2), double>();
            var bonusDic = new SortedDictionary<(int period, int variable2), double>();
            var indexes = new List<(int period, int variable2)>();
            for (var currentPeriod = period; currentPeriod <= periodEnd; currentPeriod++)
                for (var variable2 = 1; variable2 < currentPeriod; variable2++)
                {
                    if (variableTwo != 0)
                    {
                        indexes.Add((currentPeriod, variableTwo));
                        break;
                    }
                    indexes.Add((currentPeriod, variable2));
                }


            await Task.WhenAll(indexes.Select(tuple =>
                    _expectValueCalculator.CalculateExpectValue(data.ToList(), analyzer, expectValueCount,
                        tuple.period, tuple.variable2, resultDic, resultSpecialDic, selectCount, showBingo, callBack, shootAllDic
                        , calculator, bonusDic)
                ));

            sw.Stop();
            sb.Append($"Cost Time:{sw.ElapsedMilliseconds} ms \r\n");
            sb.Append($"Cost Money:{expectValueCount * Calculator.Combination(selectCount, 6) * (lottoType == LottoType.BigLotto ? 50 : 800):N} NT \r\n");
            foreach (var pair in resultDic.OrderByDescending(p => p.Value).Take(5))
                sb.Append($"period:{pair.Key.period:D3},variable2:{pair.Key.variable2:D3},Expect:{pair.Value:#0.000} \r\n");

            sb.Append("\r\nSpecial Number: \r\n");

            foreach (var pair in resultSpecialDic.OrderByDescending(p => p.Value).Take(5))
                sb.Append($"period:{pair.Key.period:D3},variable2:{pair.Key.variable2:D3},Expect:{pair.Value:#0.000} \r\n");


            sb.Append("\r\nShoot Index: \r\n");

            foreach (var pair in shootAllDic.OrderBy(p => p.Value).Take(5))
                sb.Append($"period:{pair.Key:D3},Index:{pair.Value:#0.000} \r\n");


            sb.Append("\r\n Bonus: \r\n");

            foreach (var pair in bonusDic.OrderByDescending(p => p.Value).Take(5))
                sb.Append($"period:{pair.Key:D3},Bonus:{pair.Value:N} NT \r\n");

            return sb.ToString();
        }
    }
}