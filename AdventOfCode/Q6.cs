using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;

namespace AdventOfCode
{
    // Solved only part 1.
    internal class Q6
    {
        public static int Q6A()
        {
            string input = Console.ReadLine();
            string[] values = input.Split(')');


            var items = new List<KeyValuePair<string, string>>();

            do
            {
                values = input.Split(')');
                if (input != "")
                {
                    items.Add(new KeyValuePair<string, string>(values[0], values[1]));
                }
                input = Console.ReadLine();

            } while (input != "");

            ILookup<string, string> lookup = items.ToLookup(kvp =>
                kvp.Key, kvp => kvp.Value);

           

            counter(lookup, "COM", 0);
            Console.Write(sum);

            return 0;
        }

        public static int sum = 0;
        private static int counter(ILookup<string, string> lookup, string v, int k)
        { 
            sum += k;

            string[] sets = lookup[v].ToArray();
            for (int i = 0; i < sets.Count(); i++)
            {

                counter(lookup, sets[i], k + 1);
            }

            return 1;
        }


    }

    
}
