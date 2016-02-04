using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog.Librerias.Entidades;
using Blog.Librerias.ReglasNegocio;

namespace BlotSite_Admin.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/

        public ActionResult Login()
        {

            return View();
        }

        //public string Validar(string usuario, string clave)
        //{
        //    string rpta = "";
        //    brUsuario obrUsuario = new brUsuario();
        //    beCliente obeCliente = obrUsuario.ValidarLogin(usuario, clave);
        //    if (obeCliente != null)
        //    {
        //        Session["Usuario"] = obeCliente;
        //        rpta = "Bienvenido " + obeCliente.Nombre;
        //    }
        //    else rpta = "Login invalido. Intenta de nuevo";
        //    return rpta;
        //}

    }
}
