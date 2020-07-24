using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoMapper;
using Lottery.Entities;
using Lottery.Enums;
using Lottery.Interfaces;
using Lottery.Interfaces.Services;
using Lottery.Repository.Context;
using Lottery.Repository.Entities;

namespace Lottery.Service.Web
{
    public class WebCralwer : IWebCralwer
    {
        private readonly WebBrowser webBrowser1 = new WebBrowser();
        private bool _isLoadFinish;
        private LottoType _type = LottoType.BigLotto;
        private readonly BigLotteryContext _bigLotteryContext;
        private readonly PowerLotteryContext _powerLotteryContext;
        private readonly IMapper _mapper;
        private readonly IInMemory _inMemory;
        private Action _callback;

        public LottoType LotteryType
        {
            get => _type;
            set => _type = value;
        }

        public bool Ready => _isLoadFinish;

        public WebCralwer(BigLotteryContext bigLotteryContext, PowerLotteryContext powerLotteryContext, IMapper mapper, IInMemory inMemory)
        {
            _bigLotteryContext = bigLotteryContext;
            _powerLotteryContext = powerLotteryContext;
            _mapper = mapper;
            _inMemory = inMemory;
        }

        public void InitialWebAndUpdate()
        {
            _isLoadFinish = false;
            webBrowser1.ScriptErrorsSuppressed = true;
            webBrowser1.DocumentCompleted += WebBrowser1_DocumentCompleted;

            string uriStr = _type == LottoType.BigLotto ? "http://www.9800.com.tw/lotto649/statistics.html"
                : "http://www.9800.com.tw/lotto38/statistics.html";

            Uri uri = new Uri(uriStr);
            webBrowser1.Navigate(uri);
        }

        public Task<bool> IsLoadFinish()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            return new Task<bool>(() =>
            {
                while (!this._isLoadFinish)
                {
                    if (sw.ElapsedMilliseconds > 10000)
                    {
                        return false;
                    }
                }
                return true;
            });
        }

        public void SetCallbackFunction(Action callback)
        {
            _callback = callback;
        }

        private void WebBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            webBrowser1.DocumentCompleted -= WebBrowser1_DocumentCompleted;
            webBrowser1.Document.GetElementById("p1").InnerText = "092001";
            webBrowser1.Document.All["search"].InvokeMember("submit");
            webBrowser1.DocumentCompleted += WebBrowser1_OnSearchCompleted;
        }

        private void WebBrowser1_OnSearchCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            webBrowser1.DocumentCompleted -= WebBrowser1_OnSearchCompleted;
            _isLoadFinish = true;
            UpdateData();
            _callback();
        }

        public void UpdateData()
        {
            if (!_isLoadFinish)
            {
                MessageBox.Show("Loading.... Please Wait.");
                return;
            }

            DateTime lastDate = new DateTime(1990, 12, 14);
            switch (_type)
            {
                case LottoType.BigLotto:
                    lastDate = _bigLotteryContext.GetMaxDate();
                    break;

                case LottoType.PowerLottery:
                    lastDate = _powerLotteryContext.GetMaxDate();
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }

            var list = new List<LotteryRecord>();
            var crawlerResultList = crawler();
            AnalyzeData(crawlerResultList, lastDate, list);

            switch (_type)
            {
                case LottoType.BigLotto:
                    var addList = _mapper.Map<List<BigLotteryRecord>>(list);
                    _bigLotteryContext.Add(addList);
                    _inMemory.BigLotteryRecords.AddRange(list);
                    break;

                case LottoType.PowerLottery:
                    _powerLotteryContext.Add(_mapper.Map<List<PowerLotteryRecord>>(list));
                    _inMemory.PowerLotteryRecords.AddRange(list);
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void SaveCSVFile(List<LotteryRecord> list)
        {
            StreamWriter sw = new StreamWriter($"C:\\Users\\ext_brucel\\Desktop\\loto-{DateTime.Now:yyyyMMMMdd}.csv");
            sw.WriteLine("date,one,two,three,four,five,six,special");
            foreach (var record in list)
            {
                sw.WriteLine($"{record.Date:yyyy MMMM dd},{record.First},{record.Second},{record.Third},{record.Fourth},{record.Fifth},{record.Sixth},{record.Special}");
            }
            sw.Close();
        }

        private List<List<string>> crawler()
        {
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.Load(webBrowser1.DocumentStream);

            var nodes = doc.DocumentNode
                .SelectNodes("//table")[1];

            return doc.DocumentNode
                .SelectNodes("//table")[1]
                .Descendants("tr")
                .Skip(1)
                .Select(tr => tr.Elements("td").Select(td => td.InnerText.Trim()).ToList()).ToList();
        }

        private void AnalyzeData(List<List<string>> crawlerResultList, DateTime lastDate, List<LotteryRecord> addList)
        {
            foreach (var arr in crawlerResultList)
            {
                if (arr.Count <= 12)
                    continue;
                var date = Convert.ToDateTime(arr[1]);

                if (date.CompareTo(lastDate) <= 0)
                    continue;
                addList.Add(new LotteryRecord
                {
                    ID = 0,
                    Date = Convert.ToDateTime(arr[1]),
                    First = Convert.ToInt32(arr[2]),
                    Second = Convert.ToInt32(arr[3]),
                    Third = Convert.ToInt32(arr[4]),
                    Fourth = Convert.ToInt32(arr[5]),
                    Fifth = Convert.ToInt32(arr[6]),
                    Sixth = Convert.ToInt32(arr[7]),
                    Special = Convert.ToInt32(arr[8])
                });
            }
        }
    }
}