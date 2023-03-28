namespace NEA
{
    partial class gameForm
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
            this.waitmsg = new System.Windows.Forms.Label();
            this.knockbutton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.togglehide = new System.Windows.Forms.Button();
            this.midcard3 = new System.Windows.Forms.PictureBox();
            this.midcard1 = new System.Windows.Forms.PictureBox();
            this.midcard2 = new System.Windows.Forms.PictureBox();
            this.p1card3 = new System.Windows.Forms.PictureBox();
            this.p1card1 = new System.Windows.Forms.PictureBox();
            this.p1card2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.deckcard = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.midcard3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.midcard1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.midcard2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p1card3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p1card1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p1card2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deckcard)).BeginInit();
            this.SuspendLayout();
            // 
            // waitmsg
            // 
            this.waitmsg.AutoSize = true;
            this.waitmsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.waitmsg.Location = new System.Drawing.Point(280, 208);
            this.waitmsg.Name = "waitmsg";
            this.waitmsg.Size = new System.Drawing.Size(443, 42);
            this.waitmsg.TabIndex = 0;
            this.waitmsg.Text = "waiting for other players...";
            // 
            // knockbutton
            // 
            this.knockbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knockbutton.Location = new System.Drawing.Point(772, 229);
            this.knockbutton.Name = "knockbutton";
            this.knockbutton.Size = new System.Drawing.Size(102, 33);
            this.knockbutton.TabIndex = 29;
            this.knockbutton.Text = "Knock?";
            this.knockbutton.UseVisualStyleBackColor = true;
            this.knockbutton.Visible = false;
            this.knockbutton.Click += new System.EventHandler(this.knockbutton_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(725, 130);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 48);
            this.button1.TabIndex = 28;
            this.button1.Text = "Swap all cards";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(401, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(202, 32);
            this.label4.TabIndex = 27;
            this.label4.Text = "Middle Cards:";
            this.label4.Visible = false;
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(401, 259);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(175, 32);
            this.label3.TabIndex = 26;
            this.label3.Text = "Your Cards:";
            this.label3.Visible = false;
            // 
            // togglehide
            // 
            this.togglehide.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.togglehide.Location = new System.Drawing.Point(763, 268);
            this.togglehide.Name = "togglehide";
            this.togglehide.Size = new System.Drawing.Size(123, 71);
            this.togglehide.TabIndex = 25;
            this.togglehide.Text = "Hide Cards \r\n(End Turn)";
            this.togglehide.UseVisualStyleBackColor = true;
            this.togglehide.Visible = false;
            this.togglehide.Click += new System.EventHandler(this.togglehide_Click);
            // 
            // midcard3
            // 
            this.midcard3.Location = new System.Drawing.Point(619, 84);
            this.midcard3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.midcard3.Name = "midcard3";
            this.midcard3.Size = new System.Drawing.Size(100, 149);
            this.midcard3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.midcard3.TabIndex = 24;
            this.midcard3.TabStop = false;
            this.midcard3.Visible = false;
            this.midcard3.Click += new System.EventHandler(this.midcard3_Click);
            // 
            // midcard1
            // 
            this.midcard1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.midcard1.Location = new System.Drawing.Point(407, 84);
            this.midcard1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.midcard1.Name = "midcard1";
            this.midcard1.Size = new System.Drawing.Size(100, 149);
            this.midcard1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.midcard1.TabIndex = 23;
            this.midcard1.TabStop = false;
            this.midcard1.Visible = false;
            this.midcard1.Click += new System.EventHandler(this.midcard1_Click);
            // 
            // midcard2
            // 
            this.midcard2.Location = new System.Drawing.Point(513, 84);
            this.midcard2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.midcard2.Name = "midcard2";
            this.midcard2.Size = new System.Drawing.Size(100, 149);
            this.midcard2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.midcard2.TabIndex = 22;
            this.midcard2.TabStop = false;
            this.midcard2.Visible = false;
            this.midcard2.Click += new System.EventHandler(this.midcard2_Click);
            // 
            // p1card3
            // 
            this.p1card3.Location = new System.Drawing.Point(619, 294);
            this.p1card3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.p1card3.Name = "p1card3";
            this.p1card3.Size = new System.Drawing.Size(100, 149);
            this.p1card3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.p1card3.TabIndex = 21;
            this.p1card3.TabStop = false;
            this.p1card3.Visible = false;
            this.p1card3.Click += new System.EventHandler(this.p1card3_Click);
            // 
            // p1card1
            // 
            this.p1card1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.p1card1.Location = new System.Drawing.Point(407, 294);
            this.p1card1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.p1card1.Name = "p1card1";
            this.p1card1.Size = new System.Drawing.Size(100, 149);
            this.p1card1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.p1card1.TabIndex = 20;
            this.p1card1.TabStop = false;
            this.p1card1.Visible = false;
            this.p1card1.Click += new System.EventHandler(this.p1card1_Click);
            // 
            // p1card2
            // 
            this.p1card2.Location = new System.Drawing.Point(513, 294);
            this.p1card2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.p1card2.Name = "p1card2";
            this.p1card2.Size = new System.Drawing.Size(100, 149);
            this.p1card2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.p1card2.TabIndex = 19;
            this.p1card2.TabStop = false;
            this.p1card2.Visible = false;
            this.p1card2.Click += new System.EventHandler(this.p1card2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(157, 233);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 58);
            this.label1.TabIndex = 18;
            this.label1.Text = "\r\nDeal";
            this.label1.Visible = false;
            // 
            // deckcard
            // 
            this.deckcard.Image = global::NEA.Properties.Resources.card_back_black;
            this.deckcard.InitialImage = global::NEA.Properties.Resources.card_back_black;
            this.deckcard.Location = new System.Drawing.Point(119, 294);
            this.deckcard.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.deckcard.Name = "deckcard";
            this.deckcard.Size = new System.Drawing.Size(145, 188);
            this.deckcard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.deckcard.TabIndex = 17;
            this.deckcard.TabStop = false;
            this.deckcard.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // gameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1005, 533);
            this.Controls.Add(this.knockbutton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.togglehide);
            this.Controls.Add(this.midcard3);
            this.Controls.Add(this.midcard1);
            this.Controls.Add(this.midcard2);
            this.Controls.Add(this.p1card3);
            this.Controls.Add(this.p1card1);
            this.Controls.Add(this.p1card2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.deckcard);
            this.Controls.Add(this.waitmsg);
            this.Name = "gameForm";
            this.Text = "gameForm";
            ((System.ComponentModel.ISupportInitialize)(this.midcard3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.midcard1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.midcard2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p1card3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p1card1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p1card2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deckcard)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label waitmsg;
        private System.Windows.Forms.Button knockbutton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button togglehide;
        private System.Windows.Forms.PictureBox midcard3;
        private System.Windows.Forms.PictureBox midcard1;
        private System.Windows.Forms.PictureBox midcard2;
        public System.Windows.Forms.PictureBox p1card3;
        public System.Windows.Forms.PictureBox p1card1;
        public System.Windows.Forms.PictureBox p1card2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox deckcard;
        private System.Windows.Forms.Timer timer1;
    }
}