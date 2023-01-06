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
            this.deckdebug = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.deckcard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p1card2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p1card1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p1card3)).BeginInit();
            this.SuspendLayout();
            // 
            // deckcard
            // 
            this.deckcard.Image = global::NEA.Properties.Resources.card_back_black;
            this.deckcard.Location = new System.Drawing.Point(98, 52);
            this.deckcard.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.deckcard.Name = "deckcard";
            this.deckcard.Size = new System.Drawing.Size(109, 153);
            this.deckcard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.deckcard.TabIndex = 0;
            this.deckcard.TabStop = false;
            this.deckcard.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(143, 210);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Deal";
            // 
            // p1card2
            // 
            this.p1card2.Location = new System.Drawing.Point(430, 10);
            this.p1card2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.p1card2.Name = "p1card2";
            this.p1card2.Size = new System.Drawing.Size(75, 121);
            this.p1card2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.p1card2.TabIndex = 2;
            this.p1card2.TabStop = false;
            // 
            // p1card1
            // 
            this.p1card1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.p1card1.Location = new System.Drawing.Point(350, 10);
            this.p1card1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.p1card1.Name = "p1card1";
            this.p1card1.Size = new System.Drawing.Size(75, 121);
            this.p1card1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.p1card1.TabIndex = 3;
            this.p1card1.TabStop = false;
            // 
            // p1card3
            // 
            this.p1card3.Location = new System.Drawing.Point(509, 10);
            this.p1card3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.p1card3.Name = "p1card3";
            this.p1card3.Size = new System.Drawing.Size(75, 121);
            this.p1card3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.p1card3.TabIndex = 4;
            this.p1card3.TabStop = false;
            // 
            // deckdebug
            // 
            this.deckdebug.AutoSize = true;
            this.deckdebug.Location = new System.Drawing.Point(198, 52);
            this.deckdebug.Name = "deckdebug";
            this.deckdebug.Size = new System.Drawing.Size(127, 13);
            this.deckdebug.TabIndex = 5;
            this.deckdebug.Text = "Deck should appear here";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.deckdebug);
            this.Controls.Add(this.p1card3);
            this.Controls.Add(this.p1card1);
            this.Controls.Add(this.p1card2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.deckcard);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.deckcard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p1card2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p1card1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p1card3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox deckcard;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox p1card2;
        private System.Windows.Forms.PictureBox p1card1;
        private System.Windows.Forms.PictureBox p1card3;
        private System.Windows.Forms.Label deckdebug;
    }
}

