using System;
using System.Collections.Generic;
using System.Text;

namespace Email
{
    public class BodyBuilder
    {
        public string text(string name, string surname, DateTime EndDateTime)
        {
            string body = "Szanowny " + name + surname + "/n mamy okazję zaprezentować najnowszą promocję trwającą do" + EndDateTime.Day + EndDateTime.Month + EndDateTime.Year + "/n Życzymy udanych zakupów";
            return body;
        }
    }
}
