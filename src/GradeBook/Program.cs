using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            // comment multiple lines = Hold down ctrl then k + c
            //uncomment multiple lines = Hold down ctrl then k + u

            var book = new Book("Samson's Grade Book");
            book.GradeAdded += OnGradeAdded;
            book.GradeAdded += OnGradeAdded;
            book.GradeAdded -= OnGradeAdded;
            book.GradeAdded += OnGradeAdded;

            while(true)
            {
                Console.WriteLine("Enter a grade or 'q' to quit");
                var input = Console.ReadLine();

                if (input == "q" )
                {
                    break;
                }

                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("Finally on Try Catch");
                }
                
            }

            /*
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.5);*/

            var stats = book.GetStatistics(); 

            //Formating a double number tohow many decimal places you need by doubleNumber:N3 = 3 decimal place
            Console.WriteLine(Book.CATEGORY);
            Console.WriteLine($"For the book named{book.Name}");    
            Console.WriteLine($"The lowest grade is {stats.Low}");
            Console.WriteLine($"The highest grade is {stats.High}");
            Console.WriteLine($"The avarage grade is {stats.Average:N1}");
            Console.WriteLine($"The letter grade is {stats.Letter}");
           
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("A grade was added");
        }
    }
}
