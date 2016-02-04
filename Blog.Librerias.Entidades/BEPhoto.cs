using System;

namespace Blog.Librerias.Entidades
{
    public class BEPhoto
    {
        public int idPhoto{ get; set; }
        public int idLine { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Archivo { get; set; }
        public string Thumbnail { get; set; }
        public string Estension { get; set; }
        public int Estado { get; set; }

        //ATRIBUTOS DE CONTROL
        public string Creador { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Modificador { get; set; }
        public DateTime FechaModificacion { get; set; }
    }
}
