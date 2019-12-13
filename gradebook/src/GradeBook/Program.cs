using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Rob's Grade Book");
            // book.AddGrade(89.1);
            // book.AddGrade(90.5);
            // book.AddGrade(77.5);

            //.. Loop 
            // Enter "q" to stop input and compute

            while(true) 
            {
                Console.WriteLine("Please enter grade, followed by enter key. Type 'q' to quit");
                var input = Console.ReadLine();
                if(input == "q")
                {
                    break;
                }

                try 
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch(ArgumentException ex)
                {   
                    Console.WriteLine(ex.Message);
                }
                catch(FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("**");
                }
            };

 

            book.GetStatistics();

            var stats = book.GetStatistics();

            Console.WriteLine($"For the book named {book.Name}");
            Console.WriteLine($"Average: {stats.Average:N1}. Lowest grade: {stats.Low}. Highest grade {stats.High}");
            Console.WriteLine($"The letter grade is {stats.letter}");
        }
    }
}
