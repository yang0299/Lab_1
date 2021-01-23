/****************************************************
* File name:	Program.cs
* Version:		Mircrosof Visual Studio 2019
* Author:		Boning Yang
* Student#:		040980629
* Course:		.NET Enterprise Appl 21W_CST8359_300
* Lab Section:	302
* Lab:          Hello World! An introduction to C#
* Due Date:		23-01-2021
* Submission:	23-01-2021
* Professor:	Amir Afrasiabi Rad
****************************************************/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Diagnostics;
namespace Lab1_cst8359
{
    class Program
    {
        //store all words to List from file
        public static List<string> Words = new List<string>();
        //line number count;
        public static int temp;
        /*create a display menu for program*/
        static void displaymenu()
        {
            Console.WriteLine("1 - Import Words from File\n");
            Console.WriteLine("2 - Bubble Sort words\n");
            Console.WriteLine("3 - LINQ/Lambda sort words\n");
            Console.WriteLine("4 - Count the Distinct Words\n");
            Console.WriteLine("5 - Take the first 10 words\n");
            Console.WriteLine("6 - Get the number of words that start with 'j' and display the count\n");
            Console.WriteLine("7 - Get and display of words that end with 'd' and display the count\n");
            Console.WriteLine("8 - Get and display of words that are greater than 4 characters long, and display the count\n");
            Console.WriteLine("9 - Get and display of words that are less than 3 characters long and start with the letter 'a', and display the count\n");
            Console.WriteLine("x - Exit\n");
        }
        public static int readWords()
        {
            //decalre the string content;
            string read;
            //initialize the counter number to 0;
            temp = 0;
            //read words from file
            using (StreamReader streamReader = new StreamReader("Words.txt"))
            {
                //read words as long as the current line is not empty
                while ((read = streamReader.ReadLine()) != null)
                {
                    Words.Add(read);
                    temp++;
                }
            }
            //return the number of line count;
            return temp;
        }
        public static string[] bubbleSort(List<string> Words)
        {
            //set a true flag
            bool condition = true;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for(int i=0;(i<Words.Count - 1) && condition; i++)
            {
                condition = false;
                for(int j = i+1; j < Words.Count; j++)
                {
                    if (Words[j - 1].CompareTo(Words[j]) > 0)
                    {
                        string temporary = Words[i];
                        Words[i] = Words[i + 1];
                        Words[i + 1] = temporary;
                        condition = true;
                    }
                }
            }
            Console.Write("Time elapsed:");
            Console.Write(stopwatch.ElapsedMilliseconds);
            Console.Write("ms");
            //return words;
            return Words.ToArray();
        }
        public static void linq_lambdaSort()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            //decalre length of string 
            var stringLength = from element in Words orderby element.Length select element;
            foreach(string value in stringLength)
            {
                Console.WriteLine(value);
            }
            Console.Write("Time elapsed:");
            Console.Write(stopwatch.ElapsedMilliseconds);
            Console.Write("ms");
        }
        public static void countWords()
        {
            //initialize temp to 0
            temp = 0;
            //decalre the designed words as disdinct
            var particular = Words.Distinct();
            foreach( var result in particular)
            {
                temp++;
            }
            Console.Write("The number of disdinct words is: ");
            Console.WriteLine(temp);
        }
        public static void firstTenWords()
        {
            //decalre the first ten words
            var firstTen = Words.Take(10);
            foreach(var f in firstTen)
            {
                Console.WriteLine(f);
            }
        }
        public static void jWords()
        {
            //initialize temp to 0
            temp = 0;
            //decalre the words which start with letter "j"
            var startWithJ = from n in Words where n.StartsWith("j") select n;
            foreach(var j in startWithJ)
            {
                temp++;
                Console.WriteLine(j);
            }
            Console.Write("The number of words start with 'j' is: ");
            Console.WriteLine(temp);
        }
        public static void dWords()
        {
            //initialize temp to 0
            temp = 0;
            var endWithD = from n in Words where n.EndsWith("d") select n;
            foreach(var d in endWithD)
            {
                temp++;
                Console.WriteLine(d);
            }

            Console.Write("The number of words end with 'd' is: ");
            Console.WriteLine(temp);
        }
        public static void greater4Words()
        {
            //initialize temp to 0
            temp = 0;
            //decalre the words which length is longer than 4
            var greaterThan4 = from n in Words where n.Length > 4 select n;
            foreach(var l in greaterThan4)
            {
                temp++;
                Console.WriteLine(l);
            }
            Console.Write("The number of words longer than 4 chars is: ");
            Console.WriteLine(temp);
        }
        public static void aWords()
        {
            //initialize temp to 0
            temp = 0;
            //decalre the words start with 'a'
            var startWithA = from n in Words where n.StartsWith("a") && n.Length < 3 select n;
            foreach(var a in startWithA)
            {
                temp++;
                Console.WriteLine(a);
            }
            Console.Write("The number of words length which less than 3 characters and start with 'a' is: ");
            Console.WriteLine(temp);
        }
        static void Main(string[] args)
        {
            //decalre the select of user
            string select;
            do
            {
                //show the main menu
                displaymenu();
                //promt user input for selection
                select = Console.ReadLine();
                if (select == "1")
                {
                    readWords();
                    Console.Write("Number of words found:\n");
                    Console.WriteLine(temp);
                }

                else if (select == "2")
                {
                    bubbleSort(Words);
                }

                else if (select == "3")
                {
                    linq_lambdaSort();
                }

                else if (select == "4")
                {
                    countWords();
                }

                else if (select == "5")
                {
                    firstTenWords();
                }

                else if (select == "6")
                {
                    jWords();
                }

                else if (select == "7")
                {
                    dWords();
                }

                else if (select == "8")
                {
                    greater4Words();
                }

                else if (select == "9")
                {
                    aWords();
                }

                else if (select == "x")
                {
                    Console.WriteLine("Exiting...\n");
                }

                else
                    Console.WriteLine("Invalid Input");
            } while (select != "x");
            
        }

    }
}
