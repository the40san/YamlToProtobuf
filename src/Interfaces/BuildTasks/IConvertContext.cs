namespace YamlToProtobuf.BuildTasks
{
    public interface IConvertContext
    {
        void AddMetadata<T>(IConvertMetadata metadata) where T  : IConvertMetadata;
        IConvertMetadata Get<T>() where T : IConvertMetadata;
    }
}
