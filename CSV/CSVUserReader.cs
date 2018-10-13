using CsvHelper;
using Email;
using System;
using System.IO;

namespace CSV
{
    public class CSVUserReader
    {
        public static void ReadCSV(String FilePath)
        {
            TextReader textReader = File.OpenText(FilePath);
            var csv = new CsvReader(textReader);
            var records = csv.GetRecords<EmailRecipient>();
        }


    }
}
