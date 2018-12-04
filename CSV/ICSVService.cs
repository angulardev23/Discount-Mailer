using Email;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSV
{
    public interface ICSVService
    {
        IEnumerable<EmailRecipient> ReadCSV(string filePath); 
    }
}
