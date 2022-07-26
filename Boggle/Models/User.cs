namespace Boggle.Models
{
    public class User
    {
        public User(string connectionID, string name)
        {
            ConnectionID = connectionID;
            Name = name;
            ConnectedOn = DateTime.Now;
        }

        public string ConnectionID { get; set; }
        public string Name { get; set; }
        public DateTime ConnectedOn { get; set; }


    }
}
