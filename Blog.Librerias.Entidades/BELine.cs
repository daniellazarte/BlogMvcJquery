using System;

namespace Blog.Librerias.Entidades
{
    public  class BELine
    {
        public int idLine { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public int Estado { get; set; }
        public string imgPortada { get; set; }

        //ATRIBUTOS DE CONTROL
        public string Creador { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Modificador { get; set; }
        public DateTime FechaModificacion { get; set; }

    }
}
