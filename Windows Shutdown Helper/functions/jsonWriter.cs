using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WindowsShutdownHelper.functions
{
    public class jsonWriter
    {
        
        public static void WriteJson(string fileNameWithExtension, bool writeIndented,object willWriteListOrClass)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = writeIndented
            };

            var json = JsonSerializer.Serialize(willWriteListOrClass, options);
            StreamWriter sw = new StreamWriter(fileNameWithExtension, false);
            sw.WriteLine(json); sw.Close();

        }


    }

    
}
