using System.IO;
using Google.Protobuf;

namespace YamlToProtobuf.Converter
{
    public static class ProtobufWriter
    {
        private static readonly string outputDirectoryName = "out";

        public static void WriteTo(IMessage message, string fileName)
        {
            if (!Directory.Exists(outputDirectoryName))
                Directory.CreateDirectory(outputDirectoryName);

            var path = Path.Combine(outputDirectoryName, fileName);

            using (var memoryStream = new MemoryStream())
            {
                message.WriteTo(memoryStream);
                var byteArray = memoryStream.ToArray();

                File.WriteAllBytes(path, byteArray);
            }
        }
    }
}
