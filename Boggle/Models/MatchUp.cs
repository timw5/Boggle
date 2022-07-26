namespace Boggle.Models
{
    public class MatchUp
    {
        public MatchUp(Player player1, Player player2)
        {
            Players = new List<Player>
            {
                player1,
                player2
            };
        }
        public List<Player> Players { get; set; }
        public Player? Winner { get; set; }
    }
}
