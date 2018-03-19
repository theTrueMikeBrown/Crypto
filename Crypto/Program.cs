using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using System.Net;
using System.IO;

namespace Crypto
{
    class Program
    {
        static void Main(string[] args)
        {
            ValueGetter getter = new ValueGetter();
            var values = getter.GetValues();

            foreach (var value in values)
            {
                Console.WriteLine($"{value.Item1}: {value.Item4}");
            }

            Console.WriteLine($"buy {values.First().Item1}");
            Console.WriteLine($"sell {values.Last().Item1}");

            Console.ReadKey();
        }
    }
}