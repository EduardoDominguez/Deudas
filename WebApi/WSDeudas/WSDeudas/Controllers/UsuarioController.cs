using Deudas.BL;
using Deudas.DAL.Modelo;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WSDeudas.Exceptions;
using WSDeudas.Models.Request;
using WSDeudas.Models.Response;

namespace WSDeudas.Controllers
{
    //[Authorize]
    [AllowAnonymous]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/Usuarios")]
    public class UsuarioController : ApiController
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [HttpPost]
        [Route("")]
        public HttpResponseMessage Agregar([FromBody] AgregaUsuarioRequest pUsuarioRequest)
        {
            var respuesta = new AgregaUsuarioResponse { };
            var strMetodo = "WSDeudas - Usuarios/Agregar ";
            string sid = Guid.NewGuid().ToString();

            try
            {
                if (pUsuarioRequest == null)
                    respuesta.Mensaje = "No se recibió un usuario a registrar.";
                else if (pUsuarioRequest.Nombre.Trim().Equals(""))
                    respuesta.Mensaje = "El elemento <<Nombre>> no puede estar vacío.";
                else if (pUsuarioRequest.Apematero.Trim().Equals(""))
                    respuesta.Mensaje = "El elemento <<Apematero>> no puede estar vacío.";
                else if (pUsuarioRequest.Apepaterno.Trim().Equals(""))
                    respuesta.Mensaje = "El elemento <<Apepaterno>> no puede estar vacío.";
                else if (pUsuarioRequest.Apematero.Trim().Equals(""))
                    respuesta.Mensaje = "El elemento <<Apematero>> no puede estar vacío.";
                else if (pUsuarioRequest.Correo.Trim().Equals(""))
                    respuesta.Mensaje = "El elemento <<Correo>> no puede estar vacío.";
                else if (pUsuarioRequest.Nick.Trim().Equals(""))
                    respuesta.Mensaje = "El elemento <<Nick>> no puede estar vacío.";
                else
                {

                    var resultado = new UsuarioNegocio().Agregar(new usuarios
                    {
                        nombre = pUsuarioRequest.Nombre,
                        appaterno = pUsuarioRequest.Apepaterno,
                        apmaterno = pUsuarioRequest.Apematero,
                        correo = pUsuarioRequest.Correo,
                        nick = pUsuarioRequest.Nick,
                        contrasena = pUsuarioRequest.Password
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
