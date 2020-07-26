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
    }
}