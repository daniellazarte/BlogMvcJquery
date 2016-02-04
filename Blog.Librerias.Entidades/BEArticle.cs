using System;
using System.Text.RegularExpressions;


namespace Blog.Librerias.Entidades
{
    public class BEArticle
    {
        public int idArticle { get; set; }
        public int idLine { get; set; }
        public string Titulo { get; set; }
        public string SubTitulo { get; set; }
        public string Descripcion { get; set; }
        public string Contenido { get; set; }
        public string imgArticle { get; set; }
        public DateTime Fecha { get; set; }
        public string Creador { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Modificador { get; set; }
        public DateTime FechaModificacion { get; set; }

        public string FechaString { get; set; }
        
        public string GenerateSlug()
        {
            string phrase = string.Format("{0}", Titulo);

            string str = RemoveAccent(phrase).ToLower();
            // invalid chars           
            str = Regex.Replace(str, @"[^a-z0-9\s-]", "");
            // convert multiple spaces into one space   
            str = Regex.Replace(str, @"\s+", " ").Trim();
            // cut and trim 
            str = str.Substring(0, str.Length <= 45 ? str.Length : 45).Trim();
            str = Regex.Replace(str, @"\s", "-"); // hyphens   
            return str;
        }

        private string RemoveAccent(string text)
        {
            byte[] bytes = System.Text.Encoding.GetEncoding("Cyrillic").GetBytes(text);
            return System.Text.Encoding.ASCII.GetString(bytes);
        }
    }


}
