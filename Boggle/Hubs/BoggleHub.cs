using Microsoft.AspNetCore.SignalR;
using Boggle.Models;

namespace Boggle.Hubs
{
    public class BoggleHub : Hub
    {
        private static List<Game> Games = new List<Game>();
        private static List<Boggle.Models.User> Users = new List<User>();
        private static sliceofbreadContext? sliceofbreadContext;
        public const string HubURL = "/Game";

        public void AddToGroup(string conn, string name)
        {
            Groups.AddToGroupAsync(conn, name);

        }

        public override async Task OnConnectedAsync()
        {
            sliceofbreadContext = new sliceofbreadContext();
            await Clients.Caller.SendAsync("GetConnectionID", this.Context.ConnectionId);
        }

        public override async Task OnDisconnectedAsync(Exception? e)
        {
            await base.OnDisconnectedAsync(e);
        }

        public string GetConnectionID()
        {
            return Context.ConnectionId;
        }
        
        public void AddUserToGroup(User usr)
        {
            Groups.AddToGroupAsync(usr.ConnectionID, "group1");
            Users.Add(usr);
        }




    }
}
