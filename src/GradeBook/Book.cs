using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Book
    {
        public Book(string name)
        {
            grades = new List<double>();
            this.name = name;
        }

        public void AddGrade(double grade)
        {
               grades.Add(grade);
        }

        public Statistics GetStatistics()
        { 
            //result = result + numbers[1];
            //result += numbers[1];

            var result = new Statistics();
            result.Average = 0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;

           foreach(var grade in grades) 
           {
               //To display the lowest grade number
               result.Low = Math.Min(grade,result.Low);
               // To Display the highest grade number 
               result.High = Math.Max(grade,result.High);
               //To add all the grades from the list
               result.Average += grade;
           } 
           result.Average /= grades.Count;     
           
           return result;
        }
        
        private List<double> grades;   
         private string name;

    
    }
}