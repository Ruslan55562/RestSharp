using Newtonsoft.Json;
using System;

namespace RestSharp.Test.Models
{
    class APIHelper
    {
        protected IRestClient client;
        protected IRestRequest request;
        private const string APIUrl = "http://api.mathjs.org/v4/";

        public IRestClient InitializeClient()
        {
            client = new RestClient(APIUrl)
            {
                UserAgent = "Learning RestSharp"
            };
            return client;
        }
        public string GetAPIUrl()
        {
            return APIUrl;
        }

        public IRestRequest CreatePostRequest()
        {
            return new RestRequest("", Method.POST);
        }
        public IRestRequest CreateGetRequest()
        {
            request = new RestRequest
            {
                Resource = "?expr={sqrt(Number)}&precision={precision}",
                Method = Method.GET
            };
            return request;
        }
        public IRestResponse GetPOSTResponse(IRestClient client, IRestRequest request)
        {
            return client.Execute(request);
        }
        public string DesirializePOSTResponseContent(IRestResponse Response)
        {
            dynamic result = JsonConvert.DeserializeObject(Response.Content);
            return result["result"].ToString();
        }
       
    }
}
