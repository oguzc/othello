namespace GameUserInterface
{
    partial class ResultForm
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
            this.lblResult = new System.Windows.Forms.Label();
            this.lblScoreWhite = new System.Windows.Forms.Label();
            this.lblDash = new System.Windows.Forms.Label();
            this.lblGamerWhite = new System.Windows.Forms.Label();
            this.lblGamerBlack = new System.Windows.Forms.Label();
            this.lblScoreBlack = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblResult
            // 
            this.lblResult.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblResult.Location = new System.Drawing.Point(0, 0);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(757, 55);
            this.lblResult.TabIndex = 0;
            this.lblResult.Text = "Tebrikler reyiz oyuncu, kazandınız!";
            this.lblResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblScoreWhite
            // 
            this.lblScoreWhite.AutoSize = true;
            this.lblScoreWhite.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblScoreWhite.Location = new System.Drawing.Point(387, 98);
            this.lblScoreWhite.Name = "lblScoreWhite";
            this.lblScoreWhite.Size = new System.Drawing.Size(191, 135);
            this.lblScoreWhite.TabIndex = 4;
            this.lblScoreWhite.Text = "00";
            // 
            // lblDash
            // 
            this.lblDash.AutoSize = true;
            this.lblDash.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblDash.Location = new System.Drawing.Point(345, 120);
            this.lblDash.Name = "lblDash";
            this.lblDash.Size = new System.Drawing.Size(66, 91);
            this.lblDash.TabIndex = 5;
            this.lblDash.Text = "-";
            // 
            // lblGamerWhite
            // 
            this.lblGamerWhite.AutoSize = true;
            this.lblGamerWhite.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblGamerWhite.Location = new System.Drawing.Point(583, 127);
            this.lblGamerWhite.Name = "lblGamerWhite";
            this.lblGamerWhite.Size = new System.Drawing.Size(134, 78);
            this.lblGamerWhite.TabIndex = 6;
            this.lblGamerWhite.Text = "Beyaz\r\nOyuncu";
            this.lblGamerWhite.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblGamerBlack
            // 
            this.lblGamerBlack.AutoSize = true;
            this.lblGamerBlack.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblGamerBlack.Location = new System.Drawing.Point(42, 127);
            this.lblGamerBlack.Name = "lblGamerBlack";
            this.lblGamerBlack.Size = new System.Drawing.Size(134, 78);
            this.lblGamerBlack.TabIndex = 1;
            this.lblGamerBlack.Text = "Siyah\r\nOyuncu";
            this.lblGamerBlack.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblScoreBlack
            // 
            this.lblScoreBlack.AutoSize = true;
            this.lblScoreBlack.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblScoreBlack.Location = new System.Drawing.Point(181, 98);
            this.lblScoreBlack.Name = "lblScoreBlack";
            this.lblScoreBlack.Size = new System.Drawing.Size(191, 135);
            this.lblScoreBlack.TabIndex = 3;
            this.lblScoreBlack.Text = "00";
            // 
            // ResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 266);
            this.Controls.Add(this.lblGamerWhite);
            this.Controls.Add(this.lblDash);
            this.Controls.Add(this.lblScoreWhite);
            this.Controls.Add(this.lblScoreBlack);
            this.Controls.Add(this.lblGamerBlack);
            this.Controls.Add(this.lblResult);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ResultForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ResultForm";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ResultForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label lblScoreWhite;
        private System.Windows.Forms.Label lblDash;
        private System.Windows.Forms.Label lblGamerWhite;
        private System.Windows.Forms.Label lblGamerBlack;
        private System.Windows.Forms.Label lblScoreBlack;
    }
}