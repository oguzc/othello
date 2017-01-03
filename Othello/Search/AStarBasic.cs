using System.Collections.Generic;
using System.Linq;
using Othello.GameEnvironment;
using Othello.Helper;
using Othello.Model;

namespace Othello.Search
{
    public class AStarBasic : SearchAlgorithm
    {
        private readonly Color _color;
        private readonly int _depth;
        private Queue<Node> _searchQueue;

        public AStarBasic(Game game, Color color, int depth) : base(game, color)
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
                    //AddToVisitedStates(current.Game.Board.GetState());
                    var gameOver = current.Game.GameOver();
                    if (gameOver.Color == _color)
                        return GetParentPoint(current);
                    if (gameOver.Color == _color.GetOpponentColor())
                        return new[] {-1};
                }

                foreach (var childNode in
                    from possibleMovement in
                        player.GetAvailableMoves(current.Game.Board.GetState(), VisitedStates).Where(x => x != null)
                    select new Node(possibleMovement, current, player))
                {
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
            if (current.Parent != null && current.Parent.Depth > 0)
            {
                GetParentPoint(current.Parent);
            }
            return current.Point;
        }
    }
}
