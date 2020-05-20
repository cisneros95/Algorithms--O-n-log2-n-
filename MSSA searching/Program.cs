using System;
using System.IO;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSSA_searching
{
    class Program
    {
        static void Main(string[] args)
        {
            //load the contents of a file into the dictionary  array
            string[] dictionary = File.ReadAllLines("words.txt");

            //ask the user to choose a word to search for
            Console.Write("Please enter a word to search for: ");
            string word = Console.ReadLine();

            Console.WriteLine(BinarySearch(dictionary, word));
            Console.WriteLine(LinearSearch(dictionary, word));
        }

        static int LinearSearch(string[] arr, string value)  //O(n)
        {
            value = value.ToLower();                    //O(1)

            for (int idx = 0; idx<arr.Length; idx++)    //O(n)
            {
                Thread.Sleep(10); // pause for 10 miliseconds
                if (arr[idx].ToLower() == value)
                    return idx;
            }

            return -1; //word not found                 //O(1)
        }

        static int BinarySearch(string[] arr, string value)  //O(n)
        {
            int startPos = 0;
            int endPos = arr.Length - 1;

            while(startPos<=endPos){
                int middlePos = (startPos + endPos) / 2;
                Thread.Sleep(10);
                if (arr[middlePos] == value)
                    return middlePos;
                else if (value.CompareTo(arr[middlePos]) > 0) //move to the right half
                    startPos = middlePos + 1;
                else //search to the left
                    endPos = middlePos - 1;
            }
            return -1;
        }
    }
}
