using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace Boggle.Models
{
    public class Game
    {
        public Game(GameSetup setup, sliceofbreadContext df)
        {
            Setup = setup;
            Players = new();
            db = df;
        }
        public GameSetup Setup { get; }
        public bool GameStarted { get; set; }
        public List<Player> Players { get; set; }
        public Player? Winner { get; set; }
        public sliceofbreadContext db { get; set; }
        public async Task<bool> IsWord(string word)
        {
            //var test = word.ToLower();
            return await Task.Run(() => db.Words.Any(x => x.Word == word));
        }

        
        public void IsWinner()
        {
            if (Players[0].Score > Players[1].Score)
            {
                Winner = Players[0];
            }
            else
            {
                Winner = Players[1];
            }

        }

        public static int AddScore(string word)
        {
            int length = word.Length;
            
            if (length == 3)
            {
                return 1;
            }
            else if(length == 4)
            {
                return 2;
            }
            else if (length == 5)
            {
                return 4;
            }
            else if (length == 6)
            {
                return 6;
            }
            else if (length == 7)
            {
                return 8;
            }
            else if (length == 8)
            {
                return 10;
            }
            else
            {
                return 15;
            }
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
            IsWinner();
            Players.Clear();
        }
    }
}

