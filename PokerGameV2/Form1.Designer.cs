namespace PokerGameV2
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            this.btnCallCheck = new System.Windows.Forms.Button();
            this.btnFold = new System.Windows.Forms.Button();
            this.btnCards = new System.Windows.Forms.Button();
            this.pcbGame2 = new System.Windows.Forms.PictureBox();
            this.pcbGame3 = new System.Windows.Forms.PictureBox();
            this.pcbGame4 = new System.Windows.Forms.PictureBox();
            this.pcbGame5 = new System.Windows.Forms.PictureBox();
            this.pcbPlayer1 = new System.Windows.Forms.PictureBox();
            this.pcbPlayer2 = new System.Windows.Forms.PictureBox();
            this.pcbGame1 = new System.Windows.Forms.PictureBox();
            this.btnBet = new System.Windows.Forms.Button();
            this.btnReady = new System.Windows.Forms.Button();
            this.lblPotMoney = new System.Windows.Forms.Label();
            this.lblHighestBet = new System.Windows.Forms.Label();
            this.lblYourBet = new System.Windows.Forms.Label();
            this.lblUserMoney = new System.Windows.Forms.Label();
            this.RefreshTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pcbGame2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbGame3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbGame4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbGame5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbPlayer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbPlayer2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbGame1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCallCheck
            // 
            this.btnCallCheck.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCallCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCallCheck.ForeColor = System.Drawing.Color.White;
            this.btnCallCheck.Location = new System.Drawing.Point(39, 323);
            this.btnCallCheck.Margin = new System.Windows.Forms.Padding(2);
            this.btnCallCheck.Name = "btnCallCheck";
            this.btnCallCheck.Size = new System.Drawing.Size(86, 45);
            this.btnCallCheck.TabIndex = 7;
            this.btnCallCheck.Text = "Check";
            this.btnCallCheck.UseVisualStyleBackColor = true;
            this.btnCallCheck.Click += new System.EventHandler(this.btnCallCheck_Click);
            // 
            // btnFold
            // 
            this.btnFold.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFold.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFold.ForeColor = System.Drawing.Color.White;
            this.btnFold.Location = new System.Drawing.Point(483, 323);
            this.btnFold.Margin = new System.Windows.Forms.Padding(2);
            this.btnFold.Name = "btnFold";
            this.btnFold.Size = new System.Drawing.Size(86, 45);
            this.btnFold.TabIndex = 8;
            this.btnFold.Text = "Fold";
            this.btnFold.UseVisualStyleBackColor = true;
            this.btnFold.Click += new System.EventHandler(this.btnFold_Click);
            // 
            // btnCards
            // 
            this.btnCards.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCards.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCards.ForeColor = System.Drawing.Color.White;
            this.btnCards.Location = new System.Drawing.Point(39, 262);
            this.btnCards.Margin = new System.Windows.Forms.Padding(2);
            this.btnCards.Name = "btnCards";
            this.btnCards.Size = new System.Drawing.Size(86, 45);
            this.btnCards.TabIndex = 9;
            this.btnCards.Text = "Check Cards";
            this.btnCards.UseVisualStyleBackColor = true;
            this.btnCards.Click += new System.EventHandler(this.btnCards_Click);
            // 
            // pcbGame2
            // 
            this.pcbGame2.InitialImage = null;
            this.pcbGame2.Location = new System.Drawing.Point(139, 31);
            this.pcbGame2.Margin = new System.Windows.Forms.Padding(2);
            this.pcbGame2.Name = "pcbGame2";
            this.pcbGame2.Size = new System.Drawing.Size(101, 147);
            this.pcbGame2.TabIndex = 15;
            this.pcbGame2.TabStop = false;
            // 
            // pcbGame3
            // 
            this.pcbGame3.InitialImage = null;
            this.pcbGame3.Location = new System.Drawing.Point(256, 31);
            this.pcbGame3.Margin = new System.Windows.Forms.Padding(2);
            this.pcbGame3.Name = "pcbGame3";
            this.pcbGame3.Size = new System.Drawing.Size(101, 147);
            this.pcbGame3.TabIndex = 14;
            this.pcbGame3.TabStop = false;
            // 
            // pcbGame4
            // 
            this.pcbGame4.InitialImage = null;
            this.pcbGame4.Location = new System.Drawing.Point(375, 31);
            this.pcbGame4.Margin = new System.Windows.Forms.Padding(2);
            this.pcbGame4.Name = "pcbGame4";
            this.pcbGame4.Size = new System.Drawing.Size(101, 147);
            this.pcbGame4.TabIndex = 13;
            this.pcbGame4.TabStop = false;
            // 
            // pcbGame5
            // 
            this.pcbGame5.InitialImage = null;
            this.pcbGame5.Location = new System.Drawing.Point(502, 31);
            this.pcbGame5.Margin = new System.Windows.Forms.Padding(2);
            this.pcbGame5.Name = "pcbGame5";
            this.pcbGame5.Size = new System.Drawing.Size(101, 147);
            this.pcbGame5.TabIndex = 12;
            this.pcbGame5.TabStop = false;
            // 
            // pcbPlayer1
            // 
            this.pcbPlayer1.InitialImage = null;
            this.pcbPlayer1.Location = new System.Drawing.Point(196, 199);
            this.pcbPlayer1.Margin = new System.Windows.Forms.Padding(2);
            this.pcbPlayer1.Name = "pcbPlayer1";
            this.pcbPlayer1.Size = new System.Drawing.Size(101, 147);
            this.pcbPlayer1.TabIndex = 11;
            this.pcbPlayer1.TabStop = false;
            // 
            // pcbPlayer2
            // 
            this.pcbPlayer2.InitialImage = null;
            this.pcbPlayer2.Location = new System.Drawing.Point(336, 199);
            this.pcbPlayer2.Margin = new System.Windows.Forms.Padding(2);
            this.pcbPlayer2.Name = "pcbPlayer2";
            this.pcbPlayer2.Size = new System.Drawing.Size(101, 147);
            this.pcbPlayer2.TabIndex = 10;
            this.pcbPlayer2.TabStop = false;
            // 
            // pcbGame1
            // 
            this.pcbGame1.InitialImage = null;
            this.pcbGame1.Location = new System.Drawing.Point(23, 31);
            this.pcbGame1.Margin = new System.Windows.Forms.Padding(2);
            this.pcbGame1.Name = "pcbGame1";
            this.pcbGame1.Size = new System.Drawing.Size(101, 147);
            this.pcbGame1.TabIndex = 0;
            this.pcbGame1.TabStop = false;
            // 
            // btnBet
            // 
            this.btnBet.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBet.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBet.ForeColor = System.Drawing.Color.White;
            this.btnBet.Location = new System.Drawing.Point(483, 262);
            this.btnBet.Margin = new System.Windows.Forms.Padding(2);
            this.btnBet.Name = "btnBet";
            this.btnBet.Size = new System.Drawing.Size(86, 45);
            this.btnBet.TabIndex = 16;
            this.btnBet.Text = "Bet";
            this.btnBet.UseVisualStyleBackColor = true;
            this.btnBet.Click += new System.EventHandler(this.btnBet_Click);
            // 
            // btnReady
            // 
            this.btnReady.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReady.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReady.ForeColor = System.Drawing.Color.White;
            this.btnReady.Location = new System.Drawing.Point(246, 271);
            this.btnReady.Margin = new System.Windows.Forms.Padding(2);
            this.btnReady.Name = "btnReady";
            this.btnReady.Size = new System.Drawing.Size(124, 75);
            this.btnReady.TabIndex = 17;
            this.btnReady.Text = "Ready Up";
            this.btnReady.UseVisualStyleBackColor = true;
            this.btnReady.Click += new System.EventHandler(this.btnReady_Click);
            // 
            // lblPotMoney
            // 
            this.lblPotMoney.AutoSize = true;
            this.lblPotMoney.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPotMoney.ForeColor = System.Drawing.Color.White;
            this.lblPotMoney.Location = new System.Drawing.Point(479, 199);
            this.lblPotMoney.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPotMoney.Name = "lblPotMoney";
            this.lblPotMoney.Size = new System.Drawing.Size(0, 20);
            this.lblPotMoney.TabIndex = 18;
            // 
            // lblHighestBet
            // 
            this.lblHighestBet.AutoSize = true;
            this.lblHighestBet.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHighestBet.ForeColor = System.Drawing.Color.White;
            this.lblHighestBet.Location = new System.Drawing.Point(35, 199);
            this.lblHighestBet.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblHighestBet.Name = "lblHighestBet";
            this.lblHighestBet.Size = new System.Drawing.Size(0, 20);
            this.lblHighestBet.TabIndex = 19;
            // 
            // lblYourBet
            // 
            this.lblYourBet.AutoSize = true;
            this.lblYourBet.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYourBet.ForeColor = System.Drawing.Color.White;
            this.lblYourBet.Location = new System.Drawing.Point(35, 228);
            this.lblYourBet.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblYourBet.Name = "lblYourBet";
            this.lblYourBet.Size = new System.Drawing.Size(0, 20);
            this.lblYourBet.TabIndex = 20;
            // 
            // lblUserMoney
            // 
            this.lblUserMoney.AutoSize = true;
            this.lblUserMoney.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserMoney.ForeColor = System.Drawing.Color.White;
            this.lblUserMoney.Location = new System.Drawing.Point(479, 228);
            this.lblUserMoney.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUserMoney.Name = "lblUserMoney";
            this.lblUserMoney.Size = new System.Drawing.Size(0, 20);
            this.lblUserMoney.TabIndex = 21;
            // 
            // RefreshTimer
            // 
            this.RefreshTimer.Tick += new System.EventHandler(this.RefreshTimer_Tick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGreen;
            this.ClientSize = new System.Drawing.Size(640, 415);
            this.Controls.Add(this.lblUserMoney);
            this.Controls.Add(this.lblYourBet);
            this.Controls.Add(this.lblHighestBet);
            this.Controls.Add(this.lblPotMoney);
            this.Controls.Add(this.btnReady);
            this.Controls.Add(this.btnBet);
            this.Controls.Add(this.pcbGame2);
            this.Controls.Add(this.pcbGame3);
            this.Controls.Add(this.pcbGame4);
            this.Controls.Add(this.pcbGame5);
            this.Controls.Add(this.pcbPlayer1);
            this.Controls.Add(this.pcbPlayer2);
            this.Controls.Add(this.btnCards);
            this.Controls.Add(this.btnFold);
            this.Controls.Add(this.btnCallCheck);
            this.Controls.Add(this.pcbGame1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "boop";
            ((System.ComponentModel.ISupportInitialize)(this.pcbGame2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbGame3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbGame4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbGame5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbPlayer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbPlayer2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbGame1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pcbGame1;
        private System.Windows.Forms.Button btnCallCheck;
        private System.Windows.Forms.Button btnFold;
        private System.Windows.Forms.Button btnCards;
        private System.Windows.Forms.PictureBox pcbPlayer2;
        private System.Windows.Forms.PictureBox pcbPlayer1;
        private System.Windows.Forms.PictureBox pcbGame5;
        private System.Windows.Forms.PictureBox pcbGame4;
        private System.Windows.Forms.PictureBox pcbGame3;
        private System.Windows.Forms.PictureBox pcbGame2;
        private System.Windows.Forms.Button btnBet;
        private System.Windows.Forms.Button btnReady;
        private System.Windows.Forms.Label lblPotMoney;
        private System.Windows.Forms.Label lblHighestBet;
        private System.Windows.Forms.Label lblYourBet;
        private System.Windows.Forms.Label lblUserMoney;
        private System.Windows.Forms.Timer RefreshTimer;
    }
}

