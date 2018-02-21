using QUEUE.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace QUEUE
{    
    [ServiceContract]
    public interface ICosasService
    {
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "/RegalarMisCosas/{nombre}/{cantidad}")]
        CosaResponse RegalarMisCosas(string nombre, string cantidad);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Testamento/{nombre}")]
        List<ListaCosaResponse> Testamento(string nombre);
    }
}
