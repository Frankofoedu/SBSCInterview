using System;
using System.Collections.Generic;
using System.Text;

namespace SBSCInterview
{
    class Program
    {
        static void Main(string[] args)
        {
           Console.WriteLine(StringOccurrence(""));

            Console.Read();
        }


        static string StringOccurrence(string inputString)
        {
            //loop through string
            //for each element, check if it exists in the dictionary
            //if it exists, increment count else add to the dictionary

            if (string.IsNullOrEmpty(inputString))
            {
                return "Empty string provided";
            }

            var dictOccurence = new Dictionary<char, int>();
            var sb = new StringBuilder();
            for (int i = 0; i < inputString.Length; i++)
            {
                var c = inputString[i];

                if (!dictOccurence.ContainsKey(c))
                {
                    dictOccurence.Add(c, 1);
                }
                else
                {
                    dictOccurence[c]++;
                }
            }

            foreach (var item in dictOccurence)
            {
                sb.Append($"{item.Key}{item.Value}");
            }

            return sb.ToString(); ;
        }
    }
}
