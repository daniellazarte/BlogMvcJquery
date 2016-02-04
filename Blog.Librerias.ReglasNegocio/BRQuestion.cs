using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Blog.Librerias.Entidades;
using Blog.Librerias.DataController;

namespace Blog.Librerias.ReglasNegocio
{
    public class BRQuestion : BRGeneral
    {

        public int SaveQuestion(BEQuestion Question)
        {

            DAQuestion data = new DAQuestion();
            int Resultado = 0;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    Resultado = data.SaveQuestion(con, Question);
                }
                catch (Exception ex)
                {
                    //En El Caso de Ocurrir alGun Errror Guardamos la Exepcion
                    GrabarLog(ex);
                }
            }

            return Resultado;

        }

        public List<BEQuestion> GetQuestionbyArticleId(int idArticle)
        {
            List<BEQuestion> lbeQuestion = null;

            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    DAQuestion odcQuestion = new DAQuestion();
                    lbeQuestion = odcQuestion.GetQuestionbyArticleId(con, idArticle);

                }
                catch (Exception ex)
                {
                    GrabarLog(ex);

                }
                return lbeQuestion;
            }
        }
    }
}
