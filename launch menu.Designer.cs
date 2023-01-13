namespace NEA
{
    partial class launch_menu
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
            this.offlinepnp = new System.Windows.Forms.Button();
            this.online = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cooper Black", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(307, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(215, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welcome!";
            // 
            // offlinepnp
            // 
            this.offlinepnp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.offlinepnp.Location = new System.Drawing.Point(225, 173);
            this.offlinepnp.Name = "offlinepnp";
            this.offlinepnp.Size = new System.Drawing.Size(167, 74);
            this.offlinepnp.TabIndex = 1;
            this.offlinepnp.Text = "Pass and Play (offline)";
            this.offlinepnp.UseVisualStyleBackColor = true;
            this.offlinepnp.Click += new System.EventHandler(this.offlinepnp_Click);
            // 
            // online
            // 
            this.online.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.online.Location = new System.Drawing.Point(414, 173);
            this.online.Name = "online";
            this.online.Size = new System.Drawing.Size(196, 74);
            this.online.TabIndex = 2;
            this.online.Text = "Sign up or Log in (online)";
            this.online.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cooper Black", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(271, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(300, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "What would you like to do today?";
            // 
            // launch_menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.online);
            this.Controls.Add(this.offlinepnp);
            this.Controls.Add(this.label1);
            this.Name = "launch_menu";
            this.Text = "launch_menu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button offlinepnp;
        private System.Windows.Forms.Button online;
        private System.Windows.Forms.Label label2;
    }
}