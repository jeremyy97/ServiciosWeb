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
    public class BitacoraLogica
    {
        #region propiedades
        public string Bitacora_id { set; get; }
        public DateTime Fecha { set; get; }
        public string Tipo { set; get; }
        public string Descripcion {set;get;}
		public string RegistroDetallado { set; get; }
	    public string Usuario_Id { set; get; }
        #endregion

        SqlConnection cnn;
        string error;
        int numeroError;
        string sql;
        DataSet ds;

        #region metodos
        public DataTable CargarBitacora(string usuario, string fechaInicio, string fechaFinal, string tipo)
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
                sql = "sp_Lista_Bitacora";
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
                    ds.Tables[0].Columns[1].ColumnName = "Fecha y hora";
                    DataTable dt = new DataTable();
                    dt = ds.Tables[0];
                    DataTable resultados = new DataTable();
                    resultados.Columns.Add("Codigo");
                    resultados.Columns.Add("Fecha y hora");
                    resultados.Columns.Add("Tipo");
                    resultados.Columns.Add("Descripcion");
                    resultados.Columns.Add("Detalle");
                    resultados.Columns.Add("Usuario");
                    foreach (DataRow row in dt.Rows)
                    {
                        if(usuario != "" && fechaInicio != "" && fechaFinal != "")
                        {
                            if (row[5].ToString() == usuario && 
                                Convert.ToInt32(row[1].ToString()) >= Convert.ToInt32(fechaInicio) &&
                                Convert.ToInt32(row[1].ToString()) <= Convert.ToInt32(fechaFinal)) 
                            {
                                if(tipo == "Todas")
                                {
                                    resultados.Rows.Add(row.ItemArray);
                                }
                                else
                                {
                                    if (row[2].ToString() == tipo)
                                    {
                                        resultados.Rows.Add(row.ItemArray);
                                    }
                                }
                            }
                        }
                        else if(fechaInicio != "" && fechaFinal != "")
                        {
                            if (Convert.ToDateTime(row[1].ToString()) >= Convert.ToDateTime(fechaInicio) &&
                                Convert.ToDateTime(row[1].ToString()) <= Convert.ToDateTime(fechaFinal))
                            {
                                if (tipo == "Todas")
                                {
                                    resultados.Rows.Add(row.ItemArray);
                                }
                                else
                                {
                                    if (row[2].ToString() == tipo)
                                    {
                                        resultados.Rows.Add(row.ItemArray);
                                    }
                                }
                            }
                        }
                        else if(usuario != "")
                        {
                            if (row[5].ToString() == usuario)
                            {
                                if (tipo == "Todas")
                                {
                                    resultados.Rows.Add(row.ItemArray);
                                }
                                else
                                {
                                    if (row[2].ToString() == tipo)
                                    {
                                        resultados.Rows.Add(row.ItemArray);
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (tipo == "Todas")
                            {
                                resultados.Rows.Add(row.ItemArray);
                            }
                            else
                            {
                                if (row[2].ToString() == tipo)
                                {
                                    resultados.Rows.Add(row.ItemArray);
                                }
                            }
                        }
                       
                    }
                    resultados.Columns.RemoveAt(2);
                    resultados.Columns.RemoveAt(3);
                    resultados.Columns.RemoveAt(3);
                    return resultados;
                }
            }
        }

        public BitacoraLogica BuscarRegistroBitacora(string id)
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
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@Password", SqlDbType.VarChar, "password");
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@Bitacora_id", SqlDbType.VarChar, id);
                ds = DAL.DAL.ejecuta_dataset(cnn, sql, true, parametros, ref error, ref numeroError);
                if (numeroError != 0)
                {
                    //insertar en la table de errores
                    HttpContext.Current.Response.Redirect("Error.aspx?error=" + numeroError.ToString() + "&men=" + error);
                    return null;
                }
                else
                {
                    BitacoraLogica bitacora = new BitacoraLogica();
                    bitacora.Bitacora_id = ds.Tables[0].Rows[0][0].ToString();
                    bitacora.Fecha = Convert.ToDateTime(ds.Tables[0].Rows[0][1].ToString());
                    bitacora.Descripcion = ds.Tables[0].Rows[0][2].ToString();
                    return bitacora;
                }
            }
        }

        public Boolean InsertarRegistroBitacora(BitacoraLogica bitacora)
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
                sql = "sp_Inserta_Bitacora";
                ParamStruct[] parametros = new ParamStruct[7];
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@Bitacora_id", SqlDbType.VarChar, bitacora.Bitacora_id);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@Fecha", SqlDbType.DateTime, bitacora.Fecha);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 2, "@Tipo", SqlDbType.VarChar, bitacora.Tipo);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 3, "@Descripcion", SqlDbType.VarChar, bitacora.Descripcion);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 4, "@RegistroDetallado", SqlDbType.VarChar, bitacora.RegistroDetallado);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 5, "@Usuario_Id", SqlDbType.VarChar, bitacora.Usuario_Id);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 6, "@Password", SqlDbType.VarChar, "password");
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
