namespace Othello.Model
{
    public class GameInfo : GameBasicInfo
    {
        public GameResult GameResult { get; set; }

        public GameInfo()
        {
            
        }

        public GameInfo(GameBasicInfo gameBasicInfo)
        {
            PieceCountBlack = gameBasicInfo.PieceCountBlack;
            PieceCountWhite = gameBasicInfo.PieceCountWhite;

        }
    }
}
