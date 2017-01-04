using Othello.Helper;
using Othello.Model;

namespace Othello.GameEnvironment
{
    public interface IBoard
    {
        bool MakeTheMove(Player player, int[] point);
        Piece[,] GetState();
        Piece[,] GetFinalStateForPlayer(Color color);
    }

    public class Board : IBoard
    {
        private Piece[,] _states;
        private Piece[,] _finalStatesForPlayer1;
        private Piece[,] _finalStatesForPlayer2;

        public Board()
        {
            InitializeState();
        }

        public Board(Piece[,] state, Piece[,] finalState, Color color)
        {
            EmptyBoard();
            InitializeFinalStates();

            CopyState(_states, state);
            CopyState(color == Color.Black ? _finalStatesForPlayer2 : _finalStatesForPlayer1, finalState);
        }

        private void CopyState(Piece[,] state1, Piece[,] state2)
        {
            for (var i = 0; i < state1.GetLength(0); i++)
            {
                for (var j = 0; j < state1.GetLength(1); j++)
                {
                    state1[i, j] = new Piece(state2[i, j].SeeColor());
                }
            }
        }

        public bool MakeTheMove(Player player, int[] point)
        {
            if(point[0] < 0) return false;

            _states[point[0], point[1]] = new Piece(player.SeePlayerColor());

            var piecesToBeConverted = new int[GlobalVariables.TotalCellCount][];

            SeekEast(point, player.SeePlayerColor(), piecesToBeConverted);
            SeekSouthEast(point, player.SeePlayerColor(), piecesToBeConverted);
            SeekSouth(point, player.SeePlayerColor(), piecesToBeConverted);
            SeekSouthWest(point, player.SeePlayerColor(), piecesToBeConverted);
            SeekWest(point, player.SeePlayerColor(), piecesToBeConverted);
            SeekNorthWest(point, player.SeePlayerColor(), piecesToBeConverted);
            SeekNorth(point, player.SeePlayerColor(), piecesToBeConverted);
            SeekNorthEast(point, player.SeePlayerColor(), piecesToBeConverted);

            
            for (var i = 0; i < piecesToBeConverted.Count(); i++)
            {
                _states[piecesToBeConverted[i][0], piecesToBeConverted[i][1]].ReverseColor();
            }

            return true;
        }

        public Piece[,] GetState()
        {
            return _states;
        }

        public Piece[,] GetFinalStateForPlayer(Color color)
        {
            return color == Color.Black ? _finalStatesForPlayer1 : _finalStatesForPlayer2;
        }

        #region private functions

        private void EmptyBoard()
        {
            _states = new Piece[GlobalVariables.BoardSize, GlobalVariables.BoardSize];

            for (var i = 0; i < _states.GetLength(0); i++)
            {
                for (var j = 0; j < _states.GetLength(1); j++)
                {
                    _states[i, j] = new Piece(Color.Empty);
                }
            }
        }

        private void InitializeState()
        {
            EmptyBoard();

            var halfBoardSize = GlobalVariables.BoardSize/2;

            _states[halfBoardSize - 1, halfBoardSize - 1] = new Piece(Color.White);
            _states[halfBoardSize, halfBoardSize] = new Piece(Color.White);
            _states[halfBoardSize - 1, halfBoardSize] = new Piece(Color.Black);
            _states[halfBoardSize, halfBoardSize - 1] = new Piece(Color.Black);
            
            InitializeFinalStates();
        }

        private void InitializeFinalStates()
        {
            _finalStatesForPlayer1 = new Piece[GlobalVariables.BoardSize, GlobalVariables.BoardSize];
            for (var i = 0; i < _finalStatesForPlayer1.GetLength(0); i++)
            {
                for (var j = 0; j < _finalStatesForPlayer1.GetLength(1); j++)
                {
                    _finalStatesForPlayer1[i, j] = new Piece(Color.White);
                }
            }

            _finalStatesForPlayer2 = new Piece[GlobalVariables.BoardSize, GlobalVariables.BoardSize];
            for (var i = 0; i < _finalStatesForPlayer2.GetLength(0); i++)
            {
                for (var j = 0; j < _finalStatesForPlayer2.GetLength(1); j++)
                {
                    _finalStatesForPlayer2[i, j] = new Piece(Color.Black);
                }
            }
        }

        private void Seek(int[] piece, Color color, int[] factorXY, int[][] piecesToBeConverted)
        {
            var startPointX = piece[0] + factorXY[0];
            var startPointY = piece[1] + factorXY[1];
            var tempPiecesToBeConverted = new int[GlobalVariables.TotalCellCount][];
            for (var i = 1; i < GlobalVariables.BoardSize - Helper.Helper.GetMin(startPointX, startPointY); i++)
            {
                var newX = piece[0] + (factorXY[0]*i);
                if (newX.IsOutOfBorder())
                    break;
                var newY = piece[1] + (factorXY[1]*i);
                if (newY.IsOutOfBorder())
                    break;

                var state = _states[newX, newY];
                if (state.SeeColor() == color.GetOpponentColor() && !piecesToBeConverted.ContainsSamePoint(newX, newY))
                {
                    tempPiecesToBeConverted[tempPiecesToBeConverted.Count()] = new[] {newX, newY};
                    continue;
                }

                if (state.SeeColor() != color) continue;

                for (var j = 0; j < tempPiecesToBeConverted.Count(); j++)
                {
                    piecesToBeConverted[piecesToBeConverted.Count()] = tempPiecesToBeConverted[j];
                }
                break;
            }
        }

        private void SeekEast(int[] piece, Color color, int[][] piecesToBeConverted)
        {
            Seek(piece, color, Direction.East, piecesToBeConverted);
        }

        private void SeekSouthEast(int[] piece, Color color, int[][] piecesToBeConverted)
        {
            Seek(piece, color, Direction.SouthEast, piecesToBeConverted);
        }

        private void SeekSouth(int[] piece, Color color, int[][] piecesToBeConverted)
        {
            Seek(piece, color, Direction.South, piecesToBeConverted);
        }

        private void SeekSouthWest(int[] piece, Color color, int[][] piecesToBeConverted)
        {
            Seek(piece, color, Direction.SouthWest, piecesToBeConverted);
        }

        private void SeekWest(int[] piece, Color color, int[][] piecesToBeConverted)
        {
            Seek(piece, color, Direction.West, piecesToBeConverted);
        }

        private void SeekNorthWest(int[] piece, Color color, int[][] piecesToBeConverted)
        {
            Seek(piece, color, Direction.NorthWest, piecesToBeConverted);
        }

        private void SeekNorth(int[] piece, Color color, int[][] piecesToBeConverted)
        {
            Seek(piece, color, Direction.North, piecesToBeConverted);
        }

        private void SeekNorthEast(int[] piece, Color color, int[][] piecesToBeConverted)
        {
            Seek(piece, color, Direction.NorthEast, piecesToBeConverted);
        }

        #endregion

        public int CalculateEstimatedCost(Color color)
        {
            var cost = 0;

            for (var i = 0; i < _states.GetLength(0); i++)
            {
                for (var j = 0; j < _states.GetLength(1); j++)
                {
                    if (_states[i, j].SeeColor() == color)
                        cost++;
                }
            }

            return cost;
        }
    }
}
