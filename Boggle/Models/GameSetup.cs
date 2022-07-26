namespace Boggle.Models
{
    public class GameSetup
    {
        public GameSetup(string password, int pointsToWin)
        {
            ID = Guid.NewGuid().ToString();
            Password = password;
            PointsToWin = pointsToWin;

        }
        public string ID { get; set; }
        public string Password { get; set; }
        public int PointsToWin { get; set; }
        public int NumberOfPlayers = 2;
        
        
    }
}
