using log4net;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WSDeudas.Exceptions;
using WSDeudas.Models.Request;
using Deudas.BL;
using Deudas.DAL.Modelo;
using System.Web.Http.Cors;
using WSDeudas.Models;

namespace WSDeudas.Controllers
{

    //[Authorize]
    [AllowAnonymous]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/Cargos")]
    public class CargoController : ApiController
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [HttpPost]
        [Route("")]
        public HttpResponseMessage Agregar([FromBody] AgregaCargoRequest pCargoRequest)
        {
            var respuesta = new Respuesta { };
            var strMetodo = "WSDeudas - Cargos/Agregar ";
            string sid = Guid.NewGuid().ToString();

            
            try
            {

                if (pCargoRequest == null)
                    respuesta.Mensaje = "No se recibió ningun cargo a registrar.";
                else if (pCargoRequest.IdDeuda <= 0)
                    respuesta.Mensaje = "El elemento <<IdDeuda>> debe ser mayor a cero.";
                else if (pCargoRequest.Cantidad <= 0)
                    respuesta.Mensaje = "El elemento <<Cantidad>> debe ser mayor a cero.";
                else if (pCargoRequest.IdUsuario <= 0)
                    respuesta.Mensaje = "El elemento <<IdUsuario>> debe especificar el usuario al que se le asignará la deuda.";
                else
                {
                    //log.Error("[IdDeuda:" + pCargoRequest.IdDeuda + "]" + "[Cantidad:" + pCargoRequest.Cantidad + "]" + "[IdUsuario:" + pCargoRequest.IdUsuario + "]", null);
                    var resultado = new CargoNegocio().AgregarCargo(new cargos_deudas
                    {
                        idusuario = pCargoRequest.IdUsuario,
                        iddeuda = pCargoRequest.IdDeuda,
                        cantidad = pCargoRequest.Cantidad
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
    }
}
