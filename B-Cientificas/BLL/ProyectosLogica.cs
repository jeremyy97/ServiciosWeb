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
        #region propiedades
        public string Proyecto_id { set; get; }
        public string Nombre { set; get; }
        public string RamaCientifica_Id { set; get; }
        public string Precio { set; get; }
        public string Idioma { set; get; }
        #endregion

        SqlConnection cnn;
        string error;
        int numeroError;
        string sql;
        DataSet ds;
 
        #region metodos

        public DataTable CargarProyectos()
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
                    DataTable dt = new DataTable();
                    dt = ds.Tables[0];
                    dt.Columns[0].ColumnName = "Código";
                    dt.Columns[1].ColumnName = "Nombre";
                    dt.Columns[2].ColumnName = "Rama cientifica";
                    return dt;
                }
            }
        }

        public Boolean GuardarProyecto(ProyectosLogica proyecto)
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
                sql = "sp_Inserta_Proyecto";
                ParamStruct[] parametros = new ParamStruct[6];
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@Proyecto_id", SqlDbType.VarChar, proyecto.Proyecto_id);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@Nombre", SqlDbType.VarChar, proyecto.Nombre);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 2, "@RamaCientifica_Id", SqlDbType.VarChar, proyecto.RamaCientifica_Id);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 3, "@Precio", SqlDbType.VarChar, proyecto.Precio);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 4, "@Idioma", SqlDbType.VarChar, proyecto.Idioma);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 5, "@Password", SqlDbType.VarChar, "password");
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

        public ConsecutivoLogica GenerarID()
        {
            ConsecutivoLogica consecutivoLogica = new ConsecutivoLogica();
            ConsecutivoLogica consecutivo = new ConsecutivoLogica();
            consecutivo = consecutivoLogica.BuscarConsecutivo(1);
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
                return consecutivo;
            }
        }

        public Boolean EliminarProyecto(string id)
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
                sql = "sp_Elimina_Proyecto";
                ParamStruct[] parametros = new ParamStruct[1];
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@Proyecto_id", SqlDbType.VarChar, id);
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
