using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WSDeudas.Exceptions;
using WSDeudas.Models.Request;
using WSDeudas.Models.Response;
using log4net;
using System.Web.Http.Cors;

namespace WSNomina.Controllers
{
    //[Authorize]
    [AllowAnonymous]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/Cuenta")]
    public class CuentaController : ApiController
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #region Métodos Privados
        private string ValidaSegmentos(String[] pSegmentos)
        {
            string strRespuesta = string.Empty;
            try
            {
                //Valida que el segmento 1 tenga un valor y que sea de la longitud correcta.
                if (String.IsNullOrEmpty(pSegmentos[0]))
                    strRespuesta = "El elemento <<Segmento1>> no puede estar vacío.";
                else if (pSegmentos[0].Length != 2)
                    strRespuesta = "El elemento <<Segmento1>> debe tener 2 caracteres.";

                //Valida que el segmento 2 tenga un valor y que la longitud sea correcta.
                if (String.IsNullOrEmpty(pSegmentos[1]))
                    strRespuesta = "El elemento <<Segmento2>> no puede estar vacío.";
                else if (pSegmentos[1].Length != 11)
                    strRespuesta = "El elemento <<Segmento2>> debe tener 11 caracteres.";

                //Valida que el segmento 3 tenga un valor y que la longitud sea correcta.
                if (String.IsNullOrEmpty(pSegmentos[2]))
                    strRespuesta = "El elemento <<Segmento3>> no puede estar vacío.";
                else if (pSegmentos[2].Length != 6)
                    strRespuesta = "El elemento <<Segmento3>> debe tener 6 caracteres.";

                //Valida que el segmento 4 tenga un valor y que la longitud sea correcta.
                if (String.IsNullOrEmpty(pSegmentos[3]))
                    strRespuesta = "El elemento <<Segmento4>> no puede estar vacío.";
                else if (pSegmentos[3].Length != 2)
                    strRespuesta = "El elemento <<Segmento4>> debe tener 2 caracteres.";

                //Valida que el segmento 5 tenga un valor y que la longitud sea correcta.
                if (String.IsNullOrEmpty(pSegmentos[4]))
                    strRespuesta = "El elemento <<Segmento5>> no puede estar vacío.";
                else if (pSegmentos[4].Length != 4)
                    strRespuesta = "El elemento <<Segmento5>> debe tener 4 caracteres.";

                //Valida que el segmento 6 tenga un valor y que la longitud sea correcta.
                if (String.IsNullOrEmpty(pSegmentos[5]))
                    strRespuesta = "El elemento <<Segmento6>> no puede estar vacío.";
                else if (pSegmentos[5].Length != 3)
                    strRespuesta = "El elemento <<Segmento6>> debe tener 3 caracteres.";

                //Valida que el segmento 7 tenga un valor y que la longitud sea correcta.
                if (String.IsNullOrEmpty(pSegmentos[6]))
                    strRespuesta = "El elemento <<Segmento7>> no puede estar vacío.";
                else if (pSegmentos[6].Length != 3)
                    strRespuesta = "El elemento <<Segmento7>> debe tener 3 caracteres.";

                //Valida que el segmento 8 tenga un valor y que la longitud sea correcta.
                if (String.IsNullOrEmpty(pSegmentos[7]))
                    strRespuesta = "El elemento <<Segmento8>> no puede estar vacío.";
                else if (pSegmentos[7].Length != 7)
                    strRespuesta = "El elemento <<Segmento8>> debe tener 7 caracteres.";

                //Valida que el segmento 9 tenga un valor y que la longitud sea correcta.
                if (String.IsNullOrEmpty(pSegmentos[8]))
                    strRespuesta = "El elemento <<Segmento9>> no puede estar vacío.";
                else if (pSegmentos[8].Length != 5)
                    strRespuesta = "El elemento <<Segmento9>> debe tener 5 caracteres.";

                //Valida que el segmento 10 tenga un valor y que la longitud sea correcta.
                if (String.IsNullOrEmpty(pSegmentos[9]))
                    strRespuesta = "El elemento <<Segmento10>> no puede estar vacío.";
                else if (pSegmentos[9].Length != 1)
                    strRespuesta = "El elemento <<Segmento10>> debe tener 1 caracteres.";

                //Valida que el segmento 11 tenga un valor y que la longitud sea correcta.
                if (String.IsNullOrEmpty(pSegmentos[10]))
                    strRespuesta = "El elemento <<Segmento11>> no puede estar vacío.";
                else if (pSegmentos[10].Length != 2)
                    strRespuesta = "El elemento <<Segmento11>> debe tener 2 caracteres.";

                //Valida que el segmento 12 tenga un valor y que la longitud sea correcta.
                if (String.IsNullOrEmpty(pSegmentos[11]))
                    strRespuesta = "El elemento <<Segmento12>> no puede estar vacío.";
                else if (pSegmentos[11].Length != 6)
                    strRespuesta = "El elemento <<Segmento12>> debe tener 6 caracteres.";

                //Valida que el segmento 13 tenga un valor y que la longitud sea correcta.
                if (String.IsNullOrEmpty(pSegmentos[12]))
                    strRespuesta = "El elemento <<Segmento13>> no puede estar vacío.";
                else if (pSegmentos[12].Length != 4)
                    strRespuesta = "El elemento <<Segmento13>> debe tener 4 caracteres.";
            }
            catch (Exception e)
            {
                throw;
            }

            return strRespuesta;
        }
        #endregion

