namespace MADB_Transfer
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
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox_SrcDBPath = new System.Windows.Forms.TextBox();
            this.btn_SrcDBLoad = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.textBox_DstDBPath = new System.Windows.Forms.TextBox();
            this.btn_DstDBLoad = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_SrcDBPath
            // 
            this.textBox_SrcDBPath.Location = new System.Drawing.Point(13, 13);
            this.textBox_SrcDBPath.Name = "textBox_SrcDBPath";
            this.textBox_SrcDBPath.Size = new System.Drawing.Size(278, 22);
            this.textBox_SrcDBPath.TabIndex = 0;
            // 
            // btn_SrcDBLoad
            // 
            this.btn_SrcDBLoad.Location = new System.Drawing.Point(297, 13);
            this.btn_SrcDBLoad.Name = "btn_SrcDBLoad";
            this.btn_SrcDBLoad.Size = new System.Drawing.Size(75, 23);
            this.btn_SrcDBLoad.TabIndex = 1;
            this.btn_SrcDBLoad.Text = "button1";
            this.btn_SrcDBLoad.UseVisualStyleBackColor = true;
            this.btn_SrcDBLoad.Click += new System.EventHandler(this.btn_xxxDBLoad_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabControl1.Location = new System.Drawing.Point(0, 125);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(925, 354);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tabControl2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(917, 328);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabControl2.Location = new System.Drawing.Point(3, 16);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(911, 309);
            this.tabControl2.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(903, 283);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(871, 283);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "tabPage4";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(892, 322);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // textBox_DstDBPath
            // 
            this.textBox_DstDBPath.Location = new System.Drawing.Point(553, 12);
            this.textBox_DstDBPath.Name = "textBox_DstDBPath";
            this.textBox_DstDBPath.Size = new System.Drawing.Size(279, 22);
            this.textBox_DstDBPath.TabIndex = 3;
            // 
            // btn_DstDBLoad
            // 
            this.btn_DstDBLoad.Location = new System.Drawing.Point(838, 13);
            this.btn_DstDBLoad.Name = "btn_DstDBLoad";
            this.btn_DstDBLoad.Size = new System.Drawing.Size(75, 23);
            this.btn_DstDBLoad.TabIndex = 4;
            this.btn_DstDBLoad.Text = "button2";
            this.btn_DstDBLoad.UseVisualStyleBackColor = true;
            this.btn_DstDBLoad.Click += new System.EventHandler(this.btn_xxxDBLoad_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 479);
            this.Controls.Add(this.btn_DstDBLoad);
            this.Controls.Add(this.textBox_DstDBPath);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btn_SrcDBLoad);
            this.Controls.Add(this.textBox_SrcDBPath);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_SrcDBPath;
        private System.Windows.Forms.Button btn_SrcDBLoad;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox textBox_DstDBPath;
        private System.Windows.Forms.Button btn_DstDBLoad;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
    }
}

