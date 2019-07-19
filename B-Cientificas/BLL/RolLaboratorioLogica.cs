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
    public class RolLaboratorioLogica
    {
        #region Props

        public string RolLaboratorio_id { get; set; }
        public string Nombre { get; set; }
        public string Detalle { get; set; }

        #endregion

        SqlConnection cnn;
        string error;
        int numeroError;
        string sql;
        DataSet ds;

        #region Methods

        //LISTA
        public DataSet CargasRolesLaboratorio()
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
                sql = "sp_Lista_RolLaboratorio";
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
                    ds.Tables[0].Columns[0].ColumnName = "ID";
                    ds.Tables[0].Columns[1].ColumnName = "Nombre";
                    ds.Tables[0].Columns[2].ColumnName = "Detalle";
                    return ds;
                }
            }
        }

        //CARGA
        public RolLaboratorioLogica BuscarRolLaboratorio(string rolID)
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
                sql = "sp_Carga_RolLaboratorio";
                ParamStruct[] parametros = new ParamStruct[2];
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@RolLaboratorio_id", SqlDbType.VarChar, rolID);
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
                    RolLaboratorioLogica rol = new RolLaboratorioLogica();
                    rol.RolLaboratorio_id = ds.Tables[0].Rows[0][0].ToString();
                    rol.Nombre = ds.Tables[0].Rows[0][1].ToString();
                    rol.Detalle = ds.Tables[0].Rows[0][2].ToString();
                    return rol;
                }
            }
        }

        //ACTUALIZA
        public Boolean ActualizarRolLaboratorio(RolLaboratorioLogica rol)
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
                sql = "sp_Actualiza_RolLaboratorio";
                ParamStruct[] parametros = new ParamStruct[4];
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@RolLaboratorio_id", SqlDbType.VarChar, rol.RolLaboratorio_id);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@nombre", SqlDbType.VarChar, rol.Nombre);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 2, "@detalle", SqlDbType.VarChar, rol.Detalle);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 3, "@Password", SqlDbType.VarChar, "password");
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
        public Boolean InsertarRolLaboratorio(RolLaboratorioLogica rol)
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
                sql = "sp_Inserta_RolLaboratorio";
                ParamStruct[] parametros = new ParamStruct[4];
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@RolLaboratorio_id", SqlDbType.VarChar, rol.RolLaboratorio_id);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@nombre", SqlDbType.VarChar, rol.Nombre);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@detalle", SqlDbType.VarChar, rol.Detalle);
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
