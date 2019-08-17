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
    public class OrdenLogica
    {
        #region Props

        public int Orden_id { get; set; }
        public string Montofinal { get; set; }
        public int TarjetaCredito_id { get; set; }
        public DateTime Fecha { get; set; }
        public string Cliente_id { get; set; }

        #endregion

        #region Var
        SqlConnection cnn;
        string error;
        int numeroError;
        string sql;
        DataSet ds;

        #endregion

        #region Methods




        //LISTAR
        public int BuscarIDOrden(int tarjetaid,string monto, DateTime fecha)
        {
            cnn = DAL.DAL.trae_conexion("BDClienteConnectionString", ref error, ref numeroError);
            if (cnn == null)
            {
                //insertar en la table de errores
                HttpContext.Current.Response.Redirect("Error.aspx?error=" + numeroError.ToString() + "&men=" + error);
                return 0;
            }
            else
            {
                sql = "sp_Lista_Ordenes";
                ParamStruct[] parametros = new ParamStruct[1];
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@Password", SqlDbType.VarChar, "password");
                ds = DAL.DAL.ejecuta_dataset(cnn, sql, true, parametros, ref error, ref numeroError);
                if (numeroError != 0)
                {
                    //insertar en la table de errores
                    HttpContext.Current.Response.Redirect("Error.aspx?error=" + numeroError.ToString() + "&men=" + error);
                    return 0;
                }
                else
                {
                    List<OrdenLogica> lista = ds.Tables[0].ToList<OrdenLogica>();

                    foreach (var orden in lista)
                    {
                        if (monto.Equals(orden.Montofinal) && fecha == orden.Fecha && tarjetaid == orden.TarjetaCredito_id)
                        {
                            return orden.Orden_id;
                        }
                    }

                    return 0;
                }
            }
        }

        
        //INSERTAR
        public Boolean CrearOrden(OrdenLogica orden)
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
                sql = "sp_Inserta_Orden";
                ParamStruct[] parametros = new ParamStruct[5];
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@Montofinal", SqlDbType.VarChar, orden.Montofinal);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@Tarjetacredito_id", SqlDbType.Int, orden.TarjetaCredito_id);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 2, "@Fecha", SqlDbType.DateTime, orden.Fecha);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 3, "@Cliente_id", SqlDbType.VarChar, orden.Cliente_id);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 4, "@Password", SqlDbType.VarChar, "password");
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
