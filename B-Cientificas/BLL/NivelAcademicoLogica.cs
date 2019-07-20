using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace B_Cientificas
{
    public class NivelAcademicoLogica
    {
        #region Props

        public string NivelAcademico_id { set; get; }
        public string Nombre { set; get; }
        public string Detalle { set; get; }
        public string Completo { set; get; }

        #endregion

        SqlConnection cnn;
        string error;
        int numeroError;
        string sql;
        DataSet ds;

        //LISTA
        public DataSet CargarNivelesAcademicos()
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
                sql = "sp_Lista_NivelAcademico";
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
                    ds.Tables[0].Columns[0].ColumnName = "Nivel Academico";
                    ds.Tables[0].Columns[1].ColumnName = "Nombre";
                    ds.Tables[0].Columns[2].ColumnName = "Detalle";
                    return ds;
                }
            }
        }

        //CARGA
        public NivelAcademicoLogica BuscarNivelAcademico(string nivelID)
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
                sql = "sp_Carga_NivelAcademico";
                ParamStruct[] parametros = new ParamStruct[2];
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@NivelAcademico_id", SqlDbType.VarChar, nivelID);
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
                    NivelAcademicoLogica nivel = new NivelAcademicoLogica();
                    nivel.NivelAcademico_id = ds.Tables[0].Rows[0][0].ToString();
                    nivel.Nombre = ds.Tables[0].Rows[0][1].ToString();
                    nivel.Detalle = ds.Tables[0].Rows[0][2].ToString();
                    nivel.Completo = ds.Tables[0].Rows[0][3].ToString();
                    return nivel;
                }
            }
        }

        //ACTUALIZA
        public Boolean ActualizarNivel(NivelAcademicoLogica nivel)
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
                sql = "sp_Actualiza_NivelAcademico";
                ParamStruct[] parametros = new ParamStruct[5];
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@NivelAcademico_id", SqlDbType.VarChar, nivel.NivelAcademico_id);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@Nombre", SqlDbType.VarChar, nivel.Nombre);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 2, "@Detalle", SqlDbType.VarChar, nivel.Detalle);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 3, "@Completo", SqlDbType.VarChar, nivel.Completo);
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


        //INSERTAR
        public Boolean InsertarNivel(NivelAcademicoLogica nivel)
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
                sql = "sp_Inserta_NivelAcademico";
                ParamStruct[] parametros = new ParamStruct[5];
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@NivelAcademico_id", SqlDbType.VarChar, nivel.NivelAcademico_id);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@Nombre", SqlDbType.VarChar, nivel.Nombre);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 2, "@Detalle", SqlDbType.VarChar, nivel.Detalle);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 3, "@Completo", SqlDbType.VarChar, nivel.Completo);
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




    }


}