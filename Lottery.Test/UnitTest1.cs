using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Lottery.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Test1()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            //var indexes = new List<int>
            //{
            //    1,2,3,4,5
            //};
            //var tasks = new List<Task>
            //{
            //    TaskDelay5(),
            //    TaskDelay5(),
            //    TaskDelay5(),
            //    TaskDelay5(),
            //    TaskDelay5()
            //};


            //await Task.WhenAll(indexes.Select(index => TaskDelay5(index)));

            for (int i = 1; i <= 5; i++)
                await TaskDelay5(i);

            sw.Stop();
            Assert.Pass();
        }


        private async Task TaskDelay5(int delayTime = 5)
        {
            await Task.Delay(delayTime * 1000);
        }


        [TestCase(5, 7, 6, true)]
        [TestCase(5, 7, 10, false)]
        [TestCase(-411, 7, 0, true)]
        [TestCase(int.MinValue, int.MinValue, 0, true)]
        public void CheckNumberTest(int a, int b, int n, bool result)
        {
            var ex = result;
            var actual = CheckNumber(a, b, n);
            Assert.AreEqual(actual, result);
        }


        public bool CheckNumber(int a, int b, int n)
        {
            return (a > n && b < n) || (a < n && b > n);
        }
    }
}