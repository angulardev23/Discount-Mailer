using System;

namespace DiscountMailer
{
    class Program
    {
        static void Main(string[] args)
        {
            Settings settings = new Settings();
            CSVFile.ReadCSV();
            //settings.ReadSettings();
            //Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}
