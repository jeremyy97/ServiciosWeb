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
                    dt.Columns[0].ColumnName = "Código";
                    dt.Columns[1].ColumnName = "Nombre";
                    dt.Columns[2].ColumnName = "Rama cientifica";
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
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@Proyecto_id", SqlDbType.VarChar, bitacora.Experimento_id);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@Proyecto_id", SqlDbType.VarChar, bitacora.Experimento_id);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 2, "@Proyecto_id", SqlDbType.VarChar, bitacora.Experimento_id);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 3, "@Proyecto_id", SqlDbType.VarChar, bitacora.Experimento_id);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 4, "@Proyecto_id", SqlDbType.VarChar, bitacora.Experimento_id);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 5, "@Proyecto_id", SqlDbType.VarChar, bitacora.Experimento_id);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 6, "@Proyecto_id", SqlDbType.VarChar, bitacora.Experimento_id);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 7, "@Proyecto_id", SqlDbType.VarChar, bitacora.Experimento_id);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 8, "@Proyecto_id", SqlDbType.VarChar, bitacora.Experimento_id);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 9, "@Proyecto_id", SqlDbType.VarChar, bitacora.Experimento_id);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 10, "@Proyecto_id", SqlDbType.VarChar, bitacora.Experimento_id);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 11, "@Proyecto_id", SqlDbType.VarChar, bitacora.Experimento_id);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 12, "@Proyecto_id", SqlDbType.VarChar, bitacora.Experimento_id);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 13, "@Proyecto_id", SqlDbType.VarChar, bitacora.Experimento_id);
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
