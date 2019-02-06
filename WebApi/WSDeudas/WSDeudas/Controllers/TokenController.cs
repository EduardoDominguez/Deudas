using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading;
using System.Web.Http;
using WSDeudas.Models.Request;
using WSDeudas.Models.Response;
using log4net;
using System.Configuration;
using Deudas.BL;
using Deudas.DAL.Modelo;
using System.Web.Http.Cors;

namespace WSDeudas.Controllers
{
    [AllowAnonymous]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/Autenticar")]
    public class TokenController : ApiController
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [HttpPost]
        [Route("")]
        public IHttpActionResult Autenticar([FromBody] TokenRequest login)
        {
            var tokenResponse = new TokenResponse { };
            TokenRequest loginrequest = new TokenRequest { };

            if (login == null)
                login = new TokenRequest();
            loginrequest.Username = login.Username.ToLower();
            loginrequest.Password = login.Password;

            IHttpActionResult response;
            HttpResponseMessage responseMsg = new HttpResponseMessage();
            bool isUsernamePasswordValid = false;

            if (login != null)
                isUsernamePasswordValid = (new LoginNegocio().Login(new usuarios {nick = loginrequest.Username, contrasena = loginrequest.Password }) != null) ? true : false;

            //loginrequest.Password == "admin" ? true : false;

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

        [HttpGet]
        [Route("echoping")]
        public IHttpActionResult EchoPing()
        {
            return Ok(true);
        }

        
        [HttpGet]
        [Route("echouser")]
        public IHttpActionResult EchoUser()
        {
            var identity = Thread.CurrentPrincipal.Identity;
            return Ok($"IPrincipal-user: { identity.Name} - IsAuthenticated: {identity.IsAuthenticated}");
        }

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