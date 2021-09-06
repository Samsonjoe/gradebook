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
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.5);

            var stats = book.GetStatistics(); 
            //Formating a double number tohow many decimal places you need by doubleNumber:N3 = 3 decimal place    
            Console.WriteLine($"The lowest grade is {stats.Low}");
            Console.WriteLine($"The highest grade is {stats.High}");
            Console.WriteLine($"The avarage grade is {stats.Average:N1}");
           
        }
    }
}
