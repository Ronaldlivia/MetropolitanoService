using Metropolitano.Service.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Script.Services;

namespace Metropolitano.Service
{    
    [ServiceContract]
    public interface IMetropolitanoService
    {
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "/ConsultarTarjeta/{codigoTarjeta}")]
        TarjetaResponse ConsultarTarjeta(string codigoTarjeta);


        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "/ListarTarjeta")]
        TarjetaResponse ListarTarjeta();
    }
}
