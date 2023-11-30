namespace NhanChuong
{
    partial class Sever
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
            this.DanhsachNhanChuong = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.Start = new System.Windows.Forms.Button();
            this.Chuong = new System.Windows.Forms.Button();
            this.BoxName = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // DanhsachNhanChuong
            // 
            this.DanhsachNhanChuong.HideSelection = false;
            this.DanhsachNhanChuong.Location = new System.Drawing.Point(368, 12);
            this.DanhsachNhanChuong.Name = "DanhsachNhanChuong";
            this.DanhsachNhanChuong.Size = new System.Drawing.Size(420, 373);
            this.DanhsachNhanChuong.TabIndex = 12;
            this.DanhsachNhanChuong.UseCompatibleStateImageBehavior = false;
            this.DanhsachNhanChuong.View = System.Windows.Forms.View.List;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(228, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 32);
            this.label1.TabIndex = 10;
            this.label1.Text = "label1";
            // 
            // Start
            // 
            this.Start.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Start.ForeColor = System.Drawing.SystemColors.Highlight;
            this.Start.Location = new System.Drawing.Point(12, 12);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(124, 43);
            this.Start.TabIndex = 9;
            this.Start.Text = "Bắt đầu";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // Chuong
            // 
            this.Chuong.Location = new System.Drawing.Point(403, 400);
            this.Chuong.Name = "Chuong";
            this.Chuong.Size = new System.Drawing.Size(119, 47);
            this.Chuong.TabIndex = 8;
            this.Chuong.Text = "Chuông";
            this.Chuong.UseVisualStyleBackColor = true;
            this.Chuong.Click += new System.EventHandler(this.Chuong_Click);
            // 
            // BoxName
            // 
            this.BoxName.Location = new System.Drawing.Point(12, 400);
            this.BoxName.Multiline = true;
            this.BoxName.Name = "BoxName";
            this.BoxName.Size = new System.Drawing.Size(308, 47);
            this.BoxName.TabIndex = 7;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Sever
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DanhsachNhanChuong);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.Chuong);
            this.Controls.Add(this.BoxName);
            this.Name = "Sever";
            this.Text = "Sever";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Sever_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView DanhsachNhanChuong;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.Button Chuong;
        private System.Windows.Forms.TextBox BoxName;
        private System.Windows.Forms.Timer timer1;
    }
}

