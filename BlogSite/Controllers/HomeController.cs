using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog.Librerias.Entidades;
using Blog.Librerias.ReglasNegocio;
using System.Configuration;


namespace BlogSite.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: oBTENER DEL wEBCOFING EL VALOR DE IdLine

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult getLineBlog()
        {
            string idLinea = ConfigurationManager.AppSettings["idLinea"];
            BRLine obrLine = new BRLine();
            BELine obeLine = obrLine.GetLineById(Int32.Parse(idLinea));
            return PartialView("Line", obeLine);
        }

        [HttpPost]
        public ActionResult getArticlesFromLine()
        {
            string idLinea = ConfigurationManager.AppSettings["idLinea"];
            BRArticle obrArticle = new BRArticle();
            List<BEArticle> lbeArticle = obrArticle.GetPostArticlesByLine(Int32.Parse(idLinea));
            return PartialView("Articles", lbeArticle);
        }

        
        [HttpGet]
        public ActionResult GetData(int pageIndex, int pageSize)
        {

            string idLinea = ConfigurationManager.AppSettings["idLinea"];
            BRArticle obrArticle = new BRArticle();
            List<BEArticle> lbeArticle = obrArticle.GetArticlesbyLinePaging(Int32.Parse(idLinea), pageIndex, pageSize);
            return Json(lbeArticle.ToList(), JsonRequestBehavior.AllowGet);
        }
    }
}
