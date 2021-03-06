﻿using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Dockit
{
    internal partial class Shadow : Form
    {
        #region 鼠标穿透
        [DllImport("user32", EntryPoint = "GetWindowLong")]
        private static extern uint GetWindowLong(IntPtr hwnd, int nIndex);
        [DllImport("user32", EntryPoint = "SetWindowLong")]
        private static extern uint SetWindowLong(IntPtr hwnd, int nIndex, uint dwNewLong);
        const int GWL_EXSTYLE = -20;
        const int WS_EX_TRANSPARENT = 0x20;
        const int WS_EX_LAYERED = 0x80000;
        const int WS_EX_NOACTIVATE = 0x8000000;
        #endregion

        private readonly Pen pen = new Pen(Color.FromArgb(254, 254, 254), 8f);

        public Shadow()
        {
            InitializeComponent();
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            SetWindowLong(this.Handle, GWL_EXSTYLE, GetWindowLong(this.Handle, GWL_EXSTYLE) | WS_EX_TRANSPARENT | WS_EX_LAYERED | WS_EX_NOACTIVATE);
        }

        internal void FillShadow(Rectangle rect)
        {
            this.Bounds = rect;
            this.BackColor = Color.DimGray;
            this.Visible = true;
        }

        internal void ClearShadow()
        {
            this.Visible = false;
            this.BackColor = Color.White;

            if (Dockit.filter.Spying)
            {
                this.Location = Screen.FromPoint(Cursor.Position).Bounds.Location;
                this.Size = Screen.FromPoint(Cursor.Position).Bounds.Size;
            }
            else
            {
                this.Location = new Point(0, 0);
                this.Size = new Size(0, 0);
            }

        }

        private void Shadow_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLines(pen, new Point[] { new Point(0, 0), new Point(this.Size.Width, 0), new Point(this.Size.Width, this.Size.Height), new Point(0, this.Size.Height), new Point(0, 0) });
        }


    }
}
