using System.IO;
using System.Text.Json;

namespace WindowsShutdownHelper.functions
{
    public class jsonWriter
    {
        public static void WriteJson(string fileNameWithExtension, bool writeIndented, object willWriteListOrClass)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = writeIndented
            };

            var json = JsonSerializer.Serialize(willWriteListOrClass, options);
            var sw = new StreamWriter(fileNameWithExtension, false);
            sw.WriteLine(json);
            sw.Close();
        }
    }
}