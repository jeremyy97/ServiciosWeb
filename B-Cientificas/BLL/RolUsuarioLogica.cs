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
    public class RolUsuarioLogica
    {
        #region PROPS

        public int RolUsuarioID { get; set; }
        public string UsuarioID { get; set; }

        #endregion

        SqlConnection cnn;
        string error;
        int numeroError;
        string sql;
        DataSet ds;

        #region Methods

        public DataSet CargarRoles(string usuarioID)
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
                sql = "sp_Carga_RolUsuario_Usuario";
                ParamStruct[] parametros = new ParamStruct[2];
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@Usuario_id", SqlDbType.VarChar, usuarioID);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@Password", SqlDbType.VarChar, "password");
                ds = DAL.DAL.ejecuta_dataset(cnn, sql, true, parametros, ref error, ref numeroError);
                if (numeroError != 0)
                {
                    //insertar en la table de errores
                    HttpContext.Current.Response.Redirect("Error.aspx?error=" + numeroError.ToString() + "&men=" + error);
                    return null;
                }
                else
                {
                    ds.Tables[0].Columns[0].ColumnName = "RolUsuario_id";
                    ds.Tables[0].Columns[1].ColumnName = "Usuario_id";
                    return ds;
                }
            }
        }

        #endregion

    }
}
