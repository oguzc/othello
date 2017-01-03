using Othello.GameEnvironment;
using Othello.Model;

namespace TestApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game();
            game.Start((int) GameType.OnePlayer, Difficulty.Beginner);
        }
    }
}
