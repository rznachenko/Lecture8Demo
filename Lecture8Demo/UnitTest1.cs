using FluentAssertions;
using Flurl.Http;
using NUnit.Framework;

namespace Lecture8Demo
{
    public class Tests
    {
        private static readonly IFlurlClient flurlClient = new FlurlClient();

        [Test]
        public void GetTest()
        {
            var response = "https://jsonplaceholder.typicode.com/posts"
                .GetAsync()
                .Result;
            var responseBody = response.ResponseMessage.Content.ReadAsStringAsync().Result;
        }

        [Test]
        public void GetWithFlurlClient()
        {
            var response = flurlClient.Request("posts").GetAsync().Result;
        }

        [Test]
        public void PostTest()
        {
            var response = "https://jsonplaceholder.typicode.com/posts"
                .PostJsonAsync(new
                {
                    title = "Lecture 8. API",
                    body = "Lfkdk",
                    userId = 1
                });
            var responseBody = response.Result.ResponseMessage.Content.ReadAsStringAsync().Result;
        }
    }
}