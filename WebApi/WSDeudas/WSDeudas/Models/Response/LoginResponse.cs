﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Deudas.DAL.Modelo;

namespace WSDeudas.Models.Response
{
    public class LoginResponse : Respuesta
    {
        public usuarios usuario { get; set; }
    }
}