using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Othello.Model;

namespace GameUserInterface
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
            FillDifficultyComboBox();
        }

        private void FillDifficultyComboBox()
        {
            var dataSource =
                (from object value in Enum.GetValues(typeof(Difficulty))
                    select ((Difficulty) value)
                    into difficulty
                    select new DifficultyComboItem
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
            var gameBoardForm = new GameBoardForm(this, (Difficulty) int.Parse(cbDifficulty.SelectedValue.ToString()));
            gameBoardForm.Show();
            Hide();
        }

        private void cbDifficulty_DrawItem(object sender, DrawItemEventArgs e)
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
            e.Graphics.DrawString(((DifficultyComboItem) cbx.Items[e.Index]).Name, cbx.Font, brush, e.Bounds, sf);
        }
    }
}
