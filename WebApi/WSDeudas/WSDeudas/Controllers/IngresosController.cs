using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WSDeudas.Exceptions;
using WSDeudas.Models.Request;
using WSDeudas.Models.Response;
using Deudas.BL;
using Deudas.DAL.Modelo;

namespace WSDeudas.Controllers
{
    [Authorize]
    [RoutePrefix("api/Ingresos")]
    public class IngresosController : ApiController
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [HttpPost]
        [Route("")]
        public HttpResponseMessage Agregar([FromBody] IngresosRequest pIngresoRequest)
        {
            var respuesta = new IngresoResponse { };
            var strMetodo = "WSDeudas - Ingresos/Agregar ";
            string sid = Guid.NewGuid().ToString();

            try
            {
                if (pIngresoRequest == null)
                    respuesta.Mensaje = "No se recibió un ingreso a registrar.";
                else if (pIngresoRequest.Nombre.Trim().Equals(""))
                    respuesta.Mensaje = "El nombre del ingreso no puede estar vacío.";
                else if (pIngresoRequest.Cantidad <= 0)
                    respuesta.Mensaje = "La cantidad del ingreso debe ser mayor a cero.";
                else
                {
                    var ingreso = new ingresos();
                    ingreso.cantidad_inicial = pIngresoRequest.Cantidad;
                    ingreso.fecha = pIngresoRequest.Fecha;
                    ingreso.nombre = pIngresoRequest.Nombre;

                    var resultado = new IngresoNegocio().Agregar(ingreso);


                    if (resultado > 0)
                    {
                        respuesta.Exito = true;
                        respuesta.Mensaje = "Ingreso agregado con éxito";
                    }
                    else
                    {
                        respuesta.Mensaje = "No se pudo agregar el ingreso.";
                    }
                }
            }
            catch (ServiceException Ex)
            {
                respuesta.CodigoError = Ex.Codigo.ToString();
                respuesta.Mensaje = Ex.Message;
            }
            catch (Exception Ex)
            {
                string strErrGUI = Guid.NewGuid().ToString();
                string strMensaje = "Error Interno del Servicio [GUID: " + strErrGUI + "].";
                log.Error("[" + strMetodo + "]" + "[SID:" + sid + "]" + strMensaje, Ex);

                respuesta.CodigoError = "10001";
                respuesta.Mensaje = "ERROR INTERNO DEL SERVICIO [" + strErrGUI + "]";
            }

            return Request.CreateResponse(HttpStatusCode.OK, respuesta);
        }

        [HttpGet]
        [Route("")]
        public HttpResponseMessage Consulta()
        {
            var respuesta = new IngresoResponse { };
            var strMetodo = "WSDeudas - Ingresos/Consulta ";
            string sid = Guid.NewGuid().ToString();

            try
            {
                
                respuesta.Ingresos = new IngresoNegocio().Consultar();

                if (respuesta.Ingresos.Count > 0)
                {
                    respuesta.Exito = true;
                    respuesta.Mensaje = "Se han cargado los ingresos";
                }
                else
                    respuesta.Mensaje = "No se han encontrado ingresos activos.";
                
            }
            catch (ServiceException Ex)
            {
                respuesta.CodigoError = Ex.Codigo.ToString();
                respuesta.Mensaje = Ex.Message;
            }
            catch (Exception Ex)
            {
                string strErrGUI = Guid.NewGuid().ToString();
                string strMensaje = "Error Interno del Servicio [GUID: " + strErrGUI + "].";
                log.Error("[" + strMetodo + "]" + "[SID:" + sid + "]" + strMensaje, Ex);

                respuesta.CodigoError = "10001";
                respuesta.Mensaje = "ERROR INTERNO DEL SERVICIO [" + strErrGUI + "]";
            }

            return Request.CreateResponse(HttpStatusCode.OK, respuesta);
        }
    }
}
