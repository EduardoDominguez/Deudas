using SYSCRYPTING2;
using mx.gob.Leon.DataContext;
using System.Configuration;

namespace WSDeudas
{
    public class ULAppConfig
    {

        /// <summary>
        /// Información de Conexión para el Contexto de Transacción del Sistema de SRVNOMINAS.
        /// </summary>
        public BCLCTINFO CT_ORACLE { get; set; }

        /// <summary>
        /// Indica si se ha ejecutado el método Load.
        /// </summary>
        public bool Loaded { get; set; }


        public ULAppConfig()
        {

            try
            {
                this.CT_ORACLE = new BCLCTINFO();

                this.Loaded = false;
            }
            catch (System.Exception Ex)
            {
                //throw new InternalException(Ex.Message, Ex);
                throw;
            }

        }


        /// <summary>
        /// Carga la Configuración de la Aplicación y la almacena en variables locales.
        /// </summary>
        public void Load()
        {

            string strKeyVal = string.Empty; //Valor de la Clave Privada.
            string strSrcVal = string.Empty; //Valor Original.
            string strDecVal = string.Empty; //Valir Desencriptado.

            try
            {

                this.CT_ORACLE.Provider = "";

                this.CT_ORACLE.Server = ConfigurationManager.AppSettings["SRV_ORACLE"];
                this.CT_ORACLE.UserName = ConfigurationManager.AppSettings["USER_ORACLE"];
                this.CT_ORACLE.Password = ConfigurationManager.AppSettings["PSW_ORACLE"];
                this.CT_ORACLE.DataBase = ConfigurationManager.AppSettings["ORACLE_BDP"];

                this.Loaded = true;
            }
            catch (System.Exception Ex)
            {
                //throw new InternalException(Ex.Message, Ex);
                throw;
            }

        }


    }
}