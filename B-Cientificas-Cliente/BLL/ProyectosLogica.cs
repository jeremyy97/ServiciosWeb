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
    public class ProyectosLogica
    {
        SqlConnection cnn;
        string error;
        int numeroError;
        string sql;
        DataSet ds;

        #region metodos
        public DataSet CargarProyectos()
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
                sql = "sp_Lista_Proyecto";
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
                    ds.Tables[0].Columns[0].ColumnName = "Codigo";
                    ds.Tables[0].Columns[1].ColumnName = "Nombre";
                    ds.Tables[0].Columns[5].ColumnName = "Experimentos";

                    return ds;
                }
            }
        }

        public DataTable BuscarProyectos(string rama, string precio, string nombre, string idioma)
        {
            DataTable dt;
            DataTable dtFinal = new DataTable();

            dt = CargarProyectos().Tables[0];
            dtFinal = CargarProyectos().Tables[0];
            dtFinal.Clear();

            foreach (DataRow dr in dt.Rows)
            {
                Boolean buena = true;
                if(rama != "0")
                {
                    if (dr[2].ToString() != rama)
                    {
                        buena = false;
                    }
                }
                if(precio != "")
                {
                    if (dr[3].ToString() != precio)
                    {
                        buena = false;
                    }
                }
                if (nombre != "")
                {
                    if (dr[1].ToString() != nombre)
                    {
                        buena = false;
                    }
                }
                if (idioma != "")
                {
                    if (dr[4].ToString() != idioma)
                    {
                        buena = false;
                    }
                }
                if (buena)
                {
                    dtFinal.Rows.Add(dr.ItemArray);
                    
                }


            }
            dtFinal.Columns.RemoveAt(2);
            dtFinal.Columns.RemoveAt(3);
            return dtFinal;
        }

        #endregion
    }
}
