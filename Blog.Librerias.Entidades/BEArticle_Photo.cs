using System;

namespace Blog.Librerias.Entidades
{
    public class BEArticle_Photo
    {
        public int Identifier { get; set; }
        public int idArticle { get; set; }
        public int IdPhoto { get; set; }
        public string Descripcion { get; set; }

        //ATRIBUTOS DE CONTROL
        public string Creador { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Modificador { get; set; }
        public DateTime FechaModificacion { get; set; }
    }
}
