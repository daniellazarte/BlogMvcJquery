using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Blog.Librerias.Entidades;
using Blog.Librerias.DataController;

namespace Blog.Librerias.ReglasNegocio
{
    public class BRLine: BRGeneral
    {
        public List<BELine>ListaLineas()
        {
            List<BELine> lbeLine = null;

            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    DCLine odcLine = new DCLine();
                    lbeLine = odcLine.ListaLineas(con);

                }
                catch (Exception ex)
                {
                    GrabarLog(ex);

                }
                return lbeLine;
            }
        }

        public BELine GetLineById(int idLine)
        {
            BELine oLine = new BELine();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    DCLine odcLine = new DCLine();
                    oLine = odcLine.GetLineabyId(con, idLine);

                }
                catch (Exception ex)
                {
                    GrabarLog(ex);

                }
                return oLine;
            }
        }
    }
}
