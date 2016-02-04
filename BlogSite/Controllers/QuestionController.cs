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
    public class QuestionController : Controller
    {
        //
        // GET: /Question/

        public ActionResult Question()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetReactionsbyArticle(int idArticle)
        {
                BRQuestion obrQuestion = new BRQuestion();
                List<BEQuestion> lbeQuestion = obrQuestion.GetQuestionbyArticleId(idArticle);
                return PartialView("Question", lbeQuestion);
        }


        [HttpPost]
        public ActionResult SaveQuestion(BEQuestion oQuestion)
        {
            
            int intRes = 0;
            //OBjeto a Registrar
            BRQuestion obrQuestion = new BRQuestion();
            intRes = obrQuestion.SaveQuestion(oQuestion);

            if (intRes > 0) return Json(new { idQuestion = intRes });
            else return Json(new { success = false });

        }
    }
}
