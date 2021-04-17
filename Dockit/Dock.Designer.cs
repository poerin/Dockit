namespace Dockit
{
    partial class Dock
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
            this.numTriggerTop = new System.Windows.Forms.NumericUpDown();
            this.lblTriggerTopPercent = new System.Windows.Forms.Label();
            this.grpTrigger = new System.Windows.Forms.GroupBox();
            this.chkTriggerRight = new System.Windows.Forms.CheckBox();
            this.chkTriggerBottom = new System.Windows.Forms.CheckBox();
            this.chkTriggerLeft = new System.Windows.Forms.CheckBox();
            this.chkTriggerTop = new System.Windows.Forms.CheckBox();
            this.lblTriggerLeftPercent = new System.Windows.Forms.Label();
            this.numTriggerLeft = new System.Windows.Forms.NumericUpDown();
            this.lblTriggerRightPercent = new System.Windows.Forms.Label();
            this.numTriggerRight = new System.Windows.Forms.NumericUpDown();
            this.lblTriggerBottomPercent = new System.Windows.Forms.Label();
            this.numTriggerBottom = new System.Windows.Forms.NumericUpDown();
            this.pnlTrigger = new System.Windows.Forms.Panel();
            this.grpDock = new System.Windows.Forms.GroupBox();
            this.chkDockRight = new System.Windows.Forms.CheckBox();
            this.chkDockBottom = new System.Windows.Forms.CheckBox();
            this.chkDockLeft = new System.Windows.Forms.CheckBox();
            this.chkDockTop = new System.Windows.Forms.CheckBox();
            this.lblDockLeftPercent = new System.Windows.Forms.Label();
            this.numDockLeft = new System.Windows.Forms.NumericUpDown();
            this.lblDockRightPercent = new System.Windows.Forms.Label();
            this.numDockRight = new System.Windows.Forms.NumericUpDown();
            this.lblDockBottomPercent = new System.Windows.Forms.Label();
            this.numDockBottom = new System.Windows.Forms.NumericUpDown();
            this.lblDockTopPercent = new System.Windows.Forms.Label();
            this.numDockTop = new System.Windows.Forms.NumericUpDown();
            this.pnlDock = new System.Windows.Forms.Panel();
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lstAction = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.numTriggerTop)).BeginInit();
            this.grpTrigger.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTriggerLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTriggerRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTriggerBottom)).BeginInit();
            this.grpDock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDockLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDockRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDockBottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDockTop)).BeginInit();
            this.SuspendLayout();
            // 
            // numTriggerTop
            // 
            this.numTriggerTop.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.numTriggerTop.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numTriggerTop.Location = new System.Drawing.Point(97, 24);
            this.numTriggerTop.Name = "numTriggerTop";
            this.numTriggerTop.Size = new System.Drawing.Size(47, 26);
            this.numTriggerTop.TabIndex = 1;
            this.numTriggerTop.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numTriggerTop.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // lblTriggerTopPercent
            // 
            this.lblTriggerTopPercent.AutoSize = true;
            this.lblTriggerTopPercent.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTriggerTopPercent.Location = new System.Drawing.Point(144, 27);
            this.lblTriggerTopPercent.Name = "lblTriggerTopPercent";
            this.lblTriggerTopPercent.Size = new System.Drawing.Size(21, 20);
            this.lblTriggerTopPercent.TabIndex = 2;
            this.lblTriggerTopPercent.Text = "%";
            // 
            // grpTrigger
            // 
            this.grpTrigger.Controls.Add(this.chkTriggerRight);
            this.grpTrigger.Controls.Add(this.chkTriggerBottom);
            this.grpTrigger.Controls.Add(this.chkTriggerLeft);
            this.grpTrigger.Controls.Add(this.chkTriggerTop);
            this.grpTrigger.Controls.Add(this.lblTriggerLeftPercent);
            this.grpTrigger.Controls.Add(this.numTriggerLeft);
            this.grpTrigger.Controls.Add(this.lblTriggerRightPercent);
            this.grpTrigger.Controls.Add(this.numTriggerRight);
            this.grpTrigger.Controls.Add(this.lblTriggerBottomPercent);
            this.grpTrigger.Controls.Add(this.numTriggerBottom);
            this.grpTrigger.Controls.Add(this.lblTriggerTopPercent);
            this.grpTrigger.Controls.Add(this.numTriggerTop);
            this.grpTrigger.Controls.Add(this.pnlTrigger);
            this.grpTrigger.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grpTrigger.Location = new System.Drawing.Point(12, 421);
            this.grpTrigger.Name = "grpTrigger";
            this.grpTrigger.Size = new System.Drawing.Size(238, 140);
            this.grpTrigger.TabIndex = 1;
            this.grpTrigger.TabStop = false;
            this.grpTrigger.Text = "触发区域";
            // 
            // chkTriggerRight
            // 
            this.chkTriggerRight.AutoSize = true;
            this.chkTriggerRight.Checked = true;
            this.chkTriggerRight.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTriggerRight.Location = new System.Drawing.Point(136, 68);
            this.chkTriggerRight.Name = "chkTriggerRight";
            this.chkTriggerRight.Size = new System.Drawing.Size(15, 14);
            this.chkTriggerRight.TabIndex = 9;
            this.chkTriggerRight.UseVisualStyleBackColor = true;
            // 
            // chkTriggerBottom
            // 
            this.chkTriggerBottom.AutoSize = true;
            this.chkTriggerBottom.Checked = true;
            this.chkTriggerBottom.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTriggerBottom.Location = new System.Drawing.Point(77, 106);
            this.chkTriggerBottom.Name = "chkTriggerBottom";
            this.chkTriggerBottom.Size = new System.Drawing.Size(15, 14);
            this.chkTriggerBottom.TabIndex = 3;
            this.chkTriggerBottom.UseVisualStyleBackColor = true;
            // 
            // chkTriggerLeft
            // 
            this.chkTriggerLeft.AutoSize = true;
            this.chkTriggerLeft.Checked = true;
            this.chkTriggerLeft.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTriggerLeft.Location = new System.Drawing.Point(17, 68);
            this.chkTriggerLeft.Name = "chkTriggerLeft";
            this.chkTriggerLeft.Size = new System.Drawing.Size(15, 14);
            this.chkTriggerLeft.TabIndex = 6;
            this.chkTriggerLeft.UseVisualStyleBackColor = true;
            // 
            // chkTriggerTop
            // 
            this.chkTriggerTop.AutoSize = true;
            this.chkTriggerTop.Checked = true;
            this.chkTriggerTop.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTriggerTop.Location = new System.Drawing.Point(77, 30);
            this.chkTriggerTop.Name = "chkTriggerTop";
            this.chkTriggerTop.Size = new System.Drawing.Size(15, 14);
            this.chkTriggerTop.TabIndex = 0;
            this.chkTriggerTop.UseVisualStyleBackColor = true;
            // 
            // lblTriggerLeftPercent
            // 
            this.lblTriggerLeftPercent.AutoSize = true;
            this.lblTriggerLeftPercent.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTriggerLeftPercent.Location = new System.Drawing.Point(85, 65);
            this.lblTriggerLeftPercent.Name = "lblTriggerLeftPercent";
            this.lblTriggerLeftPercent.Size = new System.Drawing.Size(21, 20);
            this.lblTriggerLeftPercent.TabIndex = 8;
            this.lblTriggerLeftPercent.Text = "%";
            // 
            // numTriggerLeft
            // 
            this.numTriggerLeft.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.numTriggerLeft.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numTriggerLeft.Location = new System.Drawing.Point(37, 62);
            this.numTriggerLeft.Name = "numTriggerLeft";
            this.numTriggerLeft.Size = new System.Drawing.Size(48, 26);
            this.numTriggerLeft.TabIndex = 7;
            this.numTriggerLeft.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numTriggerLeft.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // lblTriggerRightPercent
            // 
            this.lblTriggerRightPercent.AutoSize = true;
            this.lblTriggerRightPercent.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTriggerRightPercent.Location = new System.Drawing.Point(204, 65);
            this.lblTriggerRightPercent.Name = "lblTriggerRightPercent";
            this.lblTriggerRightPercent.Size = new System.Drawing.Size(21, 20);
            this.lblTriggerRightPercent.TabIndex = 11;
            this.lblTriggerRightPercent.Text = "%";
            // 
            // numTriggerRight
            // 
            this.numTriggerRight.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.numTriggerRight.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numTriggerRight.Location = new System.Drawing.Point(156, 62);
            this.numTriggerRight.Name = "numTriggerRight";
            this.numTriggerRight.Size = new System.Drawing.Size(48, 26);
            this.numTriggerRight.TabIndex = 10;
            this.numTriggerRight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numTriggerRight.Value = new decimal(new int[] {
            70,
            0,
            0,
            0});
            // 
            // lblTriggerBottomPercent
            // 
            this.lblTriggerBottomPercent.AutoSize = true;
            this.lblTriggerBottomPercent.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTriggerBottomPercent.Location = new System.Drawing.Point(144, 103);
            this.lblTriggerBottomPercent.Name = "lblTriggerBottomPercent";
            this.lblTriggerBottomPercent.Size = new System.Drawing.Size(21, 20);
            this.lblTriggerBottomPercent.TabIndex = 5;
            this.lblTriggerBottomPercent.Text = "%";
            // 
            // numTriggerBottom
            // 
            this.numTriggerBottom.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.numTriggerBottom.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numTriggerBottom.Location = new System.Drawing.Point(97, 100);
            this.numTriggerBottom.Name = "numTriggerBottom";
            this.numTriggerBottom.Size = new System.Drawing.Size(47, 26);
            this.numTriggerBottom.TabIndex = 4;
            this.numTriggerBottom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numTriggerBottom.Value = new decimal(new int[] {
            70,
            0,
            0,
            0});
            // 
            // pnlTrigger
            // 
            this.pnlTrigger.Location = new System.Drawing.Point(10, 19);
            this.pnlTrigger.Name = "pnlTrigger";
            this.pnlTrigger.Size = new System.Drawing.Size(222, 116);
            this.pnlTrigger.TabIndex = 13;
            this.pnlTrigger.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlTrigger_MouseMove);
            // 
            // grpDock
            // 
            this.grpDock.Controls.Add(this.chkDockRight);
            this.grpDock.Controls.Add(this.chkDockBottom);
            this.grpDock.Controls.Add(this.chkDockLeft);
            this.grpDock.Controls.Add(this.chkDockTop);
            this.grpDock.Controls.Add(this.lblDockLeftPercent);
            this.grpDock.Controls.Add(this.numDockLeft);
            this.grpDock.Controls.Add(this.lblDockRightPercent);
            this.grpDock.Controls.Add(this.numDockRight);
            this.grpDock.Controls.Add(this.lblDockBottomPercent);
            this.grpDock.Controls.Add(this.numDockBottom);
            this.grpDock.Controls.Add(this.lblDockTopPercent);
            this.grpDock.Controls.Add(this.numDockTop);
            this.grpDock.Controls.Add(this.pnlDock);
            this.grpDock.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grpDock.Location = new System.Drawing.Point(256, 421);
            this.grpDock.Name = "grpDock";
            this.grpDock.Size = new System.Drawing.Size(238, 140);
            this.grpDock.TabIndex = 2;
            this.grpDock.TabStop = false;
            this.grpDock.Text = "停靠边界";
            // 
            // chkDockRight
            // 
            this.chkDockRight.AutoSize = true;
            this.chkDockRight.Checked = true;
            this.chkDockRight.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDockRight.Location = new System.Drawing.Point(136, 68);
            this.chkDockRight.Name = "chkDockRight";
            this.chkDockRight.Size = new System.Drawing.Size(15, 14);
            this.chkDockRight.TabIndex = 9;
            this.chkDockRight.UseVisualStyleBackColor = true;
            // 
            // chkDockBottom
            // 
            this.chkDockBottom.AutoSize = true;
            this.chkDockBottom.Checked = true;
            this.chkDockBottom.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDockBottom.Location = new System.Drawing.Point(77, 106);
            this.chkDockBottom.Name = "chkDockBottom";
            this.chkDockBottom.Size = new System.Drawing.Size(15, 14);
            this.chkDockBottom.TabIndex = 3;
            this.chkDockBottom.UseVisualStyleBackColor = true;
            // 
            // chkDockLeft
            // 
            this.chkDockLeft.AutoSize = true;
            this.chkDockLeft.Checked = true;
            this.chkDockLeft.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDockLeft.Location = new System.Drawing.Point(17, 68);
            this.chkDockLeft.Name = "chkDockLeft";
            this.chkDockLeft.Size = new System.Drawing.Size(15, 14);
            this.chkDockLeft.TabIndex = 6;
            this.chkDockLeft.UseVisualStyleBackColor = true;
            // 
            // chkDockTop
            // 
            this.chkDockTop.AutoSize = true;
            this.chkDockTop.Checked = true;
            this.chkDockTop.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDockTop.Location = new System.Drawing.Point(77, 30);
            this.chkDockTop.Name = "chkDockTop";
            this.chkDockTop.Size = new System.Drawing.Size(15, 14);
            this.chkDockTop.TabIndex = 0;
            this.chkDockTop.UseVisualStyleBackColor = true;
            // 
            // lblDockLeftPercent
            // 
            this.lblDockLeftPercent.AutoSize = true;
            this.lblDockLeftPercent.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDockLeftPercent.Location = new System.Drawing.Point(85, 65);
            this.lblDockLeftPercent.Name = "lblDockLeftPercent";
            this.lblDockLeftPercent.Size = new System.Drawing.Size(21, 20);
            this.lblDockLeftPercent.TabIndex = 8;
            this.lblDockLeftPercent.Text = "%";
            // 
            // numDockLeft
            // 
            this.numDockLeft.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.numDockLeft.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(229)))), ((int)(((byte)(23)))));
            this.numDockLeft.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numDockLeft.Location = new System.Drawing.Point(37, 62);
            this.numDockLeft.Maximum = new decimal(new int[] {
            95,
            0,
            0,
            0});
            this.numDockLeft.Name = "numDockLeft";
            this.numDockLeft.Size = new System.Drawing.Size(48, 26);
            this.numDockLeft.TabIndex = 7;
            this.numDockLeft.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numDockLeft.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // lblDockRightPercent
            // 
            this.lblDockRightPercent.AutoSize = true;
            this.lblDockRightPercent.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDockRightPercent.Location = new System.Drawing.Point(204, 65);
            this.lblDockRightPercent.Name = "lblDockRightPercent";
            this.lblDockRightPercent.Size = new System.Drawing.Size(21, 20);
            this.lblDockRightPercent.TabIndex = 11;
            this.lblDockRightPercent.Text = "%";
            // 
            // numDockRight
            // 
            this.numDockRight.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.numDockRight.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(23)))), ((int)(((byte)(229)))));
            this.numDockRight.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numDockRight.Location = new System.Drawing.Point(156, 62);
            this.numDockRight.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numDockRight.Name = "numDockRight";
            this.numDockRight.Size = new System.Drawing.Size(48, 26);
            this.numDockRight.TabIndex = 10;
            this.numDockRight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numDockRight.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
            // 
            // lblDockBottomPercent
            // 
            this.lblDockBottomPercent.AutoSize = true;
            this.lblDockBottomPercent.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDockBottomPercent.Location = new System.Drawing.Point(144, 103);
            this.lblDockBottomPercent.Name = "lblDockBottomPercent";
            this.lblDockBottomPercent.Size = new System.Drawing.Size(21, 20);
            this.lblDockBottomPercent.TabIndex = 5;
            this.lblDockBottomPercent.Text = "%";
            // 
            // numDockBottom
            // 
            this.numDockBottom.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.numDockBottom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.numDockBottom.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numDockBottom.Location = new System.Drawing.Point(97, 100);
            this.numDockBottom.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numDockBottom.Name = "numDockBottom";
            this.numDockBottom.Size = new System.Drawing.Size(47, 26);
            this.numDockBottom.TabIndex = 4;
            this.numDockBottom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numDockBottom.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
            // 
            // lblDockTopPercent
            // 
            this.lblDockTopPercent.AutoSize = true;
            this.lblDockTopPercent.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDockTopPercent.Location = new System.Drawing.Point(144, 27);
            this.lblDockTopPercent.Name = "lblDockTopPercent";
            this.lblDockTopPercent.Size = new System.Drawing.Size(21, 20);
            this.lblDockTopPercent.TabIndex = 2;
            this.lblDockTopPercent.Text = "%";
            // 
            // numDockTop
            // 
            this.numDockTop.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.numDockTop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
            this.numDockTop.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numDockTop.Location = new System.Drawing.Point(97, 24);
            this.numDockTop.Maximum = new decimal(new int[] {
            95,
            0,
            0,
            0});
            this.numDockTop.Name = "numDockTop";
            this.numDockTop.Size = new System.Drawing.Size(47, 26);
            this.numDockTop.TabIndex = 1;
            this.numDockTop.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numDockTop.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // pnlDock
            // 
            this.pnlDock.Location = new System.Drawing.Point(10, 19);
            this.pnlDock.Name = "pnlDock";
            this.pnlDock.Size = new System.Drawing.Size(222, 116);
            this.pnlDock.TabIndex = 13;
            this.pnlDock.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlDock_MouseMove);
            // 
            // btnInsert
            // 
            this.btnInsert.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnInsert.Location = new System.Drawing.Point(511, 443);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(75, 30);
            this.btnInsert.TabIndex = 3;
            this.btnInsert.Text = "增加";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnUpdate.Location = new System.Drawing.Point(511, 481);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 30);
            this.btnUpdate.TabIndex = 4;
            this.btnUpdate.Text = "修改";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDelete.Location = new System.Drawing.Point(511, 520);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 30);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lstAction
            // 
            this.lstAction.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lstAction.FormattingEnabled = true;
            this.lstAction.ItemHeight = 20;
            this.lstAction.Location = new System.Drawing.Point(12, 12);
            this.lstAction.Name = "lstAction";
            this.lstAction.Size = new System.Drawing.Size(582, 384);
            this.lstAction.TabIndex = 0;
            this.lstAction.SelectedIndexChanged += new System.EventHandler(this.lstAction_SelectedIndexChanged);
            this.lstAction.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstAction_KeyDown);
            // 
            // Dock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(606, 586);
            this.Controls.Add(this.lstAction);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.grpDock);
            this.Controls.Add(this.grpTrigger);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Dock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dockit - 停靠规则";
            ((System.ComponentModel.ISupportInitialize)(this.numTriggerTop)).EndInit();
            this.grpTrigger.ResumeLayout(false);
            this.grpTrigger.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTriggerLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTriggerRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTriggerBottom)).EndInit();
            this.grpDock.ResumeLayout(false);
            this.grpDock.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDockLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDockRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDockBottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDockTop)).EndInit();
            this.ResumeLayout(false);

        }


        private System.Windows.Forms.NumericUpDown numTriggerTop;
        private System.Windows.Forms.Label lblTriggerTopPercent;
        private System.Windows.Forms.GroupBox grpTrigger;
        private System.Windows.Forms.Label lblTriggerLeftPercent;
        private System.Windows.Forms.NumericUpDown numTriggerLeft;
        private System.Windows.Forms.Label lblTriggerRightPercent;
        private System.Windows.Forms.NumericUpDown numTriggerRight;
        private System.Windows.Forms.Label lblTriggerBottomPercent;
        private System.Windows.Forms.NumericUpDown numTriggerBottom;
        private System.Windows.Forms.GroupBox grpDock;
        private System.Windows.Forms.Label lblDockLeftPercent;
        private System.Windows.Forms.NumericUpDown numDockLeft;
        private System.Windows.Forms.Label lblDockRightPercent;
        private System.Windows.Forms.NumericUpDown numDockRight;
        private System.Windows.Forms.Label lblDockBottomPercent;
        private System.Windows.Forms.NumericUpDown numDockBottom;
        private System.Windows.Forms.Label lblDockTopPercent;
        private System.Windows.Forms.NumericUpDown numDockTop;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ListBox lstAction;
        private System.Windows.Forms.CheckBox chkTriggerRight;
        private System.Windows.Forms.CheckBox chkTriggerBottom;
        private System.Windows.Forms.CheckBox chkTriggerLeft;
        private System.Windows.Forms.CheckBox chkTriggerTop;
        private System.Windows.Forms.CheckBox chkDockRight;
        private System.Windows.Forms.CheckBox chkDockBottom;
        private System.Windows.Forms.CheckBox chkDockLeft;
        private System.Windows.Forms.CheckBox chkDockTop;
        private System.Windows.Forms.Panel pnlTrigger;
        private System.Windows.Forms.Panel pnlDock;
    }
}

