using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;

namespace EB.Sensors.SignalRTests;

public class HubTests
{
    [Fact]
    public async Task reply_with_the_same_message_when_invoke_send_method()
    {
        TestServer server = null;
        var message = "Integration Testing in Microsoft AspNetCore SignalR";
        var echo = string.Empty;
        var webHostBuilder = new WebHostBuilder()
            .ConfigureServices(services =>
            {
                services.AddSignalR();
            })
            .Configure(app =>
            {
                app.UseSignalR(routes => routes.MapHub<EchoHub>("/echo"));
            });

        server = new TestServer(webHostBuilder);
        var connection = new HubConnectionBuilder()
            .WithUrl("http://localhost/echo")
            .Build();

        connection.On<string>("OnMessageRecieved", msg =>
        {
            echo = msg;
        });

        await connection.StartAsync();
        await connection.InvokeAsync("Send", message);

        echo.Should().Be(message);
    }
}