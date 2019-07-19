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
    public class ConsecutivoLogica
    {
        #region Propiedades
        public int Consecutivo_id { set; get; }
        public string Nombre { set; get; }
        public string Consecutivo { set; get; }
        public string PoseePrefijo { set; get; }
        public string Prefijo { set; get; }
        public string PoseeRango { set; get; }
        public string Inicio { set; get; }
        public string Fin { set; get; }
        public int TipoConsecutivo_Id { set;get; }
        #endregion

        SqlConnection cnn;
        string error;
        int numeroError;
        string sql;
        DataSet ds;

        #region metodos
        public DataSet CargarConsecutivos()
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
                sql = "sp_Lista_Consecutivo";
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
                    ds.Tables[0].Columns[1].ColumnName = "Descripcion";
                    ds.Tables[0].Columns[2].ColumnName = "Consecutivo";
                    return ds;
                }
            }
        }

        public  ConsecutivoLogica BuscarConsecutivo(int consecutivoID)
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
                sql = "sp_Carga_Consecutivo";
                ParamStruct[] parametros = new ParamStruct[2];
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@Consecutivo_id", SqlDbType.Int, consecutivoID);
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
                    ConsecutivoLogica consecutivo = new ConsecutivoLogica();
                    consecutivo.Consecutivo_id = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
                    consecutivo.Nombre = ds.Tables[0].Rows[0][1].ToString();
                    consecutivo.Consecutivo = ds.Tables[0].Rows[0][2].ToString();
                    consecutivo.PoseePrefijo = ds.Tables[0].Rows[0][3].ToString();
                    consecutivo.Prefijo = ds.Tables[0].Rows[0][4].ToString();
                    consecutivo.PoseeRango = ds.Tables[0].Rows[0][5].ToString();
                    consecutivo.Inicio = ds.Tables[0].Rows[0][6].ToString();
                    consecutivo.Fin = ds.Tables[0].Rows[0][7].ToString();
                    consecutivo.TipoConsecutivo_Id = Convert.ToInt32(ds.Tables[0].Rows[0][8].ToString());
                    return consecutivo;
                }
            }
        }

        public Boolean ActualizarConsecutivo(ConsecutivoLogica consecutivo)
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
                sql = "sp_Actualiza_Consecutivo";
                ParamStruct[] parametros = new ParamStruct[10];
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@Consecutivo_id", SqlDbType.Int, consecutivo.Consecutivo_id);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@nombre", SqlDbType.VarChar, consecutivo.Nombre);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 2, "@Consecutivo", SqlDbType.VarChar, consecutivo.Consecutivo);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 3, "@PoseePrefijo", SqlDbType.VarChar, consecutivo.PoseePrefijo);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 4, "@Prefijo", SqlDbType.VarChar, consecutivo.Prefijo);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 5, "@PoseeRanGO", SqlDbType.VarChar, consecutivo.PoseeRango);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 6, "@Inicio", SqlDbType.VarChar, consecutivo.Inicio);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 7, "@Fin", SqlDbType.VarChar, consecutivo.Fin);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 8, "@TipoConsecutivo_Id", SqlDbType.Int, consecutivo.TipoConsecutivo_Id);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 9, "@Password", SqlDbType.VarChar, "password");
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

        public Boolean InsertarConsecutivo(ConsecutivoLogica consecutivo)
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
                sql = "sp_Inserta_Consecutivo";
                ParamStruct[] parametros = new ParamStruct[10];
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@Consecutivo_id", SqlDbType.Int, consecutivo.Consecutivo_id);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@nombre", SqlDbType.VarChar, consecutivo.Nombre);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 2, "@Consecutivo", SqlDbType.VarChar, consecutivo.Consecutivo);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 3, "@PoseePrefijo", SqlDbType.VarChar, consecutivo.PoseePrefijo);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 4, "@Prefijo", SqlDbType.VarChar, consecutivo.Prefijo);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 5, "@PoseeRanGO", SqlDbType.VarChar, consecutivo.PoseeRango);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 6, "@Inicio", SqlDbType.VarChar, consecutivo.Inicio);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 7, "@Fin", SqlDbType.VarChar, consecutivo.Fin);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 8, "@TipoConsecutivo_Id", SqlDbType.Int, consecutivo.TipoConsecutivo_Id);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 9, "@Password", SqlDbType.VarChar, "password");
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
