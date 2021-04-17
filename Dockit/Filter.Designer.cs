namespace Dockit
{
    partial class Filter
    {

        private System.ComponentModel.IContainer components = null;


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }


        private void InitializeComponent()
        {
            this.lstProcess = new System.Windows.Forms.ListBox();
            this.picSpy = new System.Windows.Forms.PictureBox();
            this.lblHandle = new System.Windows.Forms.Label();
            this.lblWindowClass = new System.Windows.Forms.Label();
            this.txtWindowClass = new System.Windows.Forms.TextBox();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.lblFilePath = new System.Windows.Forms.Label();
            this.txtWindowTitle = new System.Windows.Forms.TextBox();
            this.lblWindowTitle = new System.Windows.Forms.Label();
            this.rdoInclude = new System.Windows.Forms.RadioButton();
            this.rdoEqual = new System.Windows.Forms.RadioButton();
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picSpy)).BeginInit();
            this.SuspendLayout();
            // 
            // lstProcess
            // 
            this.lstProcess.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.lstProcess.FormattingEnabled = true;
            this.lstProcess.HorizontalScrollbar = true;
            this.lstProcess.ItemHeight = 20;
            this.lstProcess.Location = new System.Drawing.Point(12, 12);
            this.lstProcess.Name = "lstProcess";
            this.lstProcess.Size = new System.Drawing.Size(582, 424);
            this.lstProcess.TabIndex = 0;
            // 
            // picSpy
            // 
            this.picSpy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picSpy.Location = new System.Drawing.Point(16, 530);
            this.picSpy.Name = "picSpy";
            this.picSpy.Size = new System.Drawing.Size(32, 32);
            this.picSpy.TabIndex = 1;
            this.picSpy.TabStop = false;
            this.picSpy.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picSpy_MouseDown);
            // 
            // lblHandle
            // 
            this.lblHandle.AutoSize = true;
            this.lblHandle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblHandle.Location = new System.Drawing.Point(56, 536);
            this.lblHandle.Name = "lblHandle";
            this.lblHandle.Size = new System.Drawing.Size(37, 20);
            this.lblHandle.TabIndex = 9;
            this.lblHandle.Text = "句柄";
            // 
            // lblWindowClass
            // 
            this.lblWindowClass.AutoSize = true;
            this.lblWindowClass.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblWindowClass.Location = new System.Drawing.Point(12, 459);
            this.lblWindowClass.Name = "lblWindowClass";
            this.lblWindowClass.Size = new System.Drawing.Size(65, 20);
            this.lblWindowClass.TabIndex = 1;
            this.lblWindowClass.Text = "窗口类名";
            // 
            // txtWindowClass
            // 
            this.txtWindowClass.Location = new System.Drawing.Point(83, 459);
            this.txtWindowClass.Name = "txtWindowClass";
            this.txtWindowClass.ReadOnly = true;
            this.txtWindowClass.Size = new System.Drawing.Size(116, 21);
            this.txtWindowClass.TabIndex = 2;
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(83, 498);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.ReadOnly = true;
            this.txtFilePath.Size = new System.Drawing.Size(511, 21);
            this.txtFilePath.TabIndex = 8;
            // 
            // lblFilePath
            // 
            this.lblFilePath.AutoSize = true;
            this.lblFilePath.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblFilePath.Location = new System.Drawing.Point(12, 498);
            this.lblFilePath.Name = "lblFilePath";
            this.lblFilePath.Size = new System.Drawing.Size(65, 20);
            this.lblFilePath.TabIndex = 7;
            this.lblFilePath.Text = "文件路径";
            // 
            // txtWindowTitle
            // 
            this.txtWindowTitle.Location = new System.Drawing.Point(335, 459);
            this.txtWindowTitle.Name = "txtWindowTitle";
            this.txtWindowTitle.Size = new System.Drawing.Size(259, 21);
            this.txtWindowTitle.TabIndex = 6;
            // 
            // lblWindowTitle
            // 
            this.lblWindowTitle.AutoSize = true;
            this.lblWindowTitle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblWindowTitle.Location = new System.Drawing.Point(218, 459);
            this.lblWindowTitle.Name = "lblWindowTitle";
            this.lblWindowTitle.Size = new System.Drawing.Size(65, 20);
            this.lblWindowTitle.TabIndex = 3;
            this.lblWindowTitle.Text = "窗口标题";
            // 
            // rdoInclude
            // 
            this.rdoInclude.AutoSize = true;
            this.rdoInclude.Checked = true;
            this.rdoInclude.Font = new System.Drawing.Font("微软雅黑", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdoInclude.Location = new System.Drawing.Point(289, 451);
            this.rdoInclude.Name = "rdoInclude";
            this.rdoInclude.Size = new System.Drawing.Size(46, 20);
            this.rdoInclude.TabIndex = 4;
            this.rdoInclude.TabStop = true;
            this.rdoInclude.Text = "包含";
            this.rdoInclude.UseVisualStyleBackColor = true;
            // 
            // rdoEqual
            // 
            this.rdoEqual.AutoSize = true;
            this.rdoEqual.Font = new System.Drawing.Font("微软雅黑", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdoEqual.Location = new System.Drawing.Point(289, 467);
            this.rdoEqual.Name = "rdoEqual";
            this.rdoEqual.Size = new System.Drawing.Size(46, 20);
            this.rdoEqual.TabIndex = 5;
            this.rdoEqual.Text = "等于";
            this.rdoEqual.UseVisualStyleBackColor = true;
            // 
            // btnInsert
            // 
            this.btnInsert.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnInsert.Location = new System.Drawing.Point(218, 531);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(75, 30);
            this.btnInsert.TabIndex = 10;
            this.btnInsert.Text = "增加";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnDelete.Location = new System.Drawing.Point(314, 531);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 30);
            this.btnDelete.TabIndex = 11;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // Filter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(606, 586);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.rdoEqual);
            this.Controls.Add(this.rdoInclude);
            this.Controls.Add(this.txtWindowTitle);
            this.Controls.Add(this.lblWindowTitle);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.lblFilePath);
            this.Controls.Add(this.txtWindowClass);
            this.Controls.Add(this.lblWindowClass);
            this.Controls.Add(this.lblHandle);
            this.Controls.Add(this.picSpy);
            this.Controls.Add(this.lstProcess);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Filter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dockit - 过滤清单";
            ((System.ComponentModel.ISupportInitialize)(this.picSpy)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        private System.Windows.Forms.ListBox lstProcess;
        internal System.Windows.Forms.PictureBox picSpy;
        private System.Windows.Forms.Label lblHandle;
        private System.Windows.Forms.Label lblWindowClass;
        private System.Windows.Forms.TextBox txtWindowClass;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Label lblFilePath;
        private System.Windows.Forms.TextBox txtWindowTitle;
        private System.Windows.Forms.Label lblWindowTitle;
        private System.Windows.Forms.RadioButton rdoInclude;
        private System.Windows.Forms.RadioButton rdoEqual;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnDelete;
    }
}