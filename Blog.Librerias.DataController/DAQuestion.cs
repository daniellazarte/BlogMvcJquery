using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data.Common;
using Blog.Librerias.Entidades;

namespace Blog.Librerias.DataController
{
    public class DAQuestion
    {
        public int SaveQuestion(SqlConnection con, BEQuestion oQuestion)
        {
            using (con)
            {
                SqlCommand cmd = new SqlCommand("SPI_SaveQuestion", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parm = new SqlParameter("@idQuestion", SqlDbType.Int);
                parm.Size = 50;
                parm.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(parm);

                SqlParameter parm1 = new SqlParameter("@idArticle", SqlDbType.Int);
                parm1.Value = oQuestion.idArticle;
                parm1.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(parm1);

                SqlParameter parm2 = new SqlParameter("@Alias", SqlDbType.NVarChar);
                parm2.Value = oQuestion.Alias;
                parm2.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(parm2);

                SqlParameter parm3 = new SqlParameter("@Question", SqlDbType.NVarChar);
                parm3.Value = oQuestion.Question;
                parm3.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(parm3);

                SqlParameter parm4 = new SqlParameter("@Creador", SqlDbType.NVarChar);
                parm4.Value = oQuestion.Creador;
                parm4.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(parm4);

                SqlParameter parm5 = new SqlParameter("@FechaModificacion", SqlDbType.DateTime);
                parm5.Value = oQuestion.FechaModificacion;
                parm5.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(parm5);

                SqlParameter parm6 = new SqlParameter("@Modificador", SqlDbType.NVarChar);
                parm6.Value = oQuestion.Modificador;
                parm6.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(parm6);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                object intIDQuestion = cmd.Parameters["@idQuestion"].Value;
                return (int)(intIDQuestion);

            }
        }

        public List<BEQuestion> GetQuestionbyArticleId(SqlConnection con, int idArticle)
        {
            List<BEQuestion> lbeQuestion = null;
            SqlCommand cmd = new SqlCommand("USP_GetQuestionbyArticleId", con);
            cmd.CommandType = CommandType.StoredProcedure;
            
            //ARGUMENTOS DE PROCEDURE
            DbParameter param = cmd.CreateParameter();
            param.DbType = DbType.Int32;
            param.ParameterName = "idArticle";
            param.Value = idArticle;
            cmd.Parameters.Add(param);

            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);

            if (drd != null)
            {
                lbeQuestion = new List<BEQuestion>();
                BEQuestion obeQuestion;
                while (drd.Read())
                {
                    obeQuestion = new BEQuestion();

                    if (!drd.IsDBNull(0)) { obeQuestion.idQuestion = drd.GetInt32(0); };
                    if (!drd.IsDBNull(1)) { obeQuestion.idArticle = drd.GetInt32(1); };
                    if (!drd.IsDBNull(2)) { obeQuestion.Alias = drd.GetString(2); };
                    if (!drd.IsDBNull(3)) { obeQuestion.Question = drd.GetString(3); };
                    if (!drd.IsDBNull(4)) { obeQuestion.FechaCreacion = drd.GetDateTime(4); };
                    if (!drd.IsDBNull(5)) { obeQuestion.Creador = drd.GetString(5); };
                    if (!drd.IsDBNull(6)) { obeQuestion.FechaModificacion = drd.GetDateTime(6); };
                    if (!drd.IsDBNull(7)) { obeQuestion.Modificador = drd.GetString(7); };
                    


                    lbeQuestion.Add(obeQuestion);

                }
                drd.Close();
            }

            return lbeQuestion;
        }
    }
}
