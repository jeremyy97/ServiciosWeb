using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace B_Cientificas
{
    public class NivelAcademicoLogica
    {
        public int NivelAcademico_id { set; get; }
        public string Nombre { set; get; }
        public string Detalle { set; get; }
        public string Completo { set; get; }

        SqlConnection cnn;
        string error;
        int numeroError;
        string sql;
        DataSet ds;

        public DataSet CargarNivelesAcademicos()
        {
            cnn = DAL.DAL.trae_conexion("BDConnectionString", ref error, ref numeroError);
            if (cnn == null)
            {
                //insertar en la table de errores
                HttpContext.Current.Response.Redirect("Error.aspx?error=" + numeroError.ToString() + "&men=" + error);
                return null;
            }
            else
            {
                sql = "sp_Lista_NivelAcademico";
                ParamStruct[] parametros = new ParamStruct[1];
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@Password", SqlDbType.VarChar, "password");
                ds = DAL.DAL.ejecuta_dataset(cnn, sql, true, parametros, ref error, ref numeroError);
                if (numeroError != 0)
                {
                    //insertar en la table de errores
                    HttpContext.Current.Response.Redirect("Error.aspx?error=" + numeroError.ToString() + "&men=" + error);
                    return null;
                }
                else
                {
                    ds.Tables[0].Columns[0].ColumnName = "Nivel Academico";
                    ds.Tables[0].Columns[1].ColumnName = "Nombre";
                    ds.Tables[0].Columns[2].ColumnName = "Detalle";
                    return ds;
                }
            }
        }
    }
}