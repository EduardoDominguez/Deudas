using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace WSDeudas.Models.Response
{
    public class TokenResponse
    {
        public string Token { get; set; }
        public HttpResponseMessage responseMsg { get; set; }

        public TokenResponse()
        {
            this.Token = "";
            this.responseMsg = new HttpResponseMessage() { StatusCode = System.Net.HttpStatusCode.Unauthorized };
        }
    }
}