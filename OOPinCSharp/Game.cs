using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPinCSharp
{
    public abstract class GameParent
    {
        private static decimal count; protected string? Gamename;
        protected GameParent() { }
        public string CompeteWithFriends(string name)
        {
            return "Hello Mr."+ name + ", You started competing with Friends";
        }
    }
    public interface IGameParent
    {
        public string CompeteWithFriends(string name)
        {
            return "Hello Mr." + name + ", You started competing with Friends";
        }
    }
    public class Suduko
    {
        public string SolvePuzzles(int counts)
        {
            return "Hello Player, you have registered to solve" + counts + " puzzles.";
        }
    }
    //public class GameConcrete : GameParent, Suduko
    //{

    //} 
    public  interface IGame
    { public string PlayGame(string name);
    }
    public interface IFootBallGame {  public string PlayFootBallGame(string name);}
    public class SudoGame : IGame, IFootBallGame
    {   public SudoGame() { }
        public string PlayGame(string name)
        {
            return $"Hello Mr/s. {name.ToUpper()}, your Game has Started: ";
        }
        public string PlayFootBallGame(string name)
        {
            return $"Hi {name} You have started playing a football game";
        }
        public static void MainD()
        {
            Console.WriteLine(new SudoGame().PlayGame("Anwar"));
            Console.WriteLine(new SudoGame().PlayFootBallGame("Anwar"));
        }
    }  
}
