using Othello.GameEnvironment;
using Othello.Helper;
using Othello.Model;

namespace Othello.Search
{
    public class Node
    {
        public Node Parent { get; set; }
        public int[] Point { get; set; }
        public Game Game { get; set; }
        public int Depth { get; set; }
        public int Cost { get; set; }

        public Node(int[] point, Node parent, Player player)
        {
            Point = point;
            Parent = parent;
            Game =
                new Game(
                    new Board(
                        parent.Game.Board.GetState(),
                        parent.Game.Board.GetFinalStateForPlayer(
                            player.SeePlayerColor()),
                        player.SeePlayerColor()),
                    new Player(player),
                    new Player(
                        player.SeePlayerColor().GetOpponentColor(),
                        player.SeePlayerType().GetOpponentType(),
                        player.SeePlayerDifficulty()));
            Depth = parent.Depth + 1;
        }

        public Node(int[] point, Game game, Color color)
        {
            Point = point;
            Game = new Game(
                new Board(game.Board.GetState(), game.Board.GetFinalStateForPlayer(color), color),
                new Player(game.Player1),
                new Player(game.Player2));
        }
    }
}
