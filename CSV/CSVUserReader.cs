using CsvHelper;
using Email;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CSV
{
    public class CSVUserReader
    {
        public static IEnumerable<EmailRecipient> ReadCSV(String FilePath)
        {
            TextReader textReader = File.OpenText(FilePath);
            //var csv = new CsvReader(textReader);
            IEnumerable<EmailRecipient> allValues;

            using (TextReader fileReader = File.OpenText(FilePath))
            {
                var csv = new CsvReader(fileReader);
                csv.Configuration.HasHeaderRecord = false;
                allValues = csv.GetRecords<EmailRecipient>().ToArray();
            }
            

            return allValues;
        }


    }
}
