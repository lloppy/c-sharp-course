using System.Collections.Generic;

namespace StructBenchmarking
{
    public interface IData
    {
        ITask ClassTask(int count);
        ITask StructureTask(int count);
    }

    public class ArrayCreation : IData
    {
        public ITask ClassTask(int count)
        {
            return new ClassArrayCreationTask(count);
        }

        public ITask StructureTask(int count)
        {
            return new StructArrayCreationTask(count);
        }
    }

    public class MethodCall : IData
    {
        public ITask ClassTask(int count)
        {
            return new MethodCallWithClassArgumentTask(count);
        }

        public ITask StructureTask(int count)
        {
            return new MethodCallWithStructArgumentTask(count);
        }
    }
    
    public class Experiments
    {
        public static ChartData BuildChartData(
            IData data, string title,
            IBenchmark benchmark, int repetitionsCount)
        {
            var classesTimes = new List<ExperimentResult>();
            var structuresTimes = new List<ExperimentResult>();

            foreach (var count in Constants.FieldCounts)
            {
                var classArray = data.ClassTask(count);
                var averageTime = benchmark.MeasureDurationInMs(classArray, repetitionsCount);
                classesTimes.Add(new ExperimentResult(count, averageTime));
                
                var structureArray = data.StructureTask(count);
                averageTime = benchmark.MeasureDurationInMs(structureArray, repetitionsCount);
                structuresTimes.Add(new ExperimentResult(count, averageTime));
            }
            
            return new ChartData
            {
                Title = title,
                ClassPoints = classesTimes,
                StructPoints = structuresTimes,
            };
        }
        public static ChartData BuildChartDataForArrayCreation(
            IBenchmark benchmark, int repetitionsCount)
        {
            return BuildChartData(new ArrayCreation(), 
                "Create array", benchmark, repetitionsCount);
        }
        public static ChartData BuildChartDataForMethodCall(
            IBenchmark benchmark, int repetitionsCount)
        {
            return BuildChartData(new MethodCall(), 
                "Call method with argument", benchmark, repetitionsCount);
        }
    }
}