using System;

namespace Email
{
    public class BodyBuilder
    {
        public string getBodyString(string name, string surname, DateTime EndDateTime)
        {
            return $"Szanowny  {name} " + $"{surname} " +
                $"/n mamy okazję zaprezentować najnowszą promocję trwającą do " +
                $"{EndDateTime.Day} {EndDateTime.Month} {EndDateTime.Year} /n Życzymy udanych zakupów";
        }
    }
}
