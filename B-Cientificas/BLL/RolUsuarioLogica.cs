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
    public class RolUsuarioLogica
    {
        #region PROPS

        public int Rolusuario_id { get; set; }
        public string Usuario_id { get; set; }

        #endregion

        SqlConnection cnn;
        string error;
        int numeroError;
        string sql;
        DataSet ds;

        #region Methods

        public DataSet CargarRoles(string usuarioID)
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
                sql = "sp_Carga_RolUsuario_Usuario";
                ParamStruct[] parametros = new ParamStruct[2];
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@Usuario_id", SqlDbType.VarChar, usuarioID);
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
                    ds.Tables[0].Columns[0].ColumnName = "RolUsuario_id";
                    ds.Tables[0].Columns[1].ColumnName = "Usuario_id";
                    return ds;
                }
            }
        }

        public Boolean RolAdministrador(string usuarioID)
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
                sql = "sp_Carga_RolUsuario_Usuario";
                ParamStruct[] parametros = new ParamStruct[2];
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@Usuario_id", SqlDbType.VarChar, usuarioID);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@Password", SqlDbType.VarChar, "password");
                ds = DAL.DAL.ejecuta_dataset(cnn, sql, true, parametros, ref error, ref numeroError);
                if (numeroError != 0)
                {
                    //insertar en la table de errores
                    HttpContext.Current.Response.Redirect("Error.aspx?error=" + numeroError.ToString() + "&men=" + error);
                    return false;
                }
                else
                {
                    ds.Tables[0].Columns[0].ColumnName = "RolUsuario_id";
                    ds.Tables[0].Columns[1].ColumnName = "Usuario_id";

                    List<RolUsuarioLogica> lista = ds.Tables[0].ToList<RolUsuarioLogica>();

                    foreach (var roles in lista)
                    {
                        if (roles.Rolusuario_id == 1)
                        {
                            return true;
                        }
                    }

                    return false;
                }
            }
        }

        public Boolean RolSeguridad(string usuarioID)
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
                sql = "sp_Carga_RolUsuario_Usuario";
                ParamStruct[] parametros = new ParamStruct[2];
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@Usuario_id", SqlDbType.VarChar, usuarioID);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@Password", SqlDbType.VarChar, "password");
                ds = DAL.DAL.ejecuta_dataset(cnn, sql, true, parametros, ref error, ref numeroError);
                if (numeroError != 0)
                {
                    //insertar en la table de errores
                    HttpContext.Current.Response.Redirect("Error.aspx?error=" + numeroError.ToString() + "&men=" + error);
                    return false;
                }
                else
                {
                    ds.Tables[0].Columns[0].ColumnName = "RolUsuario_id";
                    ds.Tables[0].Columns[1].ColumnName = "Usuario_id";

                    List<RolUsuarioLogica> lista = ds.Tables[0].ToList<RolUsuarioLogica>();

                    foreach (var roles in lista)
                    {
                        if (roles.Rolusuario_id == 2)
                        {
                            return true;
                        }
                    }

                    return false;
                }
            }
        }

        public Boolean RolConsecutivos(string usuarioID)
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
                sql = "sp_Carga_RolUsuario_Usuario";
                ParamStruct[] parametros = new ParamStruct[2];
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@Usuario_id", SqlDbType.VarChar, usuarioID);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@Password", SqlDbType.VarChar, "password");
                ds = DAL.DAL.ejecuta_dataset(cnn, sql, true, parametros, ref error, ref numeroError);
                if (numeroError != 0)
                {
                    //insertar en la table de errores
                    HttpContext.Current.Response.Redirect("Error.aspx?error=" + numeroError.ToString() + "&men=" + error);
                    return false;
                }
                else
                {
                    ds.Tables[0].Columns[0].ColumnName = "RolUsuario_id";
                    ds.Tables[0].Columns[1].ColumnName = "Usuario_id";

                    List<RolUsuarioLogica> lista = ds.Tables[0].ToList<RolUsuarioLogica>();

                    foreach (var roles in lista)
                    {
                        if (roles.Rolusuario_id == 3)
                        {
                            return true;
                        }
                    }

                    return false;
                }
            }
        }

        public Boolean RolMantenimiento(string usuarioID)
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
                sql = "sp_Carga_RolUsuario_Usuario";
                ParamStruct[] parametros = new ParamStruct[2];
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@Usuario_id", SqlDbType.VarChar, usuarioID);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@Password", SqlDbType.VarChar, "password");
                ds = DAL.DAL.ejecuta_dataset(cnn, sql, true, parametros, ref error, ref numeroError);
                if (numeroError != 0)
                {
                    //insertar en la table de errores
                    HttpContext.Current.Response.Redirect("Error.aspx?error=" + numeroError.ToString() + "&men=" + error);
                    return false;
                }
                else
                {
                    ds.Tables[0].Columns[0].ColumnName = "RolUsuario_id";
                    ds.Tables[0].Columns[1].ColumnName = "Usuario_id";

                    List<RolUsuarioLogica> lista = ds.Tables[0].ToList<RolUsuarioLogica>();

                    foreach (var roles in lista)
                    {
                        if (roles.Rolusuario_id == 4)
                        {
                            return true;
                        }
                    }

                    return false;
                }
            }
        }

        public Boolean RolConsulta(string usuarioID)
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
                sql = "sp_Carga_RolUsuario_Usuario";
                ParamStruct[] parametros = new ParamStruct[2];
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@Usuario_id", SqlDbType.VarChar, usuarioID);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@Password", SqlDbType.VarChar, "password");
                ds = DAL.DAL.ejecuta_dataset(cnn, sql, true, parametros, ref error, ref numeroError);
                if (numeroError != 0)
                {
                    //insertar en la table de errores
                    HttpContext.Current.Response.Redirect("Error.aspx?error=" + numeroError.ToString() + "&men=" + error);
                    return false;
                }
                else
                {
                    ds.Tables[0].Columns[0].ColumnName = "RolUsuario_id";
                    ds.Tables[0].Columns[1].ColumnName = "Usuario_id";

                    List<RolUsuarioLogica> lista = ds.Tables[0].ToList<RolUsuarioLogica>();

                    foreach (var roles in lista)
                    {
                        if (roles.Rolusuario_id == 5)
                        {
                            return true;
                        }
                    }

                    return false;
                }
            }
        }

        //Elimina
        public Boolean EliminarRoles(string usuarioID)
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
                sql = "sp_Elimina_Roles_Usuario";
                ParamStruct[] parametros = new ParamStruct[1];
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@Usuario_id", SqlDbType.VarChar, usuarioID);
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

        //Elimina
        public Boolean InsertaRol(int rol, string usuarioID)
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
                sql = "sp_Inserta_RolUsuario_Usuarios";
                ParamStruct[] parametros = new ParamStruct[2];
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@RolUsuario_id", SqlDbType.Int, rol);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@Usuario_id", SqlDbType.VarChar, usuarioID);
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
