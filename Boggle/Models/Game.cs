namespace Boggle.Models
{
    public class Game
    {
        public Game(GameSetup setup)
        {
            Setup = setup;
            Players = new();
            db = new();//access db with db.words....;
        }
        public GameSetup Setup { get; }
        public bool GameStarted { get; set; }
        public List<Player> Players { get; set; }
        public Player? Winner { get; set; }
        public sliceofbreadContext db { get; set; }
        public bool IsWord(string word)
        {
            var temp = db.Words.Where(w => w.Word.ToLower() == word.ToLower()).FirstOrDefault();
            if (temp == null)
            {
                return false;
            }
            return true;
        }
        public void AddPlayer(User user)
        {
            var player = new Player(user);
            Players.Add(player);
        }
        public void RemovePlayer(Player player)
        {
            Players.Remove(player);
        }
        public void StartGame(User p1, User p2)
        {
            GameStarted = true;
            AddPlayer(p1);
            AddPlayer(p2);
        }
        public void EndGame()
        {
            GameStarted = false;
            Players.Clear();
        }
    }
}

