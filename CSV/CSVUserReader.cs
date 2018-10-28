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
        public static IEnumerable<EmailRecipient> ReadCSV(string filePath) // -> tu ma być ICollection
        {
            // -> tu mówił o File.
            using (TextReader fileReader = File.OpenText(filePath))
            {
                var csv = new CsvReader(fileReader);
                csv.Configuration.HasHeaderRecord = false;
                return csv.GetRecords<EmailRecipient>().ToArray();  // -> pobieranie 100 rekordów na minutę
            }
            
        }


    }
}
