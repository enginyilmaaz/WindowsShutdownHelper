using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.Json;
using WindowsShutdownHelper.lang;

namespace WindowsShutdownHelper.functions
{
    internal class languageSelector

    {
        public static language languageFile()
        {
            var settings = new settings();
            if (File.Exists("settings.json"))
                settings = JsonSerializer.Deserialize<settings>(File.ReadAllText("settings.json"));

            Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "\\lang");
            if (Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "lang\\"))
            {
                if (!File.Exists("/lang/lang_en.json"))
                    jsonWriter.WriteJson("lang\\lang_en.json", true, lang_en.lang_english());
                if (!File.Exists("/lang/lang_tr.json"))
                    jsonWriter.WriteJson("lang\\lang_tr.json", true, lang_tr.lang_turkish());
                var existLanguages = Directory
                    .GetFiles(AppDomain.CurrentDomain.BaseDirectory + "lang\\", "lang_??.json")
                    .Select(Path.GetFileNameWithoutExtension)
                    .ToList();

                var currentCultureLangCode = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;


                foreach (var lang in existLanguages)
                {
                    var langCode = lang.Substring(lang.Length - 2);
                    if (settings.language == "auto")
                    {
                        if (currentCultureLangCode == langCode)
                            return JsonSerializer.Deserialize<language>(
                                File.ReadAllText("lang\\lang_" + langCode + ".json"));
                    }
                    else
                    {
                        return JsonSerializer.Deserialize<language>(
                            File.ReadAllText("lang\\lang_" + settings.language + ".json"));
                    }
                }

                foreach (var lang in existLanguages)
                {
                    var language = lang.Substring(lang.Length - 2);
                    if (settings.language == "auto")
                        if (currentCultureLangCode != lang)
                            return JsonSerializer.Deserialize<language>(
                                File.ReadAllText("lang\\lang_" + "en" + ".json"));
                }


                return null;
            }

            return null;
        }


        ///
    }
}