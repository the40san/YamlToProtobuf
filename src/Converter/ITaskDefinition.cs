using YamlToProtobuf.BuildTasks;

namespace YamlToProtobuf
{
    public interface ITaskDefinition
    {
        ConvertResult Execute();
    }
}
