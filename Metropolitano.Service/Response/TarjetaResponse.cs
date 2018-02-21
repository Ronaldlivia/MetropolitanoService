using Metropolitano.Service.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Metropolitano.Service.Response
{
    [DataContract]
    public class TarjetaResponse
    {
        [DataMember]
        public bool EsValido { get; set; }

        [DataMember]
        public string Mensaje { get; set; }

        [DataMember]
        public Tarjeta Tarjeta { get; set; }
    }
}