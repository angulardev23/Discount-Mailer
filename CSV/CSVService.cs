﻿using CsvHelper;
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

        public ICollection<EmailRecipient> ReadCSV() // -> change type to ICollection
        {
            try
            {
                var filePath = _csvConfig.Value.CSVFile;
                // -> tu mówił o File. 
                using (var fileReader = File.OpenText(filePath))
                {
                    Console.WriteLine("Reading CSV file...");
                    var csv = new CsvReader(fileReader);
                    csv.Configuration.HasHeaderRecord = false;
                    Console.WriteLine("Reading CSV file done.");
                    return csv.GetRecords<EmailRecipient>().ToArray();  // -> 100 records (paging)
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Could not read CSV file. {e}");
                throw;
            }

        }


    }
}
