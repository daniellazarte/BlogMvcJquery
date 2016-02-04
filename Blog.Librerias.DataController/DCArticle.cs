using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data.Common;
using Blog.Librerias.Entidades;



namespace Blog.Librerias.DataController
{
    public class DCArticle
    {
        public List<BEArticle> GetPostArticlesByLine(SqlConnection con,int idLine)
        {
            List<BEArticle> lbeArticle = null;
            SqlCommand cmd = new SqlCommand("USP_GetArticleListByLine", con);
            cmd.CommandType = CommandType.StoredProcedure;
            //ARGUMENTOS DE PROCEDURE
            DbParameter param = cmd.CreateParameter();
            param.DbType = DbType.Int32;
            param.ParameterName = "idLine";
            param.Value = idLine;
            cmd.Parameters.Add(param);
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);

            if (drd != null)
            {
                lbeArticle = new List<BEArticle>();
                BEArticle obeArticle;
                while (drd.Read())
                {
                    obeArticle = new BEArticle();

                    if (!drd.IsDBNull(0)) { obeArticle.idArticle = drd.GetInt32(0); };
                    if (!drd.IsDBNull(1)) { obeArticle.idLine = drd.GetInt32(1); };
                    if (!drd.IsDBNull(2)) { obeArticle.Titulo= drd.GetString(2); };
                    if (!drd.IsDBNull(3)) { obeArticle.SubTitulo= drd.GetString(3); };
                    if (!drd.IsDBNull(4)) { obeArticle.Descripcion = drd.GetString(4); };
                    if (!drd.IsDBNull(5)) { obeArticle.Contenido = drd.GetString(5); };
                    if (!drd.IsDBNull(6)) { obeArticle.imgArticle= drd.GetString(6); };
                    if (!drd.IsDBNull(7)) { obeArticle.Fecha = drd.GetDateTime(7); };
                    if (!drd.IsDBNull(8)) { obeArticle.Creador= drd.GetString(8); };
                    if (!drd.IsDBNull(9)) { obeArticle.FechaCreacion= drd.GetDateTime(9); };
                    if (!drd.IsDBNull(10)) { obeArticle.Modificador= drd.GetString(10); };
                    if (!drd.IsDBNull(11)) { obeArticle.FechaModificacion = drd.GetDateTime(11); };


                    lbeArticle.Add(obeArticle);

                }
                drd.Close();
            }

            return lbeArticle;
        }

        public BEArticle GetArticlebyId(SqlConnection con, int idArticle)
        {
            BEArticle obeArticle = new BEArticle();
            SqlCommand cmd = new SqlCommand("USP_GetArticlebyId", con);
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
                
                while (drd.Read())
                {
                    obeArticle = new BEArticle();
                    if (!drd.IsDBNull(0)) { obeArticle.idArticle = drd.GetInt32(0); };
                    if (!drd.IsDBNull(1)) { obeArticle.idLine = drd.GetInt32(1); };
                    if (!drd.IsDBNull(2)) { obeArticle.Titulo = drd.GetString(2); };
                    if (!drd.IsDBNull(3)) { obeArticle.SubTitulo = drd.GetString(3); };
                    if (!drd.IsDBNull(4)) { obeArticle.Descripcion = drd.GetString(4); };
                    if (!drd.IsDBNull(5)) { obeArticle.Contenido = drd.GetString(5); };
                    if (!drd.IsDBNull(6)) { obeArticle.imgArticle = drd.GetString(6); };
                    if (!drd.IsDBNull(7)) { obeArticle.Fecha = drd.GetDateTime(7); };
                    if (!drd.IsDBNull(8)) { obeArticle.Creador = drd.GetString(8); };
                    if (!drd.IsDBNull(9)) { obeArticle.FechaCreacion = drd.GetDateTime(9); };
                    if (!drd.IsDBNull(10)) { obeArticle.Modificador = drd.GetString(10); };
                    if (!drd.IsDBNull(11)) { obeArticle.FechaModificacion = drd.GetDateTime(11); };

                   

                }
                drd.Close();
            }

