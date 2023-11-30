namespace Client
{
    partial class Client
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Chuong = new System.Windows.Forms.Button();
            this.Danhsach = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 391);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(308, 47);
            this.textBox1.TabIndex = 0;
            // 
            // Chuong
            // 
            this.Chuong.Location = new System.Drawing.Point(386, 391);
            this.Chuong.Name = "Chuong";
            this.Chuong.Size = new System.Drawing.Size(119, 47);
            this.Chuong.TabIndex = 1;
            this.Chuong.Text = "Chuông";
            this.Chuong.UseVisualStyleBackColor = true;
            this.Chuong.Click += new System.EventHandler(this.Chuong_Click);
            // 
            // Danhsach
            // 
            this.Danhsach.HideSelection = false;
            this.Danhsach.Location = new System.Drawing.Point(368, 5);
            this.Danhsach.Name = "Danhsach";
            this.Danhsach.Size = new System.Drawing.Size(420, 373);
            this.Danhsach.TabIndex = 6;
            this.Danhsach.UseCompatibleStateImageBehavior = false;
            this.Danhsach.View = System.Windows.Forms.View.List;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 32);
            this.label1.TabIndex = 13;
            this.label1.Text = "label1";
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Danhsach);
            this.Controls.Add(this.Chuong);
            this.Controls.Add(this.textBox1);
            this.Name = "Client";
            this.Text = "Client";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Client_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button Chuong;
        private System.Windows.Forms.ListView Danhsach;
        private System.Windows.Forms.Label label1;
    }
}

