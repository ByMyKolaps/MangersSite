using System;
using System.Net;
using System.Threading.Tasks;
using Mangers;
using Mangers.Controllers;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace MangersTests
{
    public class ControllerTests : TestsBase
    {
        public ControllerTests(WebApplicationFactory<Startup> webApplicationFactory) : base(webApplicationFactory)
        {
        }

        [Theory]
        [InlineData(nameof(HomeController.Index), HttpStatusCode.OK)]
        public async Task HomeControllerTests(
            string url,
            HttpStatusCode httpStatusCode)
        {
            var response = await Client.GetAsync($"Home/{url}");
            Assert.Equal(httpStatusCode, response.StatusCode);
        }
        [Theory]
        [InlineData(nameof(AccountController.SignIn), HttpStatusCode.OK)]
        public async Task AccountTests(
            string url,
            HttpStatusCode httpStatusCode)
        {
            var response = await Client.GetAsync($"Account/{url}");
            Assert.Equal(httpStatusCode, response.StatusCode);
        }


    }
}
