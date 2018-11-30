using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSDeudas.Models.Request
{
    public class LoginRequest : Respuesta
    {
        public string Username { get; set; }
        public string Password { get; set; }   
    }
}