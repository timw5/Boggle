using Microsoft.AspNetCore.SignalR;
using Boggle.Models;

namespace Boggle.Hubs
{
    public class BoggleHub : Hub
    {
        private static List<Game> Games = new List<Game>();
        private static List<Boggle.Models.User> Users = new List<User>();
        private static Dictionary<string, int> groups = new Dictionary<string, int>();
        private static sliceofbreadContext? sliceofbreadContext;
        public const string HubURL = "/Game";

        public override async Task OnConnectedAsync()
        {
            sliceofbreadContext = new sliceofbreadContext();
            await Clients.Caller.SendAsync("GetConnectionID", this.Context.ConnectionId);
        }

        public override async Task OnDisconnectedAsync(Exception? e)
        {
            await base.OnDisconnectedAsync(e);
        }
        
        public void AddUserToGroup(string connID, string name, string password)
        {
            Groups.AddToGroupAsync(connID, password);
            User usr = new User();
            usr.ConnectionID = connID;
            usr.ConnectedOn = DateTime.Now;
            usr.Name = name;
            usr.password = password;
            Users.Add(usr);
            if(FindGroup(password)) {
                groups[password]++;
            }
            else
            {
                groups.Add(password, 1);
            }  
        }

        public bool FindGroup(string password)
        {
            if (groups.ContainsKey(password))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public string GeneratePassword()
        {
            Random rand = new Random();
            string password = "";
            for(int i = 0; i < 8; i++)
            {
                int randomletter = rand.Next(65, 90);
                password += (char)randomletter;
            }
            return password;
        }


    }
}
