using Microsoft.AspNetCore.Mvc;
using static MyBlog.Models.DataBase.BlogEntities;

namespace MyBlog.Models.View
{
    public class MessageModel
    {
        [BindProperty]
        public Message Message { get; set; }
    }
}
