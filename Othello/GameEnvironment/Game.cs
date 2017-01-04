using Othello.Model;

namespace Othello.GameEnvironment
{
    public interface IGame
    {
        void Start(int playerCount, Difficulty difficulty = Difficulty.Beginner);
        Player PlayerByColor(Color color);
        GameInfo GameOver();
        GameBasicInfo GetBasicInfo();
    }

    public class Game : IGame
    {
        public Board Board;
        public Player Player1;
        public Player Player2;

        public Game()
        {
            Board = new Board();
        }

        public Game(Board board, Player player1, Player player2)
        {
            Board = board;
            Player1 = player1;
            Player2 = player2;
        }

        public void Start(int playerCount, Difficulty difficulty = Difficulty.Beginner)
        {
            switch (playerCount)
            {
                case (int) GameType.OnlyComputer:
                    Player1 = new Player(Color.Black, PlayerType.Computer, difficulty);
                    Player2 = new Player(Color.White, PlayerType.Computer, difficulty);
                    break;
                case (int) GameType.OnePlayer:
                    Player1 = new Player(Color.Black, PlayerType.Human, difficulty);
                    Player2 = new Player(Color.White, PlayerType.Computer, difficulty);
                    break;
                case (int) GameType.TwoPlayer:
                    Player1 = new Player(Color.Black, PlayerType.Human, difficulty);
                    Player2 = new Player(Color.White, PlayerType.Human, difficulty);
                    break;
                default:
                    Player1 = new Player(Color.Black, PlayerType.Computer, difficulty);
                    Player2 = new Player(Color.White, PlayerType.Computer, difficulty);
                    break;
            }
        }

        public Player PlayerByColor(Color color)
        {
            return Player1 != null && color == Player1.SeePlayerColor() ? Player1 : Player2;
        }

        public GameInfo GameOver()
        {
            if (Player1.HasAnyAvaliableMove(Board.GetState()) || Player2.HasAnyAvaliableMove(Board.GetState()))
                return new GameInfo
                {
                    GameResult = GameResult.NotFinished
                };

            var gameInfo = new GameInfo(GetBasicInfo());

            gameInfo.GameResult =
                gameInfo.PieceCountBlack > gameInfo.PieceCountWhite
                    ? GameResult.Player1
                    : gameInfo.PieceCountWhite > gameInfo.PieceCountBlack ? GameResult.Player2 : GameResult.Even;

            return gameInfo;
        }

        public GameBasicInfo GetBasicInfo()
        {
            var pieces = Board.GetState();
            int player1 = 0, player2 = 0;
            for (var i = 0; i < pieces.GetLength(0); i++)
            {
                for (var j = 0; j < pieces.GetLength(1); j++)
                {
                    var pieceColor = pieces[i, j].SeeColor();
                    if (pieceColor == Player1.SeePlayerColor())
                    {
                        player1++;
                    }
                    else if (pieceColor == Player2.SeePlayerColor())
                    {
                        player2++;
                    }
                }
            }

            return new GameBasicInfo
            {
                PieceCountBlack = player1,
                PieceCountWhite = player2
            };
        }

        #region private functions

        private bool IsNotFinishedYet()
        {
            return Player1 != null && Player1.HasAnyAvaliableMove(Board.GetState()) || Player2.HasAnyAvaliableMove(Board.GetState());
        }

        #endregion
    }
}
