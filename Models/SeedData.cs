using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BooksContext(
                serviceProvider.GetRequiredService<DbContextOptions<BooksContext>>()))
            {
                
                if (context.Book.Any())
                {
                    return;  
                }

                context.Book.AddRange(
                    new Book
                    {
                        Title = " Harry Potter i Kamen mudraca",
                        ReleaseDate = DateTime.Parse("1997-2-12"),
                        Genre = "Roman",
                        Rating = "R",
                        Price = 17.00M
                      
                    },

                    new Book
                    {
                        Title = " Harry Potter i Odaja tajni",
                        ReleaseDate = DateTime.Parse("1998-3-13"),
                        Genre = "Roman",
                        Rating = "R",
                        Price = 8.99M
                    },

                    new Book
                    {
                        Title = " Harry Potter i Zatočenik Azkabana",
                        ReleaseDate = DateTime.Parse("1999-2-23"),
                        Genre = "Roman",
                        Rating = "S",
                        Price = 12.80M
                    }
                   
                    );
                context.SaveChanges();
            }
        }
    }
}
