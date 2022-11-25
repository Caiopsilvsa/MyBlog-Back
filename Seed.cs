using MyBlog.Data;
using MyBlog.Entities;
using static Azure.Core.HttpHeader;
using System.Runtime.Intrinsics.X86;
using System.Drawing;
using System.Collections.Generic;

namespace MyBlog
{
    public class Seed
    {
        private readonly DataContext dataContext;

        public Seed(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public void SeedDataContext()
        {
            if (!dataContext.Posts.Any())
            {
                var PostList = new List<Post>()
                {
                    new Post()
                    {
                        Author = "João Neto",
                        Titulo = "Dolor anim cupidatat",
                        SubTitulo = "Sunt esse aliqua ullamco in incididunt consequat commodo.",
                        Conteudo = "Dolor anim cupidatat occaecat aliquip et Lorem ut elit fugiat. Mollit eu pariatur est sunt. Minim fugiat sit do dolore eu elit ex do id sunt. Qui fugiat nostrud occaecat nisi est dolor qui fugiat laborum cillum. Occaecat consequat ex mollit commodo ad irure cillum nulla velit ex pariatur veniam cupidatat. Officia veniam officia non deserunt mollit.\r\n",
                        CreatedAt = DateTime.Now,
                        Categoria = "Esportes"
            },

                 new Post()
                    {
                        Author = "Paulo Rodrigues",
                        Titulo = "Dolor anim cupidatat",
                        SubTitulo = "Sunt esse aliqua ullamco in incididunt consequat commodo.",
                        Conteudo = "Dolor anim cupidatat occaecat aliquip et Lorem ut elit fugiat. Mollit eu pariatur est sunt. Minim fugiat sit do dolore eu elit ex do id sunt. Qui fugiat nostrud occaecat nisi est dolor qui fugiat laborum cillum. Occaecat consequat ex mollit commodo ad irure cillum nulla velit ex pariatur veniam cupidatat. Officia veniam officia non deserunt mollit.\r\n",
                        CreatedAt = DateTime.Now,
                        Categoria = "Mundo"
                    }
        };
                dataContext.Posts.AddRange(PostList);
                dataContext.SaveChanges();
            }
        }
    }
}
