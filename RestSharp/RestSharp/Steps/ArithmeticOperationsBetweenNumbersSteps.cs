using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp.Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace RestSharp.Test.Steps
{
    [Binding]
    public class ArithmeticOperationsBetweenNumbersSteps
    {
        APIHelper helper = new APIHelper();
        IRestClient client;
        IRestRequest request;
        IRestResponse response;
        private readonly ScenarioContext _scenarioContext;

        string GetScenarioExpression(ScenarioContext ScenarioExpr)
        {
            return ScenarioExpr.Get<string>("FirstNumber") + ScenarioExpr.Get<string>("Action") + ScenarioExpr.Get<string>("SecondNumber");
        }

        public ArithmeticOperationsBetweenNumbersSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }


        [Given(@"I have entered (.*) into the searchfield")]
        public void GivenIHaveEnteredIntoTheSearchfield(double FirstNumber)
        {
            client = helper.InitializeClient();
            request = helper.InitializePostRequest();
            _scenarioContext.Add("FirstNumber", $"{FirstNumber}");
        }

        [Given(@"I have entered the '(.*)' into the searchfield")]
        public void GivenIHaveEnteredTheIntoTheSearchfield(string Action)
        {
            _scenarioContext.Add("Action", $"{Action}");
        }

        [Given(@"I have entered the (.*) number and (.*) into the searchfield")]
        [Obsolete]
        public void GivenIHaveEnteredTheNumberAndIntoTheSearchfield(double SecondNumber, int precision)
        {
            _scenarioContext.Add("SecondNumber", $"{SecondNumber}");
            request.AddJsonBody(new { expr = GetScenarioExpression(_scenarioContext), precision = $"{precision}" }).RequestFormat = DataFormat.Json;
        }

        [Given(@"I enter the  (.*) and (.*) into the searchfield")]
        public void GivenIEnterTheAndIntoTheSearchfield(double SqrtNumber, int precision)
        {
            client = helper.InitializeClient();
            request = helper.InitializeGetRequest();
            request.AddUrlSegment("sqrt(Number)", $"sqrt({SqrtNumber})").AddUrlSegment("precision", $"{precision}");
        }

        [Then(@"the result (.*) should be on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(double ExpectedResult)
        {
            response = client.Execute(request);
            Assert.AreEqual($"{ExpectedResult}", helper.DesirializePOSTResponseContent(response), "The Actual result isn't as expected");
        }

        [Then(@"The square root of entered number = (.*)")]
        public void ThenTheSquareRootOfEnteredNumber(double ExpectedResult)
        {
            response = client.Get(request);
            Assert.AreEqual($"{ExpectedResult}", response.Content.ToString(), "The Actual result isn't as expected ");
        }
    }
}












