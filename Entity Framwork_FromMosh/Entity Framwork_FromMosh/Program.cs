using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Framwork_FromMosh
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new SQL_TutorialEntities();
            var post = new Post()
            {
                Body = "Body",
                DataPublished = DateTime.Now,
                Title = "Title"
                //PostID = 1
            };
            context.Posts.Add(post);
            context.SaveChanges();
        }
    }
}
