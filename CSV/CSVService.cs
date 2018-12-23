using CsvHelper;
using Email;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace CSV
{
    public class CSVService : ICSVService
    {
        public int CsvIndex { get; set; }

        private readonly IOptions<CsvConfig> _csvConfig;
        public CSVService(IOptions<CsvConfig> csvConfig)
        {
            _csvConfig = csvConfig;
        }

        public ICollection<EmailRecipient> ReadCSV() // -> change type to ICollection
        {
            try
            {
                LoadCsvIndex();
                Console.WriteLine($"Reading CSV file from index {CsvIndex}...");  
                var csvFilePath = _csvConfig.Value.CSVFile;
                var pagingSize = _csvConfig.Value.PagingSize;

                using (var fileReader = File.OpenText(csvFilePath))
                {
                    var emailRecipients = new Collection<EmailRecipient>();
                    var csv = new CsvReader(fileReader);
                    csv.Configuration.HasHeaderRecord = false;
                    var fileIndex = 0;
                    while (csv.Read())
                    {
                        if(fileIndex >= CsvIndex && (fileIndex - CsvIndex) < pagingSize)
                        {
                            var record = csv.GetRecord<EmailRecipient>();
                            emailRecipients.Add(record);
                        }
                        fileIndex++;
                    }

                    Console.WriteLine("Reading CSV file done.");
                    return emailRecipients;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Could not read CSV file. {e}");
                throw;
            }
        }

        private void LoadCsvIndex()
        {
            var fileReader = GetCsvIndexFile();
    
            try
            {       
                CsvIndex = int.Parse(fileReader.ReadLine());
                fileReader.Close();
            }
            catch (Exception e)
            {
                File.WriteAllText(GetCsvIndexPath(), "0");
                Console.WriteLine($"Error in GetCsvIndex: {e}");
                fileReader.Close();
                throw;
            }
        }

        public void SetCsvIndex(int csvIndex)
        {
            CsvIndex = csvIndex;
            File.WriteAllText(GetCsvIndexPath(), CsvIndex.ToString());
        }

        public void AddCsvIndex(int csvIndex)
        {
            CsvIndex += csvIndex;
            File.WriteAllText(GetCsvIndexPath(), CsvIndex.ToString());
        }

        private StreamReader GetCsvIndexFile()
        {
            try
            {
                return File.OpenText(GetCsvIndexPath());
            }
            catch (Exception e)
            {
                File.WriteAllText(GetCsvIndexPath(), "0");
                Console.WriteLine($"Error while getting CsvIndexFile: {e}");
                return File.OpenText(GetCsvIndexPath());
                //throw;
            }
        }

        private string GetCsvIndexPath()
        {
            return Path.Combine(Directory.GetCurrentDirectory(), "CsvIndexFile.txt");
        }
    }
}
