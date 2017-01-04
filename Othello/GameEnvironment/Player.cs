using System.Collections.Generic;
using System.Linq;
using Othello.Helper;
using Othello.Model;
using Othello.Search;

namespace Othello.GameEnvironment
{
    public interface IPlayer
    {
        Color SeePlayerColor();
        PlayerType SeePlayerType();
        Difficulty SeePlayerDifficulty();
        int[][] GetAvailableMoves(Piece[,] states, List<Piece[,]> visitedStates = null);
        int[][] GetAvailableMoves();
        int[] Play(Game game);
    }

    public class Player : IPlayer
    {
        private readonly Color _playerColor;
        private readonly PlayerType _playerType;
        private readonly Difficulty _difficulty;
        private Color OpponentType => _playerColor.GetOpponentColor();
        private int[][] _availableMoves;

        public Player(Color playerColor, PlayerType playerType, Difficulty difficulty = Difficulty.Beginner)
        {
            _playerColor = playerColor;
            _playerType = playerType;
            _difficulty = difficulty;
        }

        public Player(Player player)
        {
            _playerColor = player._playerColor;
            _playerType = player._playerType;
            _difficulty = player._difficulty;

        }

        public Color SeePlayerColor()
        {
            return _playerColor;
        }

        public PlayerType SeePlayerType()
        {
            return _playerType;
        }

        public Difficulty SeePlayerDifficulty()
        {
            return _difficulty;
        }

        public int[][] GetAvailableMoves(Piece[,] states, List<Piece[,]> visitedStates = null)
        {
            _availableMoves = new int[GlobalVariables.TotalCellCount][];

            var ownPieces = GetOwnPieces(states);

            for (var i = 0; i < ownPieces.GetLength(0); i++)
            {
                if (ownPieces[i] == null)
                    break; 

                SeekEast(states, ownPieces[i], visitedStates);
                SeekSouthEast(states, ownPieces[i], visitedStates);
                SeekSouth(states, ownPieces[i], visitedStates);
                SeekSouthWest(states, ownPieces[i], visitedStates);
                SeekWest(states, ownPieces[i], visitedStates);
                SeekNorthWest(states, ownPieces[i], visitedStates);
                SeekNorth(states, ownPieces[i], visitedStates);
                SeekNorthEast(states, ownPieces[i], visitedStates);
            }

            return _availableMoves;
        }

        public bool HasAnyAvaliableMove(Piece[,] states)
        {
            _availableMoves = new int[GlobalVariables.TotalCellCount][];

            var ownPieces = GetOwnPieces(states);

            for (var i = 0; i < ownPieces.Length; i++)
            {
                if (ownPieces[i] == null)
                    break;

                SeekEast(states, ownPieces[i]);
                if (_availableMoves.HasAvailableMoves())
                    return true;
                SeekSouthEast(states, ownPieces[i]);
                if (_availableMoves.HasAvailableMoves())
                    return true;
                SeekSouth(states, ownPieces[i]);
                if (_availableMoves.HasAvailableMoves())
                    return true;
                SeekSouthWest(states, ownPieces[i]);
                if (_availableMoves.HasAvailableMoves())
                    return true;
                SeekWest(states, ownPieces[i]);
                if (_availableMoves.HasAvailableMoves())
                    return true;
                SeekNorthWest(states, ownPieces[i]);
                if (_availableMoves.HasAvailableMoves())
                    return true;
                SeekNorth(states, ownPieces[i]);
                if (_availableMoves.HasAvailableMoves())
                    return true;
                SeekNorthEast(states, ownPieces[i]);
                if (_availableMoves.HasAvailableMoves())
                    return true;
            }

            return false;
        }

        public int[][] GetAvailableMoves()
        {
            return _availableMoves;
        }

        public int[] Play(Game game)
        {
            var aStar =
                new AStar(
                    new Game(
                        new Board(game.Board.GetState(), game.Board.GetFinalStateForPlayer(_playerColor), _playerColor),
                        new Player(game.PlayerByColor(_playerColor)),
                        new Player(game.PlayerByColor(_playerColor.GetOpponentColor()))),
                    _playerColor,
                    (int) _difficulty);

            return aStar.MakeSearch();
        }

        #region private functions

        private int[][] GetOwnPieces(Piece[,] states)
        {
            var pieces = new int[GlobalVariables.TotalCellCount][];
            var counter = 0;

            for (var i = 0; i < states.GetLength(0); i++)
            {
                for (var j = 0; j < states.GetLength(1); j++)
                {
                    if (states[i, j].SeeColor() == _playerColor)
                    {
                        pieces[counter++] = new[] {i, j};
                    }
                }
            }

            return pieces;
        }

        private void Seek(Piece[,] states, int[] piece, int[] factorXY, List<Piece[,]> visitedStates = null)
        {
            var counter = 0;
            for (var i = 1; i <= GlobalVariables.BoardSize; i++)
            {
                var newX = piece[0] + (factorXY[0]*i);
                if (newX.IsOutOfBorder())
                    break;
                var newY = piece[1] + (factorXY[1]*i);
                if (newY.IsOutOfBorder())
                    break;

                var state = states[newX, newY];

                if (state.SeeColor() == _playerColor || (i == 1 && state.SeeColor() == Color.Empty))
                    break;

                if (state.SeeColor() == OpponentType)
                {
                    counter++;
                    continue;
                }

                if (counter > 0 && state.SeeColor() == Color.Empty
                    //&& (visitedStates == null
                        //|| visitedStates.
                        //)
                    )
                {
                    if (!_availableMoves.ContainsSamePoint(newX, newY))
                        _availableMoves[_availableMoves.Count()] = new[] {newX, newY};
                    break;
                }
            }
        }

        private void SeekEast(Piece[,] states, int[] piece, List<Piece[,]> visitedStates = null)
        {
            Seek(states, piece, Direction.East, visitedStates);
        }

        private void SeekSouthEast(Piece[,] states, int[] piece, List<Piece[,]> visitedStates = null)
        {
            Seek(states, piece, Direction.SouthEast, visitedStates);
        }

        private void SeekSouth(Piece[,] states, int[] piece, List<Piece[,]> visitedStates = null)
        {
            Seek(states, piece, Direction.South, visitedStates);
        }

        private void SeekSouthWest(Piece[,] states, int[] piece, List<Piece[,]> visitedStates = null)
        {
            Seek(states, piece, Direction.SouthWest, visitedStates);
        }

        private void SeekWest(Piece[,] states, int[] piece, List<Piece[,]> visitedStates = null)
        {
            Seek(states, piece, Direction.West, visitedStates);
        }

        private void SeekNorthWest(Piece[,] states, int[] piece, List<Piece[,]> visitedStates = null)
        {
            Seek(states, piece, Direction.NorthWest, visitedStates);
        }

        private void SeekNorth(Piece[,] states, int[] piece, List<Piece[,]> visitedStates = null)
        {
            Seek(states, piece, Direction.North, visitedStates);
        }

        private void SeekNorthEast(Piece[,] states, int[] piece, List<Piece[,]> visitedStates = null)
        {
            Seek(states, piece, Direction.NorthEast, visitedStates);
        }

        #endregion
    }
}
