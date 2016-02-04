using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Blog.Librerias.Entidades;
using Blog.Librerias.DataController;

namespace Blog.Librerias.ReglasNegocio
{
    public class BRArticle : BRGeneral
    {
        public List<BEArticle> GetPostArticlesByLine(int idLine)
        {
            List<BEArticle> lbeArticle = null;

            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    DCArticle odcArticle = new DCArticle();
                    lbeArticle = odcArticle.GetPostArticlesByLine(con, idLine);

                }
                catch (Exception ex)
                {
                    GrabarLog(ex);

                }
                return lbeArticle;
            }
        }

        public BEArticle GetArticleById(int idArticle)
        {
            BEArticle oArticle = new BEArticle();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    DCArticle odArticle = new DCArticle();
                    oArticle = odArticle.GetArticlebyId(con, idArticle);

                }
                catch (Exception ex)
                {
                    GrabarLog(ex);

                }
                return oArticle;
            }
        }
        
        public int SaveArticle(BEArticle Articulo){

            DCArticle data = new DCArticle();
            int Resultado = 0;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    Resultado = data.SaveArticle(con,Articulo);
                }
                catch (Exception ex)
                {
                    //En El Caso de Ocurrir alGun Errror Guardamos la Exepcion
                    GrabarLog(ex);
                }
            }

            return Resultado;         

        }

        public int SaveImageToArticle(int idArticle ,string imagePath, string Modificador)
        {

            int intRes = 0;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    DCArticle odArticle = new DCArticle();
                    intRes = odArticle.SaveImagesToArticle(con,idArticle, imagePath, Modificador);

                }
                catch (Exception ex)
                {
                    GrabarLog(ex);

                }
              
            }
            return intRes;
        }

        public List<BEArticle> GetArticlesbyLinePaging(int idLine, int PageIndex, int PageSize)
        {
            List<BEArticle> lbeArticle = null;

            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    DCArticle odcArticle = new DCArticle();
                    lbeArticle = odcArticle.GetArticlesbyLinePaging(con, idLine, PageIndex, PageSize);
                }
                catch (Exception ex)
                {
                    GrabarLog(ex);
                }

                return lbeArticle;
            }
        }

    }
}
