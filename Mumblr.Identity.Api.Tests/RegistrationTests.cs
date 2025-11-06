using System.Net;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace Mumblr.Identity.Api.Tests;

public class RegistrationTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public RegistrationTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task Post_Register_Returns_501_While_Stubbed()
    {
        // Arrange
        var client = _factory.CreateClient();
        var payload = new
        {
            email = "alice@example.com",
            userName = "alice",
            password = "CorrectHorse1!"
        };

        // Act
        var resp = await client.PostAsJsonAsync("/auth/register", payload);

        // Assert (plain xUnit)
        Assert.Equal(HttpStatusCode.NotImplemented, resp.StatusCode);

        var body = await resp.Content.ReadFromJsonAsync<Dictionary<string, string>>();
        Assert.NotNull(body);
        Assert.True(body!.ContainsKey("message"));
        Assert.Equal("Registration not implemented yet.", body["message"]);
    }
}
