using Mangers;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using Xunit;

namespace MangersTests
{
    public abstract class TestsBase : IClassFixture<WebApplicationFactory<Startup>>
    {
        protected readonly WebApplicationFactory<Startup> WebApplicationFactory;

        protected readonly HttpClient Client;

        protected TestsBase(WebApplicationFactory<Startup> webApplicationFactory)
        {
            WebApplicationFactory = webApplicationFactory;
            Client = webApplicationFactory.CreateClient();
        }
    }
}
