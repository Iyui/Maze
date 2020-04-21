namespace 迷宫
{
    partial class Form1
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
            this.btn_createMap = new System.Windows.Forms.Button();
            this.txt_str = new System.Windows.Forms.TextBox();
            this.btn_test = new System.Windows.Forms.Button();
            this.lb_x = new System.Windows.Forms.Label();
            this.lb_y = new System.Windows.Forms.Label();
            this.FillPath = new System.Windows.Forms.RadioButton();
            this.LinePath = new System.Windows.Forms.RadioButton();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.DFSPath = new System.Windows.Forms.RadioButton();
            this.BFSPath = new System.Windows.Forms.RadioButton();
            this.tbarShowSpeed = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.tbarShowSpeed)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_createMap
            // 
            this.btn_createMap.Location = new System.Drawing.Point(621, 543);
            this.btn_createMap.Name = "btn_createMap";
            this.btn_createMap.Size = new System.Drawing.Size(75, 23);
            this.btn_createMap.TabIndex = 0;
            this.btn_createMap.Text = "创建迷宫";
            this.btn_createMap.UseVisualStyleBackColor = true;
            this.btn_createMap.Click += new System.EventHandler(this.Btn_createMap_Click);
            // 
            // txt_str
            // 
            this.txt_str.Location = new System.Drawing.Point(12, 376);
            this.txt_str.Multiline = true;
            this.txt_str.Name = "txt_str";
            this.txt_str.Size = new System.Drawing.Size(588, 212);
            this.txt_str.TabIndex = 1;
            // 
            // btn_test
            // 
            this.btn_test.Location = new System.Drawing.Point(702, 543);
            this.btn_test.Name = "btn_test";
            this.btn_test.Size = new System.Drawing.Size(75, 23);
            this.btn_test.TabIndex = 2;
            this.btn_test.Text = "寻路";
            this.btn_test.UseVisualStyleBackColor = true;
            this.btn_test.Click += new System.EventHandler(this.btn_test_Click);
            // 
            // lb_x
            // 
            this.lb_x.AutoSize = true;
            this.lb_x.Location = new System.Drawing.Point(619, 528);
            this.lb_x.Name = "lb_x";
            this.lb_x.Size = new System.Drawing.Size(29, 12);
            this.lb_x.TabIndex = 3;
            this.lb_x.Text = "lb_x";
            // 
            // lb_y
            // 
            this.lb_y.AutoSize = true;
            this.lb_y.Location = new System.Drawing.Point(655, 528);
            this.lb_y.Name = "lb_y";
            this.lb_y.Size = new System.Drawing.Size(41, 12);
            this.lb_y.TabIndex = 4;
            this.lb_y.Text = "label2";
            // 
            // FillPath
            // 
            this.FillPath.AutoSize = true;
            this.FillPath.Location = new System.Drawing.Point(621, 391);
            this.FillPath.Name = "FillPath";
            this.FillPath.Size = new System.Drawing.Size(95, 16);
            this.FillPath.TabIndex = 5;
            this.FillPath.TabStop = true;
            this.FillPath.Text = "radioButton1";
            this.FillPath.UseVisualStyleBackColor = true;
            this.FillPath.CheckedChanged += new System.EventHandler(this.ModelChanged);
            // 
            // LinePath
            // 
            this.LinePath.AutoSize = true;
            this.LinePath.Location = new System.Drawing.Point(621, 413);
            this.LinePath.Name = "LinePath";
            this.LinePath.Size = new System.Drawing.Size(95, 16);
            this.LinePath.TabIndex = 6;
            this.LinePath.TabStop = true;
            this.LinePath.Text = "radioButton2";
            this.LinePath.UseVisualStyleBackColor = true;
            this.LinePath.CheckedChanged += new System.EventHandler(this.ModelChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(683, 321);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(78, 16);
            this.checkBox1.TabIndex = 7;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // DFSPath
            // 
            this.DFSPath.AutoSize = true;
            this.DFSPath.Location = new System.Drawing.Point(621, 435);
            this.DFSPath.Name = "DFSPath";
            this.DFSPath.Size = new System.Drawing.Size(95, 16);
            this.DFSPath.TabIndex = 8;
            this.DFSPath.TabStop = true;
            this.DFSPath.Text = "深度优先搜索";
            this.DFSPath.UseVisualStyleBackColor = true;
            this.DFSPath.CheckedChanged += new System.EventHandler(this.ModelChanged);
            // 
            // BFSPath
            // 
            this.BFSPath.AutoSize = true;
            this.BFSPath.Checked = true;
            this.BFSPath.Location = new System.Drawing.Point(621, 457);
            this.BFSPath.Name = "BFSPath";
            this.BFSPath.Size = new System.Drawing.Size(95, 16);
            this.BFSPath.TabIndex = 9;
            this.BFSPath.TabStop = true;
            this.BFSPath.Text = "广度优先搜索";
            this.BFSPath.UseVisualStyleBackColor = true;
            this.BFSPath.CheckedChanged += new System.EventHandler(this.ModelChanged);
            // 
            // tbarShowSpeed
            // 
            this.tbarShowSpeed.Location = new System.Drawing.Point(760, 446);
            this.tbarShowSpeed.Maximum = 100;
            this.tbarShowSpeed.Minimum = 1;
            this.tbarShowSpeed.Name = "tbarShowSpeed";
            this.tbarShowSpeed.Size = new System.Drawing.Size(104, 45);
            this.tbarShowSpeed.TabIndex = 10;
            this.tbarShowSpeed.Value = 30;
            this.tbarShowSpeed.Scroll += new System.EventHandler(this.tbarShowSpeed_Scroll);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 606);
            this.Controls.Add(this.tbarShowSpeed);
            this.Controls.Add(this.BFSPath);
            this.Controls.Add(this.DFSPath);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.LinePath);
            this.Controls.Add(this.FillPath);
            this.Controls.Add(this.lb_y);
            this.Controls.Add(this.lb_x);
            this.Controls.Add(this.btn_test);
            this.Controls.Add(this.txt_str);
            this.Controls.Add(this.btn_createMap);
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbarShowSpeed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_createMap;
        private System.Windows.Forms.TextBox txt_str;
        private System.Windows.Forms.Button btn_test;
        private System.Windows.Forms.Label lb_x;
        private System.Windows.Forms.Label lb_y;
        private System.Windows.Forms.RadioButton FillPath;
        private System.Windows.Forms.RadioButton LinePath;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.RadioButton DFSPath;
        private System.Windows.Forms.RadioButton BFSPath;
        private System.Windows.Forms.TrackBar tbarShowSpeed;
    }
}

