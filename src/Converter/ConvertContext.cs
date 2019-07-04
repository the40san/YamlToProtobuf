using System;
using System.Collections.Generic;

namespace YamlToProtobuf.BuildTasks
{
    public class ConvertContext : IConvertContext
    {
        private readonly IDictionary<Type, IConvertMetadata> _convertContexts
            = new Dictionary<Type, IConvertMetadata>();

        public void AddMetadata<T>(IConvertMetadata metadata) where T : IConvertMetadata
        {
            _convertContexts.Add(typeof(T), metadata);
        }

        public IConvertMetadata Get<T>() where T : IConvertMetadata
        {
            _convertContexts.TryGetValue(typeof(T), out var value);
            return value;
        }
    }
}
