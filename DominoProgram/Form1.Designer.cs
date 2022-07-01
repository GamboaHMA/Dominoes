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
            this.lblPlayers = new System.Windows.Forms.Label();
            this.TotalTokens = new System.Windows.Forms.DomainUpDown();
            this.TotalPlayers = new System.Windows.Forms.DomainUpDown();
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
            this.SuspendLayout();
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
            this.TotalTokens.BackColor = System.Drawing.SystemColors.GrayText;
            this.TotalTokens.ForeColor = System.Drawing.SystemColors.Info;
            this.TotalTokens.ImeMode = System.Windows.Forms.ImeMode.On;
            this.TotalTokens.InterceptArrowKeys = false;
            this.TotalTokens.Location = new System.Drawing.Point(586, 96);
            this.TotalTokens.Name = "TotalTokens";
            this.TotalTokens.ReadOnly = true;
            this.TotalTokens.Size = new System.Drawing.Size(134, 23);
            this.TotalTokens.TabIndex = 5;
            this.TotalTokens.Text = "TotalTokens";
            this.TotalTokens.Wrap = true;
            // 
            // TotalPlayers
            // 
            this.TotalPlayers.BackColor = System.Drawing.SystemColors.GrayText;
            this.TotalPlayers.ForeColor = System.Drawing.SystemColors.Info;
            this.TotalPlayers.ImeMode = System.Windows.Forms.ImeMode.On;
            this.TotalPlayers.InterceptArrowKeys = false;
            this.TotalPlayers.Location = new System.Drawing.Point(586, 55);
            this.TotalPlayers.Name = "TotalPlayers";
            this.TotalPlayers.ReadOnly = true;
            this.TotalPlayers.Size = new System.Drawing.Size(134, 23);
            this.TotalPlayers.TabIndex = 6;
            this.TotalPlayers.Text = "TotalPlayers";
            this.TotalPlayers.Wrap = true;
            this.TotalPlayers.SelectedItemChanged += new System.EventHandler(this.TotalPlayers_SelectedItemChanged);
            // 
            // TotalTokensForPlayer
            // 
            this.TotalTokensForPlayer.BackColor = System.Drawing.SystemColors.GrayText;
            this.TotalTokensForPlayer.ForeColor = System.Drawing.SystemColors.Info;
            this.TotalTokensForPlayer.ImeMode = System.Windows.Forms.ImeMode.On;
            this.TotalTokensForPlayer.InterceptArrowKeys = false;
            this.TotalTokensForPlayer.Location = new System.Drawing.Point(586, 141);
            this.TotalTokensForPlayer.Name = "TotalTokensForPlayer";
            this.TotalTokensForPlayer.ReadOnly = true;
            this.TotalTokensForPlayer.Size = new System.Drawing.Size(134, 23);
            this.TotalTokensForPlayer.TabIndex = 7;
            this.TotalTokensForPlayer.Text = "TotalTokensForPlayer";
            this.TotalTokensForPlayer.Wrap = true;
            // 
            // btnInitialitePlayersTokens
            // 
            this.btnInitialitePlayersTokens.Location = new System.Drawing.Point(586, 233);
            this.btnInitialitePlayersTokens.Name = "btnInitialitePlayersTokens";
            this.btnInitialitePlayersTokens.Size = new System.Drawing.Size(134, 23);
            this.btnInitialitePlayersTokens.TabIndex = 8;
            this.btnInitialitePlayersTokens.Text = "InitialitePlayersTokens";
            this.btnInitialitePlayersTokens.UseVisualStyleBackColor = true;
            this.btnInitialitePlayersTokens.Click += new System.EventHandler(this.play_butt_Click);
            // 
            // distributeTokens
            // 
            this.distributeTokens.Enabled = false;
            this.distributeTokens.Location = new System.Drawing.Point(586, 262);
            this.distributeTokens.Name = "distributeTokens";
            this.distributeTokens.Size = new System.Drawing.Size(134, 23);
            this.distributeTokens.TabIndex = 9;
            this.distributeTokens.Text = "DistributeTokens";
            this.distributeTokens.UseVisualStyleBackColor = true;
            this.distributeTokens.Click += new System.EventHandler(this.distributeTokens_Click);
            // 
            // lstMoves
            // 
            this.lstMoves.FormattingEnabled = true;
            this.lstMoves.ItemHeight = 15;
            this.lstMoves.Location = new System.Drawing.Point(12, 222);
            this.lstMoves.Name = "lstMoves";
            this.lstMoves.Size = new System.Drawing.Size(168, 139);
            this.lstMoves.TabIndex = 11;
            // 
            // lblMoves
            // 
            this.lblMoves.AutoSize = true;
            this.lblMoves.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblMoves.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblMoves.Location = new System.Drawing.Point(26, 204);
            this.lblMoves.Name = "lblMoves";
            this.lblMoves.Size = new System.Drawing.Size(42, 15);
            this.lblMoves.TabIndex = 12;
            this.lblMoves.Text = "Moves";
            // 
            // lblActuallyTable
            // 
            this.lblActuallyTable.AutoSize = true;
            this.lblActuallyTable.BackColor = System.Drawing.SystemColors.ControlText;
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
            this.btnStartGame.Location = new System.Drawing.Point(586, 204);
            this.btnStartGame.Name = "btnStartGame";
            this.btnStartGame.Size = new System.Drawing.Size(134, 23);
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
            this.treePlayers.Location = new System.Drawing.Point(12, 55);
            this.treePlayers.Name = "treePlayers";
            this.treePlayers.Size = new System.Drawing.Size(168, 142);
            this.treePlayers.TabIndex = 16;
            // 
            // btnNextMove
            // 
            this.btnNextMove.Enabled = false;
            this.btnNextMove.Location = new System.Drawing.Point(586, 338);
            this.btnNextMove.Name = "btnNextMove";
            this.btnNextMove.Size = new System.Drawing.Size(134, 23);
            this.btnNextMove.TabIndex = 17;
            this.btnNextMove.Text = "NextMove";
            this.btnNextMove.UseVisualStyleBackColor = true;
            this.btnNextMove.Visible = false;
            this.btnNextMove.Click += new System.EventHandler(this.bttnNextMove_Click);
            // 
            // DominoEngine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.ClientSize = new System.Drawing.Size(732, 443);
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
            this.Controls.Add(this.TotalPlayers);
            this.Controls.Add(this.TotalTokens);
            this.Controls.Add(this.lblPlayers);
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
        private DomainUpDown TotalPlayers;
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
    }
}