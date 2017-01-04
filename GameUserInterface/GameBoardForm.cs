using System;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Othello.GameEnvironment;
using Othello.Helper;
using Othello.Model;
using Color = Othello.Model.Color;

namespace GameUserInterface
{
    public partial class GameBoardForm : Form
    {
        private readonly Difficulty _difficulty;
        private const int ImageSize = 100;
        private Game _game;
        private int[][] _availableMoves;
        private Color _turn = Color.Black;

        public GameBoardForm(Difficulty difficulty = Difficulty.Beginner)
        {
            InitializeComponent();
            _difficulty = difficulty;
        }

        private void GameBoardForm_Load(object sender, EventArgs e)
        {
            _game = new Game();
            _game.Start((int)GameType.OnlyComputer, _difficulty);
            CreateGameArena(_game.Board.GetState());
        }

        private void CreateGameArena(Piece[,] pieces)
        {
            for (var i = 0; i < pieces.GetLength(0); i++)
            {
                for (var j = 0; j < pieces.GetLength(1); j++)
                {
                    var pictureBox = new PictureBox
                    {
                        Image = new Bitmap(GetImage(pieces[i, j].SeeColor())),
                        Size = new Size(ImageSize, ImageSize),
                        Location = new Point(i * ImageSize, j * ImageSize),
                        Name = i + "_" + j
                    };

                    if (pieces[i, j].SeeColor() == Color.Empty)
                    {
                        pictureBox.MouseEnter += PictureBoxOnMouseEnter;
                        pictureBox.MouseLeave += PictureBoxOnMouseLeave;
                        pictureBox.Click += PictureBoxOnClick;
                    }
                    pictureBox.Paint += PictureBoxOnPaint;
                    pnlGameArena.Controls.Add(pictureBox);
                }
            }

            _availableMoves = _game.PlayerByColor(_turn).GetAvailableMoves(_game.Board.GetState());
        }

        private static void PictureBoxOnPaint(object sender, PaintEventArgs paintEventArgs)
        {
            using (var myFont = new Font("Arial", 14))
            {
                var pictureBox = sender as PictureBox;
                if (pictureBox != null)
                    paintEventArgs.Graphics.DrawString(pictureBox.Name, myFont, Brushes.MediumSeaGreen, new Point(2, 2));
            }
        }

        private void UpdateGameArena(Piece[,] pieces)
        {
            for (var i = 0; i < pieces.GetLength(0); i++)
            {
                for (var j = 0; j < pieces.GetLength(1); j++)
                {
                    var pictureBox = pnlGameArena.Controls.Find(i + "_" + j, true).FirstOrDefault() as PictureBox;
                    pictureBox?.Invoke((MethodInvoker)(() =>
                    {
                        pictureBox.Image = new Bitmap(GetImage(_game.Board.GetState()[i, j].SeeColor()));
                        pictureBox.Invalidate();
                        pictureBox.Update();
                        pictureBox.Refresh();
                        Application.DoEvents();
                    }));
                }
            }

            _turn = _turn.GetOpponentColor();
            _availableMoves = _game.PlayerByColor(_turn).GetAvailableMoves(_game.Board.GetState());
            if (_availableMoves.HasNoAvailableMove())
            {
                _turn = _turn.GetOpponentColor();
                _availableMoves = _game.PlayerByColor(_turn).GetAvailableMoves(_game.Board.GetState());
            }

            if (_availableMoves.HasAvailableMoves())
            {
                var player = _game.PlayerByColor(_turn);
                if (_game.PlayerByColor(_turn).SeePlayerType() == PlayerType.Human) return;

                var game =
                    new Game(
                        new Board(
                            _game.Board.GetState(),
                            _game.Board.GetFinalStateForPlayer(player.SeePlayerColor()),
                            player.SeePlayerColor()),
                        new Player(player.SeePlayerColor(), player.SeePlayerType(), player.SeePlayerDifficulty()),
                        new Player(
                            player.SeePlayerColor().GetOpponentColor(),
                            player.SeePlayerType().GetOpponentType(),
                            player.SeePlayerDifficulty()));

                var point = player.Play(game);
                _game.Board.MakeTheMove(player, point);
                Thread.Sleep((int)_difficulty * 100);
                UpdateGameArena(_game.Board.GetState());
                return;
            }

            var resultForm = new ResultForm(_game);
            resultForm.Show();
        }

        private static Bitmap GetImage(Color color)
        {
            switch (color)
            {
                case Color.White:
                    return Properties.Resources.board_and_white_piece;
                case Color.Black:
                    return Properties.Resources.board_and_black_piece;
                default:
                    return Properties.Resources.board_empty;
            }
        }

        private static Bitmap GetHoverImage(Color color)
        {
            switch (color)
            {
                case Color.White:
                    return Properties.Resources.board_and_white_piece_hover;
                case Color.Black:
                    return Properties.Resources.board_and_black_piece_hover;
                default:
                    return Properties.Resources.board_empty;
            }
        }

        private void PictureBoxOnMouseEnter(object sender, EventArgs eventArgs)
        {
            var pictureBox = sender as PictureBox;

            var ints = pictureBox.Name.Split('_').Select(int.Parse).ToList();

            for (var i = 0; i < _availableMoves.Count(); i++)
            {
                if (ints[0] != _availableMoves[i][0] || ints[1] != _availableMoves[i][1]) continue;

                pictureBox.Image = new Bitmap(GetHoverImage(_turn));
                break;
            }
        }

        private void PictureBoxOnMouseLeave(object sender, EventArgs eventArgs)
        {
            var pictureBox = sender as PictureBox;

            var ints = pictureBox.Name.Split('_').Select(int.Parse).ToList();

            for (var i = 0; i < _availableMoves.Count(); i++)
            {
                if (ints[0] != _availableMoves[i][0] || ints[1] != _availableMoves[i][1]) continue;

                pictureBox.Image = new Bitmap(Properties.Resources.board_empty);
                break;
            }
        }

        private void PictureBoxOnClick(object sender, EventArgs eventArgs)
        {
            var pictureBox = sender as PictureBox;

            var ints = pictureBox.Name.Split('_').Select(int.Parse).ToList();

            for (var i = 0; i < _availableMoves.Count(); i++)
            {
                if (ints[0] != _availableMoves[i][0] || ints[1] != _availableMoves[i][1]) continue;

                pictureBox.Image = new Bitmap(GetImage(_turn));

                _game.Board.MakeTheMove(_game.PlayerByColor(_turn), _availableMoves[i]);
                UpdateGameArena(_game.Board.GetState());

                break;
            }
        }
    }
}
