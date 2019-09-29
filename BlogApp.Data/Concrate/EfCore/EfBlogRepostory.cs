using BlogApp.Data.Abstract;
using BlogApp.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogApp.Data.Concrate.EfCore
{
   public class EfBlogRepostory : IBlogRepostory
    {
        private BlogContext context;
        public EfBlogRepostory(BlogContext _context)
        {
            context = _context;
        }
        public void AddBlog(Blog entity)
        {
            context.Blogs.Add(entity);
          
            context.SaveChanges();
        }

        public void DleteBlog(int BlogId)
        {
            var blog = context.Blogs.FirstOrDefault(p=>p.Id==BlogId);

            if (blog !=null)
            {
                context.Remove(blog);

            }
        }

        public IQueryable<Blog> GetAll()
        {
            //context.Blogs.FromSql("");
            //return context.Blogs;
            var blog = context.Blogs.FromSql("select * from Blogs where Body = 'banan'");
            return blog;
        }


        public IQueryable<Blog> GetAll2()
        {
           var blog= context.Blogs.FromSql("select * from Blogs");
            return blog;
        }
        public Blog GetByIId(int blogId)
        {
            return context.Blogs.FirstOrDefault(p => p.Id == blogId);
        }

        public void UpdateBlog(Blog entity)
        {
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
