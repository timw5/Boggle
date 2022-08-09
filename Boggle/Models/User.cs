using Microsoft.AspNetCore.SignalR.Client;

namespace Boggle.Models
{
    public class User
    {
        public User() 
        {
            ConnectedOn = DateTime.Now;
        }
    
        public User(string connectionID, string name)
        {
            ConnectionID = connectionID;
            Name = name;
            ConnectedOn = DateTime.Now;
        }

        public string? ConnectionID { get; set; }
        public string? Name { get; set; }
        public DateTime ConnectedOn { get; set; }
        public HubConnection? hub { get; set; }
        public string? password { get; set; }
        public string? GroupName { get; set; }


    }
}
