using Email;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSV
{
    public interface ICSVService
    {
        ICollection<EmailRecipient> ReadCSV();
        void SetCsvIndex(int csvIndex);
        void AddCsvIndex(int csvIndex);
    }
}
