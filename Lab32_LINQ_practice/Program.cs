using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Lab32_LINQ_practice
{
    class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Student(string Name, int Age)
        {
            this.Name = Name;
            this.Age = Age;
        }
    }
    class Program
    {
        public static List<int> Nums = new List<int> { 10, 2330, 112233, 10, 949, 3764, 2942 };
        public static List<Student> Students = new List<Student>()
            {
                new Student("Jimmy", 13),
                new Student("Hannah Banana", 21),
                new Student("Justin", 30),
                new Student("Sarah", 53),
                new Student("Hannibal", 15),
                new Student("Phillip", 16),
                new Student("Maria", 63),
                new Student("Abe", 33),
                new Student("Curtis", 10)
            };
        static void Main(string[] args)
        {
            Console.WriteLine("Lab - LINQ");

            LinqNums();

            LinqStudents();
        }
        public static void PrintIntegers(string message, List<int> integers)
        {
            Console.Write($"{message} : ");
            foreach (int number in integers)
            {
                Console.Write($"{number}, ");
            }
            Console.WriteLine("\n");
        }
        public static void LinqNums()
        {
            /* For nums:
             *
             * 1) Find the Minimum value
             * 2) Find the Maximum value
             * 3) Find the Maximum value less than 10000
             * 4) Find all the values between 10 and 100
             * 5) Find all the Values between 100000 and 999999 inclusive
             * 6) Count all the even numbers
             */
            Console.WriteLine("\n\nFor Nums...\n\n");

            // 1) Find the Minimum value
            int minOfList = Nums.Min();
            Console.WriteLine($"Find the Minimum value: {minOfList}");

            // 2) Find the Maximum value
            int maxOfList = Nums.Max();
            Console.WriteLine($"Find the Maximum value: {maxOfList}");

            // 3) Find the Maximum value less than 10000
            int maxBelow10k = Nums.Where(x => x < 10000).Max();
            Console.WriteLine($"Find the Maximum value less than 10000: {maxBelow10k}");

            // 4) Find all the values between 10 and 100
            List<int> rangeValues4 = Nums.Where(x => x >= 10 && x <= 100).ToList();
            PrintIntegers("Find all the values between 10 and 100", rangeValues4);

            // 5) Find all the Values between 100000 and 999999 inclusive
            List<int> rangeValues5 = Nums.Where(x => x >= 100000 && x <= 999999).ToList();
            PrintIntegers("Find all the Values between 100000 and 999999 inclusive", rangeValues5);

            // 6) Count all the even numbers
            int countEvens = Nums.Where(x => x % 2 == 0).Count();
            Console.WriteLine($"Count all the even numbers: {countEvens}");
        }
        public static void PrintStudents(string message, List<Student> students)
        {
            Console.Write($"{message} : ");
            foreach (Student student in students)
            {
                Console.Write($"{student.Name} / {student.Age}, ");
            }
            Console.WriteLine("\n");
        }
        public static void LinqStudents()
        {
            /* For students: 
             * 
             * 1) Find all students age of 21 and over (aka US drinking age)
             * 2) Find the oldest student
             * 3) Find the youngest student
             * 4) Find the oldest student under the age of 25
             * 5) Find all students over 21 and with even ages
             * 6) Find all teenage students (13 to 19 inclusive)
             * 7) Find all students whose name starts with a vowel
             */
            Console.WriteLine("\n\nFor students...\n\n");
            // 1) Find all students age of 21 and over (aka US drinking age)
            List <Student> studentsOfAge = Students.Where(x => x.Age >= 21).ToList();
            PrintStudents("Find all students age of 21 and over (aka US drinking age)", studentsOfAge);

            // 2) Find the oldest student
            int studentOldest = Students.Max(x => x.Age);
            List<Student> studentOldestList = Students.Where(x => x.Age == studentOldest).ToList();
            PrintStudents("Find the oldest student", studentOldestList);

            // 3) Find the youngest student
            int studentYoungest = Students.Min(x => x.Age);
            List<Student> studentYoungestList = Students.Where(x => x.Age == studentYoungest).ToList();
            PrintStudents("Find the youngest student", studentYoungestList);

            // 4) Find the oldest student under the age of 25
            int studentOldestUnder25max = Students.Where(x => x.Age < 25).ToList().Max(x => x.Age);
            List<Student> studentOldestUnder25maxList = Students.Where(x => x.Age == studentOldestUnder25max).ToList();
            PrintStudents("Find the oldest student under the age of 25", studentOldestUnder25maxList);

            // 5) Find all students over 21 and with even ages
            List<Student> studentsOver21EvenAged
                    = Students.Where(x => x.Age > 21 && x.Age % 2 == 0).ToList();
            PrintStudents("Find all students over 21 and with even ages", studentsOver21EvenAged);

            // 6) Find all teenage students (13 to 19 inclusive)
            List<Student> studentsTeens = Students.Where(x => x.Age >= 13 && x.Age <= 19).ToList();
            PrintStudents("Find all teenage students (13 to 19 inclusive)", studentsTeens);

           // 7) Find all students whose name starts with a vowel
            List<Student> studentsStartWithVowel 
                    = Students.Where(x => "AEIOU".Contains(x.Name.Substring(0, 1))).ToList();
            PrintStudents("Find all students whose name starts with a vowel", studentsStartWithVowel);
        }
    }
}
