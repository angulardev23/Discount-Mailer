using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DiscountMailer
{
    class CSVFile
    {
        public static void ReadCSV(String FilePath)
        {
            using (var reader = new StreamReader(@"C:\Users\garu\Desktop\test.csv"))
            {
                List<string> listA = new List<string>();
                List<string> listB = new List<string>();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');

                    Console.WriteLine(values[0]);
                    listA.Add(values[0]);
                    //listB.Add(values[1]);
                }
            }
        }
    }
}
