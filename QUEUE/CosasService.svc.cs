using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using QUEUE.Response;
using QUEUE.Persistencia;
using IronSharp.Core;
using IronSharp.IronMQ;

namespace QUEUE
{    
    public class CosasService : ICosasService
    {

        CosaDAO objTarjetaDAO = new CosaDAO();

        public CosaResponse RegalarMisCosas(string nombre, string cantidad)
        {
            CosaResponse objCosaResponse = new CosaResponse();

            if (objTarjetaDAO.Registrar(nombre, int.Parse(cantidad)))
            {
                objCosaResponse.Exito = true;
                objCosaResponse.Mensaje = "Se procedio a registrar el regalo";
                objCosaResponse.Nombre = nombre;
                objCosaResponse.Cantidad = int.Parse(cantidad);
            }

            return objCosaResponse;
        }

        public List<ListaCosaResponse> Testamento(string nombre)
        {
            List<ListaCosaResponse> lstListaCosaResponse = new List<ListaCosaResponse>();

            //Leer Cola
            var iromMq = IronSharp.IronMQ.Client.New(new IronClientConfig { ProjectId = "5a7bb9b0c85cba0009ca8dd2", Token = "zXvLUZqzULL4SSp5G3qa", Host = "mq-aws-eu-west-1-1.iron.io", Scheme = "http", Port = 80 });

            QueueClient queue = iromMq.Queue("Wsservice");

            //QueueMessage msg;
            //msg = queue.Reserve();
            //msg = queue.Next();

            //MessageCollection messages;
            //messages = queue.Reserve(6);

            var message = queue.PeekNext();
            var messages = queue.Peek(13);

            //int c = 0;

            //while(c <= 13)
            //{
                
            //}
            //foreach ( obj in messages)
            //{
            this.RegalarMisCosas(messages.Messages[0].Body.ToString(), messages.Messages[1].Body.ToString());
            //}
            //while (queue.p)
            //{
            //    //Insetar
            //    
            //}


            lstListaCosaResponse = objTarjetaDAO.Consultar(nombre);



            return lstListaCosaResponse;
        }
    }
}
