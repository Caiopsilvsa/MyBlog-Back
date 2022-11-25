using System.ComponentModel.DataAnnotations.Schema;

namespace MyBlog.Entities
{
    [Table("Posts")]
    public class Post
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Titulo { get; set; }
        public string SubTitulo { get; set; }
        public string Conteudo { get; set; }
        public DateTime CreatedAt { get; set; }
        public String Categoria { get; set; }    
    }
}
