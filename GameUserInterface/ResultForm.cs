using System.Windows.Forms;
using Othello.GameEnvironment;
using Othello.Helper;
using Othello.Model;

namespace GameUserInterface
{
    public partial class ResultForm : Form
    {
        private readonly Game _game;

        public ResultForm(Game game)
        {
            InitializeComponent();

            _game = game;
        }

        private void ResultForm_Load(object sender, System.EventArgs e)
        {
            var gameOver = _game.GameOver();

            if (gameOver.GameResult == GameResult.Player1 || gameOver.GameResult == GameResult.Player2)
            {
                var player = _game.PlayerByColor(gameOver.GameResult.GetColor());

                if (player.SeePlayerType() == PlayerType.Human)
                {
                    BackColor = System.Drawing.Color.ForestGreen;
                    ForeColor = System.Drawing.Color.White;
                    ChangeColorOfLabels(System.Drawing.Color.White);
                    lblResult.Text = $"Congratulations, {player.SeePlayerColor().GetName()} You Just Won The Game!";
                }
            }

            if (gameOver.GameResult == GameResult.Even)
            {
                BackColor = System.Drawing.Color.DarkBlue;
                lblResult.Text = "Draw!";
            }
            else
            {
                if (gameOver.GameResult == GameResult.Player1)
                {
                    BackColor = System.Drawing.Color.Black;
                    ForeColor = System.Drawing.Color.White;
                    ChangeColorOfLabels(System.Drawing.Color.White);
                }
                else if (gameOver.GameResult == GameResult.Player2)
                {
                    BackColor = System.Drawing.Color.White;
                    ForeColor = System.Drawing.Color.Black;
                    ChangeColorOfLabels(System.Drawing.Color.Black);
                }
                lblResult.Text = $"{gameOver.GameResult.GetColor().GetName()} Player Won The Game!";
            }

            lblScoreBlack.Text = gameOver.PieceCountBlack.ToString();
            lblScoreWhite.Text = gameOver.PieceCountWhite.ToString();
        }

        private void ChangeColorOfLabels(System.Drawing.Color color)
        {
            foreach (var control in Controls)
            {
                if (control.GetType() != typeof(Label)) continue;
                var label = control as Label;
                if (label != null) label.ForeColor = color;
            }
        }
    }
}
