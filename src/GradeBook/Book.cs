using System;
using System.Collections.Generic;

namespace GradeBook
{
    public delegate void GradeAddedDelegate(Object sender, EventArgs args);
    


    public class Book
    {
        public Book(string name)
        {
            grades = new List<double>();
            Name = name;
        }

        public void AddGrade(char letter)
        {
            switch(letter)
            {
                case 'A':
                AddGrade(90);
                break;

                 case 'B':
                AddGrade(80);
                break;

                 case 'C':
                AddGrade(70);
                break;

                default:
                AddGrade(0);
                break;
            }
        }

        public void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                grades.Add(grade);   
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }

        public event GradeAddedDelegate GradeAdded;

        public Statistics GetStatistics()
        { 
            //result = result + numbers[1];
            //result += numbers[1];

            var result = new Statistics();
            result.Average = 0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;

           //foreach(var grade in grades) 
           for( var index = 0; index < grades.Count; index += 1)
           {

              /**
               if(grades[index] == 42.1)
               {
                    //This will stop itterating the loop and will not add anymore after this value is encountered
                   break;

                   //This will skip this number and continue itterating
                   continue;
               }**/

               //To display the lowest grade number
               result.Low = Math.Min(grades[index],result.Low);
               // To Display the highest grade number 
               result.High = Math.Max(grades[index],result.High);
               //To add all the grades from the list
               result.Average += grades[index];
           } 
           result.Average /= grades.Count;

           switch(result.Average)
           {
               case var d when d >= 90.0:
               result.Letter = 'A';
               break;

               case var d when d >= 80.0:
               result.Letter = 'B';
               break;

               case var d when d >= 70.0:
               result.Letter = 'C';
               break;

               case var d when d >= 60.0:
               result.Letter = 'D';
               break;

               default:
               result.Letter = 'F';
               break;
           }     
           
           return result;
        }
        
        private List<double> grades;   
        
        public String Name 
        {
            get; 
            set;
        }

        //Can not be altered anywhere else in code except in the constructor ALONE/ONLY
        //readonly string category = "Science";

        //Cannot be written into even on constructor
        //You cannot access a static member via an object reference but can only access it using a type name
        public const string CATEGORY = "Science";
    }
}