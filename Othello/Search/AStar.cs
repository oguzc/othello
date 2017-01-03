using System.Collections.Generic;
using System.Linq;
using Othello.GameEnvironment;
using Othello.Helper;
using Othello.Model;

namespace Othello.Search
{
    public class AStar : SearchAlgorithm
    {
        private readonly Color _color;
        private readonly int _depth;
        private Queue<Node> _searchQueue;

        public AStar(Game game, Color color, int depth) : base(game, color)
        {
            _color = color;
            _depth = depth;
            _searchQueue = new Queue<Node>();
        }

        public override int[] MakeSearch()
        {
            _searchQueue.Clear();

            var nodeComparer = new NodeComparer();
            _searchQueue.Enqueue(Root);

            Node current = null;
            var counter = 0;
            while (_searchQueue.Count != 0 && (current == null || (_depth > 0 && current.Depth < _depth)))
            {
                current = _searchQueue.Dequeue();

                var player = current.Game.PlayerByColor(_color);

                if (counter > 0)
                {
                    current.Game.Board.MakeTheMove(player, current.Point);
                    NodesExpanded++;

                    var gameOver = current.Game.GameOver();
                    if (gameOver.Color == _color)
                        return GetParentPoint(current);
                    if (gameOver.Color == _color.GetOpponentColor())
                        return new[] {-1};
                }

                if (current.Cost>0)
                {
                    //Move opponent
                    var aStar =
                        new AStarBasic(
                            new Game(
                                new Board(current.Game.Board.GetState(),
                                    current.Game.Board.GetFinalStateForPlayer(_color.GetOpponentColor()),
                                    _color.GetOpponentColor()),
                                new Player(current.Game.PlayerByColor(_color.GetOpponentColor())),
                                new Player(current.Game.PlayerByColor(_color))),
                            _color.GetOpponentColor(),
                            1);
                    var makeSearch = aStar.MakeSearch();

                    current.Game.Board.MakeTheMove(current.Game.PlayerByColor(_color.GetOpponentColor()), makeSearch);
                }

                foreach (var childNode in
                    from possibleMovement in
                        player.GetAvailableMoves(current.Game.Board.GetState()).Where(x => x != null)
                    select new Node(possibleMovement, current, player))
                {
                    //create node
                    childNode.Cost = childNode.Parent.Cost +
                                     childNode.Game.Board.CalculateEstimatedCost(
                                         _color.GetOpponentColor());
                    _searchQueue.Enqueue(childNode);
                    TotalNodesInMemory++;
                }
                var list = _searchQueue.ToList();
                list.Sort(nodeComparer);
                _searchQueue = new Queue<Node>(list);

                counter++;
            }

            return GetParentPoint(current);
        }

        private static int[] GetParentPoint(Node current)
        {
            while (true)
            {
                if (current.Parent != null && current.Parent.Depth > 0)
                {
                    current = current.Parent;
                }
                else
                {
                    return current.Point;
                }
            }
        }
    }
}
