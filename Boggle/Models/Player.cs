namespace Boggle.Models
{
    public class Player
    {

        public Player(User user)
        {
            User = user;
            Score = 0;
            this.LeftGame = false;
            var temp = new Board();
            GameBoard = temp.BoggleBoard;
            
            WordsGuessed = new();
        }
        public List<List<char>> GameBoard;
        public List<string>? WordsGuessed;
        public User User { get; set; }
        public int Score { get; set; }
        public bool LeftGame { get; set; }
    }
}
