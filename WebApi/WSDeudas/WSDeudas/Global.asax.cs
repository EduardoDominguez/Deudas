using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace WSDeudas
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            Exception ex = Server.GetLastError();

            try
            {
                log.Error("\r\n_________________________" + ex.Message + "\r\n InnerException: " + ex.InnerException.Message + "_________________________", ex);
            }
            catch
            {
                log.Error("\r\n_________________________" + ex.Message + "\r\n _________________________", ex);
            }
        }
    }
}
