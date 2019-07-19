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
        private int Usuario_ID {set; get;}
        private string Nombre { set; get; }
        private string Primer_Apellido { set; get; }
        private string Segundo_Apellido { set; get; }
        private string Celular { set; get; }
        private string UrlFirma { set; get; }
        private string UrlFoto { set; get; }
        private string Usuario { set; get; }
        private string Password { set; get; }
        private string Puesto_Id { set; get; }
        private string Nivel_Academico { set; get; }
        #endregion

        SqlConnection cnn;
        string error;
        int numeroError;
        string sql;
        DataSet ds;
        #region metodos

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
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@Usuario_id", SqlDbType.Int, usuario.Usuario_ID);
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
