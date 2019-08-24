using ConexionBD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace B_Cientificas_WS.Controllers
{
    public class EasyPayController : ApiController
    {


        [HttpGet]
        public string GetResult(int Num_Cuenta, int Codigo_Seguridad, string Contrasena, decimal monto)
        {
            string resultado = String.Empty;

            using (BCientificasClienteEntities contexto = new BCientificasClienteEntities())
            {

                var cuentas = contexto.sp_Lista_EasyPay("password");

                foreach (var cuenta in cuentas)
                {
                    //Validacion Numero Cuenta
                    if (Num_Cuenta.ToString().Equals(cuenta.Num_Cuenta))
                    {
                        ////Validación Codigo Seguridad
                        if (Codigo_Seguridad.ToString().Equals(cuenta.Codigo_Seguridad))
                        {
                            //Validación Contraseña
                            if (Contrasena.Equals(cuenta.Contrasena))
                            {
                                //Validación Monto
                                if (monto <= Convert.ToInt32(cuenta.Saldo))
                                {
                                    resultado = "0";
                                    ActualizarEasyPay(cuenta.EasyPay_Id, monto, cuenta.Saldo);
                                    GuardarTransaccion(cuenta.EasyPay_Id, resultado);
                                    break;
                                }
                                else
                                {
                                    resultado = "-4";
                                    GuardarTransaccion(cuenta.EasyPay_Id, resultado);
                                    break;
                                }

                            }
                            else
                            {
                                resultado = "-3";
                                GuardarTransaccion(cuenta.EasyPay_Id, resultado);
                                break;
                            }
                        }
                        else
                        {
                            resultado = "-2";
                            GuardarTransaccion(cuenta.EasyPay_Id, resultado);
                            break;
                        }
                    }
                    else
                    {
                        resultado = "-1";
                        
                    }
                }

                return resultado;

            }
        }


        private void GuardarTransaccion(int cuenta, string resultado)
        {
            string motivo = String.Empty;
            switch (Convert.ToInt32(resultado))
            {
                case -1:
                    motivo = "Número de Cuenta Inválido";
                    break;
                case -2:
                    motivo = "Código Seguridad Inválido";
                    break;
                case -3:
                    motivo = "Contraseña Inválida";
                    break;
                case -4:
                    motivo = "Fondos insuficientes";
                    break;
                case 0:
                    motivo = "Transacción Exitosa";
                    break;
                default:
                    motivo = "Error";
                    break;
            }
            using (BCientificasClienteEntities contexto = new BCientificasClienteEntities())
            {
                var t = contexto.sp_Inserta_TransaccionEasyPay(DateTime.Now, motivo, resultado, cuenta, "password");
            }
        }

        private void ActualizarEasyPay(int easypay, decimal monto, string saldo)
        {
            using (BCientificasClienteEntities contexto = new BCientificasClienteEntities())
            {

                    int saldoReal = Convert.ToInt32(saldo) - Convert.ToInt32(monto);
                    var u = contexto.sp_Actualiza_EasyPay_Saldo(easypay, saldoReal.ToString(), "password");

            }
        }
    }
}
