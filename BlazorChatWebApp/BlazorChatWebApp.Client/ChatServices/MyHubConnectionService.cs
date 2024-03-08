using ChatModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;

namespace BlazorChatWebApp.Client.ChatServices
{
    public class MyHubConnectionService
    {

    
        private readonly HubConnection _hubConnection;
        public bool IsConnected { get; set; }

        public MyHubConnectionService(NavigationManager navigationManager)
        {
            //Initialize hub connection
            _hubConnection = new HubConnectionBuilder()
        .WithUrl(navigationManager.ToAbsoluteUri("/chathub")).Build();


            _hubConnection.StartAsync();
            GetConnectionState();
        }

        public HubConnection GetHubConnection() => _hubConnection;


        public bool GetConnectionState()
        {
            var hubConnection = GetHubConnection();
            IsConnected = hubConnection != null;    
            return IsConnected;
        }



    }
}
