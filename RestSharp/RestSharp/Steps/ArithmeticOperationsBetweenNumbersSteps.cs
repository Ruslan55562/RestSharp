using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace RestSharp.Test.Steps
{
    [Binding]
    public class ArithmeticOperationsBetweenNumbersSteps
    {
        string JsonBody;
        IRestClient client;
        IRestRequest request;
        IRestResponse response;
        const string APIUrl = "http://api.mathjs.org/v4/";
        void InitializeClient()
        {
            client = new RestClient(APIUrl);
            client.UserAgent = "Learning RestSharp";
        }
        [Given(@"I have entered (.*) into the searchfield")]
        public void GivenIHaveEnteredIntoTheSearchfield(double FirstNumber)
        {
            InitializeClient();
            request = new RestRequest("", Method.POST);
            JsonBody = $"{FirstNumber}";
        }

        [Given(@"I have entered the '(.*)' into the searchfield")]
        public void GivenIHaveEnteredTheIntoTheSearchfield(string Action)
        {
            JsonBody += Action;
        }

        [Given(@"I have entered the (.*) number and (.*) into the searchfield")]
        [Obsolete]
        public void GivenIHaveEnteredTheNumberAndIntoTheSearchfield(double SecondNumber, int precision)
        {
            JsonBody += $"{SecondNumber}";
            request.AddJsonBody(new { expr = $"{JsonBody}", precision = $"{precision}" }).RequestFormat = DataFormat.Json;
        }

        [Given(@"I enter the  (.*) and (.*) into the searchfield")]
        public void GivenIEnterTheAndIntoTheSearchfield(double SqrtNumber, int precision)
        {
            InitializeClient();
            request = new RestRequest
            {
                Resource = "?expr={sqrt(Number)}&precision={precision}",
                Method = Method.GET
            };
            request.AddUrlSegment("sqrt(Number)", $"sqrt({SqrtNumber})").AddUrlSegment("precision", $"{precision}");
        }

        [Then(@"the result (.*) should be on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(double ExpectedResult)
        {
            response = client.Execute(request);
            dynamic result = JsonConvert.DeserializeObject(response.Content);
            Assert.AreEqual($"{ExpectedResult}", result["result"].ToString(), "The Actual result isn't as expected");
        }

        [Then(@"The square root of entered number = (.*)")]
        public void ThenTheSquareRootOfEnteredNumber(double ExpectedResult)
        {
            response = client.Get(request);
            Assert.AreEqual($"{ExpectedResult}", response.Content.ToString(), "The Actual result isn't as expected ");
        }
    }
}












