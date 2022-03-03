using System;
using System.Linq;
using LibApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LibApp.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                SeedDBWithMemberShipTypes(context);
                SeedDBWithCustomers(context);
                SeedDBWithGenres(context);
                SeedDBWithBooks(context);
                SeedDBWithRentals(context);


                context.SaveChanges();
            }
        }
        public static void SeedDBWithMemberShipTypes(ApplicationDbContext context)
        {
            if (context.MembershipTypes.Any())
            {
                Console.WriteLine("Database already seeded with MemberShipTypes Data");
                return;
            }

            context.MembershipTypes.AddRange(
                new MembershipType
                {
                    Id = 1,
                    SignUpFee = 0,
                    DurationInMonths = 0,
                    DiscountRate = 0,
                    Name = "Basic"
                },
                new MembershipType
                {
                    Id = 2,
                    SignUpFee = 20,
                    DurationInMonths = 1,
                    DiscountRate = 10,
                    Name = "Simple"
                },
                new MembershipType
                {
                    Id = 3,
                    SignUpFee = 60,
                    DurationInMonths = 3,
                    DiscountRate = 20,
                    Name = "Advanced"
                },
                new MembershipType
                {
                    Id = 4,
                    SignUpFee = 200,
                    DurationInMonths = 12,
                    DiscountRate = 30,
                    Name = "Premium"
                });
        }

        public static void SeedDBWithCustomers(ApplicationDbContext context)
        {
            if (context.Customers.Any())
            {
                Console.WriteLine("Database already seeded with Customers Data");
                return;
            }

            context.Customers.AddRange(
                 new Customer
                 {
                     Name = "John Nowakowski",
                     HasNewsletterSubscribed = true,
                     MembershipTypeId = 3,
                     Birthdate = new DateTime(1998, 5, 20)
                 },
                 new Customer
                 {
                     Name = "Peper Nowakow",
                     HasNewsletterSubscribed = true,
                     MembershipTypeId = 1,
                     Birthdate = new DateTime(1988, 5, 20)
                 },
                 new Customer
                 {
                     Name = "Jake Nowakowski",
                     HasNewsletterSubscribed = false,
                     MembershipTypeId = 2,
                     Birthdate = new DateTime(1999, 12, 20)
                 },
                 new Customer
                 {
                     Name = "Mike Nowakowski",
                     HasNewsletterSubscribed = false,
                     MembershipTypeId = 1,
                     Birthdate = new DateTime(2000, 05, 20)
                 }
             );
        }


        public static void SeedDBWithGenres(ApplicationDbContext context)
        {
            if (context.Genre.Any())
            {
                Console.WriteLine("Database already seeded with Genre Data");
                return;
            }

            context.Genre.AddRange(
                 new Genre { Id = 1, Name = "Komedia" },
                new Genre { Id = 2, Name = "Fantasy" },
                new Genre { Id = 3, Name = "Romans" },
                new Genre { Id = 5, Name = "Biografia" },
                new Genre { Id = 6, Name = "Poemat" }
            );
        }

        public static void SeedDBWithBooks(ApplicationDbContext context)
        {
            if (context.Books.Any())
            {
                Console.WriteLine("Database already seeded with Books Data");
                return;
            }

            context.Books.AddRange(
                new Book
                {
                    Name = "Metro 2033",
                    AuthorName = "Dmitrij Głuchowski",
                    GenreId = 2,
                    DateAdded = new DateTime(),
                    NumberAvailable = 20,
                    NumberInStock = 20,
                    ReleaseDate = new DateTime(2002, 6, 28)
                },
                 new Book
                 {
                     Name = "Metro 2034",
                     AuthorName = "Dmitrij Głuchowski",
                     GenreId = 2,
                     DateAdded = new DateTime(),
                     NumberAvailable = 5,
                     NumberInStock = 10,
                     ReleaseDate = new DateTime(2009, 5, 12)
                 }
            );
        }

        public static void SeedDBWithRentals(ApplicationDbContext context)
        {
            if (context.Rentals.Any())
            {
                Console.WriteLine("Database already seeded with Rentals Data");
                return;
            }

            Book firstBook = context.Books.Where(x => x.Name == "Metro 2033").FirstOrDefault();
            Book secondBook = context.Books.Where(x => x.Name == "Metro 2034").FirstOrDefault();

            Customer firstCustomer = context.Customers.Where(x => x.Name == "John Nowakowski").FirstOrDefault();
            Customer secondCustomer = context.Customers.Where(x => x.Name == "Mike Nowakowski").FirstOrDefault();
            Customer thirdCustomer = context.Customers.Where(x => x.Name == "Jake Nowakowski").FirstOrDefault();

            context.Rentals.AddRange(
                new Rental
                {
                    Book = firstBook,
                    Customer = secondCustomer,
                    DateRented = DateTime.Now,
                },
                new Rental
                {
                    Book = secondBook,
                    Customer = firstCustomer,
                    DateRented = DateTime.Now,
                },
                new Rental
                {
                    Book = secondBook,
                    Customer = thirdCustomer,
                    DateRented = DateTime.Now,
                }
             );
        }
    }
}