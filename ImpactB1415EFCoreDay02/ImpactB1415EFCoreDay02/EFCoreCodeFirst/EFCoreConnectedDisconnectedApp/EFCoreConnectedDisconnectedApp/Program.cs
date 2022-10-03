using EFCoreConnectedDisconnectedApp.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace EFCoreConnectedDisconnectedApp
{
    class Program
    {
        static IdentityCodeFirstContext context = new IdentityCodeFirstContext();
        static void Main(string[] args)
        {
            //Connected Architecture
            Console.WriteLine("EF Core Connected Architecture");
            Author author = new Author
            {
                FirstName = "Narayan",
                LastName = "Dharap",
                ContactNo = 9807612390,
                DateOfBirth = new DateTime(1940, 08, 07)
            };
            context.Authors.Add(author);
            int result = context.SaveChanges();
            if(result>0)
                Console.WriteLine("Author added successfully");
            else
                Console.WriteLine("Failed to add author");

            //Disconnected Architecture
            Console.WriteLine("EF Core Disconnected Architecture");
            Author author2 = new Author
            {
                FirstName = "Ratnakar",
                LastName = "Matkari",
                ContactNo = 8871902345,
                DateOfBirth = new DateTime(1930, 03, 06)
            };
            var authorEntry = context.Entry(author2);
            authorEntry.State = EntityState.Added;
            Author author3 = new Author
            {
                FirstName = "P L",
                LastName = "Deshpande",
                ContactNo = 9912309876,
                DateOfBirth = new DateTime(1950, 01, 01)
            };
            var authorEntry2 = context.Entry(author3);
            authorEntry2.State = EntityState.Added;
            result = context.SaveChanges();
            if (result > 0)
                Console.WriteLine("Authors added successfully");
            else
                Console.WriteLine("Failed to add author");
        }
    }
}
