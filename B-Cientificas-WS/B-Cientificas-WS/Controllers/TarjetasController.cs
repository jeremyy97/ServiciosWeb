using ConexionBD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace B_Cientificas_WS.Controllers
{
    public class TarjetasController : ApiController
    {

        [HttpGet]
        public string GetResult(string Num_Tarjeta, string Mes_Exp, int Anno_Exp, int CVV, decimal monto, string tipo, string debitoCredito)
        {
            string resultado = String.Empty;

            using (BCientificasClienteEntities contexto = new BCientificasClienteEntities())
            {

                var tarjetas = contexto.sp_Lista_TarjetaCredito("password");

                foreach (var tarjeta in tarjetas)
                {
                    //Validacion Número
                    if (Num_Tarjeta.Equals(tarjeta.NumeroTarjeta))
                    {
                        //Validación Vencimiento
                        if (Mes_Exp.Equals(tarjeta.MesVencimiento) && Anno_Exp.ToString().Equals(tarjeta.AnnoVencimiento))
                        {
                            //Validación si ya vencio la tarjeta
                            if (Anno_Exp > DateTime.Now.Year || (Anno_Exp == DateTime.Now.Year && Mes_Exp.Equals(DateTime.Now.ToString("MM"))))
                            {
                                //Validación CVV
                                if (CVV.ToString().Equals(tarjeta.CVV))
                                {
                                    //Validacion Tipo Tarjeta y Saldo
                                    if (debitoCredito.Equals(tarjeta.DebitoCredito) && debitoCredito.Equals("Debito"))
                                    {
                                        if (monto <= Convert.ToInt32(tarjeta.Saldo))
                                        {
                                            resultado = "0";
                                            ActualizarTarjeta(tarjeta.TarjetaCredito_id,monto,tarjeta.Saldo,tarjeta.DebitoCredito);
                                            GuardarTransaccion(tarjeta.TarjetaCredito_id, resultado);
                                            break;
                                        }
                                        else
                                        {
                                            resultado = "-4";
                                            GuardarTransaccion(tarjeta.TarjetaCredito_id, resultado);
                                            break;
                                        }
                                    }


                                    if (debitoCredito.Equals(tarjeta.DebitoCredito) && debitoCredito.Equals("Credito"))
                                    {
                                        int saldoReal = Convert.ToInt32(tarjeta.Limite) - Convert.ToInt32(tarjeta.Saldo);
                                        if (monto <= saldoReal)
                                        {
                                            resultado = "0";
                                            ActualizarTarjeta(tarjeta.TarjetaCredito_id, monto, tarjeta.Saldo, tarjeta.DebitoCredito);
                                            GuardarTransaccion(tarjeta.TarjetaCredito_id, resultado);
                                            break;
                                        }
                                        else
                                        {
                                            resultado = "-4";
                                            GuardarTransaccion(tarjeta.TarjetaCredito_id, resultado);
                                            break;
                                        }
                                    }

                                }
                                else
                                {
                                    resultado = "-3";
                                    GuardarTransaccion(tarjeta.TarjetaCredito_id, resultado);
                                    break;
                                }
                            }
                            else
                            {
                                resultado = "-2";
                                GuardarTransaccion(tarjeta.TarjetaCredito_id, resultado);
                                break;
                            }
                        }
                        else
                        {
                            resultado = "-2";
                            GuardarTransaccion(tarjeta.TarjetaCredito_id, resultado);
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

        private void GuardarTransaccion(int tarjeta, string resultado)
        {
            string motivo = String.Empty;
            switch (Convert.ToInt32(resultado))
            {
                case -1:
                    motivo = "Número de Tarjeta Inválido";
                    break;
                case -2:
                    motivo = "Fecha de expiración inválida o la tarjeta expiro";
                    break;
                case -3:
                    motivo = "CVV incorrecto";
                    break;
                case -4:
                    motivo = "Fondos insuficientes";
                    break;
                case 0 :
                    motivo = "Transacción Exitosa";
                    break;
                default:
                    motivo = "Error";
                    break;
            }
            using (BCientificasClienteEntities contexto = new BCientificasClienteEntities())
            {
                var t = contexto.sp_Inserta_TransaccionTarjeta(DateTime.Now, motivo, resultado, tarjeta, "password");
            }
        }

        private void ActualizarTarjeta (int tarjetaid, decimal monto, string saldo, string debitoCredito)
        {
            using(BCientificasClienteEntities contexto = new BCientificasClienteEntities())
            {
                if (debitoCredito.Equals("Debito"))
                {
                    int saldoReal = Convert.ToInt32(saldo) - Convert.ToInt32(monto);
                    var u = contexto.sp_Actualiza_TarjetaCredito_Saldo(tarjetaid, saldoReal.ToString(), "password");
                }
                else
                {
                    int saldoReal = Convert.ToInt32(saldo) + Convert.ToInt32(monto);
                    var u = contexto.sp_Actualiza_TarjetaCredito_Saldo(tarjetaid, saldoReal.ToString(), "password");
                }
            }
        }



    }
}
