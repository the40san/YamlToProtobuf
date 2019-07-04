using YamlToProtobuf.BuildTasks;

namespace YamlToProtobuf.ConvertMetadata
{
    public class NullMetadata : IConvertMetadata
    {
        public int TestInt { get; }

        public NullMetadata(int testInt = 1)
        {
            TestInt = testInt;
        }
    }
}
