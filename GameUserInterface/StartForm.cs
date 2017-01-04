using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Othello.Model;

namespace GameUserInterface
{
    public partial class StartForm : Form
    {
        private GameBoardForm gameBoardForm;

        public StartForm()
        {
            InitializeComponent();
            FillGameTypeComboBox();
            FillDifficultyComboBox();
        }

        private void FillGameTypeComboBox()
        {
            var dataSource =
                (from object value in Enum.GetValues(typeof(GameType))
                    select ((GameType) value)
                    into gameType
                    select new ComboBoxItem
                    {
                        Name = gameType.ToString(),
                        Value = (int) gameType
                    }).ToList();

            cbGameType.DataSource = dataSource;
            cbGameType.DisplayMember = "Name";
            cbGameType.ValueMember = "Value";
        }

        private void FillDifficultyComboBox()
        {
            var dataSource =
                (from object value in Enum.GetValues(typeof(Difficulty))
                    select ((Difficulty) value)
                    into difficulty
                    select new ComboBoxItem
                    {
                        Name = difficulty.ToString(),
                        Value = (int) difficulty
                    }).ToList();

            cbDifficulty.DataSource = dataSource;
            cbDifficulty.DisplayMember = "Name";
            cbDifficulty.ValueMember = "Value";
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            gameBoardForm?.Dispose();
            gameBoardForm =
                new GameBoardForm(
                    this,
                    (GameType)int.Parse(cbGameType.SelectedValue.ToString()),
                    (Difficulty) int.Parse(cbDifficulty.SelectedValue.ToString()));
            gameBoardForm.Show();
            Hide();
        }

        private void cbDifficulty_DrawItem(object sender, DrawItemEventArgs e)
        {
            DrawComboBox(sender, e);
        }

        private void cbGameType_DrawItem(object sender, DrawItemEventArgs e)
        {
            DrawComboBox(sender, e);
        }

        private static void DrawComboBox(object sender, DrawItemEventArgs e)
        {
            // By using Sender, one method could handle multiple ComboBoxes
            var cbx = sender as ComboBox;
            if (cbx == null) return;
            // Always draw the background
            e.DrawBackground();

            // Drawing one of the items?
            if (e.Index < 0) return;
            // Set the string alignment.  Choices are Center, Near and Far
            var sf = new StringFormat
            {
                LineAlignment = StringAlignment.Center,
                Alignment = StringAlignment.Center
            };

            // Set the Brush to ComboBox ForeColor to maintain any ComboBox color settings
            // Assumes Brush is solid
            Brush brush = new SolidBrush(cbx.ForeColor);

            // If drawing highlighted selection, change brush
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                brush = SystemBrushes.HighlightText;

            // Draw the string
            e.Graphics.DrawString(((ComboBoxItem)cbx.Items[e.Index]).Name, cbx.Font, brush, e.Bounds, sf);
        }
    }
}
