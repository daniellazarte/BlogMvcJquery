using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog.Librerias.Entidades;
using Blog.Librerias.ReglasNegocio;
using Blog.Util;
using System.Configuration;




namespace BlogSite.Controllers
{
    public class ArticleController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Posts(int id)
        {
            
            BRArticle obrArticle = new BRArticle();
            BEArticle oArticle = obrArticle.GetArticleById(id);
            return View(oArticle);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaveArticle(BEArticle oArticulo)

        {

            int intRes = 0;
            string strModificador = "AMIGO";
            string idLinea = ConfigurationManager.AppSettings["idLinea"];
            DateTime FechaRegistro = DateTime.Now;

            //OBjeto a Registrar
            BRArticle oBRArticle = new BRArticle();
            oArticulo.FechaModificacion = DateTime.Now;
            oArticulo.idLine = Int32.Parse(idLinea);
            intRes = oBRArticle.SaveArticle(oArticulo);
  
            if (intRes > 0) return Json(new { idArticle = intRes});
            else return Json(new { success = false });

        }

        //Add Images
        public ActionResult AddImages(int id)
        {
            
            return View();
        }

       [HttpPost]
        public ActionResult AddImages(int id, HttpPostedFileBase file)
        {
            int intRes = 0;
            int idArticle = id;
            string imgNameResult = "";
            foreach (string item in Request.Files)
            {
                if (file.ContentLength == 0)
                    continue;
                if (file.ContentLength > 0)
                {
                    ImageUpload imageUpload = new ImageUpload { Width = 800 };
                    ImageResult imageResult = imageUpload.RenameUploadFile(file);
                    imgNameResult = imageResult.ImageName.ToString();
                    if (imageResult.Success)
                    {

                        string strModificador = "AMIGO";
                        DateTime FechaRegistro = DateTime.Now;

                        //Guardar el Registro de la fotografía
                        BRArticle oBRArticle = new BRArticle();
                        intRes = oBRArticle.SaveImageToArticle(idArticle, imgNameResult, strModificador);
                    }
                }
            }

            return RedirectToAction("../home");
        }
    }
}
