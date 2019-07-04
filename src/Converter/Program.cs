using System;
using YamlToProtobuf.BuildTasks;

namespace YamlToProtobuf
{
    public class Program
    {
        private static void Main(string[] _)
        {
            var taskDefinition = new DefaultTaskDefinition();

            var result = taskDefinition.Execute();
            if (result != ConvertResult.Success)
            {
                Console.WriteLine("Convert failed");
                return;
            }

            Console.WriteLine("Convert Succeed.");
        }
    }
}
