using Othello.Helper;
using Othello.Model;

namespace Othello.GameEnvironment
{
    public interface IPiece
    {
        Color SeeColor();
        void ColorItBlack();
        void ColorItWhite();
        void ReverseColor();
    }

    public class Piece : IPiece
    {
        private Color Color { get; set; }

        public Piece(Color color)
        {
            Color = color;
        }

        public Color SeeColor()
        {
            return Color;
        }

        public void ColorItBlack()
        {
            Color = Color.Black;
        }

        public void ColorItWhite()
        {
            Color = Color.White;
        }

        public void ReverseColor()
        {
            Color = Color.GetOpponentColor();
        }

        #region private functions

        #endregion
    }
}
