using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4902_GCD2501
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* 
             * Example 1: Output 
               See more: https://www.w3schools.com/cs/cs_output.php
             */

            //Console.WriteLine("Hello World!");
            //Console.WriteLine(2025);
            //Console.WriteLine("Year " + 2025);
            //Console.WriteLine("Hello " + "World");
            //Console.WriteLine(2025 + 1);
            //Console.WriteLine(2025 - 1);
            //Console.WriteLine("Next year is: " + (2025 + 1));
            //Console.WriteLine($"Previous year is: {(2025 - 1)}");

            /* 
             * Example 2: Variables 
             * See more: https://www.w3schools.com/cs/cs_variables.php
             */

            //int a = 5;
            //int b = 0;
            //b = 7;
            //Console.WriteLine($"sum(a+b) = {(a+b)}");

            //string name = "John";
            //Console.WriteLine($"Hello {name}");
            //int age = 25;
            //Console.WriteLine($"You are {age} years old");
            //Console.WriteLine($"You were born in {2025 - age}");

            /* 
             * Example 3: Input 
             * See more: https://www.w3schools.com/cs/cs_output.php
             *      https://www.w3schools.com/cs/cs_type_casting.php
             */

            //Console.WriteLine("Please enter your name: ");
            //string name = Console.ReadLine();
            //Console.WriteLine($"Hello {name}");

            //Console.WriteLine("Please enter your age: ");
            //string ageString = Console.ReadLine();
            //int age = int.Parse(ageString);

            //Console.WriteLine($"You are {age} years old");
            //Console.WriteLine($"You were born in {2025 - age}");

            /*
             * Example 4: Boolean
             * See more: https://www.w3schools.com/cs/cs_booleans.php 
             */

            //int a = 50;
            //int b = 7;
            //Console.WriteLine($"a < b: {a < b}");
            //Console.WriteLine($"a > b: {a > b}");

            /*
             * Example 5: If statements
             * See more: https://www.w3schools.com/cs/cs_conditions_elseif.php
             */

            //Console.WriteLine("Please enter x: ");
            //string xString = Console.ReadLine();
            //double x = double.Parse(xString);

            //Console.WriteLine("Please enter y: ");
            //double y = double.Parse(Console.ReadLine());

            //if (x > y)
            //{
            //    Console.WriteLine("x is greater than y");
            //}
            //else if (x < y)
            //{
            //    Console.WriteLine("x is less than y");
            //}
            //else
            //{
            //    Console.WriteLine("x is equal to y");
            //}

            /*
             * Example 6: Switch statements
             * See more: https://www.w3schools.com/cs/cs_switch.php
             */

            //Console.WriteLine("Please enter a day of the week (1-7): ");
            //int day = int.Parse(Console.ReadLine());

            //switch (day)
            //{
            //    case 1:
            //        Console.WriteLine("Monday");
            //        break;
            //    case 2:
            //        Console.WriteLine("Tuesday");
            //        break;
            //    case 3:
            //        Console.WriteLine("Wednesday");
            //        break;
            //    case 4:
            //        Console.WriteLine("Thursday");
            //        break;
            //    case 5:
            //        Console.WriteLine("Friday");
            //        break;
            //    case 6:
            //        Console.WriteLine("Saturday");
            //        break;
            //    case 7:
            //        Console.WriteLine("Sunday");
            //        break;
            //    default:
            //        Console.WriteLine("Invalid day");
            //        break;
            //}

            /*
             * Example 7: While Loops
             * See more: https://www.w3schools.com/cs/cs_while_loop.php
             *           https://www.w3schools.com/cs/cs_break.php
             */

            //while (true)
            //{
            //    // block of code
            //    Console.WriteLine("Please enter your name: ");
            //    string name = Console.ReadLine();
            //    Console.WriteLine($"Hello {name}");

            //    Console.WriteLine("Do you want to continue? (y/n)");
            //    string answer = Console.ReadLine();
            //    if (answer == "n")
            //    {
            //        break;
            //    }

            //}


            /*
             * Example 8: While Loops + Switch Statements
             */

            //while (true)
            //{
            //    Console.WriteLine("\nContact Management System");
            //    Console.WriteLine("1. Add Contact");
            //    Console.WriteLine("2. Edit Contact");
            //    Console.WriteLine("3. Remove Contact");
            //    Console.WriteLine("4. Search Contact");
            //    Console.WriteLine("\nPlease choose an option (1-4): ");

            //    string option = Console.ReadLine(); // user input for option

            //    switch (option)
            //    {
            //        case "1":
            //            Console.WriteLine("--Add Contact--");
            //            Console.WriteLine("Please enter your name: ");
            //            string name = Console.ReadLine();
            //            Console.WriteLine("Please enter your phone number: ");
            //            string phoneNumber = Console.ReadLine();

            //            Console.WriteLine($"Contact (Name: {name}, Phone Number: {phoneNumber}) was added.");
            //            break;
            //        case "2":
            //            Console.WriteLine("--Edit Contact--");
            //            break;
            //        case "3":
            //            Console.WriteLine("--Remove Contact--");
            //            break;
            //        case "4":
            //            Console.WriteLine("--Search Contact--");
            //            break;
            //        default:
            //            Console.WriteLine("Invalid option");
            //            break;
            //    }

            //    Console.WriteLine("\nDo you want to continue? (y/n)"); // Y/y or N/n
            //    string answer = Console.ReadLine().ToLower(); // user input for answer
            //    if (answer == "n")
            //    {
            //        Console.WriteLine("Goodbye!");
            //        break;
            //    }
            //}

            /* 
             * Example 9: Arrays
             * See more: https://www.w3schools.com/cs/cs_arrays.php
             */

            // Integer Array

            //int x = 5;
            //int[] y = new int[5];

            //for(int i = 0; i < 5; i++)
            //{
            //    Console.WriteLine("y[" + i + "] = " + y[i]);

            //    //Console.WriteLine($"y[{i}] = {y[i]}");
            //}

            //y[0] = 10;
            //y[1] = 20;
            //y[2] = 30;
            //y[3] = 40;
            //y[4] = 50;

            //for (int i = 0; i < 5; i++)
            //{
            //    //Console.WriteLine("y[" + i + "] = " + y[i]);

            //    Console.WriteLine($"y[{i}] = {y[i]}");
            //}

            // String Array

            //string[] names = new string[] { "John", "Jane", "Joe", "Jill", "Jack" };

            //for (int i = 0; i < 5; i++)
            //{
            //    Console.WriteLine("names[" + i + "] = " + names[i]);
            //}

            //for (int i = 0; i < names.Length; i++)
            //{
            //    Console.WriteLine("names[" + i + "] = " + names[i]);
            //}
        }
    }
}
