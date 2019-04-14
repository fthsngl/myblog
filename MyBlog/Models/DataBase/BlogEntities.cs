using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Models.DataBase
{
    public class BlogEntities
    {
        [Table("User")]
        public class User
        {
            [Key]
            public int Id { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public string Role { get; set; }
        }
        [Table("Message")]
        public class Message
        {
            [Key]
            public int Id { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public string Messages { get; set; }
        }
        [Table("Write")]
        public class Write
        {
            [Key]
            public int Id { get; set; }
            public string Konu { get; set; }
            public string Mesaj { get; set; }
            public string Resim { get; set; }
            public DateTime Tarih { get; set; }
        }
    }

}
