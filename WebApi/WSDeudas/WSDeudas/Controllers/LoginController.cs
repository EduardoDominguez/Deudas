using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WSDeudas.Models.Request;
using WSDeudas.Models.Response;
using WSDeudas.Exceptions;
using log4net;
using Deudas.BL;
using Deudas.DAL.Modelo;
using System.Web.Http.Cors;

namespace WSDeudas.Controllers
{
    [Authorize]

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/Login")]
    public class LoginController : ApiController
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [HttpPost]
        [Route("")]
        public HttpResponseMessage Login([FromBody] LoginRequest pLoginRequest)
        {
            var respuesta = new LoginResponse { };
            var strMetodo = "WSDeudas - Login ";
            string sid = Guid.NewGuid().ToString();
            
            try
            {
                var acceso = new usuarios();
                acceso.nick = pLoginRequest.Username;
                acceso.contrasena = pLoginRequest.Password;
                var pNegocio = new LoginNegocio();
                var usuario = pNegocio.Login(acceso);

                if (usuario != null)
                    respuesta.Exito = true;
                else
                {
                    respuesta.Mensaje = "El usuario o contraseña son incorrectos.";
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
            finally
            {
                
            }

            return Request.CreateResponse(HttpStatusCode.OK, respuesta);
        }
    }
}