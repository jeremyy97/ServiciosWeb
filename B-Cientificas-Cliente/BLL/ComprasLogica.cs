﻿using DAL;
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
    public class ComprasLogica
    {
        SqlConnection cnn;
        string error;
        int numeroError;
        string sql;
        DataSet ds;

        #region metodos
        public DataSet CargarOrdenes()
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
                sql = "sp_Lista_Orden_Proyecto";
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
                    return ds;
                }
            }
        }

        public DataTable cargarCompras()
        {
            ProyectosLogica proyectosLogica = new ProyectosLogica();
            DataTable proyectos = proyectosLogica.BuscarProyectos("0", "", "", "");
            DataTable ordenes = CargarOrdenes().Tables[0];
            DataTable compras = new DataTable();
            DataColumn column;
            column = new DataColumn("Codigo", Type.GetType("System.String"));
            compras.Columns.Add(column);
            column = new DataColumn("Proyecto", Type.GetType("System.String"));
            compras.Columns.Add(column);
            column = new DataColumn("Precio", Type.GetType("System.String"));
            compras.Columns.Add(column);
            column = new DataColumn("Experimentos", Type.GetType("System.String"));
            compras.Columns.Add(column);
            foreach (DataRow row in ordenes.Rows)
            {
                foreach(DataRow dr in proyectos.Rows)
                {
                    if(row[1].ToString() == dr[0].ToString())
                    {
                        compras.Rows.Add(dr.ItemArray);
                    }
                }
            }
            return compras;
        }
        #endregion
    }
}