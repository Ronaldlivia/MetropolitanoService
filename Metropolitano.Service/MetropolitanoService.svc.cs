using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Metropolitano.Service.Response;
using Metropolitano.Service.Persistencia;
using Metropolitano.Service.Dominio;
using IronSharp.Core;
using IronSharp.IronMQ;
namespace Metropolitano.Service
{       
    public class MetropolitanoService : IMetropolitanoService
    {
        TarjetaDAO objTarjetaDAO = new TarjetaDAO();

        public TarjetaResponse ConsultarTarjeta(string codigoTarjeta)
        {
            TarjetaResponse objTarjetaResponse = new TarjetaResponse();
            objTarjetaResponse.EsValido = false;

            try
            {
                if (string.IsNullOrEmpty(codigoTarjeta))
                {
                    objTarjetaResponse.Mensaje = "No se especificó el código de tarjeta";
                    return objTarjetaResponse;
                }

                Tarjeta objTarjeta = objTarjetaDAO.Consultar(codigoTarjeta);

                if (string.IsNullOrEmpty(objTarjeta.CodigoTarjeta))
                {
                    objTarjetaResponse.Mensaje = "No se encontró registro de tarjeta.";
                }
                else
                {
                    objTarjetaResponse.Mensaje = "Tarjeta válida.";
                    objTarjetaResponse.EsValido = true;
                    objTarjetaResponse.Tarjeta = objTarjeta;
                }
            }
            catch (Exception ex)
            {
                objTarjetaResponse.Mensaje = "Se presentó un error al intentar consultar la tarjeta. Error: " + ex.Message;
            }

            return objTarjetaResponse;
        }


        public TarjetaResponse ListarTarjeta()
        {
            TarjetaResponse objTarjetaResponse = new TarjetaResponse();
            objTarjetaResponse.EsValido = false;

            try
            {

                var iromMq = IronSharp.IronMQ.Client.New(new IronClientConfig { ProjectId = "5a7bb9b0c85cba0009ca8dd2", Token = "zXvLUZqzULL4SSp5G3qa", Host = "mq-aws-eu-west-1-1.iron.io", Scheme = "http", Port = 80 });

                QueueClient queue = iromMq.Queue("Tarjeta");
                var message = queue.PeekNext();
                var messages = queue.Peek(13);

                foreach (var item in messages.Messages)
                {
                    bool objTarjeta = objTarjetaDAO.ActualizarTarjeta(item.Body);

                }
                objTarjetaResponse.EsValido = true;
                objTarjetaResponse.Mensaje = "Tarjeta Actualizada";
                message.Delete();





            }
            catch (Exception ex)
            {
                objTarjetaResponse.Mensaje = "Se presentó un error al intentar consultar la tarjeta. Error: " + ex.Message;
            }

            return objTarjetaResponse;
        }
    }
}