            return obeArticle;
        }

        public int SaveArticle (SqlConnection con, BEArticle oArticulo)
        {
            
            using (con)
            {
                SqlCommand cmd = new SqlCommand("SPI_SaveArticle", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parm0 = new SqlParameter("@idArticle", SqlDbType.Int);
                parm0.Size = 50;
                parm0.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(parm0);

                SqlParameter parm = new SqlParameter("@idLine", SqlDbType.Int);
                parm.Value = oArticulo.idLine;
                parm.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(parm);

                SqlParameter parm2 = new SqlParameter("@titulo", SqlDbType.NVarChar);
                parm2.Value = oArticulo.Titulo;
                parm2.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(parm2);

                SqlParameter parm3 = new SqlParameter("@subTitulo", SqlDbType.NVarChar);
                parm3.Value = oArticulo.SubTitulo;
                parm3.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(parm3);
              
                SqlParameter parm4 = new SqlParameter("@Descripcion", SqlDbType.NVarChar);
                parm4.Value = oArticulo.Descripcion;
                parm4.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(parm4);

                SqlParameter parm5 = new SqlParameter("@Contenido", SqlDbType.Text);
                parm5.Value = oArticulo.Contenido;
                parm5.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(parm5);

                SqlParameter parm6 = new SqlParameter("@imgArticle", SqlDbType.NVarChar);
                parm6.Value = oArticulo.imgArticle;
                parm6.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(parm6);

                
                SqlParameter parm7 = new SqlParameter("@creador", SqlDbType.NVarChar);
                parm7.Value = oArticulo.Creador;
                parm7.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(parm7);

                SqlParameter parm8 = new SqlParameter("@Modificador", SqlDbType.NVarChar);
                parm8.Value = oArticulo.Modificador;
                parm8.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(parm8);

                SqlParameter parm9 = new SqlParameter("@dtmFechaModificacion", SqlDbType.DateTime);
                parm9.Value = oArticulo.FechaModificacion;
                parm9.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(parm9);



                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                object intIdArticle =  cmd.Parameters["@idArticle"].Value;
                return  (int)(intIdArticle);
               
            } 

            //DbParameter Param1 = BaseData.DbProvider.CreateParameter();
            //Param1.Value = oArticulo.idLine;
            //Param1.ParameterName = "@idLine";
            //Parametros.Add(Param1);

            //DbParameter Param2 = BaseData.DbProvider.CreateParameter();
            //Param2.Value = oArticulo.Titulo;
            //Param2.ParameterName = "@titulo";
            //Parametros.Add(Param2);

            //DbParameter Param3 = BaseData.DbProvider.CreateParameter();
            //Param3.Value = oArticulo.SubTitulo;
            //Param3.ParameterName = "@subTitulo";
            //Parametros.Add(Param3);

            //DbParameter Param4 = BaseData.DbProvider.CreateParameter();
            //Param4.Value = oArticulo.Descripcion;
            //Param4.ParameterName = "@Descripcion";
            //Parametros.Add(Param4);

            //DbParameter Param5 = BaseData.DbProvider.CreateParameter();
            //Param5.Value = oArticulo.Contenido;
            //Param5.ParameterName = "@Contenido";
            //Parametros.Add(Param5);

            //DbParameter Param6 = BaseData.DbProvider.CreateParameter();
            //Param6.Value = oArticulo.imgArticle;
            //Param6.ParameterName = "@imgArticle";
            //Parametros.Add(Param6);

            //DbParameter Param7 = BaseData.DbProvider.CreateParameter();
            //Param7.Value = oArticulo.Creador;
            //Param7.ParameterName = "@Creador";
            //Parametros.Add(Param7);

            //DbParameter Param8 = BaseData.DbProvider.CreateParameter();
            //Param8.Value = oArticulo.Modificador;
            //Param8.ParameterName = "@Modificador";
            //Parametros.Add(Param8);

            //DbParameter Param9 = BaseData.DbProvider.CreateParameter();
            //Param9.Value = oArticulo.FechaModificacion;
            //Param9.ParameterName = "@dtmFechaModificacion";
            //Parametros.Add(Param9);

            //return BaseData.ejecutaNonQuery("SPI_SaveArticle", Parametros);
           
        }

        public int SaveImagesToArticle(SqlConnection con, int IdArticle, string imgArticle, string Modificador)
        {

            using (con)
            {
                SqlCommand cmd = new SqlCommand("SPU_SaveImageArticle", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parm = new SqlParameter("@idArticle", SqlDbType.Int);
                parm.Size = 50;
                parm.Value = IdArticle;
                parm.Direction = ParameterDirection.InputOutput;
                cmd.Parameters.Add(parm);

                SqlParameter parm1 = new SqlParameter("@imgArticle", SqlDbType.VarChar);
                parm1.Value = imgArticle;
                parm1.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(parm1);

                SqlParameter parm2 = new SqlParameter("@Modificador", SqlDbType.VarChar);
                parm2.Value = Modificador;
                parm2.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(parm2);



                //con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                object intIdArticle = cmd.Parameters["@idArticle"].Value;
                return (int)(intIdArticle);
            }
        }

        public List<BEArticle> GetArticlesbyLinePaging(SqlConnection con, int idLine, int PageIndex, int PageSize)
        {
            List<BEArticle> lbeArticle = null;
            SqlCommand cmd = new SqlCommand("GetArticlesPaging", con);
            cmd.CommandType = CommandType.StoredProcedure;
            
            //ARGUMENTOS DE PROCEDURE
            DbParameter param = cmd.CreateParameter();
            param.DbType = DbType.Int32;
            param.ParameterName = "@PageIndex";
            param.Value = PageIndex;
            cmd.Parameters.Add(param);

            DbParameter param2 = cmd.CreateParameter();
            param2.DbType = DbType.Int32;
            param2.ParameterName = "@PageSize";
            param2.Value = PageSize;
            cmd.Parameters.Add(param2);

            DbParameter param3 = cmd.CreateParameter();
            param3.DbType = DbType.Int32;
            param3.ParameterName = "@RecordCount";
            param3.Value = 0;
            cmd.Parameters.Add(param3);

            DbParameter param4 = cmd.CreateParameter();
            param4.DbType = DbType.Int32;
            param4.ParameterName = "@idLine";
            param4.Value = idLine;
            cmd.Parameters.Add(param4);


            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);

            if (drd != null)
            {
                lbeArticle = new List<BEArticle>();
                BEArticle obeArticle;
                while (drd.Read())
                {
                    obeArticle = new BEArticle();

                    if (!drd.IsDBNull(1)) { obeArticle.idArticle = drd.GetInt32(1); };
                    if (!drd.IsDBNull(2)) { obeArticle.idLine = drd.GetInt32(2); };
                    if (!drd.IsDBNull(3)) { obeArticle.Titulo = drd.GetString(3); };
                    if (!drd.IsDBNull(4)) { obeArticle.SubTitulo = drd.GetString(4); };
                    if (!drd.IsDBNull(5)) { obeArticle.Descripcion = drd.GetString(5); };
                    if (!drd.IsDBNull(6)) { obeArticle.Contenido = drd.GetString(6); };
                    if (!drd.IsDBNull(7)) { obeArticle.imgArticle = drd.GetString(7); };
                    if (!drd.IsDBNull(8)) { obeArticle.Fecha = drd.GetDateTime(8); };
                    if (!drd.IsDBNull(9)) { obeArticle.Creador = drd.GetString(9); };
                    if (!drd.IsDBNull(10)) { obeArticle.FechaCreacion = drd.GetDateTime(10); };
                    if (!drd.IsDBNull(11)) { obeArticle.Modificador = drd.GetString(11); };
                    if (!drd.IsDBNull(12)) { obeArticle.FechaModificacion = drd.GetDateTime(12); };
                    if (!drd.IsDBNull(13)) { obeArticle.FechaString = drd.GetString(13); };


                    lbeArticle.Add(obeArticle);

                }

                drd.Close();
            }

            return lbeArticle;
        }
    }
}
