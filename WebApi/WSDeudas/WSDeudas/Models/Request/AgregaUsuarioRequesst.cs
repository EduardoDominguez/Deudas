﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSDeudas.Models.Request
{
    public class AgregaUsuarioRequest
    {
        public string Nombre { get; set; }
        public string Apepaterno { get; set; }
        public string Apematerno { get; set; }
        public string Nick { get; set; }
        public string Correo { get; set; }
        public string Password { get; set; }

        public AgregaUsuarioRequest()
        {
            this.Nombre = string.Empty;
            this.Apepaterno = string.Empty;
            this.Apematerno = string.Empty;
            this.Nick = string.Empty;
            this.Correo = string.Empty;
            this.Password = string.Empty;
        }
    }
}