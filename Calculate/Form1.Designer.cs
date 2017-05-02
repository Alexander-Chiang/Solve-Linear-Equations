namespace 迭代法求解线性方程组
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rtxbLog = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnOutput = new System.Windows.Forms.Button();
            this.txbOutput = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txbOmega = new System.Windows.Forms.TextBox();
            this.labOmega = new System.Windows.Forms.Label();
            this.btnCalc = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbMethod = new System.Windows.Forms.ComboBox();
            this.txbEpsilon = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txbIterativeTimes = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnInput = new System.Windows.Forms.Button();
            this.txbInput = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开输入ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开输出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查看帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rtxbLog);
            this.groupBox1.Location = new System.Drawing.Point(5, 241);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(583, 223);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "日志";
            // 
            // rtxbLog
            // 
            this.rtxbLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtxbLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxbLog.Location = new System.Drawing.Point(3, 17);
            this.rtxbLog.Name = "rtxbLog";
            this.rtxbLog.ReadOnly = true;
            this.rtxbLog.Size = new System.Drawing.Size(577, 203);
            this.rtxbLog.TabIndex = 2;
            this.rtxbLog.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(212, 214);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 12);
            this.label4.TabIndex = 23;
            this.label4.Text = "          ︾          ";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnOutput);
            this.groupBox3.Controls.Add(this.txbOutput);
            this.groupBox3.Location = new System.Drawing.Point(308, 30);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(270, 57);
            this.groupBox3.TabIndex = 22;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "输出";
            // 
            // btnOutput
            // 
            this.btnOutput.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOutput.Location = new System.Drawing.Point(241, 19);
            this.btnOutput.Name = "btnOutput";
            this.btnOutput.Size = new System.Drawing.Size(27, 22);
            this.btnOutput.TabIndex = 1;
            this.btnOutput.Text = "...";
            this.btnOutput.UseVisualStyleBackColor = true;
            this.btnOutput.Click += new System.EventHandler(this.btnOutput_Click);
            // 
            // txbOutput
            // 
            this.txbOutput.Location = new System.Drawing.Point(6, 20);
            this.txbOutput.Name = "txbOutput";
            this.txbOutput.ReadOnly = true;
            this.txbOutput.Size = new System.Drawing.Size(230, 21);
            this.txbOutput.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txbOmega);
            this.groupBox4.Controls.Add(this.labOmega);
            this.groupBox4.Controls.Add(this.btnCalc);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.cmbMethod);
            this.groupBox4.Controls.Add(this.txbEpsilon);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.txbIterativeTimes);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Location = new System.Drawing.Point(14, 99);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(564, 108);
            this.groupBox4.TabIndex = 21;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "设置";
            // 
            // txbOmega
            // 
            this.txbOmega.Enabled = false;
            this.txbOmega.Location = new System.Drawing.Point(347, 64);
            this.txbOmega.Name = "txbOmega";
            this.txbOmega.Size = new System.Drawing.Size(81, 21);
            this.txbOmega.TabIndex = 8;
            this.txbOmega.Text = "1";
            this.txbOmega.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbOmega_KeyPress);
            // 
            // labOmega
            // 
            this.labOmega.AutoSize = true;
            this.labOmega.Enabled = false;
            this.labOmega.Location = new System.Drawing.Point(256, 69);
            this.labOmega.Name = "labOmega";
            this.labOmega.Size = new System.Drawing.Size(89, 12);
            this.labOmega.TabIndex = 7;
            this.labOmega.Text = "松弛因子(ω)：";
            // 
            // btnCalc
            // 
            this.btnCalc.Location = new System.Drawing.Point(468, 64);
            this.btnCalc.Name = "btnCalc";
            this.btnCalc.Size = new System.Drawing.Size(75, 23);
            this.btnCalc.TabIndex = 6;
            this.btnCalc.Text = "计算";
            this.btnCalc.UseVisualStyleBackColor = true;
            this.btnCalc.Click += new System.EventHandler(this.btnCalc_Click_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(280, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "迭代方法：";
            // 
            // cmbMethod
            // 
            this.cmbMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMethod.FormattingEnabled = true;
            this.cmbMethod.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cmbMethod.Location = new System.Drawing.Point(347, 26);
            this.cmbMethod.Name = "cmbMethod";
            this.cmbMethod.Size = new System.Drawing.Size(104, 20);
            this.cmbMethod.TabIndex = 4;
            this.cmbMethod.SelectedIndexChanged += new System.EventHandler(this.cmbMethod_SelectedIndexChanged);
            // 
            // txbEpsilon
            // 
            this.txbEpsilon.Location = new System.Drawing.Point(123, 64);
            this.txbEpsilon.Name = "txbEpsilon";
            this.txbEpsilon.Size = new System.Drawing.Size(81, 21);
            this.txbEpsilon.TabIndex = 3;
            this.txbEpsilon.Text = "0.0001";
            this.txbEpsilon.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbEpsilon_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "收敛标准(ε)：";
            // 
            // txbIterativeTimes
            // 
            this.txbIterativeTimes.Location = new System.Drawing.Point(123, 25);
            this.txbIterativeTimes.Name = "txbIterativeTimes";
            this.txbIterativeTimes.Size = new System.Drawing.Size(81, 21);
            this.txbIterativeTimes.TabIndex = 1;
            this.txbIterativeTimes.Text = "1000";
            this.txbIterativeTimes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbIterativeTimes_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "最大迭代次数：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnInput);
            this.groupBox2.Controls.Add(this.txbInput);
            this.groupBox2.Location = new System.Drawing.Point(14, 30);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(270, 57);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "输入";
            // 
            // btnInput
            // 
            this.btnInput.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnInput.Location = new System.Drawing.Point(241, 19);
            this.btnInput.Name = "btnInput";
            this.btnInput.Size = new System.Drawing.Size(27, 22);
            this.btnInput.TabIndex = 1;
            this.btnInput.Text = "...";
            this.btnInput.UseVisualStyleBackColor = true;
            this.btnInput.Click += new System.EventHandler(this.btnInput_Click);
            // 
            // txbInput
            // 
            this.txbInput.Location = new System.Drawing.Point(6, 20);
            this.txbInput.Name = "txbInput";
            this.txbInput.ReadOnly = true;
            this.txbInput.Size = new System.Drawing.Size(230, 21);
            this.txbInput.TabIndex = 0;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(594, 25);
            this.menuStrip1.TabIndex = 25;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开输入ToolStripMenuItem,
            this.打开输出ToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(58, 21);
            this.文件ToolStripMenuItem.Text = "文件(&F)";
            // 
            // 打开输入ToolStripMenuItem
            // 
            this.打开输入ToolStripMenuItem.Name = "打开输入ToolStripMenuItem";
            this.打开输入ToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.打开输入ToolStripMenuItem.Text = "打开输入(&I)";
            this.打开输入ToolStripMenuItem.Click += new System.EventHandler(this.打开输入ToolStripMenuItem_Click);
            // 
            // 打开输出ToolStripMenuItem
            // 
            this.打开输出ToolStripMenuItem.Name = "打开输出ToolStripMenuItem";
            this.打开输出ToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.打开输出ToolStripMenuItem.Text = "打开输出(&O)";
            this.打开输出ToolStripMenuItem.Click += new System.EventHandler(this.打开输出ToolStripMenuItem_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.退出ToolStripMenuItem.Text = "退出(&E)";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.查看帮助ToolStripMenuItem,
            this.关于ToolStripMenuItem});
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(61, 21);
            this.帮助ToolStripMenuItem.Text = "帮助(&H)";
            // 
            // 查看帮助ToolStripMenuItem
            // 
            this.查看帮助ToolStripMenuItem.Name = "查看帮助ToolStripMenuItem";
            this.查看帮助ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.查看帮助ToolStripMenuItem.Text = "查看帮助(&V)";
            this.查看帮助ToolStripMenuItem.Click += new System.EventHandler(this.查看帮助ToolStripMenuItem_Click);
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.关于ToolStripMenuItem.Text = "关于(&A)";
            this.关于ToolStripMenuItem.Click += new System.EventHandler(this.关于ToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AcceptButton = this.btnCalc;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 471);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "线性方程组求解";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnOutput;
        private System.Windows.Forms.TextBox txbOutput;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnCalc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbMethod;
        private System.Windows.Forms.TextBox txbEpsilon;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbIterativeTimes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnInput;
        private System.Windows.Forms.TextBox txbInput;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox txbOmega;
        private System.Windows.Forms.Label labOmega;
        private System.Windows.Forms.RichTextBox rtxbLog;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开输入ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开输出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查看帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;


    }
}

