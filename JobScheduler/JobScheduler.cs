using CSV;
using System;
using System.Collections.Generic;
using System.Text;

namespace Job
{
    public class JobScheduler
    {
        private ICSVService _cSVService;
        public JobScheduler(ICSVService cSVService)
        {
            _cSVService = cSVService;
        }

        public void Run()
        {
            _cSVService.ReadCSV("file");
        }
    }
}
