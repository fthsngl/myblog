using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static MyBlog.Models.DataBase.BlogEntities;

namespace MyBlog.Models.DataBase
{
    public class BlogContext:DbContext
    {
        DbSet<User> User { get; set; }
        DbSet<Message> Message { get; set; }
        DbSet<Write> Write { get; set; }
        

        public BlogContext(DbContextOptions<BlogContext> option) : base(option)
        {

        }
    }
}
