using System;
using System.Collections.Generic;
using System.Text;

namespace Email
{
    public class EmailConfig
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
    }
}
