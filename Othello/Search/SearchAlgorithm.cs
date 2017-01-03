using System.Collections.Generic;
using Othello.GameEnvironment;
using Othello.Model;

namespace Othello.Search
{
    public abstract class SearchAlgorithm
    {
        protected List<Piece[,]> VisitedStates;
        protected Node Root;
        public string Name;
        public int NodesExpanded, TotalNodesInMemory;
        private Stack<Node> _historyData = new Stack<Node>();

        protected SearchAlgorithm(Game game, Color color)
        {
            Root = new Node(
                new[] {0, 0},
                new Game(
                    new Board(
                        game.Board.GetState(),
                        game.Board.GetFinalStateForPlayer(game.Player1.SeePlayerColor()),
                        color),
                    new Player(game.Player1),
                    new Player(game.Player2)),
                color);
            //VisitedStates = new List<Piece[,]>();
        }

        public abstract int[] MakeSearch();

        protected void AddToVisitedStates(Piece[,] state)
        {
            if (VisitedStates.Contains(state))
                return;
            VisitedStates.Add(state);
        }
    }
}
