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
using Deudas.EL;
using Deudas.DAL.Modelo;
using System.Web.Http.Cors;
using System.Configuration;
using System.IO;

namespace WSDeudas.Controllers
{
    //[Authorize]
    [AllowAnonymous]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/Notificacion")]
    public class NotificacionesController : ApiController
    {

        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [HttpPost]
        [Route("")]
        public HttpResponseMessage Enviar([FromBody] EnviaNotificacionRequest pEnvivioNotificacion)
        {
            var respuesta = new IngresoResponse { };
            var strMetodo = "WSDeudas - Notificacion/Enviar ";
            string sid = Guid.NewGuid().ToString();

            try
            {
                if (pEnvivioNotificacion == null)
                    respuesta.Mensaje = "No se recibió ningun dato para enviar notificacion.";
                else if (string.IsNullOrEmpty(pEnvivioNotificacion.Titulo.Trim()))
                    respuesta.Mensaje = "El elemento <<Titulo>> no puede estar vacío.";
                else if (string.IsNullOrEmpty(pEnvivioNotificacion.Mensaje.Trim()))
                    respuesta.Mensaje = "El elemento <<Mensaje>>  no puede estar vacío.";
                else if (string.IsNullOrEmpty(pEnvivioNotificacion.Correo.Trim()))
                    respuesta.Mensaje = "El elemento <<Correo>>  no puede estar vacío.";

                else
                {
                    var token = new NotificacionNegocio().ObtieneToken(pEnvivioNotificacion.Correo.Trim());

                    if(!string.IsNullOrEmpty(token))
                    {
                        var resultado = SendMessage(token, pEnvivioNotificacion.Titulo, pEnvivioNotificacion.Mensaje);
                        if (!resultado.Equals("-1"))
                        {
                            respuesta.Exito = true;
                            respuesta.Mensaje = resultado;
                        }
                        else
                        {
                            respuesta.Mensaje = "No se pudo enviar la notificación";
                        }
                    }
                    else
                    {
                        respuesta.Mensaje = "No se pudo encontrar el token para el correo " + pEnvivioNotificacion.Correo;
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

        
         public string SendMessage(string pTokenDestinatario, string pTitle, string pBoby)
         {
                string serverKey = ConfigurationManager.AppSettings["SERVER_KEY_FIREBASE"];

                try
                {
                    var result = "-1";
                    var webAddr = "https://fcm.googleapis.com/fcm/send";

                    //var regID = "phoneRegID";
                    //pTokenDestinatario = "eSW7GIylK_8:APA91bEC5FKJgXn6bTL4apxN1CzXP3jXBzm_DrVCwcW0W-Owt-u0qu-UBeSbKndhPCPuvpECA7ZOxYu3Q-ZyzsUk-veQQAgswXtm-OiPKu4XkQRk9uWMaL5I5SgkWAib8_VY3mwVdfKS";

                    var httpWebRequest = (HttpWebRequest)WebRequest.Create(webAddr);
                    httpWebRequest.ContentType = "application/json";
                    httpWebRequest.Headers.Add("Authorization:key=" + serverKey);
                    httpWebRequest.Method = "POST";

                    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                    {
                        string json = "{\"to\": \"" + pTokenDestinatario + "\",\"notification\": {\"title\": \""+ pTitle+"\",\"body\": \""+ pBoby+"\"},\"priority\":10}";
                        //registration_ids, array of strings -  to, single recipient
                        streamWriter.Write(json);
                        streamWriter.Flush();
                    }

                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        result = streamReader.ReadToEnd();
                    }

                    return result;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
         }

        [HttpPut]
        [Route("")]
        public HttpResponseMessage ActualizaToken([FromBody] ActualizaTokenRequest pRequestToken)
        {
            var respuesta = new ActualizaTokenNotificacionResponse { };
            var strMetodo = "WSDeudas - Notificaciones/ActualizaToken ";
            string sid = Guid.NewGuid().ToString();

            try
            {
                if (pRequestToken == null)
                    respuesta.Mensaje = "No se recibió ninguna deuda a registrar.";
                else if (string.IsNullOrEmpty(pRequestToken.Token.Trim()))
                    respuesta.Mensaje = "El elemento  <<Token>> no puede estar vacío.";
                else if (pRequestToken.IdUsuario <= 0)
                    respuesta.Mensaje = "El elemento <<IdUsuario>> debe especificar un usuario.";
                else
                {
                    var resultado = new NotificacionNegocio().ActualizaToken(pRequestToken.IdUsuario, pRequestToken.Token);

                    if(resultado > 0)
                    {
                        respuesta.Exito = true;
                        respuesta.Mensaje = "Token actualizado con éxito";
                    }
                    else
                    {
                        respuesta.Mensaje = "No se pudo actualizar el token.";
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
