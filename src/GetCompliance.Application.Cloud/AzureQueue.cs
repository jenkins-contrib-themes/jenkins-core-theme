using System;
using GetCompliance.Application.Queue;
using RestSharp;

namespace GetCompliance.Application.Cloud
{
    public class AzureQueue : IQueue
    {
        public void PutMessage(Message message)
        {
            var restClient = new RestClient("http://127.0.0.1:10001/");
            var request = new RestRequest("devstoreaccount1/myqueue", Method.PUT);
            
        }

        public Message GetMessage()
        {
            throw new System.NotImplementedException();
        }
    }
}
