using MyBlog.Entities;

namespace MyBlog.Dto
{
    public class PostDto
    {
        public string Author { get; set; }
        public string Titulo { get; set; }
        public string SubTitulo { get; set; }
        public string Conteudo { get; set; }
        public DateTime CreatedAt { get; set; }
        public String Categoria { get; set; }
    }
}
