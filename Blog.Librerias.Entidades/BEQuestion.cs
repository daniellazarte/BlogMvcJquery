using System;


namespace Blog.Librerias.Entidades
{
    public class BEQuestion
    {
        public int idQuestion { get; set; }
        public int idArticle { get; set; }
        public string Alias { get; set; }
        public string Question { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Creador { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string Modificador { get; set; }

    }
}
