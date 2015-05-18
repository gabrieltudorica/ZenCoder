namespace UI
{
    partial class HangmanView
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
            this.hiddenWord = new System.Windows.Forms.Label();
            this.failedGuesses = new System.Windows.Forms.Label();
            this.failedGuessesList = new System.Windows.Forms.Label();
            this.remainingAttempts = new System.Windows.Forms.Label();
            this.remainingAttemptsCount = new System.Windows.Forms.Label();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hanging = new System.Windows.Forms.PictureBox();
            this.howToPlayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hanging)).BeginInit();
            this.SuspendLayout();
            // 
            // hiddenWord
            // 
            this.hiddenWord.AutoSize = true;
            this.hiddenWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hiddenWord.Location = new System.Drawing.Point(41, 101);
            this.hiddenWord.Name = "hiddenWord";
            this.hiddenWord.Size = new System.Drawing.Size(0, 42);
            this.hiddenWord.TabIndex = 0;
            // 
            // failedGuesses
            // 
            this.failedGuesses.AutoSize = true;
            this.failedGuesses.Location = new System.Drawing.Point(37, 317);
            this.failedGuesses.Name = "failedGuesses";
            this.failedGuesses.Size = new System.Drawing.Size(107, 17);
            this.failedGuesses.TabIndex = 1;
            this.failedGuesses.Text = "Failed guesses:";
            // 
            // failedGuessesList
            // 
            this.failedGuessesList.AutoSize = true;
            this.failedGuessesList.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.failedGuessesList.Location = new System.Drawing.Point(150, 317);
            this.failedGuessesList.Name = "failedGuessesList";
            this.failedGuessesList.Size = new System.Drawing.Size(0, 17);
            this.failedGuessesList.TabIndex = 2;
            // 
            // remainingAttempts
            // 
            this.remainingAttempts.AutoSize = true;
            this.remainingAttempts.Location = new System.Drawing.Point(7, 344);
            this.remainingAttempts.Name = "remainingAttempts";
            this.remainingAttempts.Size = new System.Drawing.Size(137, 17);
            this.remainingAttempts.TabIndex = 3;
            this.remainingAttempts.Text = "Remaining attempts:";
            // 
            // remainingAttemptsCount
            // 
            this.remainingAttemptsCount.AutoSize = true;
            this.remainingAttemptsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.remainingAttemptsCount.Location = new System.Drawing.Point(150, 344);
            this.remainingAttemptsCount.Name = "remainingAttemptsCount";
            this.remainingAttemptsCount.Size = new System.Drawing.Size(0, 17);
            this.remainingAttemptsCount.TabIndex = 4;
            // 
            // menu
            // 
            this.menu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem,
            this.howToPlayToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(695, 28);
            this.menu.TabIndex = 5;
            this.menu.Text = "menuStrip1";
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            this.newGameToolStripMenuItem.Size = new System.Drawing.Size(94, 24);
            this.newGameToolStripMenuItem.Text = "New Game";
            this.newGameToolStripMenuItem.Click += new System.EventHandler(this.StartNewGame_Click);
            // 
            // hanging
            // 
            this.hanging.Location = new System.Drawing.Point(409, 78);
            this.hanging.Name = "hanging";
            this.hanging.Size = new System.Drawing.Size(256, 256);
            this.hanging.TabIndex = 6;
            this.hanging.TabStop = false;
            // 
            // howToPlayToolStripMenuItem
            // 
            this.howToPlayToolStripMenuItem.AutoSize = false;
            this.howToPlayToolStripMenuItem.Name = "howToPlayToolStripMenuItem";
            this.howToPlayToolStripMenuItem.Size = new System.Drawing.Size(101, 24);
            this.howToPlayToolStripMenuItem.Text = "How to Play";
            this.howToPlayToolStripMenuItem.Click += new System.EventHandler(this.howToPlayToolStripMenuItem_Click);
            // 
            // HangmanView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 374);
            this.Controls.Add(this.hanging);
            this.Controls.Add(this.remainingAttemptsCount);
            this.Controls.Add(this.remainingAttempts);
            this.Controls.Add(this.failedGuessesList);
            this.Controls.Add(this.failedGuesses);
            this.Controls.Add(this.hiddenWord);
            this.Controls.Add(this.menu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menu;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HangmanView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hangman";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.HangmanUI_KeyDown);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hanging)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label hiddenWord;
        private System.Windows.Forms.Label failedGuesses;
        private System.Windows.Forms.Label failedGuessesList;
        private System.Windows.Forms.Label remainingAttempts;
        private System.Windows.Forms.Label remainingAttemptsCount;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
        private System.Windows.Forms.PictureBox hanging;
        private System.Windows.Forms.ToolStripMenuItem howToPlayToolStripMenuItem;
    }
}

