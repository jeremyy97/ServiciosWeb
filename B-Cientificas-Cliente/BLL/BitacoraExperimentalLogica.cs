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
    public class BitacoraExperimentalLogica
    {

        #region propiedades
        public string Experimento_id { set; get; }
        public string Nombre { set; get; }
        public string FechaInicio { set; get; }
        public string FechaFin { set; get; }
        public string urlMuestra1 { set; get; }
        public string urlMuestra2 { set; get; }
        public string urlMuestra3 { set; get; }
        public string urlMuestra4 { set; get; }
        public string urlMuestra5 { set; get; }
        public string Detalle1 { set; get; }
        public string Detalle2 { set; get; }
        public string Usuario_Crea { set; get; }
        public string Usuario_Testigo { set; get; }
        public string Proyecto_Id { set; get; }
        #endregion

        SqlConnection cnn;
        string error;
        int numeroError;
        string sql;
        DataSet ds;

        //CARGAR BITACORA
        public BitacoraExperimentalLogica CargarBitacora(string proyecto)
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
                sql = "sp_Carga_TarjetaCreditoXCliente";
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
                   

                    List<BitacoraExperimentalLogica> lista = ds.Tables[0].ToList<BitacoraExperimentalLogica>();

                    foreach (var bitacora in lista)
                    {
                        if (bitacora.Proyecto_Id.Equals(proyecto))
                        {
                            return bitacora;
                        }
                    }

                    return null;
                }
            }
        }





    }
}
