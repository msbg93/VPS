namespace VPSNotification
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
            this.generate = new System.Windows.Forms.Button();
            this.status = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.SendEmail = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.status2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // generate
            // 
            this.generate.Location = new System.Drawing.Point(182, 17);
            this.generate.Name = "generate";
            this.generate.Size = new System.Drawing.Size(86, 23);
            this.generate.TabIndex = 0;
            this.generate.Text = "Generate";
            this.generate.UseVisualStyleBackColor = true;
            this.generate.Click += new System.EventHandler(this.generate_Click);
            // 
            // status
            // 
            this.status.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.status.Location = new System.Drawing.Point(6, 43);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(262, 71);
            this.status.TabIndex = 1;
            this.status.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.status.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Retirement Notification";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.generate);
            this.groupBox1.Controls.Add(this.status);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(274, 117);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Generate";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.status2);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.SendEmail);
            this.groupBox2.Location = new System.Drawing.Point(12, 135);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(274, 126);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Email";
            // 
            // SendEmail
            // 
            this.SendEmail.Location = new System.Drawing.Point(182, 21);
            this.SendEmail.Name = "SendEmail";
            this.SendEmail.Size = new System.Drawing.Size(86, 23);
            this.SendEmail.TabIndex = 0;
            this.SendEmail.Text = "Send Email";
            this.SendEmail.UseVisualStyleBackColor = true;
            this.SendEmail.Click += new System.EventHandler(this.SendEmail_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Send Notification";
            // 
            // status2
            // 
            this.status2.Location = new System.Drawing.Point(6, 47);
            this.status2.Name = "status2";
            this.status2.Size = new System.Drawing.Size(262, 76);
            this.status2.TabIndex = 4;
            this.status2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "VPS Notification";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button generate;
        private System.Windows.Forms.Label status;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button SendEmail;
        private System.Windows.Forms.Label status2;
    }
}

