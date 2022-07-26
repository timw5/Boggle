using Microsoft.Azure.SignalR;
using Microsoft.AspNetCore.SignalR;
using Boggle.Models;
using AutoMapper;

namespace Boggle.Hubs
{
    public class BoggleHub: Hub
    {
        private static List<Game> Games = new List<Game>();
        private static List<User> Users = new List<User>();
        private readonly IMapper Mapper;

        public BoggleHub(IMapper mapper)
        {
            Mapper = mapper;
        }   
        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
        }
        
        public void AddUser(string name)
        {
            var user = new User(Context.ConnectionId, name);
            Users.Add(user);
        }

        
    }
}
