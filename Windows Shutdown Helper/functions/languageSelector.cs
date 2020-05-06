using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace WindowsShutdownHelper.functions
{
    internal class languageSelector

    {
        public static language languageFile()
        {
            var settings = new settings();
            if (File.Exists("settings.json"))
                settings = JsonSerializer.Deserialize<settings>(File.ReadAllText("settings.json"));
            if (Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "lang\\"))
            {
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