using System.Net.Http.Json;
using Xunit;

namespace SmartERPBackend.Tests.Auth
{
    public class AuthTests : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public AuthTests(CustomWebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Register_User_Should_Return_Success()
        {
            // Arrange
            var request = new
            {
                Email = $"test_{Guid.NewGuid()}@mail.com",
                Password = "Test@123",
                FullName = "Test User"
            };

            // Act
            var response = await _client.PostAsJsonAsync("/api/Auth/Register", request);

            // Assert
            var error = await response.Content.ReadAsStringAsync();

            Assert.True(
    response.IsSuccessStatusCode,
    $"API Failed: {response.StatusCode} - {error}"
);
            response.EnsureSuccessStatusCode();
        }
    }
}