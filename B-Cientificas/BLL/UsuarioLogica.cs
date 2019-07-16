using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using DAL;

namespace BLL
{
    public class UsuarioLogica
    {
        #region propiedades
        private int Usuario_ID {set; get;}
        private string Nombre { set; get; }
        private string Primer_Apellido { set; get; }
        private string Segundo_Apellido { set; get; }
        private string Celular { set; get; }
        private string UrlFirma { set; get; }
        private string UrlFoto { set; get; }
        private string Usuario { set; get; }
        private string Password { set; get; }
        #endregion

        SqlConnection cnn;
        string error;
        int numeroError;
        string sql;
        DataSet ds;
        #region metodos

        public Boolean Login(string usuario, string password)   
        {
            cnn = DAL.DAL.trae_conexion("BDConnectionString", ref error, ref numeroError);
            if (cnn == null)
            {
                //insertar en la table de errores
                HttpContext.Current.Response.Redirect("Error.aspx?error=" + numeroError.ToString() + "&men=" + error);
                return false;
            }
            else
            {
                sql = "sp_Login";
                ParamStruct[] parametros = new ParamStruct[2];
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@Password", SqlDbType.VarChar, "password");
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@Usuario", SqlDbType.VarChar, usuario);
                ds = DAL.DAL.ejecuta_dataset(cnn, sql, true, parametros, ref error, ref numeroError);
                if (numeroError != 0)
                {
                    //insertar en la table de errores
                    HttpContext.Current.Response.Redirect("Error.aspx?error=" + numeroError.ToString() + "&men=" + error);
                    return false;
                }
                else
                {
                    foreach(DataTable dt in ds.Tables)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (dt.Rows[i]["Usuario"].ToString() == usuario && dt.Rows[i]["Password"].ToString() == password)
                            {
                                return true;
                            }
                        }
                    }
                    return false;
                }
            }
        }

        public DataSet CargarUsuarios()
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
                sql = "sp_Lista_Usuario";
                ds = DAL.DAL.ejecuta_dataset(cnn, sql, true, ref error, ref numeroError);
                if (numeroError != 0)
                {
                    //insertar en la table de errores
                    HttpContext.Current.Response.Redirect("Error.aspx?error=" + numeroError.ToString() + "&men=" + error);
                    return null;
                }
                else
                {
                    return ds;
                }
            }

        }
        #endregion
    }
}
