namespace DominoProgram
{
    partial class DominoEngine
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ComboRules = new System.Windows.Forms.ComboBox();
            this.lblPlayers = new System.Windows.Forms.Label();
            this.TotalTokens = new System.Windows.Forms.DomainUpDown();
            this.TotalTokensForPlayer = new System.Windows.Forms.DomainUpDown();
            this.btnInitialitePlayersTokens = new System.Windows.Forms.Button();
            this.distributeTokens = new System.Windows.Forms.Button();
            this.lstMoves = new System.Windows.Forms.ListBox();
            this.lblMoves = new System.Windows.Forms.Label();
            this.lblActuallyTable = new System.Windows.Forms.Label();
            this.btnStartGame = new System.Windows.Forms.Button();
            this.lblGameOver = new System.Windows.Forms.Label();
            this.treePlayers = new System.Windows.Forms.TreeView();
            this.btnNextMove = new System.Windows.Forms.Button();
            this.comboPlayers = new System.Windows.Forms.ComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDone = new System.Windows.Forms.Button();
            this.comboNextTurn = new System.Windows.Forms.ComboBox();
            this.comboGameOver = new System.Windows.Forms.ComboBox();
            this.comboValidMove = new System.Windows.Forms.ComboBox();
            this.comboWinners = new System.Windows.Forms.ComboBox();
            this.comboStartGame = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // ComboRules
            // 
            this.ComboRules.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ComboRules.CausesValidation = false;
            this.ComboRules.FormattingEnabled = true;
            this.ComboRules.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ComboRules.Location = new System.Drawing.Point(444, 56);
            this.ComboRules.Name = "ComboRules";
            this.ComboRules.Size = new System.Drawing.Size(121, 23);
            this.ComboRules.TabIndex = 18;
            this.ComboRules.Text = "Rules";
            // 
            // lblPlayers
            // 
            this.lblPlayers.AutoSize = true;
            this.lblPlayers.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblPlayers.Location = new System.Drawing.Point(24, 37);
            this.lblPlayers.Name = "lblPlayers";
            this.lblPlayers.Size = new System.Drawing.Size(44, 15);
            this.lblPlayers.TabIndex = 3;
            this.lblPlayers.Text = "Players";
            // 
            // TotalTokens
            // 
            this.TotalTokens.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.TotalTokens.ForeColor = System.Drawing.SystemColors.WindowText;
            this.TotalTokens.ImeMode = System.Windows.Forms.ImeMode.On;
            this.TotalTokens.InterceptArrowKeys = false;
            this.TotalTokens.Location = new System.Drawing.Point(571, 55);
            this.TotalTokens.Name = "TotalTokens";
            this.TotalTokens.ReadOnly = true;
            this.TotalTokens.Size = new System.Drawing.Size(132, 23);
            this.TotalTokens.TabIndex = 5;
            this.TotalTokens.Text = "TotalTokens";
            this.TotalTokens.Wrap = true;
            // 
            // TotalTokensForPlayer
            // 
            this.TotalTokensForPlayer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.TotalTokensForPlayer.ForeColor = System.Drawing.SystemColors.WindowText;
            this.TotalTokensForPlayer.ImeMode = System.Windows.Forms.ImeMode.On;
            this.TotalTokensForPlayer.InterceptArrowKeys = false;
            this.TotalTokensForPlayer.Location = new System.Drawing.Point(571, 97);
            this.TotalTokensForPlayer.Name = "TotalTokensForPlayer";
            this.TotalTokensForPlayer.ReadOnly = true;
            this.TotalTokensForPlayer.Size = new System.Drawing.Size(132, 23);
            this.TotalTokensForPlayer.TabIndex = 7;
            this.TotalTokensForPlayer.Text = "TotalTokensForPlayer";
            this.TotalTokensForPlayer.Wrap = true;
            // 
            // btnInitialitePlayersTokens
            // 
            this.btnInitialitePlayersTokens.Location = new System.Drawing.Point(571, 185);
            this.btnInitialitePlayersTokens.Name = "btnInitialitePlayersTokens";
            this.btnInitialitePlayersTokens.Size = new System.Drawing.Size(90, 23);
            this.btnInitialitePlayersTokens.TabIndex = 8;
            this.btnInitialitePlayersTokens.Text = "InitialitePlayersTokens";
            this.btnInitialitePlayersTokens.UseVisualStyleBackColor = true;
            this.btnInitialitePlayersTokens.Click += new System.EventHandler(this.play_butt_Click);
            // 
            // distributeTokens
            // 
            this.distributeTokens.Enabled = false;
            this.distributeTokens.Location = new System.Drawing.Point(571, 233);
            this.distributeTokens.Name = "distributeTokens";
            this.distributeTokens.Size = new System.Drawing.Size(90, 23);
            this.distributeTokens.TabIndex = 9;
            this.distributeTokens.Text = "DistributeTokens";
            this.distributeTokens.UseVisualStyleBackColor = true;
            this.distributeTokens.Click += new System.EventHandler(this.distributeTokens_Click);
            // 
            // lstMoves
            // 
            this.lstMoves.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lstMoves.FormattingEnabled = true;
            this.lstMoves.ItemHeight = 15;
            this.lstMoves.Location = new System.Drawing.Point(270, 55);
            this.lstMoves.Name = "lstMoves";
            this.lstMoves.Size = new System.Drawing.Size(168, 319);
            this.lstMoves.TabIndex = 11;
            // 
            // lblMoves
            // 
            this.lblMoves.AutoSize = true;
            this.lblMoves.BackColor = System.Drawing.Color.Green;
            this.lblMoves.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblMoves.Location = new System.Drawing.Point(292, 37);
            this.lblMoves.Name = "lblMoves";
            this.lblMoves.Size = new System.Drawing.Size(42, 15);
            this.lblMoves.TabIndex = 12;
            this.lblMoves.Text = "Moves";
            // 
            // lblActuallyTable
            // 
            this.lblActuallyTable.AutoSize = true;
            this.lblActuallyTable.BackColor = System.Drawing.Color.Green;
            this.lblActuallyTable.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblActuallyTable.Location = new System.Drawing.Point(24, 369);
            this.lblActuallyTable.Name = "lblActuallyTable";
            this.lblActuallyTable.Size = new System.Drawing.Size(80, 15);
            this.lblActuallyTable.TabIndex = 13;
            this.lblActuallyTable.Text = "ActuallyTable:";
            // 
            // btnStartGame
            // 
            this.btnStartGame.Enabled = false;
            this.btnStartGame.Location = new System.Drawing.Point(571, 141);
            this.btnStartGame.Name = "btnStartGame";
            this.btnStartGame.Size = new System.Drawing.Size(90, 23);
            this.btnStartGame.TabIndex = 14;
            this.btnStartGame.Text = "StartGame";
            this.btnStartGame.UseVisualStyleBackColor = true;
            this.btnStartGame.Visible = false;
            this.btnStartGame.Click += new System.EventHandler(this.btnStartGame_Click);
            // 
            // lblGameOver
            // 
            this.lblGameOver.AutoSize = true;
            this.lblGameOver.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblGameOver.Location = new System.Drawing.Point(318, 9);
            this.lblGameOver.Name = "lblGameOver";
            this.lblGameOver.Size = new System.Drawing.Size(63, 15);
            this.lblGameOver.TabIndex = 15;
            this.lblGameOver.Text = "GameOver";
            // 
            // treePlayers
            // 
            this.treePlayers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.treePlayers.Location = new System.Drawing.Point(12, 56);
            this.treePlayers.Name = "treePlayers";
            this.treePlayers.Size = new System.Drawing.Size(252, 240);
            this.treePlayers.TabIndex = 16;
            // 
            // btnNextMove
            // 
            this.btnNextMove.Enabled = false;
            this.btnNextMove.Location = new System.Drawing.Point(571, 282);
            this.btnNextMove.Name = "btnNextMove";
            this.btnNextMove.Size = new System.Drawing.Size(90, 23);
            this.btnNextMove.TabIndex = 17;
            this.btnNextMove.Text = "NextMove";
            this.btnNextMove.UseVisualStyleBackColor = true;
            this.btnNextMove.Visible = false;
            this.btnNextMove.Click += new System.EventHandler(this.bttnNextMove_Click);
            // 
            // comboPlayers
            // 
            this.comboPlayers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.comboPlayers.FormattingEnabled = true;
            this.comboPlayers.Location = new System.Drawing.Point(12, 302);
            this.comboPlayers.Name = "comboPlayers";
            this.comboPlayers.Size = new System.Drawing.Size(148, 23);
            this.comboPlayers.TabIndex = 19;
            this.comboPlayers.Text = "Players";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(12, 331);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(56, 23);
            this.btnAdd.TabIndex = 20;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDone
            // 
            this.btnDone.Enabled = false;
            this.btnDone.Location = new System.Drawing.Point(74, 331);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(56, 23);
            this.btnDone.TabIndex = 21;
            this.btnDone.Text = "Done";
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // comboNextTurn
            // 
            this.comboNextTurn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.comboNextTurn.FormattingEnabled = true;
            this.comboNextTurn.Location = new System.Drawing.Point(444, 96);
            this.comboNextTurn.Name = "comboNextTurn";
            this.comboNextTurn.Size = new System.Drawing.Size(121, 23);
            this.comboNextTurn.TabIndex = 22;
            this.comboNextTurn.Text = "NextTurn";
            // 
            // comboGameOver
            // 
            this.comboGameOver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.comboGameOver.FormattingEnabled = true;
            this.comboGameOver.Location = new System.Drawing.Point(444, 142);
            this.comboGameOver.Name = "comboGameOver";
            this.comboGameOver.Size = new System.Drawing.Size(121, 23);
            this.comboGameOver.TabIndex = 23;
            this.comboGameOver.Text = "GameOver";
            // 
            // comboValidMove
            // 
            this.comboValidMove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.comboValidMove.FormattingEnabled = true;
            this.comboValidMove.Location = new System.Drawing.Point(444, 185);
            this.comboValidMove.Name = "comboValidMove";
            this.comboValidMove.Size = new System.Drawing.Size(121, 23);
            this.comboValidMove.TabIndex = 24;
            this.comboValidMove.Text = "ValidMove";
            // 
            // comboWinners
            // 
            this.comboWinners.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.comboWinners.FormattingEnabled = true;
            this.comboWinners.Location = new System.Drawing.Point(444, 233);
            this.comboWinners.Name = "comboWinners";
            this.comboWinners.Size = new System.Drawing.Size(121, 23);
            this.comboWinners.TabIndex = 25;
            this.comboWinners.Text = "Winners";
            // 
            // comboStartGame
            // 
            this.comboStartGame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.comboStartGame.FormattingEnabled = true;
            this.comboStartGame.Location = new System.Drawing.Point(444, 283);
            this.comboStartGame.Name = "comboStartGame";
            this.comboStartGame.Size = new System.Drawing.Size(121, 23);
            this.comboStartGame.TabIndex = 26;
            this.comboStartGame.Text = "StarGame";
            // 
            // DominoEngine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackColor = System.Drawing.Color.Green;
            this.ClientSize = new System.Drawing.Size(732, 443);
            this.Controls.Add(this.comboStartGame);
            this.Controls.Add(this.comboWinners);
            this.Controls.Add(this.comboValidMove);
            this.Controls.Add(this.comboGameOver);
            this.Controls.Add(this.comboNextTurn);
            this.Controls.Add(this.btnDone);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.comboPlayers);
            this.Controls.Add(this.ComboRules);
            this.Controls.Add(this.btnNextMove);
            this.Controls.Add(this.treePlayers);
            this.Controls.Add(this.lblGameOver);
            this.Controls.Add(this.btnStartGame);
            this.Controls.Add(this.lblActuallyTable);
            this.Controls.Add(this.lblMoves);
            this.Controls.Add(this.lstMoves);
            this.Controls.Add(this.distributeTokens);
            this.Controls.Add(this.btnInitialitePlayersTokens);
            this.Controls.Add(this.TotalTokensForPlayer);
            this.Controls.Add(this.TotalTokens);
            this.Controls.Add(this.lblPlayers);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "DominoEngine";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Domino";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label lblPlayers;
        private DomainUpDown TotalTokens;
        private DomainUpDown TotalTokensForPlayer;
        private Button btnInitialitePlayersTokens;
        private Button distributeTokens;
        private ListBox lstMoves;
        private Label lblMoves;
        private Label lblActuallyTable;
        private Button btnStartGame;
        private Label lblGameOver;
        private TreeView treePlayers;
        private Button button1;
        private Button btnNextMove;
        private ComboBox comboPlayers;
        private Button btnAdd;
        private Button btnDone;
        private ComboBox ComboRules;
        private ComboBox comboNextTurn;
        private ComboBox comboGameOver;
        private ComboBox comboValidMove;
        private ComboBox comboWinners;
        private ComboBox comboStartGame;
    }
}