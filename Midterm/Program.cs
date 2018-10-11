using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm
{
    class Program
    {
        //enums
        private enum DiceNames
        {
            SnakeEyes = 2,
            Trey = 3,
            Seven = 7,
            YoLeven = 11,
            BoxCars = 12
        }
        static void Main(string[] args)
        {
            //const will never change
            const String DAVID = "David";
            Console.WriteLine(DAVID);
            String s = String.Format("The time is {0:d}", DateTime.Now);
            Console.WriteLine(s);
            Test test1 = new Test("John", "Brown");
            Console.WriteLine($"The first name is {test1.name} and the last name is {test1.LastName}.");
            int y = 5;
            int z;
            //value of y will change after being passed
            Values(ref y);
            Console.WriteLine(y);
            //value will be given to z once it is passed
            ValuesOut(out z);
            Console.WriteLine(z);
            int[] firstArray = { 1, 2, 3 };
            foreach (var el in firstArray)
            {
                Console.WriteLine(el);
            }
            //working with lists
            var items = new List<String>();
            Console.WriteLine("Before adding to items: " +
                $"Count = {items.Count}; Capacity = {items.Capacity}");
            items.Add("red");
            items.Insert(0, "yellow");
            Console.WriteLine("After adding two elements to items: " +
                $"Count = {items.Count}; Capacity = {items.Capacity}");
            foreach (var item in items)
            {
                Console.Write($"{item} \n");
            }
            items.RemoveAt(1);
            items.Add("violet");
            items.Add("orange");

            //LINQ examples
            Console.WriteLine("\nUsing LINQ below:");
            var v =
                from item in items
                where item.StartsWith("v")
                select item;
            foreach (var item in v)
            {
                Console.WriteLine(item);
            }
            var green =
                from item in items
                where item == "yellow"
                select item;
            foreach (var item in green)
            {
                Console.WriteLine(item);
            }
            int[] linqArray = { 1, 2, 3, 4, 7, 5, 6 };
            var sorted =
                from item in linqArray
                orderby item
                select item;
            foreach (var item in sorted)
            {
                Console.WriteLine(item);
            }
            //remember .Distinct in foreach statement
            //try catch exception handling
            try
            {
                Console.WriteLine("Blah blah blah");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            //expression boided method used
            int cubed = test1.Cube(5);
            Console.WriteLine(cubed);

            //recursion with factorial
            int factorial = test1.Factorial(5);
            Console.WriteLine(factorial);

            /* C# Classes and Methods information
             * -----------------------------------------
             * CONSTRUCTORS - represented below
             * THIS - represented below - used for when instance variable and var in constructor are the same
             * BASE - used for inheriting the base class in a child class's constructor. Looks like ": base(base class properties)"
             * STATIC - used for only within a class
             * PUBLIC - available basically everywhere
             * PRIVATE - limits access to only a class
             * PROTECTED - limits access to base class and derived classes
             */

            Console.ReadKey();
        }

        //passing by reference
        static void Values(ref int x)
        {
            x = x * x;
        }

        //passing with out
        static void ValuesOut(out int x)
        {
            x = 6;
            x = x * x;
        }

        public class Test
        {
            //public and private properties
            public String name;
            private String lastName;

            //constructor
            public Test(String name, String lastName)
            {
                this.name = name;
                LastName = lastName;
            }

            public String LastName
            {
                get
                {
                    return lastName;
                }
                set
                {
                    if (value == "Brown")
                    {
                        lastName = "Green";
                    }
                    else
                    {
                        lastName = value;
                    }
                }
            }

            //expression bodied method
            public int Cube(int x) => x * x * x;

            public int Factorial(int number)
            {
                if (number <= 1)
                {
                    return 1;
                }
                else
                {
                    return number * Factorial(number - 1);
                }
            }
        }
    }
}
