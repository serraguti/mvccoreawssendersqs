using Amazon.SQS;
using Amazon.SQS.Model;
using Microsoft.Extensions.Configuration;
using MvcCoreSenderSQS.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MvcCoreSenderSQS.Services
{
    public class ServiceSQS
    {
        private IAmazonSQS clientSQS;
        private String queueUrl;

        public ServiceSQS(IAmazonSQS clientsqs, 
            IConfiguration configuration)
        {
            this.queueUrl = configuration["AWSSQS:QueueUrl"];
            this.clientSQS = clientsqs;
        }

        public async Task<bool> SendMessageAsync(MensajeUsuario mensaje)
        {
            String data = JsonConvert.SerializeObject(mensaje);
            SendMessageRequest request =
                new SendMessageRequest(this.queueUrl, data);
            //CUANDO ENVIAMOS EL MENSAJE, NOS DEVUELVE UNA RESPUESTA
            //HTTP
            SendMessageResponse response =
                await this.clientSQS.SendMessageAsync(request);
            if (response.HttpStatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
