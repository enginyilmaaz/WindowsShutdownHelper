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
            settings settings = new settings();
            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\settings.json"))
            {
                settings = JsonSerializer.Deserialize<settings>(
                    File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "\\settings.json"));
            }

            Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "\\lang");
            if (Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\lang"))
            {
                if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\lang\\lang_en.json"))
                {
                    jsonWriter.WriteJson(AppDomain.CurrentDomain.BaseDirectory + "lang\\lang_en.json", true,
                        lang_en.lang_english());
                }

                if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\lang\\lang_tr.json"))
                {
                    jsonWriter.WriteJson(AppDomain.CurrentDomain.BaseDirectory + "lang\\lang_tr.json", true,
                        lang_tr.lang_turkish());
                }

                System.Collections.Generic.List<string> existLanguages = Directory
                    .GetFiles(AppDomain.CurrentDomain.BaseDirectory + "lang\\", "lang_??.json")
                    .Select(Path.GetFileNameWithoutExtension)
                    .ToList();

                string currentCultureLangCode = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;


                foreach (string lang in existLanguages)
                {
                    string langCode = lang.Substring(lang.Length - 2);
                    if (settings.language == "auto")
                    {
                        if (currentCultureLangCode == langCode)
                        {
                            return JsonSerializer.Deserialize<language>(
                                File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "lang\\lang_" + langCode +
                                                 ".json"));
                        }
                    }
                    else
                    {
                        return JsonSerializer.Deserialize<language>(
                            File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "lang\\lang_" + settings.language +
                                             ".json"));
                    }
                }

                foreach (string lang in existLanguages)
                {
                   
                    if (settings.language == "auto")
                    {
                        if (currentCultureLangCode != lang)
                        {
                            return JsonSerializer.Deserialize<language>(
                                File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "lang\\lang_" + "en" +
                                                 ".json"));
                        }
                    }
                }


                return null;
            }

            return null;
        }


     
    }
}