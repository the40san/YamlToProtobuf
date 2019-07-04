using System.Collections.Generic;
using YamlToProtobuf.BuildTasks;
using YamlToProtobuf.ConvertMetadata;
using YamlToProtobuf.ConvertTasks;

namespace YamlToProtobuf
{
    public class DefaultTaskDefinition : ITaskDefinition
    {
        private readonly IList<IConvertTask> _convertTasks;
        private readonly IConvertContext _convertContext;

        public DefaultTaskDefinition()
        {
            _convertTasks = CreateConvertTasks();
            _convertContext = CreateConvertContext();
        }

        public ConvertResult Execute()
        {
            return ConvertRunner.Run(_convertTasks, _convertContext);
        }

        // Task define for use.
        private IList<IConvertTask> CreateConvertTasks()
        {
            var result = new List<IConvertTask>();
            // Add custom tasks here.

            result.Add(new NullConvertTask());
            result.Add(new TestConvertTask());

            //
            return result;
        }

        private IConvertContext CreateConvertContext()
        {
            var context = new ConvertContext();
            // Add custom metadata here.
            context.AddMetadata<NullMetadata>(new NullMetadata());

            //
            return context;
        }
    }
}
