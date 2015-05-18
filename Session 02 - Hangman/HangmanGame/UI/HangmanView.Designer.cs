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
            this.SuspendLayout();
            // 
            // hiddenWord
            // 
            this.hiddenWord.AutoSize = true;
            this.hiddenWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hiddenWord.Location = new System.Drawing.Point(77, 101);
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
            // HangmanView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 374);
            this.Controls.Add(this.remainingAttemptsCount);
            this.Controls.Add(this.remainingAttempts);
            this.Controls.Add(this.failedGuessesList);
            this.Controls.Add(this.failedGuesses);
            this.Controls.Add(this.hiddenWord);
            this.Name = "HangmanView";
            this.Text = "Hangman";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.HangmanUI_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label hiddenWord;
        private System.Windows.Forms.Label failedGuesses;
        private System.Windows.Forms.Label failedGuessesList;
        private System.Windows.Forms.Label remainingAttempts;
        private System.Windows.Forms.Label remainingAttemptsCount;
    }
}

