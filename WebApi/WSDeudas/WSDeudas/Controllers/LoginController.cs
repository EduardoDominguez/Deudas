using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web;
using System.Threading;
using System.Web.Http;
using WSDeudas.Models.Request;
using WSDeudas.Models.Response;
using WSDeudas.Exceptions;
using log4net;

using System.Configuration;
using System.Threading.Tasks;
using Deudas.BL;
using Deudas.DAL.Modelo;

namespace WSDeudas.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/Login")]
    public class LoginController : ApiController
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [HttpPost]
        [Route("Autenticar")]
        public IHttpActionResult Autenticar([FromBody] TokenRequest login)
        {
            var tokenResponse = new TokenResponse { };
            TokenRequest loginrequest = new TokenRequest { };
            loginrequest.Username = login.Username.ToLower();
            loginrequest.Password = login.Password;

            IHttpActionResult response;
            HttpResponseMessage responseMsg = new HttpResponseMessage();
            bool isUsernamePasswordValid = false;       

            if(login != null)
                isUsernamePasswordValid=loginrequest.Password=="admin" ? true:false;
            
            // if credentials are valid
            if (isUsernamePasswordValid)
            {
                string token = createToken(loginrequest.Username);
                //return the token
                return Ok<string>(token);
            }
            else
            {
                // if credentials are not valid send unauthorized status code in response
                tokenResponse.responseMsg.StatusCode = HttpStatusCode.Unauthorized;
                response = ResponseMessage(tokenResponse.responseMsg);
                return response;
            }
        }


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
                    respuesta.CodigoError = "El usuario o contraseña son incorrectos.";
                }
            }
            catch (ServiceException Ex)
            {
                respuesta.CodigoError = Ex.Codigo.ToString();
                respuesta.MensajeError = Ex.Message;
            }
            catch (Exception Ex)
            {
                string strErrGUI = Guid.NewGuid().ToString();
                string strMensaje = "Error Interno del Servicio [GUID: " + strErrGUI + "].";
                log.Error("[" + strMetodo + "]" + "[SID:" + sid + "]" + strMensaje, Ex);

                respuesta.CodigoError = "10001";
                respuesta.MensajeError = "ERROR INTERNO DEL SERVICIO [" + strErrGUI + "]";
            }
            finally
            {
                
            }

            return Request.CreateResponse(HttpStatusCode.OK, respuesta);
        }
        
        [HttpGet]
        [Route("echoping")]
        public IHttpActionResult EchoPing()
        {
            return Ok(true);
        }

        /*
        [HttpGet]
        [Route("echouser")]
        public IHttpActionResult EchoUser()
        {
            var identity = Thread.CurrentPrincipal.Identity;
            return Ok(String.Format("IPrincipal-user: {0} - IsAuthenticated: {1}", identity.Name, identity.IsAuthenticated));
        }*/

        private string createToken(string username)
        {
            //Set issued at date
            DateTime issuedAt = DateTime.UtcNow;
            //set the time when it expires
            DateTime expires = DateTime.UtcNow.AddDays(Convert.ToInt32(ConfigurationManager.AppSettings["JWT_EXPIRE_DAYS"]));
            //DateTime expires = DateTime.UtcNow.AddMinutes(Convert.ToInt32(ConfigurationManager.AppSettings["JWT_EXPIRE_DAYS"]));

            //http://stackoverflow.com/questions/18223868/how-to-encrypt-jwt-security-token
            var tokenHandler = new JwtSecurityTokenHandler();

            //create a identity and add claims to the user which we want to log in
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, username)                
            });

            string sec = ConfigurationManager.AppSettings["JWT_SECRET_KEY"];
            var now = DateTime.UtcNow;
            var securityKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(sec));
            var signingCredentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(securityKey, Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256Signature);
            //create the jwt
            var token =
                (JwtSecurityToken)
                    tokenHandler.CreateJwtSecurityToken(issuer: ConfigurationManager.AppSettings["JWT_ISSUER_TOKEN"], audience: ConfigurationManager.AppSettings["JWT_AUDIENCE_TOKEN"],
                        subject: claimsIdentity, notBefore: issuedAt, expires: expires, signingCredentials: signingCredentials);
            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }
    }
}