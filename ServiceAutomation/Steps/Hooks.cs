using BoDi;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using TechTalk.SpecFlow;

namespace ServiceAutomation.Steps
{
    [Binding]
    public sealed class Hooks
    {
        private IObjectContainer ObjectContainer { get; set; }

        public TestContext TestContext { get; set; }

        public Hooks(IObjectContainer objectContainer, TestContext context)
        {
            TestContext = context;
            ObjectContainer = objectContainer;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("HeaderName", "HeaderValue");
            ObjectContainer.RegisterInstanceAs<HttpClient>(httpClient);
        }
    }
}
