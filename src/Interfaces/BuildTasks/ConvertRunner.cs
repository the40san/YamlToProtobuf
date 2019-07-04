using System.Collections.Generic;

namespace YamlToProtobuf.BuildTasks
{
    public static class ConvertRunner
    {
        public static ConvertResult Run(IEnumerable<IConvertTask> tasks, IConvertContext context)
        {
            foreach (var task in tasks)
            {
                var returnCode = task.Convert(context);
                if (returnCode != ConvertResult.Success)
                    return ConvertResult.Failed;
            }
            return ConvertResult.Success;
        }
    }
}
