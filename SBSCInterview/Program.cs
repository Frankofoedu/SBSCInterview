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
           Console.WriteLine(AbsoluteDiff(new List<int> {1,4,6, 9}, 3));


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


        static int AbsoluteDiff(List<int> arr, int k)
        {
            var set = arr.ToHashSet();
            var oldCount = arr.Count;

            return LoopThrough(arr, set, oldCount, k);


            static int LoopThrough(List<int> arr, HashSet<int> set, int oldCount, int k)
            {
                var listDiff = new List<int>();
                for (int i = 0; i < arr.Count - 1; i++)
                {
                    var diff = Math.Abs(arr[i] - arr[i + 1]);

                    if (!set.Contains(diff))
                    {
                        set.Add(diff);
                        listDiff.Add(diff);
                    }
                }

                if (set.Count != oldCount)
                {
                    oldCount = set.Count;
                    return LoopThrough(listDiff, set, oldCount, k);
                }
                else
                {
                    try
                    {

                        //find kth element
                        return set.OrderBy(x => x).ElementAt(k);
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        return -1;
                    }

                }

            }
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
            foreach (var c in inputString)
            {
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
