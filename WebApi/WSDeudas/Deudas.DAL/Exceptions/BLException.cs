//*************************************************************************************************************
//Archivo:          BLException.cs
//Descripción:      Esta clase representa una Excepción generada en la capa de negocios.
//Creado el:        06/05/2014
//Creado Por:       José Falcón Pérez.
//Modificado el:    30/11/2018
//Modificado por:   Mario Eduardo Domínguez Meléndez
//*************************************************************************************************************

using System;
using System.Runtime.Serialization;

namespace Deudas.DAL.Exceptions
{
    /// <summary>
    /// Implementación de una excepción de la capa de usuario.
    /// </summary>
    public class BLException : System.ApplicationException
    {
        /// <summary>
        /// Constructor de la Clase (Implementación 1)
        /// </summary>
        public BLException()
            : base(string.Empty)
        {

        }

        /// <summary>
        /// Constructor de la Clase (Implementación 2)
        /// </summary>
        /// <param name="new_message">Nuevo mensaje que será asignado a la excepción</param>
        /// <param name="new_errorcode">Código del Error</param>
        public BLException(string new_message, int new_errorcode)
            : base(new_message)
        {
            HResult = new_errorcode;
        }

        /// <summary>
        /// Constructor de la Clase (Implementación 3)
        /// </summary>
        /// <param name="new_message">Nuevo mensaje que será asignado a la excepción</param>
        /// <param name="new_errorcode">Código del Error</param>
        public BLException(string new_message, int new_errorcode, Exception inner_exception)
            : base(new_message, inner_exception)
        {
            HResult = new_errorcode;
        }

        /// <summary>
        /// Constructor de la Clase (Implementación 4)
        /// </summary>
        /// <param name="new_message">Nuevo mensaje que será asignado a la excepción</param>
        /// <param name="inner_exception">Un System.Exception que contiene la excepción interna de la cual deriva la actual.</param>
        public BLException(string new_message, Exception inner_exception)
            : base(new_message, inner_exception)
        {

        }

        /// <summary>
        /// Constructor de la Clase (Implementación 5)
        /// </summary>
        /// <param name="info" >Un System.Runtime.Serialization.SerializationInfo que contiene los datos necesarios para serializar o desserializar un objeto.</param>
        /// <param name="context" >Un  System.Runtime.Serialization.StreamingContext que describe el origen y destino de un determiando stream serializado.</param>
        public BLException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {

        }

        /// <summary>
        /// Devuelve el Código del Error.
        /// </summary>
        public int Codigo
        {
            get { return HResult; }
        }


    }
}