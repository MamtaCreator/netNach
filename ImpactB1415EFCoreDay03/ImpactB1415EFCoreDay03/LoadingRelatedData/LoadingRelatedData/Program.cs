using LoadingRelatedData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace LoadingRelatedData
{
    class Program
    {
       
        static void Main(string[] args)
        {
            //Uncomment one method at a time and see the output

            EagarLoading1();
            Console.WriteLine();
            //EagarLoading2();
            Console.WriteLine();
            //LazyLoading1();
            Console.WriteLine();
            //ExplicitLoading1();
            Console.WriteLine();
            //ExplicitLoading2();
            Console.ReadKey();
        }

        static void EagarLoading1()
        {
            ChinookContext context = new ChinookContext();
            var customerInvoices = context.Customers.Include
                (cust => cust.Invoices);
            foreach (var customer in customerInvoices)
            {
                Console.WriteLine("First Name:{0}, Last Name:{1}",
                    customer.FirstName, customer.LastName);
                foreach (var invoice in customer.Invoices)
                {
                    Console.WriteLine("\t\tInvoice Date:{0}, Total:{1}",
                        invoice.InvoiceDate, invoice.Total);
                }
            }
        }

        static void EagarLoading2()
        {
            ChinookContext context = new ChinookContext();
            var custInvInvLines = context.Customers
                                  .Include(cust => cust.Invoices)
                                  .ThenInclude(inv => inv.InvoiceLines)
                                  .Where(cust => cust.FirstName.StartsWith("A")).ToList();
            foreach (var customer in custInvInvLines)
            {
               Console.WriteLine("First Name:{0}, Last Name:{1}",
                    customer.FirstName, customer.LastName);
                foreach (var invoice in customer.Invoices)
                {
                    Console.WriteLine("\tInvoice Date:{0}, Total:{1}",
                        invoice.InvoiceDate, invoice.Total);
                    foreach (var invoiceLine in invoice.InvoiceLines)
                    {
                        Console.WriteLine("\t Unit Price:{0}, Quantity:{1}",
                            invoiceLine.UnitPrice, invoiceLine.Quantity);
                    }
                }
            }
        }

        static void LazyLoading1()
        {
            ChinookContext context = new ChinookContext();
            var albums = context.Albums.Take(5).ToList();
            foreach (var album in albums)
            {
                Console.WriteLine("Album Name:{0}",album.Title);
                foreach (var track in album.Tracks)
                {
                    Console.WriteLine("\tTrack Name:{0}",track.Name);
                }
            }
        }

        static void ExplicitLoading1()
        {
            ChinookContext context = new ChinookContext();
            var tracks = context.Tracks.Take(5).ToList();
            foreach (var track in tracks)
            {
                context.Entry(track).Reference(t => t.Album).Load();
                context.Entry(track.Album).Reference(t => t.Artist).Load();
                Console.WriteLine("{0} {1} {2}",track.Name,track.Album.Title,track.Album.Artist.Name);
            }
        }

        static void ExplicitLoading2()
        {
            ChinookContext context = new ChinookContext();
            var albums = context.Albums.Take(5).ToList();
            foreach (var album in albums)
            {
                context.Entry(album).Collection(t => t.Tracks).Load();
                context.Entry(album).Reference(t => t.Artist).Load();
                Console.WriteLine("{0} {1}",album.Title, album.Artist.Name);
                foreach (var track in album.Tracks)
                {
                    Console.WriteLine("\t{0}",track.Name);
                }
            }
        }
    }
}
