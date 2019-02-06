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
using System.Web.Http.Cors;

namespace WSDeudas.Controllers
{
    [Authorize]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
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
                    respuesta.Mensaje = "El elemento <<Nombre>> no puede estar vacío.";
                else if (pIngresoRequest.Cantidad <= 0)
                    respuesta.Mensaje = "El elemento <<Cantidad>> debe ser mayor a cero.";
                else if (pIngresoRequest.IdUsuario <= 0)
                    respuesta.Mensaje = "El elemento <<IdUsuario>> debe ser mayor a cero.";
                else
                {
                    
                    var resultado = new IngresoNegocio().Agregar(new ingresos
                    {
                        cantidad_inicial = pIngresoRequest.Cantidad,
                        fecha = pIngresoRequest.Fecha,
                        nombre = pIngresoRequest.Nombre,
                        idusuario = pIngresoRequest.IdUsuario
                    });


                    if (resultado > 0)
                    {
                        respuesta.Exito = true;
                        respuesta.Mensaje = "Ingreso agregado con éxito";
                    }
                    else
                        respuesta.Mensaje = "No se pudo agregar el ingreso.";
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
        public HttpResponseMessage Consulta(int pIdIngreso)
        {
            var respuesta = new IngresoConsultaResponse { };
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
                    respuesta.Mensaje = "No se han encontrado ingresos.";
                
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
        [Route("{pIdIngreso}")]
        public HttpResponseMessage ConsultaPorId(int pIdIngreso)
        {
            var respuesta = new IngresoConsultaResponse { };
            var strMetodo = "WSDeudas - Ingresos/Consulta ";
            string sid = Guid.NewGuid().ToString();

            try
            {
                respuesta.Ingresos = new IngresoNegocio().ConsultarPorId(pIdIngreso);

                if (respuesta.Ingresos.Count > 0)
                {
                    respuesta.Exito = true;
                    respuesta.Mensaje = $"Se ha cargado el ingreso con id {pIdIngreso}";
                }
                else
                    respuesta.Mensaje = $"No existe el ingreso con id {pIdIngreso}";

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
