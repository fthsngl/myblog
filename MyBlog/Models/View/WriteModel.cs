using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static MyBlog.Models.DataBase.BlogEntities;

namespace MyBlog.Models.View
{
    public class WriteModel
    {
        public Write Write { get; set; }
        public List<Write> WriteList { get; set; }
    }
}