        #region Métodos Públicos
        
        /*/// <summary>
        /// Consulta si una combinación contable existe.
        /// </summary>
        /// <param name="pCuenta">Combinación contable a consultar</param>
        /// <returns>HttpResponseMessage que contiene la información de la respuesta del método.</returns>
        [HttpGet]
        [Route("Validar/{pCuenta}")]
        public async Task<HttpResponseMessage> Validar(String pCuenta)
        {
            ValidaCuentaRespuesta respuesta = null;
            ValidaCuentaSolicitud objSolicitud = null;
            var strMetodo = "WSNominas-Validar Cuenta";
            string sid = Guid.NewGuid().ToString();
            var objCT = new BCLCTORACLE();
            var objCfg = new ULAppConfig();

            try
            {
                //Genera la respuesta para el Cliente.
                respuesta = new ValidaCuentaRespuesta();
                //Valida que el objeto no este vacío.
                if (string.IsNullOrEmpty(pCuenta))
                    respuesta.MensajeError = "Se debe especificar un parámetro <<pCuenta>> como entrada";

                var arrCombinacion = pCuenta.Split('-');
                if (arrCombinacion.Length != 13)
                    respuesta.MensajeError = "La combinación no tiene la estructura correcta a 13 segmentos.";

                var strMsjSegmentos = ValidaSegmentos(arrCombinacion);
                if (!strMsjSegmentos.Equals(""))
                    respuesta.MensajeError = strMsjSegmentos;
                else if (respuesta.MensajeError.Equals(""))
                {
                    objSolicitud = new ValidaCuentaSolicitud(arrCombinacion);

                    //Consultar cuenta.
                    objCfg.Load();
                    objCT.InitContexto(objCfg.CT_ORACLE);
                    objCT.CrearContexto();

                    boCuenta cuenta = null;
                    using (var objBL = new Cuentas(objCT))
                    {
                        var strMsjExisteCuenta = await objBL.ValidaCuenta(objSolicitud.Combinacion);
                        if (!strMsjExisteCuenta.Equals("NO EXISTE"))
                            cuenta = await objBL.GetCuenta(objSolicitud.Combinacion);
                    }

                    if (cuenta != null)
                    {
                        respuesta.NombreCuenta = cuenta.DescripcionSegmento2;
                        respuesta.CuentaValida = true;
                    }
                }

                respuesta.Exito = true;
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
                objCfg = null;

                if (objCT != null)
                    objCT.Dispose();
            }

            return Request.CreateResponse(HttpStatusCode.OK, respuesta);
        }

        /// <summary>
        /// Consulta el presupuesto de una .
        /// </summary>
        /// <param name="pCuenta">Combinación contable a consultar</param>
        /// <returns>HttpResponseMessage que contiene la información de la respuesta del método.</returns>
        [HttpGet]
        [Route("Presupuesto")]
        public async Task<HttpResponseMessage> Presupuesto([FromUri] PresupuestoSolicitud pSolicitud)
        {
            PresupuestoRespuesta respuesta = null;
            var strMetodo = "WSNominas-Validar Presupuesto";
            string sid = Guid.NewGuid().ToString();
            var objCT = new BCLCTORACLE();
            var objCfg = new ULAppConfig();
            int intTemp = 0;
            bool blnPuedeConvertir = false;

            try
            {
                //Genera la respuesta para el Cliente.
                respuesta = new PresupuestoRespuesta();
                //Valida que el objeto no este vacío.
                if (pSolicitud == null)
                    respuesta.MensajeError = "Se debe especificar los parámetos correctos como entrada";

                //Valida Mes inicial
                blnPuedeConvertir = int.TryParse(Convert.ToString(pSolicitud.MesInicial), out intTemp);
                //Valida que sea un número.
                if (!blnPuedeConvertir)
                    respuesta.MensajeError = "El elemento <<MesInicial>> debe de ser un valor numérico.";

                //Valida que el mes inicial sea correcto.
                if (pSolicitud.MesInicial <= 0)
                    respuesta.MensajeError = "El elemento <<MesInicial>> debe de ser un número mayor a cero.";
                else if (pSolicitud.MesInicial > 12)
                    respuesta.MensajeError = "El elemento <<MesInicial>> no puede ser un número mayor a doce.";

                //Valida Mes Final.
                blnPuedeConvertir = int.TryParse(Convert.ToString(pSolicitud.MesFinal), out intTemp);
                //Valida que sea un número.
                if (!blnPuedeConvertir)
                    respuesta.MensajeError = "El elemento <<MesFinal>> debe de ser un valor numérico.";

                //Valida que el mes final.
                if (pSolicitud.MesFinal <= 0)
                    respuesta.MensajeError = "El elemento <<MesFinal>> debe de ser un número mayor a cero.";
                else if (pSolicitud.MesFinal > 12)
                    respuesta.MensajeError = "El elemento <<MesFinal>> no puede ser un número mayor a doce.";

                //Valida que el mes final no sea mayor al inicial.
                if (pSolicitud.MesFinal < pSolicitud.MesInicial)
                    respuesta.MensajeError = "El elemento <<MesFinal>> no puede ser mayor al <<MesInicial>>.";

                //Valida que sea un número.
                blnPuedeConvertir = int.TryParse(Convert.ToString(pSolicitud.Ejercicio), out intTemp);

                if (!blnPuedeConvertir)
                    respuesta.MensajeError = "El elemento <<Ejercicio>> debe de ser un valor numérico.";

                //Valida que el año sea correcto.
                if (pSolicitud.Ejercicio <= 0)
                    respuesta.MensajeError = "El elemento <<Ejercicio>> debe de ser un número mayor a cero.";

                if (string.IsNullOrEmpty(pSolicitud.Combinacion))
                    respuesta.MensajeError = "Se debe especificar un parámetro <<pCuenta>> como entrada";

                var arrCombinacion = pSolicitud.Combinacion.Split('-');
                if (arrCombinacion.Length != 13)
                    respuesta.MensajeError = "La combinación no tiene la estructura correcta a 13 segmentos.";

                var strMsjSegmentos = ValidaSegmentos(arrCombinacion);
                if (!strMsjSegmentos.Equals(""))
                    respuesta.MensajeError = strMsjSegmentos;
                else if (respuesta.MensajeError.Equals(""))
                {
                    //Consultar cuenta.
                    objCfg.Load();
                    objCT.InitContexto(objCfg.CT_ORACLE);
                    objCT.CrearContexto();

                    boCuenta cuenta;
                    using (var objBL = new Cuentas(objCT))
                    {
                        cuenta = await objBL.GetCuenta(pSolicitud.Combinacion);
                        if (cuenta != null)
                        {
                            respuesta.PresupuestoCuenta = await objBL.ConsultaPresupuesto(pSolicitud.Combinacion, pSolicitud.MesInicial, pSolicitud.MesFinal, pSolicitud.Ejercicio);
                            respuesta.CuentaValida = true;
                        }
                    }
                }

                respuesta.Exito = true;
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
                objCfg = null;

                if (objCT != null)
                    objCT.Dispose();
            }

            return Request.CreateResponse(HttpStatusCode.OK, respuesta);
        }*/
        #endregion
    }
}
