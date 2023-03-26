namespace NEA
{
    partial class onlinelobbies
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
            this.welcomemsg = new System.Windows.Forms.Label();
            this.LobbyBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Lobby1List = new System.Windows.Forms.ListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.Lobby2List = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Lobby2Btn = new System.Windows.Forms.Button();
            this.LeaveLobby1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // welcomemsg
            // 
            this.welcomemsg.AutoSize = true;
            this.welcomemsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcomemsg.Location = new System.Drawing.Point(33, 31);
            this.welcomemsg.Name = "welcomemsg";
            this.welcomemsg.Size = new System.Drawing.Size(170, 38);
            this.welcomemsg.TabIndex = 0;
            this.welcomemsg.Text = "Welcome!";
            // 
            // LobbyBtn
            // 
            this.LobbyBtn.Location = new System.Drawing.Point(149, 256);
            this.LobbyBtn.Name = "LobbyBtn";
            this.LobbyBtn.Size = new System.Drawing.Size(75, 23);
            this.LobbyBtn.TabIndex = 1;
            this.LobbyBtn.Text = "Join";
            this.LobbyBtn.UseVisualStyleBackColor = true;
            this.LobbyBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(136, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 40);
            this.label1.TabIndex = 2;
            this.label1.Text = "Lobby 1:\r\nPlayers:";
            // 
            // Lobby1List
            // 
            this.Lobby1List.FormattingEnabled = true;
            this.Lobby1List.ItemHeight = 16;
            this.Lobby1List.Location = new System.Drawing.Point(125, 166);
            this.Lobby1List.Name = "Lobby1List";
            this.Lobby1List.Size = new System.Drawing.Size(120, 84);
            this.Lobby1List.TabIndex = 4;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(662, 46);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Refresh";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Lobby2List
            // 
            this.Lobby2List.FormattingEnabled = true;
            this.Lobby2List.ItemHeight = 16;
            this.Lobby2List.Location = new System.Drawing.Point(470, 166);
            this.Lobby2List.Name = "Lobby2List";
            this.Lobby2List.Size = new System.Drawing.Size(120, 84);
            this.Lobby2List.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(481, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 40);
            this.label2.TabIndex = 7;
            this.label2.Text = "Lobby 2:\r\nPlayers:";
            // 
            // Lobby2Btn
            // 
            this.Lobby2Btn.Location = new System.Drawing.Point(494, 256);
            this.Lobby2Btn.Name = "Lobby2Btn";
            this.Lobby2Btn.Size = new System.Drawing.Size(75, 23);
            this.Lobby2Btn.TabIndex = 6;
            this.Lobby2Btn.Text = "Join";
            this.Lobby2Btn.UseVisualStyleBackColor = true;
            // 
            // LeaveLobby1
            // 
            this.LeaveLobby1.Location = new System.Drawing.Point(149, 256);
            this.LeaveLobby1.Name = "LeaveLobby1";
            this.LeaveLobby1.Size = new System.Drawing.Size(75, 23);
            this.LeaveLobby1.TabIndex = 9;
            this.LeaveLobby1.Text = "Leave";
            this.LeaveLobby1.UseVisualStyleBackColor = true;
            this.LeaveLobby1.Visible = false;
            this.LeaveLobby1.Click += new System.EventHandler(this.LeaveLobby1_Click);
            // 
            // onlinelobbies
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.LeaveLobby1);
            this.Controls.Add(this.Lobby2List);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Lobby2Btn);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Lobby1List);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LobbyBtn);
            this.Controls.Add(this.welcomemsg);
            this.Name = "onlinelobbies";
            this.Text = "onlinegame";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label welcomemsg;
        private System.Windows.Forms.Button LobbyBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox Lobby1List;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListBox Lobby2List;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Lobby2Btn;
        private System.Windows.Forms.Button LeaveLobby1;
    }
}