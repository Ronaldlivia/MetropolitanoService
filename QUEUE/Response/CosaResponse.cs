using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace QUEUE.Response
{
    [DataContract]
    public class CosaResponse
    {
        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public int Cantidad { get; set; }

        [DataMember]
        public string Mensaje { get; set; }

        [DataMember]
        public bool Exito { get; set; }
    }


    public class ListaCosaResponse
    {
        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public int Cantidad { get; set; }
    }
}