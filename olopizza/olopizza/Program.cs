using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;


namespace olopizza
{
    class Program
    {

        /*The following code takes the pizzas.json file,
         * parses the content, adds it to a list (tops)
         * it then groups the list using lambda expressions
         * orders by count and finally presents the output 
         * to the console.
         * 
         * Disclaimer: My first time working with json... ;-)
         */ 


        static void Main(string[] args)
        {
            using (StreamReader r = new StreamReader(Environment.CurrentDirectory + @"\pizzas.json"))
            {
                var json = r.ReadToEnd();
                var value = JArray.Parse(json).Children()["toppings"].Values(); 

                List<string> tops = new List<string>();

                foreach (var Value in value)
                {

                    tops.Add(Value.ToString());
                }


                var counts = tops.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());
                var foo = counts.OrderByDescending(x => x.Value).ToList().Take(20);

                Console.WriteLine("The Top 20 toppings are as follows: \r\n");
                foreach(var faa in counts.OrderByDescending(x => x.Value).ToList().Take(20)) Console.WriteLine(faa);

                Console.WriteLine("\r\n\r\nHit 'Escape' key to close console...");


                if (Console.ReadKey(true).Key == ConsoleKey.Escape)
                {
                    Process.GetCurrentProcess().Kill(); // Leaving console open to read output. Hit Escape to close
                }
            }

        }
    }
    
}

