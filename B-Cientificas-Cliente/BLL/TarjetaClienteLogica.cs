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
    public class TarjetaClienteLogica
    {
        #region Props

        public int TarjetaCredito_id { get; set; }
        public string Cliente_Id { get; set; }

        #endregion

        #region Var
        SqlConnection cnn;
        string error;
        int numeroError;
        string sql;
        DataSet ds;

        #endregion

        #region Methods

        

        //INSERTAR
        public Boolean CrearTarjetaCliente(string clienteid, int tarjetaid)
        {
            cnn = DAL.DAL.trae_conexion("BDClienteConnectionString", ref error, ref numeroError);
            if (cnn == null)
            {
                //insertar en la table de errores
                HttpContext.Current.Response.Redirect("Error.aspx?error=" + numeroError.ToString() + "&men=" + error);
                return false;
            }
            else
            {
                sql = "sp_Inserta_TarjetaCredito_Cliente";
                ParamStruct[] parametros = new ParamStruct[3];
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@TarjetaCredito_id", SqlDbType.Int, tarjetaid);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@Cliente_Id", SqlDbType.VarChar, clienteid);            
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

        //ELIMINAR
        public Boolean EliminarTarjetaCliente(int tarjeta_id, string clienteid)
        {
            cnn = DAL.DAL.trae_conexion("BDClienteConnectionString", ref error, ref numeroError);
            if (cnn == null)
            {
                //insertar en la table de errores
                HttpContext.Current.Response.Redirect("Error.aspx?error=" + numeroError.ToString() + "&men=" + error);
                return false;
            }
            else
            {
                sql = "sp_Elimina_TarjetaCredito_Cliente";
                ParamStruct[] parametros = new ParamStruct[2];
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@TarjetaCredito_id", SqlDbType.Int, tarjeta_id);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@Cliente_Id", SqlDbType.VarChar, clienteid);
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
