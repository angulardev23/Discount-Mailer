using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CSV
{
    public class CSVUserReader
    {
        public void ReadCSV(String FilePath)
        {
            TextReader textReader = File.OpenText(FilePath);
            var csv = new CsvReader(textReader);
            var records = csv.GetRecords<dynamic>();
        }


    }
}
