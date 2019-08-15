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
    public class TarjetasLogica
    {
        #region Props

        public int TarjetaCredito_id { get; set; }
        public string NumeroTarjeta { get; set; }
        public string NombreTarjeta { get; set; }
        public string MesVencimiento { get; set; }
        public string AnnoVencimiento { get; set; }
        public string CVV { get; set; }
        public int TipoTarjeta_Id { get; set; }
        public string DebitoCredito { get; set; }
        public string Saldo { get; set; }
        public string Limite { get; set; }
        
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
        public int BuscarIDTarjeta(string numTarjeta)
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
                sql = "sp_Lista_TarjetaCredito";
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
                    List<TarjetasLogica> lista = ds.Tables[0].ToList<TarjetasLogica>();

                    foreach (var tarjeta in lista)
                    {
                        if (numTarjeta.Equals(tarjeta.NumeroTarjeta))
                        {
                            return tarjeta.TarjetaCredito_id;
                        } 
                    }

                    return 0;
                }
            }
        }

        public List<TarjetasLogica> CargarTarjetasXCliente(string clienteid)
        {
            cnn = DAL.DAL.trae_conexion("BDClienteConnectionString", ref error, ref numeroError);
            if (cnn == null)
            {
                //insertar en la table de errores
                HttpContext.Current.Response.Redirect("Error.aspx?error=" + numeroError.ToString() + "&men=" + error);
                return null;
            }
            else
            {
                sql = "sp_Carga_TarjetaCreditoXCliente";
                ParamStruct[] parametros = new ParamStruct[2];
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@Password", SqlDbType.VarChar, "password");
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@Cliente_Id", SqlDbType.VarChar, clienteid);
                ds = DAL.DAL.ejecuta_dataset(cnn, sql, true, parametros, ref error, ref numeroError);
                if (numeroError != 0)
                {
                    //insertar en la table de errores
                    HttpContext.Current.Response.Redirect("Error.aspx?error=" + numeroError.ToString() + "&men=" + error);
                    return null;
                }
                else
                {
                   /* DataTable dt = new DataTable();
                    dt = ds.Tables[0];
                    dt.Columns[0].ColumnName = "TarjetaCredito_id";
                    dt.Columns[1].ColumnName = "NumeroTarjeta";
                    dt.Columns[2].ColumnName = "NombreTarjeta";
                    dt.Columns[3].ColumnName = "MesVencimiento";
                    dt.Columns[4].ColumnName = "AnnoVencimiento";
                    dt.Columns[5].ColumnName = "CVV";
                    dt.Columns[6].ColumnName = "TipoTarjeta_id";
                    dt.Columns[7].ColumnName = "DebitoCredito";
                    dt.Columns[8].ColumnName = "Saldo";
                    dt.Columns[9].ColumnName = "Limite";
                    */

                    List<TarjetasLogica> lista = ds.Tables[0].ToList<TarjetasLogica>();                  

                    foreach (var t in lista)
                    {
                        StringBuilder duplicado = new StringBuilder(t.NumeroTarjeta);
                        int tam = duplicado.Length;
                        if (tam == 15)
                        {
                            duplicado.Remove(0, 11);
                            duplicado.Insert(0, "XXXXXXXXXXX");
                        }
                        if (tam == 16)
                        {
                            duplicado.Remove(0, 12);
                            duplicado.Insert(0, "XXXXXXXXXXXX");
                        }
                        t.NumeroTarjeta = duplicado.ToString();


                    }

                    return lista;
                }
            }
        }

        //INSERTAR
        public Boolean CrearTarjeta(TarjetasLogica tarjeta)
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
                sql = "sp_Inserta_TarjetaCredito";
                ParamStruct[] parametros = new ParamStruct[10];
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@NumeroTarjeta", SqlDbType.VarChar, tarjeta.NumeroTarjeta);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@NombreTarjeta", SqlDbType.VarChar, tarjeta.NombreTarjeta);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 2, "@MesVencimiento", SqlDbType.VarChar, tarjeta.MesVencimiento);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 3, "@AnnoVencimiento", SqlDbType.VarChar, tarjeta.AnnoVencimiento);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 4, "@CVV", SqlDbType.VarChar, tarjeta.CVV);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 5, "@TipoTarjeta_Id", SqlDbType.Int, tarjeta.TipoTarjeta_Id);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 6, "@DebitoCredito", SqlDbType.VarChar, tarjeta.DebitoCredito);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 7, "@Saldo", SqlDbType.VarChar, tarjeta.Saldo);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 8, "@Limite", SqlDbType.VarChar, tarjeta.Limite);
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

        //ELIMINAR
        public Boolean EliminarTarjeta(int tarjeta_id)
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
                sql = "sp_Elimina_TarjetaCredio";
                ParamStruct[] parametros = new ParamStruct[1];
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@TarjetaCredito_id", SqlDbType.Int, tarjeta_id);
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

        //ACTUALIZAR
        public Boolean ActualizarTarjeta(TarjetasLogica tarjeta)
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
                sql = "sp_Actualiza_TarjetaCredito";
                ParamStruct[] parametros = new ParamStruct[11];
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@TarjetaCredito_Id", SqlDbType.Int, tarjeta.TarjetaCredito_id);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@NumeroTarjeta", SqlDbType.VarChar, tarjeta.NumeroTarjeta);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 2, "@NombreTarjeta", SqlDbType.VarChar, tarjeta.NombreTarjeta);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 3, "@MesVencimiento", SqlDbType.VarChar, tarjeta.MesVencimiento);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 4, "@AnnoVencimiento", SqlDbType.VarChar, tarjeta.AnnoVencimiento);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 5, "@CVV", SqlDbType.VarChar, tarjeta.CVV);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 6, "@TipoTarjeta_Id", SqlDbType.Int, tarjeta.TipoTarjeta_Id);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 7, "@DebitoCredito", SqlDbType.VarChar, tarjeta.DebitoCredito);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 8, "@Saldo", SqlDbType.VarChar, tarjeta.Saldo);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 9, "@Limite", SqlDbType.VarChar, tarjeta.Limite);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 10, "@Password", SqlDbType.VarChar, "password");
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

        //BUSCAR

        public TarjetasLogica CargarTarjeta(int tarjeta_id)
        {
            cnn = DAL.DAL.trae_conexion("BDClienteConnectionString", ref error, ref numeroError);
            if (cnn == null)
            {
                //insertar en la table de errores
                HttpContext.Current.Response.Redirect("Error.aspx?error=" + numeroError.ToString() + "&men=" + error);
                return null;
            }
            else
            {
                sql = "sp_Carga_TarjetaCredito";
                ParamStruct[] parametros = new ParamStruct[2];
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@Password", SqlDbType.VarChar, "password");
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@TarjetaCredito_id", SqlDbType.Int, tarjeta_id);
                ds = DAL.DAL.ejecuta_dataset(cnn, sql, true, parametros, ref error, ref numeroError);
                if (numeroError != 0)
                {
                    //insertar en la table de errores
                    HttpContext.Current.Response.Redirect("Error.aspx?error=" + numeroError.ToString() + "&men=" + error);
                    return null;
                }
                else
                {
                    TarjetasLogica tarjeta = new TarjetasLogica();
                    tarjeta.TarjetaCredito_id = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                    tarjeta.NumeroTarjeta = ds.Tables[0].Rows[0][1].ToString();
                    tarjeta.NombreTarjeta = ds.Tables[0].Rows[0][2].ToString();
                    tarjeta.MesVencimiento = ds.Tables[0].Rows[0][3].ToString();
                    tarjeta.AnnoVencimiento = ds.Tables[0].Rows[0][4].ToString();
                    tarjeta.CVV = ds.Tables[0].Rows[0][5].ToString();
                    tarjeta.TipoTarjeta_Id = Convert.ToInt32(ds.Tables[0].Rows[0][6]);
                    tarjeta.DebitoCredito = ds.Tables[0].Rows[0][7].ToString();
                    tarjeta.Saldo = ds.Tables[0].Rows[0][8].ToString();
                    tarjeta.Limite = ds.Tables[0].Rows[0][9].ToString();
                    return tarjeta;
                }
            }
        }

        #endregion

    }
}
