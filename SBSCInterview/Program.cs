using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SBSCInterview
{
    class Program
    {
        static void Main(string[] args)
        {
           Console.WriteLine(HyphenSeperatedNumber("1 - 2 - 2 - 4 - 5"));


            Console.Read();
        }
        static bool HyphenSeperatedNumber(string inputString)
        {
            
            if (string.IsNullOrWhiteSpace(inputString))
            {
                return false;
            }

            //split string to integer array
              var arr = inputString.Split('-').Select(int.Parse).ToList();

            if (arr.Count <= 0)
                return false;

            if (arr.Count <= 2)
                return true;

            //get difference
            var diff = arr[1] - arr[0];

            for (int i = 0; i < arr.Count - 1; i++)
            {
                if (arr[i + 1] - arr[i] != diff)
                {
                    return false;
                }
            }

            return true;
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
