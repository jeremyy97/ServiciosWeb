using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BLL
{
    public class DescargasLogica
    {
        #region propiedades
        public int Descarga_id { set; get; }
        public DateTime Fecha {set;get;}
        public string Descripcion { set; get; }
        public string Usuario_id { set; get; }
        #endregion

        SqlConnection cnn;
        string error;
        int numeroError;
        string sql;
        DataSet ds;

        #region metodos

        public DataTable CargarDescargas(string fechaInicio, string fechaFinal)
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
                sql = "sp_Lista_Descarga";
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
                    DataTable dt = new DataTable();
                    dt = ds.Tables[0];
                    DataTable resultados = new DataTable();
                    resultados.Columns.Add("Codigo");
                    resultados.Columns.Add("Fecha y hora");
                    resultados.Columns.Add("Descripcion");
                    resultados.Columns.Add("Usuario_Id");
                    foreach (DataRow row in dt.Rows)
                    {
                        if (fechaInicio != "" && fechaFinal != "")
                        {
                            if (Convert.ToDateTime(row[1].ToString()) >= Convert.ToDateTime(fechaInicio) &&
                                Convert.ToDateTime(row[1].ToString()) <= Convert.ToDateTime(fechaFinal))
                            {
                                resultados.Rows.Add(row.ItemArray);
                            }
                        }
                        else
                        {
                            resultados.Rows.Add(row.ItemArray);

                        }
                    }
                    resultados.Columns.RemoveAt(3);
                    return resultados;
                }
            }
        }
        #endregion

    }
}
