namespace NEA
{
    partial class Form1
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
            this.deckcard = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.p1card2 = new System.Windows.Forms.PictureBox();
            this.p1card1 = new System.Windows.Forms.PictureBox();
            this.p1card3 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.midcard3 = new System.Windows.Forms.PictureBox();
            this.midcard1 = new System.Windows.Forms.PictureBox();
            this.midcard2 = new System.Windows.Forms.PictureBox();
            this.togglehide = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.knockButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.deckcard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p1card2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p1card1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p1card3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.midcard3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.midcard1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.midcard2)).BeginInit();
            this.SuspendLayout();
            // 
            // deckcard
            // 
            this.deckcard.Image = global::NEA.Properties.Resources.deal;
            this.deckcard.InitialImage = global::NEA.Properties.Resources.card_back_black;
            this.deckcard.Location = new System.Drawing.Point(12, 309);
            this.deckcard.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.deckcard.Name = "deckcard";
            this.deckcard.Size = new System.Drawing.Size(145, 188);
            this.deckcard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.deckcard.TabIndex = 0;
            this.deckcard.TabStop = false;
            this.deckcard.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 269);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 38);
            this.label1.TabIndex = 1;
            this.label1.Text = "Deal";
            // 
            // p1card2
            // 
            this.p1card2.Location = new System.Drawing.Point(406, 309);
            this.p1card2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.p1card2.Name = "p1card2";
            this.p1card2.Size = new System.Drawing.Size(100, 149);
            this.p1card2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.p1card2.TabIndex = 2;
            this.p1card2.TabStop = false;
            this.p1card2.Click += new System.EventHandler(this.p1card2_Click);
            // 
            // p1card1
            // 
            this.p1card1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.p1card1.Location = new System.Drawing.Point(300, 309);
            this.p1card1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.p1card1.Name = "p1card1";
            this.p1card1.Size = new System.Drawing.Size(100, 149);
            this.p1card1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.p1card1.TabIndex = 3;
            this.p1card1.TabStop = false;
            this.p1card1.Click += new System.EventHandler(this.p1card1_Click);
            // 
            // p1card3
            // 
            this.p1card3.Location = new System.Drawing.Point(512, 309);
            this.p1card3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.p1card3.Name = "p1card3";
            this.p1card3.Size = new System.Drawing.Size(100, 149);
            this.p1card3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.p1card3.TabIndex = 4;
            this.p1card3.TabStop = false;
            this.p1card3.Click += new System.EventHandler(this.p1card3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 25.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(440, 50);
            this.label2.TabIndex = 6;
            this.label2.Text = "Pass and Play Mode";
            // 
            // midcard3
            // 
            this.midcard3.Location = new System.Drawing.Point(512, 99);
            this.midcard3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.midcard3.Name = "midcard3";
            this.midcard3.Size = new System.Drawing.Size(100, 149);
            this.midcard3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.midcard3.TabIndex = 9;
            this.midcard3.TabStop = false;
            this.midcard3.Click += new System.EventHandler(this.midcard3_Click);
            // 
            // midcard1
            // 
            this.midcard1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.midcard1.Location = new System.Drawing.Point(300, 99);
            this.midcard1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.midcard1.Name = "midcard1";
            this.midcard1.Size = new System.Drawing.Size(100, 149);
            this.midcard1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.midcard1.TabIndex = 8;
            this.midcard1.TabStop = false;
            this.midcard1.Click += new System.EventHandler(this.midcard1_Click);
            // 
            // midcard2
            // 
            this.midcard2.Location = new System.Drawing.Point(406, 99);
            this.midcard2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.midcard2.Name = "midcard2";
            this.midcard2.Size = new System.Drawing.Size(100, 149);
            this.midcard2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.midcard2.TabIndex = 7;
            this.midcard2.TabStop = false;
            this.midcard2.Click += new System.EventHandler(this.midcard2_Click);
            // 
            // togglehide
            // 
            this.togglehide.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.togglehide.Location = new System.Drawing.Point(656, 283);
            this.togglehide.Name = "togglehide";
            this.togglehide.Size = new System.Drawing.Size(123, 71);
            this.togglehide.TabIndex = 10;
            this.togglehide.Text = "Hide Cards \r\n(End Turn)";
            this.togglehide.UseVisualStyleBackColor = true;
            this.togglehide.Visible = false;
            this.togglehide.Click += new System.EventHandler(this.togglehide_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(294, 274);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(175, 32);
            this.label3.TabIndex = 11;
            this.label3.Text = "Your Cards:";
            this.label3.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(294, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(202, 32);
            this.label4.TabIndex = 12;
            this.label4.Text = "Middle Cards:";
            this.label4.Visible = false;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(618, 145);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 48);
            this.button1.TabIndex = 13;
            this.button1.Text = "Swap all cards";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
<<<<<<< Updated upstream
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Lucida Fax", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(656, 440);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(172, 45);
            this.button2.TabIndex = 14;
            this.button2.Text = "Knock";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
=======
>>>>>>> Stashed changes
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(16, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 29);
            this.label5.TabIndex = 15;
            this.label5.Text = "Player: ";
            this.label5.Visible = false;
            // 
            // knockButton
            // 
            this.knockButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knockButton.Location = new System.Drawing.Point(671, 214);
            this.knockButton.Name = "knockButton";
            this.knockButton.Size = new System.Drawing.Size(89, 63);
            this.knockButton.TabIndex = 16;
            this.knockButton.Text = "Knock";
            this.knockButton.UseVisualStyleBackColor = true;
            this.knockButton.Visible = false;
            this.knockButton.Click += new System.EventHandler(this.knockButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 497);
            this.Controls.Add(this.knockButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.togglehide);
            this.Controls.Add(this.midcard3);
            this.Controls.Add(this.midcard1);
            this.Controls.Add(this.midcard2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.p1card3);
            this.Controls.Add(this.p1card1);
            this.Controls.Add(this.p1card2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.deckcard);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.deckcard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p1card2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p1card1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p1card3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.midcard3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.midcard1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.midcard2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox deckcard;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox midcard3;
        private System.Windows.Forms.PictureBox midcard1;
        private System.Windows.Forms.PictureBox midcard2;
        private System.Windows.Forms.Button togglehide;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.PictureBox p1card2;
        public System.Windows.Forms.PictureBox p1card3;
        public System.Windows.Forms.PictureBox p1card1;
        public System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button knockButton;
    }
}

