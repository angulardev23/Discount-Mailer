﻿using Email;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSV
{
    public interface ICSVService
    {
        ICollection<EmailRecipient> ReadCSV();
    }
}
