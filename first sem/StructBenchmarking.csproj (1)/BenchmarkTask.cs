using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using NUnit.Framework;

namespace StructBenchmarking
{
    public class Benchmark : IBenchmark
	{
        public double MeasureDurationInMs(ITask task, int repetitionCount)
        {
            
            GC.Collect();                   // Эти две строчки нужны, чтобы уменьшить вероятность того,
            GC.WaitForPendingFinalizers();  // что Garbadge Collector вызовется в середине измерений
                                            // и как-то повлияет на них.
            task.Run();
            var watch = new Stopwatch();
            watch.Start();
            for (var i = 0; i < repetitionCount; i++)
                task.Run();
            watch.Stop();

            return watch.Elapsed.TotalMilliseconds / repetitionCount;
        }
	}

    [TestFixture]
    public class RealBenchmarkUsageSample
    {
        [Test]
        public void StringConstructorFasterThanStringBuilder()
        {
            var benchmark = new Benchmark();

            var stringTime = benchmark.MeasureDurationInMs(new StringTest(), 1000);
            var stringBuilderTime = benchmark.MeasureDurationInMs(new StringBuilderTest(), 1000);

            Assert.Less(stringTime, stringBuilderTime);
        }
    }

    public class StringBuilderTest : ITask
    {
        public void Run()
        {
            var str = new StringBuilder();
            for (var i = 0; i < 1000; i ++)
                str.Append('a');
            str.ToString();
        }
    }

    public class StringTest : ITask
    {
        public void Run()
        {
            var task = new string('a', 1000);
        }
    }
}