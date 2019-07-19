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
    public class TipoConsecutivoLogica
    {

        #region Props
        public int TipoConsecutivoID { get; set; }
        public string Nombre { get; set; }
        #endregion

        SqlConnection cnn;
        string error;
        int numeroError;
        string sql;
        DataSet ds;

        #region Methods

        //LISTA
        public DataSet CargarTiposConsecutivos()
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
                sql = "sp_Lista_TipoConsecutivo";
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

                    return ds;
                }
            }
        }

        //CARGA
        public TipoConsecutivoLogica BuscarTipoConsecutivo(int consecutivoID)
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
                sql = "sp_Carga_TipoConsecutivo";
                ParamStruct[] parametros = new ParamStruct[2];
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@TipoConsecutivo_id", SqlDbType.Int, consecutivoID);
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
                    TipoConsecutivoLogica tipoConsecutivo = new TipoConsecutivoLogica();
                    tipoConsecutivo.TipoConsecutivoID = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
                    tipoConsecutivo.Nombre = ds.Tables[0].Rows[0][1].ToString();
                    return tipoConsecutivo;
                }
            }
        }

        //ACTUALIZA
        public Boolean ActualizarTipoConsecutivo(TipoConsecutivoLogica tipoConsecutivo)
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
                sql = "sp_Actualiza_TipoConsecutivo";
                ParamStruct[] parametros = new ParamStruct[3];
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@TipoConsecutivo_id", SqlDbType.Int, tipoConsecutivo.TipoConsecutivoID);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@nombre", SqlDbType.VarChar, tipoConsecutivo.Nombre);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 2, "@Password", SqlDbType.VarChar, "password");
                DAL.DAL.conectar(cnn, ref error, ref numeroError);
                DAL.DAL.ejecuta_sqlcommand(cnn, sql, true, parametros, ref error, ref numeroError);
                if (numeroError != 0)
                {
                    //insertar en la table de errores
                    HttpContext.Current.Response.Redirect("Error.aspx?error=" + numeroError.ToString() + "&men=" + error);
                    DAL.DAL.desconectar(cnn, ref error, ref numeroError);
                    return false;
                }
                else
                {
                    DAL.DAL.desconectar(cnn, ref error, ref numeroError);
                    return true;
                }
            }
        }

        //INSERTA
        public Boolean InsertarTipoConsecutivo(TipoConsecutivoLogica tipoConsecutivo)
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
                sql = "sp_Inserta_TipoConsecutivo";
                ParamStruct[] parametros = new ParamStruct[3];
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@TipoConsecutivo_id", SqlDbType.Int, tipoConsecutivo.TipoConsecutivoID);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@nombre", SqlDbType.VarChar, tipoConsecutivo.Nombre);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 2, "@Password", SqlDbType.VarChar, "password");
                DAL.DAL.conectar(cnn, ref error, ref numeroError);
                DAL.DAL.ejecuta_sqlcommand(cnn, sql, true, parametros, ref error, ref numeroError);
                if (numeroError != 0)
                {
                    //insertar en la table de errores
                    HttpContext.Current.Response.Redirect("Error.aspx?error=" + numeroError.ToString() + "&men=" + error);
                    DAL.DAL.desconectar(cnn, ref error, ref numeroError);
                    return false;
                }
                else
                {
                    DAL.DAL.desconectar(cnn, ref error, ref numeroError);
                    return true;
                }
            }
        }

        #endregion

    }
}
