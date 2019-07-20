using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using DAL;

namespace BLL
{
    public class UsuarioLogica
    {
        #region propiedades
        public string Usuario_ID {set; get;}
        public string Nombre { set; get; }
        public string Primer_Apellido { set; get; }
        public string Segundo_Apellido { set; get; }
        public string Celular { set; get; }
        public string UrlFirma { set; get; }
        public string UrlFoto { set; get; }
        public string Usuario { set; get; }
        public string Password { set; get; }
        public string Puesto_Id { set; get; }
        public string Nivel_Academico { set; get; }
        #endregion

        SqlConnection cnn;
        string error;
        int numeroError;
        string sql;
        DataSet ds;
        #region metodos

        //LOGIN
        public Boolean Login(string usuario, string password)   
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
                sql = "sp_Login";
                ParamStruct[] parametros = new ParamStruct[2];
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@Password", SqlDbType.VarChar, "password");
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@Usuario", SqlDbType.VarChar, usuario);
                ds = DAL.DAL.ejecuta_dataset(cnn, sql, true, parametros, ref error, ref numeroError);
                if (numeroError != 0)
                {
                    //insertar en la table de errores
                    HttpContext.Current.Response.Redirect("Error.aspx?error=" + numeroError.ToString() + "&men=" + error);
                    return false;
                }
                else
                {
                    foreach(DataTable dt in ds.Tables)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (dt.Rows[i][1].ToString() == usuario && dt.Rows[i][2].ToString() == password)
                            {
                                return true;
                            }
                        }
                    }
                    return false;
                }
            }
        }

        //LISTA
        public DataSet CargarUsuarios()
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
                sql = "sp_Lista_Usuario";
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
                    ds.Tables[0].Columns[2].ColumnName = "Primer_Apellido";
                    ds.Tables[0].Columns[3].ColumnName = "Segundo_Apellido";
                    ds.Tables[0].Columns[7].ColumnName = "Usuario";

                    return ds;


                    
                    /*return ds;*/
                }
            }
        }

        //LISTA
        public DataTable CargarUsuariosResu()
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
                sql = "sp_Lista_Usuario";
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
                    dt.Columns[0].ColumnName = "Usuario_ID";
                    dt.Columns[1].ColumnName = "Nombre";
                    dt.Columns[2].ColumnName = "Primer_Apellido";
                    dt.Columns[3].ColumnName = "Segundo_Apellido";
                    dt.Columns.RemoveAt(4);
                    dt.Columns.RemoveAt(5);
                    dt.Columns.RemoveAt(6);
                    dt.Columns.RemoveAt(4);
             

                    return dt;



                    /*return ds;*/
                }
            }
        }

        //CREAR
        public Boolean CrearUsuario(UsuarioLogica usuario)
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
                sql = "sp_Inserta_Usuario";
                ParamStruct[] parametros = new ParamStruct[12];
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@Usuario_id", SqlDbType.VarChar, usuario.Usuario_ID);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@Nombre", SqlDbType.VarChar, usuario.Nombre);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 2, "@Primer_Apellido", SqlDbType.VarChar, usuario.Primer_Apellido);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 3, "@Segundo_Apellido", SqlDbType.VarChar, usuario.Segundo_Apellido);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 4, "@Celular", SqlDbType.VarChar, usuario.Celular);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 5, "@urlFirma", SqlDbType.VarChar, usuario.UrlFirma);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 6, "@urlFoto", SqlDbType.VarChar, usuario.UrlFoto);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 7, "@Usuario", SqlDbType.VarChar, usuario.Usuario);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 8, "@Password", SqlDbType.VarChar, usuario.Password);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 9, "@Puesto_Id", SqlDbType.VarChar, usuario.Puesto_Id);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 10, "@NivelAcademico_Id", SqlDbType.VarChar, usuario.Nivel_Academico);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 11, "@PasswordE", SqlDbType.VarChar, "password");
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

        //CARGA
        public UsuarioLogica BuscarUsuario(string usuarioID)
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
                sql = "sp_Carga_Usuario";
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
                    UsuarioLogica usuario = new UsuarioLogica();
                    usuario.Usuario_ID = ds.Tables[0].Rows[0][0].ToString();
                    usuario.Nombre = ds.Tables[0].Rows[0][1].ToString();
                    usuario.Primer_Apellido = ds.Tables[0].Rows[0][2].ToString();
                    usuario.Segundo_Apellido = ds.Tables[0].Rows[0][3].ToString();
                    usuario.Celular = ds.Tables[0].Rows[0][4].ToString();
                    usuario.UrlFirma = ds.Tables[0].Rows[0][5].ToString();
                    usuario.UrlFoto = ds.Tables[0].Rows[0][6].ToString();
                    usuario.Usuario = ds.Tables[0].Rows[0][7].ToString();
                    usuario.Password = ds.Tables[0].Rows[0][8].ToString();
                    usuario.Puesto_Id = ds.Tables[0].Rows[0][9].ToString();
                    usuario.Nivel_Academico = ds.Tables[0].Rows[0][10].ToString();

                    return usuario;
                }
            }
        }

        //CREAR
        public Boolean ActualizarUsuario(UsuarioLogica usuario)
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
                sql = "sp_Actualiza_Usuario";
                ParamStruct[] parametros = new ParamStruct[12];
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@Usuario_id", SqlDbType.VarChar, usuario.Usuario_ID);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@Nombre", SqlDbType.VarChar, usuario.Nombre);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 2, "@Primer_Apellido", SqlDbType.VarChar, usuario.Primer_Apellido);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 3, "@Segundo_Apellido", SqlDbType.VarChar, usuario.Segundo_Apellido);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 4, "@Celular", SqlDbType.VarChar, usuario.Celular);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 5, "@urlFirma", SqlDbType.VarChar, usuario.UrlFirma);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 6, "@urlFoto", SqlDbType.VarChar, usuario.UrlFoto);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 7, "@Usuario", SqlDbType.VarChar, usuario.Usuario);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 8, "@Password", SqlDbType.VarChar, usuario.Password);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 9, "@Puesto_Id", SqlDbType.VarChar, usuario.Puesto_Id);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 10, "@NivelAcademico_Id", SqlDbType.VarChar, usuario.Nivel_Academico);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 11, "@PasswordE", SqlDbType.VarChar, "password");
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
