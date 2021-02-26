﻿using System;
using System.Linq;
using System.Collections.Generic;

namespace ISM6225_Assignment2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question1:
            Console.WriteLine("Question 1");
            int[] ar1 = { 2, 5, 1, 3, 4, 7 };
            int n1 = 3;
            ShuffleArray(ar1, n1);
            Console.WriteLine();

            Console.WriteLine("Question 2");
            int[] ar2 = { 0, 1, 0, 3, 12 };
            MoveZeroes(ar2);
            Console.WriteLine("");

            //Question3
            Console.WriteLine("Question 3");
            int[] ar3 = { 1, 2, 3, 1, 1, 3 };
            CoolPairs(ar3);
            Console.WriteLine();

            //Question 4
            Console.WriteLine("Question 4");
            int[] ar4 = { 2, 7, 11, 15 };
            int target = 9;
            TwoSum(ar4, target);
            Console.WriteLine();

            //Question 5
            Console.WriteLine("Question 5");
            string s5 = "korfsucy";
            int[] indices = { 6, 4, 3, 2, 1, 0, 5, 7 };
            RestoreString(s5, indices);
            Console.WriteLine();

            //Question 6
            Console.WriteLine("Question 6");
            string s61 = "bulls";
            string s62 = "sunny";
            if (Isomorphic(s61, s62))
            {
                Console.WriteLine("Yes the two strings are Isomorphic");
            }
            else
            {
                Console.WriteLine("No, the given strings are not Isomorphic");
            }
            Console.WriteLine();

            //Question 7
            Console.WriteLine("Question 7");
            int[,] scores = { { 1, 91 }, { 1, 92 }, { 2, 93 }, { 2, 97 }, { 1, 60 }, { 2, 77 }, { 1, 65 }, { 1, 87 }, { 1, 100 }, { 2, 100 }, { 2, 76 } };
            HighFive(scores);
            Console.WriteLine();


            //Question 8
            Console.WriteLine("Question 8");
            int n8 = 19;
            getNumber(n8); // added for the sum squares calculation 
            if (HappyNumber(n8))
            {
                Console.WriteLine("{0} is a happy number", n8);
            }
            else
            {
                Console.WriteLine("{0} is not a happy number", n8);
            }

            Console.WriteLine();

            //Question 9
            Console.WriteLine("Question 9");
            int[] ar9 = { 7, 1, 5, 3, 6, 4 };
            int profit = Stocks(ar9);
            if (profit == 0)
            {
                Console.WriteLine("No Profit is possible");
            }
            else
            {
                Console.WriteLine("Profit is {0}", profit);
            }
            Console.WriteLine();

            //Question 10
            Console.WriteLine("Question 10");
            int n10 = 3;
            Stairs(n10);
            Console.WriteLine();


        }

        private static void ShuffleArray(int[] nums, int n)
        {
            try
            {
                int[] x = new int[n];   //empty arrays of n length for adding later
                int[] y = new int[n];

                for (int i = 0; i < n; i++)  //adding to x array
                {
                    x[i] = nums[i];
                    //Console.WriteLine(x[i]);
                }

                for (int i = n; i < n * 2; i++) //adding to y array
                {
                    int buffer = i - n; //stupid but need to this to change i value or will error out 
                    y[buffer] = nums[i];
                    //Console.WriteLine(y[buffer]);
                }

                int[] shuffled = new int[2 * n];    //length of shuffled array

                for (int i = 0; i < n; i++) //merge the 2 arrays back together in xn,yn order
                {
                    int buffer1 = i + i;   //doing math in stored variabel for index instead of in brackets
                    int buffer2 = i + i + 1;
                    shuffled[buffer1] = x[i];
                    shuffled[buffer2] = y[i];

                }

                for (int i = 0; i < n * 2; i++)
                {
                    Console.Write(shuffled[i] + ",");
                }


            }
            catch (Exception)
            {

                throw;
            }
        }

        private static void MoveZeroes(int[] ar2)
        {
            try
            {
                // move everything that is not 0, bumping everyone down and bringing the 0's the end 
                int last = ar2.Length;
                int j = 0;

                for (int i = 0; i < last; i++)
                {
                    if (ar2[i] != 0) //sort (just moving not comparing values) everything not 0
                    {
                        int temp = ar2[j];  //take value we want to swap out and store in temp
                        ar2[j] = ar2[i];    //take now empty j and replace it with i 
                        ar2[i] = temp;  // take now empty i and replace it with temp 
                        j++;
                    }


                }

                for (int q = 0; q < last; q++)
                {
                    Console.Write(ar2[q] + ",");    //printing results
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        private static void CoolPairs(int[] nums)
        {

            //create a dictionary to store the values and keys
            Dictionary<int, int> dict1 = new Dictionary<int, int>();
            int sum = 0;
            try
            {

                for (int i = 0; i < nums.Length; i++) //loop through nums once for every i in array
                {
                    for (int j = nums.Length - 1; j >= 0; j--) //decrementing, looping backwards through the array for every i 
                    {
                        if (nums[i] == nums[j] && i < j) //if the two numbers are a pair and the incrementer is lower than the decrementer, add to the dictionary
                        {
                            //Console.WriteLine(nums[i] + "," +nums[j]);
                            if (dict1.ContainsKey(nums[i])) //if the key (value from nums) is already there 
                            {
                                int counter = dict1[nums[i]];   //increment the conuter and replace the value for the key
                                counter++;
                                dict1[nums[i]] = counter;
                            }
                            else
                            {
                                dict1.Add(nums[i], 1); // else add the key and the value of one
                            }
                        }
                    }
                }


                foreach (var x in dict1)     // sum up the values in the dictionary for each key
                {
                    //Console.WriteLine(x.Key +","+ x.Value);
                    sum += x.Value;
                }
                Console.Write(sum); // print the total to show number of cool pairs 



            }
            catch (Exception)
            {

                throw;
            }
        }

        private static void TwoSum(int[] nums, int target)
        {
            try
            {
                int times = nums.Length; // set length var

                for (int i = 0; i < times; i++) //outer loop for number of times to try a var
                {
                    for (int j = 1; j < times; j++) // inner loop to copmpare outer loop var to each other var 
                    {
                        if (nums[i] + nums[j] == target && i != j) //add nums i and nums j and see if it equals the target
                        {
                            Console.WriteLine(i + "," + j); // print first pair of indices that succeed
                            return; // use return not break, break will just end of the one the loops, return will terminate
                        }

                    }

                }


            }
            catch (Exception)
            {

                throw;
            }

        }
        private static void RestoreString(string s, int[] indices)
        {
            try
            {
                Dictionary<int, string> dict2 = new Dictionary<int, string>(); //create dictionary for storage use
                string[] myStringArray = new string[s.Length]; //create empty string array to store chars in s 

                for (int i = 0; i < s.Length; i++) //add chars in s to new string array
                {
                    myStringArray[i] = s[i].ToString();
                }


                for (int k = 0; k < myStringArray.Length; k++) //add i's from indices array to the key
                {                                             //add i's from String arraay to the values
                    dict2.Add(indices[k], myStringArray[k]);
                }

                foreach (var x in dict2.OrderBy(x => x.Key)) //order the dict based on keys
                {
                    Console.Write(x.Value);             //print the values of the keys 
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        private static bool Isomorphic(string s1, string s2)
        {
            try
            {
                int size = 256; //makign size for large array
                //grab lengths of the 2 arrays 
                int s1length = s1.Length;
                int s2length = s2.Length;

                if (s1length != s2length) //need arrays to be same space to test isomorphic
                {
                    return false;
                }

                //create 2 arrays
                int[] s1new = new int[256];
                int[] s2new = new int[256];

                for (int i = 0; i < s1length; i++)
                {
                    //if current char doesn't map to the other string
                    if (s1new[s1[i]] != s2new[s2[i]])
                    {
                        return false;
                    }
                    //else increment the count 
                    s1new[s1[i]]++;
                    s2new[s2[i]]++;

                    Console.WriteLine(i + " " + s1new[s1[i]] + " " + s2new[s2[i]]);

                }

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private static void HighFive(int[,] items)
        {
            try
            {

                List<int> changeArray = new List<int>(); //add new array to it 

                for (int i = 0; i < items.GetLength(0); i++) //add 2D array to list bc 2d arrays are annoying
                {
                    for (int j = 0; j < 2; j++)
                    {
                        int dummy = items[i, 0];
                        changeArray.Add(items[i, j]);

                    }

                }

                List<int> keyStorage = new List<int>(); // store keys
                List<int> valueStorage = new List<int>(); // store values 


                for (int i = 0; i < changeArray.Count; i++) // loop through and add to lists
                {
                    if (i % 2 == 0) // if an even i it is a grade, if an odd, it is a key
                    {
                        keyStorage.Add(changeArray[i]);
                    }
                    else
                    {
                        valueStorage.Add(changeArray[i]);
                    }
                }



                //Keys for student ids
                List<int> uniqueKeys = new List<int>(valueStorage.Distinct());
                //keys array
                int[] keys2 = uniqueKeys.ToArray();
                //create new arrays for seperating test scores
                List<int> student1 = new List<int>();
                List<int> student2 = new List<int>();

                for (int m = 0; m < keyStorage.Count; m++)
                {
                    if (keyStorage[m] == 1)
                    {
                        student1.Add(valueStorage[m]);
                    }
                    else if (keyStorage[m] == 2)
                    {
                        student2.Add(valueStorage[m]);
                    }


                }

                //change lists into arrays and then reverse sort them 
                int[] student1Grades = student1.ToArray();
                Array.Sort(student1Grades);
                Array.Reverse(student1Grades);

                int[] student2Grades = student2.ToArray();
                Array.Sort(student2Grades);
                Array.Reverse(student2Grades);

                //Take averages
                double average1 = student1Grades.Average();
                double average2 = student2Grades.Average();

                //display averages
                Console.WriteLine("1" + "," + average1 + "," + "2" + "," + average2);





            }
            catch (Exception)
            {



                throw;
            }
        }

        public static int getNumber(int n) // method used to sum the squares of digits
        {
            int temp;
            int sum = 0;

            while (n > 0)
            {
                temp = n % 10;
                sum += (temp * temp);
                n /= 10;

            }
            return sum;
        }

        private static bool HappyNumber(int n)
        {
            try
            {
                int num1; // number 1
                int num2; // number 2
                num1 = num2 = n; // initialize to n 

                do
                {
                    num1 = getNumber(num1); // run num1 through the sum squares method above

                    num2 = getNumber(getNumber(num2)); // run num2 through the sum squares method above twice 
                    Console.WriteLine(num1 + " " + num2);
                }
                while (num1 != num2); // once number both reach one it is a happy number 

                return true;


            }
            catch (Exception)
            {

                throw;
            }
        }

        private static int Stocks(int[] prices)
        {
            try
            {
                int firstday = 0;
                int lastday = prices.Length;
                /// profit = 0;

                if (lastday <= firstday)
                    return 0;
                List<int> cashMoneyProfit = new List<int>(); // storing the profits computed

                for (int i = firstday; i < lastday - 1; i++)
                {
                    for (int j = 1; j < lastday - 1; j++)
                    {
                        if (prices[j] > prices[i] && i < j)
                        {
                            int profitNow = prices[j] - prices[i];

                            cashMoneyProfit.Add(profitNow);
                        }
                    }
                }

                int profit = cashMoneyProfit.Max();
                //if(cashMoneyProfit.Max() > 0)
                return profit;


            }
            catch (Exception)
            {


                throw;
            }
        }

        private static void Stairs(int steps)
        {
            try
            {
                int n = steps; // initialize input

                    if (n == 1) // one is special case
                    {
                        Console.WriteLine(1);
                    }
                    else if (n == 2) // 2 is a special case
                    {
                        Console.WriteLine(2);
                    }
                    else //use recursion to find number of possibilites then / 2 because we want only ways up steps
                    {
                        n = (n * (n - 1))/2;
                    Console.WriteLine(n);
                    }

            }
            catch (Exception)
            {

                throw;
            }

        }
      }   
}
