namespace YamlToProtobuf.BuildTasks
{
    public interface IConvertTask
    {
        ConvertResult Convert(IConvertContext context);
    }
}
