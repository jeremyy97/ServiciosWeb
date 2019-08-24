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
    public class BitacoraExperimentalLogica
    {
        #region propiedades
        public string Experimento_id { set; get; }
        public string Nombre { set; get; }
        public string FechaInicio { set; get; }
        public string FechaFin { set; get; }
        public string urlMuestra1 { set; get; }
        public string urlMuestra2 { set; get; }
        public string urlMuestra3 { set; get; }
        public string urlMuestra4 { set; get; }
        public string urlMuestra5 { set; get; }
        public string Detalle1 { set; get; }
        public string Detalle2 { set; get; }
        public string Usuario_Crea { set; get; }
        public string Usuario_Testigo { set; get; }
        public string Proyecto_Id { set; get; }
        #endregion

        SqlConnection cnn;
        string error;
        int numeroError;
        string sql;
        DataSet ds;

        #region metodos

        public DataTable CargarBitacora()
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
                sql = "sp_Lista_BitacoraExperimental";
                ParamStruct[] parametros = new ParamStruct[1];
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@password", SqlDbType.VarChar, "password");
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
                    dt.Columns.RemoveAt(2);
                    dt.Columns.RemoveAt(2);
                    dt.Columns.RemoveAt(2);
                    dt.Columns.RemoveAt(2);
                    dt.Columns.RemoveAt(2);
                    dt.Columns.RemoveAt(2);
                    dt.Columns.RemoveAt(2);
                    dt.Columns.RemoveAt(2);
                    dt.Columns.RemoveAt(2);
                    dt.Columns[0].ColumnName = "Código";
                    return dt;
                }
            }
        }

        public ConsecutivoLogica GenerarID()
        {
            ConsecutivoLogica consecutivoLogica = new ConsecutivoLogica();
            ConsecutivoLogica consecutivo = new ConsecutivoLogica();
            consecutivo = consecutivoLogica.BuscarConsecutivo(2);
            int codigo = Convert.ToInt32(consecutivo.Consecutivo) + 1;
            int inicio = Convert.ToInt32(consecutivo.Inicio);
            int fin = Convert.ToInt32(consecutivo.Fin);
            if (codigo > inicio && codigo <= fin)
            {
                if (Convert.ToBoolean(consecutivo.PoseePrefijo))
                {
                    consecutivo.Consecutivo = codigo.ToString();
                    return consecutivo;
                }
                else
                {
                    consecutivo.Consecutivo = codigo.ToString();
                    return consecutivo;
                }

            }
            else
            {
                return null;
            }
        }


        public Boolean CrearExperimento(BitacoraExperimentalLogica bitacora)
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
                sql = "sp_Inserta_BitacoraExperimental";
                ParamStruct[] parametros = new ParamStruct[15];
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@Experimento_id", SqlDbType.VarChar, bitacora.Experimento_id);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@Nombre", SqlDbType.VarChar, bitacora.Nombre);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 2, "@FechaInicio", SqlDbType.VarChar, bitacora.FechaInicio);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 3, "@FechaFin", SqlDbType.VarChar, bitacora.FechaFin);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 4, "@urlMuestra1", SqlDbType.VarChar, bitacora.urlMuestra1);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 5, "@urlMuestra2", SqlDbType.VarChar, bitacora.urlMuestra2);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 6, "@urlMuestra3", SqlDbType.VarChar, bitacora.urlMuestra3);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 7, "@urlMuestra4", SqlDbType.VarChar, bitacora.urlMuestra4);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 8, "@urlMuestra5", SqlDbType.VarChar, bitacora.urlMuestra5);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 9, "@Detalle1", SqlDbType.VarChar, bitacora.Detalle1);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 10, "@Detalle2", SqlDbType.VarChar, bitacora.Detalle2);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 11, "@Usuario_Crea", SqlDbType.VarChar, bitacora.Usuario_Crea);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 12, "@Usuario_Testigo", SqlDbType.VarChar, bitacora.Usuario_Testigo);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 13, "@Proyecto_Id", SqlDbType.VarChar, bitacora.Proyecto_Id);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 14, "@Password", SqlDbType.VarChar, "password");
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
