using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using YamlDotNet.RepresentationModel;
using YamlToProtobuf.BuildTasks;
using YamlToProtobuf.Converter;

namespace YamlToProtobuf.ConvertTasks
{
    public class TestConvertTask : IConvertTask
    {
        public ConvertResult Convert(IConvertContext context)
        {
            var convertResult = new List<TestValue>();
            using (var sr = new StreamReader(@"yaml/test.yml", Encoding.UTF8))
            {
                var yamlStream = new YamlStream();
                yamlStream.Load(sr);

                var values = yamlStream.Documents[0].RootNode as YamlSequenceNode;
                foreach (YamlMappingNode v in values)
                {
                    var v1 = v.Children[new YamlScalarNode("v1")].ToString();
                    var v2 = v.Children[new YamlScalarNode("v2")].ToString();

                    var testValue = new TestValue()
                    {
                        V1 = uint.Parse(v1),
                        V2 = uint.Parse(v2)
                    };
                    convertResult.Add(testValue);
                }
            }

            var testValues = new TestValueAll();
            testValues.TestValues.AddRange(convertResult);

            ProtobufWriter.WriteTo(testValues, "testValues");


            return ConvertResult.Success;
        }
    }
}
