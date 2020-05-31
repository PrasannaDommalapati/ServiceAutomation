using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceAutomation.Models;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace ServiceAutomation.Steps.Users
{
    [Binding]
    public sealed class CreateSteps
    {
        private readonly HttpClient HttpClient;
        private readonly TestContext TestContext;
        private HttpResponseMessage ResponseMessage;

        public CreateSteps(HttpClient httpClient, TestContext testContext)
        {
            HttpClient = httpClient;
            TestContext = testContext;
        }

        [When("I create an user using POST")]
        public async Task WhenICreateAnUserUsingPOST()
        {
            var uri = new Uri(TestContext.Properties["Users"].ToString());
            var content = JsonSerializer.Serialize(new User
            {
                Email = "test@apple.com",
                FirstName = "string",
                LastName = "string",
                Birthday = DateTime.Parse("2020-05-31T15:53:02.166Z"),
                DateModified = DateTime.Parse("2020-05-31T15:53:02.166Z")
            });
            
            var message = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = uri,
                Content = new StringContent(content, Encoding.UTF8, MediaTypeNames.Application.Json)
            };

            ResponseMessage = await HttpClient.SendAsync(message).ConfigureAwait(false);
        }

        [Then("the statuscode should be '(.*)'")]
        public void ThenTheStatuscodeShouldBe(int statusCode)
        {
            Assert.AreEqual(statusCode, (int)ResponseMessage.StatusCode);
        }
    }
}
