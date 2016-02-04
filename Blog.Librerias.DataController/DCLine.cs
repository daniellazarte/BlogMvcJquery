using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Blog.Librerias.Entidades;
using System.Data.Common;

namespace Blog.Librerias.DataController
{
    public class DCLine
    {
        public List<BELine>ListaLineas(SqlConnection con)
        {
            List<BELine> lbeLine = null;
            SqlCommand cmd = new SqlCommand("USP_LineList", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);

            if (drd != null)
            {
                lbeLine = new List<BELine>();
                BELine obeLine;
                while(drd.Read())
                {
                    obeLine = new BELine();
                    obeLine.idLine = drd.GetInt32(0);
                    obeLine.Titulo = drd.GetString(1);
                    obeLine.Descripcion = drd.GetString(2);
                    obeLine.Estado = drd.GetInt32(3);
                    obeLine.imgPortada = drd.GetString(4);
                    obeLine.Creador = drd.GetString(5);
                    obeLine.FechaCreacion= drd.GetDateTime(6);
                    obeLine.Modificador= drd.GetString(7);
                    obeLine.FechaModificacion = drd.GetDateTime(8);

                    lbeLine.Add(obeLine);

                }
                drd.Close();
            }

            return lbeLine;
        }

        public BELine GetLineabyId(SqlConnection con, int idLine)
        {
            BELine obeLine = new BELine();
            SqlCommand cmd = new SqlCommand("USP_GetLineabyId", con);
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
                while (drd.Read())
                {
                    //obeLine.idLine = drd.GetInt32(0);
                    //obeLine.Titulo = drd.GetString(1);
                    //obeLine.Descripcion = drd.GetString(2);
                    //obeLine.Estado = drd.GetInt32(3);
                    //obeLine.imgPortada =  Convert.ToString(drd["imgPortada"]);
                    //obeLine.Creador = drd.GetString(5);
                    //obeLine.FechaCreacion = drd.GetDateTime(6);
                    //obeLine.Modificador = drd.GetString(7);
                    //if (!drd.IsDBNull(8)) { obeLine.FechaModificacion = drd.GetDateTime(8); };

                    if (!drd.IsDBNull(0)) { obeLine.idLine = drd.GetInt32(0); };
                    if (!drd.IsDBNull(1)) { obeLine.Titulo = drd.GetString(1); };
                    if (!drd.IsDBNull(2)) { obeLine.Descripcion = drd.GetString(2); };
                    if (!drd.IsDBNull(3)) { obeLine.Estado= drd.GetInt32(3); };
                    if (!drd.IsDBNull(4)) { obeLine.imgPortada = drd.GetString(4); };
                    if (!drd.IsDBNull(5)) { obeLine.Creador = drd.GetString(5); };
                    if (!drd.IsDBNull(6)) { obeLine.FechaCreacion = drd.GetDateTime(6); };
                    if (!drd.IsDBNull(7)) { obeLine.Modificador = drd.GetString(7); };
                    if (!drd.IsDBNull(8)) { obeLine.FechaModificacion = drd.GetDateTime(8); };

                     
                }
                drd.Close();
            }

            return obeLine;
        }

    }
}
