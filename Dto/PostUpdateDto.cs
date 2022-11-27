namespace MyBlog.Dto
{
    public class PostUpdateDto
    {
        public string Author { get; set; }
        public string Titulo { get; set; }
        public string SubTitulo { get; set; }
        public string Conteudo { get; set; }
        public DateTime CreatedAt { get; set; } =  DateTime.Now;
        public String Categoria { get; set; }
    }
}
