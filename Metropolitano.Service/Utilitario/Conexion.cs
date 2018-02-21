using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Metropolitano.Service.Utilitario
{
    public class Conexion
    {
        public static string cnMetropolitano = ConfigurationManager.ConnectionStrings["cnMetropolitano"].ConnectionString;
    }
}