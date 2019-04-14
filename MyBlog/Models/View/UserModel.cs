using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static MyBlog.Models.DataBase.BlogEntities;

namespace MyBlog.Models.View
{
    public class UserModel
    {
        public UserModel()
        {
            User = new User();
        }
        public User User { get; set; }
        public string Email { get; set; }
    }
}
