using DistanceCalculator.Core.Commands;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.WebUtilities;
using System.Net;

namespace DistanceCalculator.IntegrationTests.Controllers
{
    public class DistanceCalculatorApiTest : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public DistanceCalculatorApiTest(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("DistanceCalculator")]
        public async Task Get_EndpointReturnsSuccess(string url)
        {
            var queryParams = new Dictionary<string, string?>()
            {
                { "coordinatesStart", "53.297975, -6.372663" },
                { "coordinatesEnd", "41.385101, -81.440440" },
                { "radius", "6371" },
            };

            var requestUrl = QueryHelpers.AddQueryString(url, queryParams);

            var client = _factory.CreateClient();

            var response = await client.GetAsync(requestUrl);

            Assert.True(response.IsSuccessStatusCode);
        }

        [Theory]
        [InlineData("DistanceCalculator")]
        public async Task Get_InvalidCommand_EndpointReturnsBadRequest(string url)
        {
            var queryParams = new Dictionary<string, string?>()
            {
                { "coordinatesStart", "" },
                { "coordinatesEnd", "41.385101, -81.440440" },
                { "radius", "6371" },
            };

            var requestUrl = QueryHelpers.AddQueryString(url, queryParams);

            var client = _factory.CreateClient();

            var response = await client.GetAsync(requestUrl);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Theory]
        [InlineData("DistanceCalculator")]
        public async Task Get_ServiceValidationError_EndpointReturnsBadRequest(string url)
        {
            var queryParams = new Dictionary<string, string?>()
            {
                { "coordinatesStart", "a,-6.372663" },
                { "coordinatesEnd", "41.385101, -81.440440" },
                { "radius", "6371" },
            };

            var requestUrl = QueryHelpers.AddQueryString(url, queryParams);

            var client = _factory.CreateClient();

            var response = await client.GetAsync(requestUrl);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}