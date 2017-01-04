namespace GameUserInterface
{
    partial class GameBoardForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlGameArena = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pnlGameArena
            // 
            this.pnlGameArena.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlGameArena.Location = new System.Drawing.Point(0, 0);
            this.pnlGameArena.Name = "pnlGameArena";
            this.pnlGameArena.Size = new System.Drawing.Size(1065, 982);
            this.pnlGameArena.TabIndex = 1;
            // 
            // GameBoardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::GameUserInterface.Properties.Resources.gameboard_background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1302, 982);
            this.Controls.Add(this.pnlGameArena);
            this.MaximizeBox = false;
            this.Name = "GameBoardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Othello Game";
            this.Load += new System.EventHandler(this.GameBoardForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlGameArena;
    }
}