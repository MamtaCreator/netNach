using EFCoreCodeFirst.Models;
using System;

namespace EFCoreCodeFirst
{
    class Program
    {
        static ReadingContext context = new ReadingContext();
        static void Main(string[] args)
        {
            //Author author = new Author { FirstName = "Chetan", LastName = "Bhagat", DateOfBirth = new DateTime(1975, 07, 05), ContactNo = 9988776655 };
            //context.Authors.Add(author);
            //int result = context.SaveChanges();
            //if (result > 0)
            //    Console.WriteLine("Author added successfully");
            //else
            //    Console.WriteLine("Failed to add the author");
            AddMulipleAuthors();
            Console.ReadKey();
        }

        static void AddMulipleAuthors()
        {
            Author author1 = new Author { FirstName = "Abdul", LastName = "Kalam", DateOfBirth = new DateTime(1920, 01, 07), ContactNo = 9988787655 };
            Author author2 = new Author { FirstName = "J K", LastName = "Rowling", DateOfBirth = new DateTime(1950, 03, 05), ContactNo = 4409871234 };
            Author author3 = new Author { FirstName = "Sydney", LastName = "Scheldon", DateOfBirth = new DateTime(1960, 07, 05), ContactNo = 198734521 };
            context.Authors.AddRange(author1, author2, author3);
            int result = context.SaveChanges();
            if(result>0)
                Console.WriteLine("Authors added successfully");
            else
                Console.WriteLine("Failed to add authors");
        }
    }
}
