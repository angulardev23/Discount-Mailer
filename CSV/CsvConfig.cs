using System;
using System.Collections.Generic;
using System.Text;

namespace CSV
{
    public class CsvConfig
    {
        public string CSVFile { get; set; }
        public string CsvIndexFile { get; set; }
        public int PagingSize { get; set; }
    }
}
