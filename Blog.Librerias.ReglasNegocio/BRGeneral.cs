using System;
using System.Configuration;
using Blog.Librerias.Entidades;
using General.Librerias.CodigoUsuario;
using General.Librerias.EntidadesNegocio;

namespace Blog.Librerias.ReglasNegocio
{
   public class BRGeneral
    {
         public string CadenaConexion { get; set; }
         private string rutaLog;

         public BRGeneral()
           {
             CadenaConexion = ConfigurationManager.ConnectionStrings["conBlog"].ConnectionString;
             rutaLog = ConfigurationManager.AppSettings["AppLogPath"];
           }

         public void GrabarLog(Exception ex)
         {
             BELog obeLog = new BELog();
             obeLog.MensajeError = ex.Message;
             obeLog.DetalleError = ex.StackTrace;
             string archivo = string.Format("{0}Logerror_{1}_2_{3}.txt", rutaLog, DateTime.Now.Year, DateTime.Now.Month.ToString().PadLeft(2, '0'), DateTime.Now.Day.ToString().PadLeft(2, '0'));
             ucObjeto.Grabar(obeLog, archivo);
         }
    }
}
