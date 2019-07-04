using YamlToProtobuf.BuildTasks;

namespace YamlToProtobuf.ConvertTasks
{
    public class NullConvertTask : IConvertTask
    {
        public ConvertResult Convert(IConvertContext context)
        {
            return ConvertResult.Success;
        }
    }
}
