namespace NEA
{
    partial class podium
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
            this.label1 = new System.Windows.Forms.Label();
            this.wtext = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.card1 = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.card2 = new System.Windows.Forms.PictureBox();
            this.card3 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.card1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.card2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.card3)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(163, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Winner:";
            // 
            // wtext
            // 
            this.wtext.AutoSize = true;
            this.wtext.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wtext.Location = new System.Drawing.Point(295, 44);
            this.wtext.Name = "wtext";
            this.wtext.Size = new System.Drawing.Size(189, 29);
            this.wtext.TabIndex = 1;
            this.wtext.Text = "PLACEHOLDER";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(226, 202);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(22, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "<";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // card1
            // 
            this.card1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.card1.Location = new System.Drawing.Point(254, 151);
            this.card1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.card1.Name = "card1";
            this.card1.Size = new System.Drawing.Size(100, 149);
            this.card1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.card1.TabIndex = 4;
            this.card1.TabStop = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(553, 202);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(22, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = ">";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // card2
            // 
            this.card2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.card2.Location = new System.Drawing.Point(350, 151);
            this.card2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.card2.Name = "card2";
            this.card2.Size = new System.Drawing.Size(100, 149);
            this.card2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.card2.TabIndex = 6;
            this.card2.TabStop = false;
            // 
            // card3
            // 
            this.card3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.card3.Location = new System.Drawing.Point(447, 151);
            this.card3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.card3.Name = "card3";
            this.card3.Size = new System.Drawing.Size(100, 149);
            this.card3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.card3.TabIndex = 7;
            this.card3.TabStop = false;
            // 
            // podium
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.card3);
            this.Controls.Add(this.card2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.card1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.wtext);
            this.Controls.Add(this.label1);
            this.Name = "podium";
            this.Text = "podium";
            ((System.ComponentModel.ISupportInitialize)(this.card1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.card2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.card3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label wtext;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.PictureBox card1;
        private System.Windows.Forms.Button button2;
        public System.Windows.Forms.PictureBox card2;
        public System.Windows.Forms.PictureBox card3;
    }
}