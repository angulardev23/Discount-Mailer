using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json.Linq;

namespace DiscountMailer
{
    class Settings
    {
        string SettingsFilePath = "settings.json";
        JObject SettingsJson;
        static int IndexCSV;
        static String RecipientsFileCSV;


        public void setIndexCSV(int index)
        {
            IndexCSV = index;
         }

        public Settings()
        {
            string result = string.Empty;
            using (StreamReader r = new StreamReader(SettingsFilePath))
            {
                var json = r.ReadToEnd();
                SettingsJson = JObject.Parse(json);
                foreach (var item in SettingsJson.Properties())
                {
                    if (item.Name.Contains("RecipientsFileCSV"))
                    {
                        item.Value = item.Value.ToString();
                    } else if (item.Name.Contains("IndexCSV")) {
                        int parsedIndex = 0;
                        if (Int32.TryParse(item.Value.ToString(), out parsedIndex))
                            IndexCSV = parsedIndex;
                    }
                        
                }
                result = SettingsJson.ToString();
                Console.WriteLine(result);
            }
            File.WriteAllText(SettingsFilePath, result);
        }


    }
}
