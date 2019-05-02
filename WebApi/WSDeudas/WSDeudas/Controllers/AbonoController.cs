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
    //[Authorize]
    [AllowAnonymous]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/Abono")]
    public class AbonoController : ApiController
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [HttpPost]
        [Route("")]
        public HttpResponseMessage Agregar([FromBody] AbonoRequest pAbonoRequest)
        {
            var respuesta = new DeudaConsultaResponse { };
            var strMetodo = "WSDeudas - Abono/Agregar ";
            string sid = Guid.NewGuid().ToString();

            try
            {
                if (pAbonoRequest == null)
                    respuesta.Mensaje = "No se recibió ninguna abono a registrar.";
                else if (pAbonoRequest.IdDeuda<= 0)
                    respuesta.Mensaje = "El elemento  <<IdDeuda>> debe ser mayor a cero.";
                else if (pAbonoRequest.IdIngreso <= 0)
                    respuesta.Mensaje = "Debe especificar el <<IdIngreso>> al que se afectará.";
                else if (pAbonoRequest.Cantidad <= 0)
                    respuesta.Mensaje = "El elemento <<Cantidad>> debe ser mayor a cero.";
                else if (pAbonoRequest.IdUsuario <= 0)
                    respuesta.Mensaje = "El elemento <<IdUsuario>> debe especificar el usuario al que se le asignará la deuda.";
                else
                {
                    var resultado = new AbonoNegocio().Agregar(new abonos_deuda
                    {
                        idingreso = pAbonoRequest.IdIngreso,
                        idusuario = pAbonoRequest.IdUsuario,
                        iddeuda = pAbonoRequest.IdDeuda,
                        cantidad = pAbonoRequest.Cantidad
                    });

                    if (resultado.RET_NUMEROERROR == 0)
                    {
                        respuesta.Exito = true;
                        respuesta.Mensaje = resultado.RET_VALORDEVUELTO;
                    }
                    else
                    {
                        respuesta.Mensaje = resultado.RET_VALORDEVUELTO;
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

        //[HttpGet]
        //[Route("")]
        //public HttpResponseMessage Consulta()
        //{
        //    var respuesta = new DeudaConsultaResponse { };
        //    var strMetodo = "WSDeudas - Deudas/Consulta ";
        //    string sid = Guid.NewGuid().ToString();

        //    try
        //    {

        //        respuesta.Deudas = new DeudaNegocio().Consultar();

        //        if (respuesta.Deudas.Count > 0)
        //        {
        //            respuesta.Exito = true;
        //            respuesta.Mensaje = "Se han cargado las deudas con éxito";
        //        }
        //        else
        //            respuesta.Mensaje = "No se han encontrado deudas.";

        //    }
        //    catch (ServiceException Ex)
        //    {
        //        respuesta.CodigoError = Ex.Codigo.ToString();
        //        respuesta.Mensaje = Ex.Message;
        //    }
        //    catch (Exception Ex)
        //    {
        //        string strErrGUI = Guid.NewGuid().ToString();
        //        string strMensaje = "Error Interno del Servicio [GUID: " + strErrGUI + "].";
        //        log.Error("[" + strMetodo + "]" + "[SID:" + sid + "]" + strMensaje, Ex);

        //        respuesta.CodigoError = "10001";
        //        respuesta.Mensaje = "ERROR INTERNO DEL SERVICIO [" + strErrGUI + "]";
        //    }

        //    return Request.CreateResponse(HttpStatusCode.OK, respuesta);
        //}

        //[HttpGet]
        //[Route("{pIdDeuda}")]
        //public HttpResponseMessage ConsultaPorId(int pIdDeuda)
        //{
        //    var respuesta = new DeudaConsultaResponse { };
        //    var strMetodo = "WSDeudas - Abonos/Consulta ";
        //    string sid = Guid.NewGuid().ToString();

        //    try
        //    {

        //        respuesta.Deudas = new DeudaNegocio().ConsultarPorId(pIdDeuda);

        //        if (respuesta.Deudas.Count > 0)
        //        {
        //            respuesta.Exito = true;
        //            respuesta.Mensaje = $"Se han cargado las deuda id {pIdDeuda} con éxito";
        //        }
        //        else
        //            respuesta.Mensaje = $"No existe la deuda con id {pIdDeuda}.";

        //    }
        //    catch (ServiceException Ex)
        //    {
        //        respuesta.CodigoError = Ex.Codigo.ToString();
        //        respuesta.Mensaje = Ex.Message;
        //    }
        //    catch (Exception Ex)
        //    {
        //        string strErrGUI = Guid.NewGuid().ToString();
        //        string strMensaje = "Error Interno del Servicio [GUID: " + strErrGUI + "].";
        //        log.Error("[" + strMetodo + "]" + "[SID:" + sid + "]" + strMensaje, Ex);

        //        respuesta.CodigoError = "10001";
        //        respuesta.Mensaje = "ERROR INTERNO DEL SERVICIO [" + strErrGUI + "]";
        //    }

        //    return Request.CreateResponse(HttpStatusCode.OK, respuesta);
        //}

        //[HttpPost]
        //[Route("Cargo")]
        //public HttpResponseMessage AgregarCargo()
        //{
        //    var respuesta = new DeudaConsultaResponse { };
        //    var strMetodo = "WSDeudas - Deudas/Consulta ";
        //    string sid = Guid.NewGuid().ToString();

        //    try
        //    {

        //        respuesta.Deudas = new DeudaNegocio().Consultar();

        //        if (respuesta.Deudas.Count > 0)
        //        {
        //            respuesta.Exito = true;
        //            respuesta.Mensaje = "Se han cargado los ingresos";
        //        }
        //        else
        //            respuesta.Mensaje = "No se han encontrado ingresos activos.";

        //    }
        //    catch (ServiceException Ex)
        //    {
        //        respuesta.CodigoError = Ex.Codigo.ToString();
        //        respuesta.Mensaje = Ex.Message;
        //    }
        //    catch (Exception Ex)
        //    {
        //        string strErrGUI = Guid.NewGuid().ToString();
        //        string strMensaje = "Error Interno del Servicio [GUID: " + strErrGUI + "].";
        //        log.Error("[" + strMetodo + "]" + "[SID:" + sid + "]" + strMensaje, Ex);

        //        respuesta.CodigoError = "10001";
        //        respuesta.Mensaje = "ERROR INTERNO DEL SERVICIO [" + strErrGUI + "]";
        //    }

        //    return Request.CreateResponse(HttpStatusCode.OK, respuesta);
        //}
    }
}

