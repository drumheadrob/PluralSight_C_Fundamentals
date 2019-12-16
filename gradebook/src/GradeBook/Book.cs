using System;
using System.Collections.Generic;

namespace GradeBook
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);


    public class NamedObject
    {
        public NamedObject(string name)
        {
            Name = name;
        }

        public string Name
        {
            get;
            set;
        }
    }

    public class Book : NamedObject
    {
        public Book(string name) : base(name)
        {
            Grades = new List<double>();
            Name = name;
        }

        public void AddLetterGrade(char letter)
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
                case 'D':
                    AddGrade(60);
                    break;
                default:
                    AddGrade(0);
                    break;              
            }
        }


        public void AddGrade(double grade)
        {
            if(grade <= 100 && grade >= 0)
            {
                Grades.Add(grade);
                if(GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }

            }
            else
            {
                throw new ArgumentException($"invalid {nameof(grade)}");
            }
        }

        public event GradeAddedDelegate GradeAdded;

        public Statistics GetStatistics()
        {
            var result = new Statistics();
            result.Average = 0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;

            for(var index = 0; index < Grades.Count; index += 1)
            {
                result.High = Math.Max(Grades[index], result.High);
                result.Low = Math.Min(Grades[index], result.Low);
                result.Average += Grades[index];
            };
            result.Average /= Grades.Count;

            switch(result.Average)
            {
                case var d when d >= 90.0:
                    result.letter = 'A';
                    break;
                case var d when d >= 80.0:
                    result.letter = 'B';
                    break;
                case var d when d >= 70.0:
                    result.letter = 'C';
                    break;
                case var d when d >= 60.0:
                    result.letter = 'D';
                    break;    
                default :
                    result.letter = 'F';
                    break;    
            }

            return result;
        }

        public List<double> Grades;

        public const string CATEGORY = "Science";
    }
}
