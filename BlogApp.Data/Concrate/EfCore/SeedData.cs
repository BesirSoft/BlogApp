using BlogApp.Entity;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogApp.Data.Concrate.EfCore
{
  public static  class SeedData
    {
    



        public static void Seed( IApplicationBuilder app)
        {

            BlogContext context = app.ApplicationServices.GetRequiredService<BlogContext>();
           
             context.Database.Migrate();
            if (!context.Categories.Any())
            {


                context.Categories.AddRange(
                    
                    
                    new Entity.Category() { Name="Category 1"},
                    new Entity.Category() { Name = "Category 2" },
                    new Entity.Category() { Name = "Category 3" },
                    new Entity.Category() { Name = "Category 4" },
                    new Entity.Category() { Name = "Category 5" }




                    );
                context.SaveChanges();

            }



            if (!context.Blogs.Any())
            {


                context.Blogs.AddRange(


                     new Blog() { Title = "Blog title 1", Desciription = "Blog Description", Body = "Blog Body 1", Image = "1.jpeg", Date = DateTime.Now.AddDays(-5), isApproved = true, CategoryId = 1 },
                    new Blog() { Title = "Blog title 2", Desciription = "Blog Description", Body = "Blog Body 1", Image = "2.jpeg", Date = DateTime.Now.AddDays(-7), isApproved = true, CategoryId = 2 },
                    new Blog() { Title = "Blog title 3", Desciription = "Blog Description", Body = "Blog Body 1", Image = "3.jpeg", Date = DateTime.Now.AddDays(-8), isApproved = false, CategoryId = 3 },
                    new Blog() { Title = "Blog title 4", Desciription = "Blog Description", Body = "Blog Body 1", Image = "4.jpeg", Date = DateTime.Now.AddDays(-9), isApproved = true, CategoryId = 4 }




                    );
                context.SaveChanges();

            }

        }



    }
}
