namespace Algor_04
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.txtOpen = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // txtOpen
            // 
            this.txtOpen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(69)))), ((int)(((byte)(51)))));
            this.txtOpen.FlatAppearance.BorderColor = System.Drawing.Color.GreenYellow;
            this.txtOpen.FlatAppearance.BorderSize = 3;
            this.txtOpen.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DeepPink;
            this.txtOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtOpen.ForeColor = System.Drawing.Color.GreenYellow;
            this.txtOpen.Location = new System.Drawing.Point(676, 12);
            this.txtOpen.Name = "txtOpen";
            this.txtOpen.Size = new System.Drawing.Size(102, 30);
            this.txtOpen.TabIndex = 1;
            this.txtOpen.Text = "Read Map";
            this.txtOpen.UseVisualStyleBackColor = false;
            this.txtOpen.Click += new System.EventHandler(this.txtOpen_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(57)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(790, 489);
            this.Controls.Add(this.txtOpen);
            this.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ForeColor = System.Drawing.SystemColors.WindowText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Escape from L.A.";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button txtOpen;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

