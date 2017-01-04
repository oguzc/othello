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
            this.pnlScoreBoard = new System.Windows.Forms.Panel();
            this.lblPlayer2 = new System.Windows.Forms.Label();
            this.lblPlayer1 = new System.Windows.Forms.Label();
            this.btnRestart = new System.Windows.Forms.Button();
            this.lblScoreForPlayer2 = new System.Windows.Forms.Label();
            this.lblScoreForPlayer1 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTurnInfo = new System.Windows.Forms.Label();
            this.pnlScoreBoard.SuspendLayout();
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
            // pnlScoreBoard
            // 
            this.pnlScoreBoard.BackgroundImage = global::GameUserInterface.Properties.Resources.gameboard_background;
            this.pnlScoreBoard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlScoreBoard.Controls.Add(this.lblTurnInfo);
            this.pnlScoreBoard.Controls.Add(this.lblPlayer2);
            this.pnlScoreBoard.Controls.Add(this.lblPlayer1);
            this.pnlScoreBoard.Controls.Add(this.btnRestart);
            this.pnlScoreBoard.Controls.Add(this.lblScoreForPlayer2);
            this.pnlScoreBoard.Controls.Add(this.lblScoreForPlayer1);
            this.pnlScoreBoard.Controls.Add(this.label1);
            this.pnlScoreBoard.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlScoreBoard.Location = new System.Drawing.Point(1071, 0);
            this.pnlScoreBoard.Name = "pnlScoreBoard";
            this.pnlScoreBoard.Size = new System.Drawing.Size(231, 982);
            this.pnlScoreBoard.TabIndex = 2;
            // 
            // lblPlayer2
            // 
            this.lblPlayer2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblPlayer2.AutoSize = true;
            this.lblPlayer2.BackColor = System.Drawing.Color.Transparent;
            this.lblPlayer2.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblPlayer2.ForeColor = System.Drawing.Color.SeaGreen;
            this.lblPlayer2.Location = new System.Drawing.Point(64, 601);
            this.lblPlayer2.Name = "lblPlayer2";
            this.lblPlayer2.Size = new System.Drawing.Size(105, 38);
            this.lblPlayer2.TabIndex = 3;
            this.lblPlayer2.Text = "White";
            this.lblPlayer2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPlayer1
            // 
            this.lblPlayer1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblPlayer1.AutoSize = true;
            this.lblPlayer1.BackColor = System.Drawing.Color.Transparent;
            this.lblPlayer1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblPlayer1.ForeColor = System.Drawing.Color.SeaGreen;
            this.lblPlayer1.Location = new System.Drawing.Point(64, 253);
            this.lblPlayer1.Name = "lblPlayer1";
            this.lblPlayer1.Size = new System.Drawing.Size(103, 38);
            this.lblPlayer1.TabIndex = 0;
            this.lblPlayer1.Text = "Black";
            this.lblPlayer1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnRestart
            // 
            this.btnRestart.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnRestart.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnRestart.Location = new System.Drawing.Point(3, 909);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(216, 61);
            this.btnRestart.TabIndex = 4;
            this.btnRestart.Text = "Restart";
            this.btnRestart.UseVisualStyleBackColor = true;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // lblScoreForPlayer2
            // 
            this.lblScoreForPlayer2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblScoreForPlayer2.AutoSize = true;
            this.lblScoreForPlayer2.BackColor = System.Drawing.Color.Transparent;
            this.lblScoreForPlayer2.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblScoreForPlayer2.ForeColor = System.Drawing.Color.SeaGreen;
            this.lblScoreForPlayer2.Location = new System.Drawing.Point(26, 484);
            this.lblScoreForPlayer2.Name = "lblScoreForPlayer2";
            this.lblScoreForPlayer2.Size = new System.Drawing.Size(193, 135);
            this.lblScoreForPlayer2.TabIndex = 2;
            this.lblScoreForPlayer2.Text = "00";
            this.lblScoreForPlayer2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblScoreForPlayer1
            // 
            this.lblScoreForPlayer1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblScoreForPlayer1.AutoSize = true;
            this.lblScoreForPlayer1.BackColor = System.Drawing.Color.Transparent;
            this.lblScoreForPlayer1.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblScoreForPlayer1.ForeColor = System.Drawing.Color.SeaGreen;
            this.lblScoreForPlayer1.Location = new System.Drawing.Point(26, 276);
            this.lblScoreForPlayer1.Name = "lblScoreForPlayer1";
            this.lblScoreForPlayer1.Size = new System.Drawing.Size(193, 135);
            this.lblScoreForPlayer1.TabIndex = 0;
            this.lblScoreForPlayer1.Text = "00";
            this.lblScoreForPlayer1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.SeaGreen;
            this.label1.Location = new System.Drawing.Point(72, 374);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 135);
            this.label1.TabIndex = 1;
            this.label1.Text = "-";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTurnInfo
            // 
            this.lblTurnInfo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTurnInfo.AutoSize = true;
            this.lblTurnInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblTurnInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTurnInfo.ForeColor = System.Drawing.Color.SeaGreen;
            this.lblTurnInfo.Location = new System.Drawing.Point(42, 9);
            this.lblTurnInfo.Name = "lblTurnInfo";
            this.lblTurnInfo.Size = new System.Drawing.Size(154, 38);
            this.lblTurnInfo.TabIndex = 5;
            this.lblTurnInfo.Text = "Turn info";
            this.lblTurnInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GameBoardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::GameUserInterface.Properties.Resources.gameboard_background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1302, 982);
            this.Controls.Add(this.pnlScoreBoard);
            this.Controls.Add(this.pnlGameArena);
            this.MaximizeBox = false;
            this.Name = "GameBoardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Othello Game";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GameBoardForm_FormClosed);
            this.Load += new System.EventHandler(this.GameBoardForm_Load);
            this.pnlScoreBoard.ResumeLayout(false);
            this.pnlScoreBoard.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlGameArena;
        private System.Windows.Forms.Panel pnlScoreBoard;
        private System.Windows.Forms.Label lblScoreForPlayer1;
        private System.Windows.Forms.Label lblPlayer1;
        private System.Windows.Forms.Label lblScoreForPlayer2;
        private System.Windows.Forms.Label lblPlayer2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.Label lblTurnInfo;
    }
}