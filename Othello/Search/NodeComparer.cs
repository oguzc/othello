using System.Collections.Generic;
using Othello.Helper;

namespace Othello.Search
{
    public class NodeComparer : IComparer<Node>
    {
        public int Compare(Node x, Node y)
        {
            return (x.Cost - y.Cost)*100 + (x.Depth - y.Depth)*10 + (x.Point.GetDiffWith(y.Point));
        }
    }
}
