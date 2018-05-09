using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
///https://gist.github.com/anurse/ecfa679d39380e21b72459f3eca4bbff#file-startup_configureservices-cs
public class ChatHub : Hub
{
    public override async Task OnConnectedAsync()
    {
        await Clients.All.SendAsync("SendAction", Context.ConnectionId, "joined");
    }
    public override async Task OnDisconnectedAsync(Exception exception)
    {
        await Clients.All.SendAsync("SendAction", Context.ConnectionId, "left");
    }

    public async Task Send(string message)
    {
        await Clients.All.SendAsync("SendMessage", Context.ConnectionId, message);
    }
}