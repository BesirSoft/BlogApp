using BlogApp.Data.Abstract;
using BlogApp.Entity;
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
            return context.Blogs;
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
