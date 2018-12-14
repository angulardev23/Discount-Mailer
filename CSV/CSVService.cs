using CsvHelper;
using Email;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CSV
{
    public class CSVService : ICSVService
    {
        private readonly IOptions<CsvConfig> _csvConfig;
        public CSVService(IOptions<CsvConfig> csvConfig)
        {
            _csvConfig = csvConfig;
        }

        public IEnumerable<EmailRecipient> ReadCSV() // -> tu ma być ICollection
        {
            var filePath = _csvConfig.Value.CSVFile;
            Console.WriteLine("Reading CSV...");
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
