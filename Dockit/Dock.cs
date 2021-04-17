using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace Dockit
{
    public partial class Dock : Form
    {
        protected override void OnClosing(CancelEventArgs e)
        {
            HideTriggerPreview();
            HideDockPreview();
            this.Visible = false;
            e.Cancel = true;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            HideTriggerPreview();
            HideDockPreview();
        }

        public Dock()
        {
            InitializeComponent();
            gTrigger = pnlTrigger.CreateGraphics();
            gDock = pnlDock.CreateGraphics();

            chkTriggerTop.CheckedChanged += chkTriggerTop_CheckedChanged;
            chkTriggerBottom.CheckedChanged += chkTriggerBottom_CheckedChanged;
            chkTriggerLeft.CheckedChanged += chkTriggerLeft_CheckedChanged;
            chkTriggerRight.CheckedChanged += chkTriggerRight_CheckedChanged;
            chkDockTop.CheckedChanged += chkDockTop_CheckedChanged;
            chkDockBottom.CheckedChanged += chkDockBottom_CheckedChanged;
            chkDockLeft.CheckedChanged += chkDockLeft_CheckedChanged;
            chkDockRight.CheckedChanged += chkDockRight_CheckedChanged;

            foreach (XmlElement xe in Dockit.xeDocks)
            {
                XmlElement xeTrigger = (XmlElement)xe.SelectSingleNode("Trigger");
                XmlElement xeDock = (XmlElement)xe.SelectSingleNode("Dock");

                lstAction.Items.Add("触发：[ " + "上:" + xeTrigger.GetAttribute("Top") + " | 下:" + xeTrigger.GetAttribute("Bottom") + " | 左:" + xeTrigger.GetAttribute("Left") + " | 右:" + xeTrigger.GetAttribute("Right") + " ]  —  停靠：[ " + "上:" + xeDock.GetAttribute("Top") + " | 下:" + xeDock.GetAttribute("Bottom") + " | 左:" + xeDock.GetAttribute("Left") + " | 右:" + xeDock.GetAttribute("Right") + " ]");
            }

        }


        #region 预览事件

        Graphics gTrigger, gDock;
        bool isShowTriggerPreview = false;
        bool isShowDockPreview = false;

        private void ShowTriggerPreview()
        {
            chkTriggerTop.Visible = false;
            chkTriggerBottom.Visible = false;
            chkTriggerLeft.Visible = false;
            chkTriggerRight.Visible = false;
            numTriggerTop.Visible = false;
            numTriggerBottom.Visible = false;
            numTriggerLeft.Visible = false;
            numTriggerRight.Visible = false;
            lblTriggerTopPercent.Visible = false;
            lblTriggerBottomPercent.Visible = false;
            lblTriggerLeftPercent.Visible = false;
            lblTriggerRightPercent.Visible = false;

            pnlTrigger.Refresh();
            gTrigger.FillRectangle(Brushes.LightGray, 0, 0, pnlTrigger.Width, pnlTrigger.Height);

            int top = chkTriggerTop.Checked ? (int)numTriggerTop.Value : 0;
            int bottom = chkTriggerBottom.Checked ? (int)numTriggerBottom.Value : 100;
            int left = chkTriggerLeft.Checked ? (int)numTriggerLeft.Value : 0;
            int right = chkTriggerRight.Checked ? (int)numTriggerRight.Value : 100;

            if ((top == bottom) && (left == right))
            {
                gTrigger.DrawRectangle(new Pen(Color.Red, 4f), left * pnlTrigger.Width / 100f - 2, top * pnlTrigger.Height / 100f - 2, 4, 4);
            }
            else if ((top == bottom) || (left == right))
            {
                gTrigger.DrawLine(new Pen(Color.Red, 6f), left * pnlTrigger.Width / 100f, top * pnlTrigger.Height / 100f, right * pnlTrigger.Width / 100f, bottom * pnlTrigger.Height / 100f);
            }
            else
            {
                gTrigger.FillRectangle(Brushes.Red, left * pnlTrigger.Width / 100f, top * pnlTrigger.Height / 100f, pnlTrigger.Width * (right - left) / 100f, pnlTrigger.Height * (bottom - top) / 100f);
            }

            isShowTriggerPreview = true;
        }

        internal void HideTriggerPreview()
        {
            chkTriggerTop.Visible = true;
            chkTriggerBottom.Visible = true;
            chkTriggerLeft.Visible = true;
            chkTriggerRight.Visible = true;
            numTriggerTop.Visible = true;
            numTriggerBottom.Visible = true;
            numTriggerLeft.Visible = true;
            numTriggerRight.Visible = true;
            lblTriggerTopPercent.Visible = true;
            lblTriggerBottomPercent.Visible = true;
            lblTriggerLeftPercent.Visible = true;
            lblTriggerRightPercent.Visible = true;

            gTrigger.Clear(pnlTrigger.BackColor);
            gTrigger.FillRectangle(Brushes.LightGray, pnlTrigger.Width - 32, 0, 32, 18);
            gTrigger.FillRectangle(Brushes.Red, pnlTrigger.Width - 23, 4, 14, 10);
            isShowTriggerPreview = false;
        }

        internal void ShowDockPreview()
        {
            chkDockTop.Visible = false;
            chkDockBottom.Visible = false;
            chkDockLeft.Visible = false;
            chkDockRight.Visible = false;
            numDockTop.Visible = false;
            numDockBottom.Visible = false;
            numDockLeft.Visible = false;
            numDockRight.Visible = false;
            lblDockTopPercent.Visible = false;
            lblDockBottomPercent.Visible = false;
            lblDockLeftPercent.Visible = false;
            lblDockRightPercent.Visible = false;

            pnlDock.Refresh();
            gDock.FillRectangle(Brushes.LightGray, 0, 0, pnlDock.Width, pnlDock.Height);

            if (chkDockTop.Checked)
            {
                gDock.DrawLine(new Pen(Color.FromArgb(229, 23, 23), 4f), 0, (int)numDockTop.Value * pnlDock.Height / 100f, pnlDock.Width, (int)numDockTop.Value * pnlDock.Height / 100f);
            }

            if (chkDockBottom.Checked)
            {
                gDock.DrawLine(new Pen(Color.FromArgb(23, 229, 229), 4f), 0, (int)numDockBottom.Value * pnlDock.Height / 100f, pnlDock.Width, (int)numDockBottom.Value * pnlDock.Height / 100f);
            }

            if (chkDockLeft.Checked)
            {
                gDock.DrawLine(new Pen(Color.FromArgb(126, 229, 23), 4f), (int)numDockLeft.Value * pnlDock.Width / 100f, 0, (int)numDockLeft.Value * pnlDock.Width / 100f, pnlDock.Height);
            }

            if (chkDockRight.Checked)
            {
                gDock.DrawLine(new Pen(Color.FromArgb(126, 23, 229), 4f), (int)numDockRight.Value * pnlDock.Width / 100f, 0, (int)numDockRight.Value * pnlDock.Width / 100f, pnlDock.Height);
            }

            isShowDockPreview = true;
        }

        internal void HideDockPreview()
        {
            chkDockTop.Visible = true;
            chkDockBottom.Visible = true;
            chkDockLeft.Visible = true;
            chkDockRight.Visible = true;
            numDockTop.Visible = true;
            numDockBottom.Visible = true;
            numDockLeft.Visible = true;
            numDockRight.Visible = true;
            lblDockTopPercent.Visible = true;
            lblDockBottomPercent.Visible = true;
            lblDockLeftPercent.Visible = true;
            lblDockRightPercent.Visible = true;

            gDock.Clear(pnlDock.BackColor);
            gDock.FillRectangle(Brushes.LightGray, pnlDock.Width - 32, 0, 32, 18);
            gDock.FillRectangle(Brushes.Red, pnlDock.Width - 32, 8, 32, 2);
            gDock.FillRectangle(Brushes.Blue, pnlDock.Width - 17, 0, 2, 18);
            isShowDockPreview = false;
        }

        internal void pnlTrigger_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Location.X > 190 && e.Location.Y < 17)
            {
                if (!isShowTriggerPreview)
                {
                    ShowTriggerPreview();
                }
            }
            else
            {
                if (isShowTriggerPreview)
                {
                    HideTriggerPreview();
                }
            }
        }

        private void pnlDock_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Location.X > 190 && e.Location.Y < 17)
            {
                if (!isShowDockPreview)
                {
                    ShowDockPreview();
                }
            }
            else
            {
                if (isShowDockPreview)
                {
                    HideDockPreview();
                }
            }
        }

        #endregion

        #region Checkbox 事件
        void chkTriggerTop_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTriggerBottom.Checked)
            {
                numTriggerTop.Enabled = chkTriggerTop.Checked;
            }
            else
            {
                chkTriggerTop.Checked = true;
            }
        }

        void chkTriggerBottom_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTriggerTop.Checked)
            {
                numTriggerBottom.Enabled = chkTriggerBottom.Checked;
            }
            else
            {
                chkTriggerBottom.Checked = true;
            }
        }

        void chkTriggerLeft_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTriggerRight.Checked)
            {
                numTriggerLeft.Enabled = chkTriggerLeft.Checked;
            }
            else
            {
                chkTriggerLeft.Checked = true;
            }
        }

        void chkTriggerRight_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTriggerLeft.Checked)
            {
                numTriggerRight.Enabled = chkTriggerRight.Checked;
            }
            else
            {
                chkTriggerRight.Checked = true;
            }
        }

        void chkDockTop_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDockBottom.Checked || chkDockLeft.Checked || chkDockRight.Checked)
            {
                numDockTop.Enabled = chkDockTop.Checked;
            }
            else
            {
                chkDockTop.Checked = true;
            }
        }

        void chkDockBottom_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDockTop.Checked || chkDockLeft.Checked || chkDockRight.Checked)
            {
                numDockBottom.Enabled = chkDockBottom.Checked;
            }
            else
            {
                chkDockBottom.Checked = true;
            }
        }

        void chkDockLeft_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDockTop.Checked || chkDockBottom.Checked || chkDockRight.Checked)
            {
                numDockLeft.Enabled = chkDockLeft.Checked;
            }
            else
            {
                chkDockLeft.Checked = true;
            }
        }

        void chkDockRight_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDockTop.Checked || chkDockBottom.Checked || chkDockLeft.Checked)
            {
                numDockRight.Enabled = chkDockRight.Checked;
            }
            else
            {
                chkDockRight.Checked = true;
            }
        }
        #endregion


        private void btnInsert_Click(object sender, EventArgs e)
        {
            int tTop = chkTriggerTop.Checked ? (int)numTriggerTop.Value : 0;
            int tBottom = chkTriggerBottom.Checked ? (int)numTriggerBottom.Value : 100;
            int tLeft = chkTriggerLeft.Checked ? (int)numTriggerLeft.Value : 0;
            int tRight = chkTriggerRight.Checked ? (int)numTriggerRight.Value : 100;

            if (tTop > tBottom || tLeft > tRight)
            {
                MessageBox.Show("触发区域设置有误！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int dTop = chkDockTop.Checked ? (int)numDockTop.Value : -1;
            int dBottom = chkDockBottom.Checked ? (int)numDockBottom.Value : -1;
            int dLeft = chkDockLeft.Checked ? (int)numDockLeft.Value : -1;
            int dRight = chkDockRight.Checked ? (int)numDockRight.Value : -1;

            if (((dTop != -1 && dBottom != -1) && (dTop + 10 > dBottom)) || ((dLeft != -1 && dRight != -1) && (dLeft + 10 > dRight)))
            {
                MessageBox.Show("停靠边界跨度过小！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            XmlElement xeDockRule = Dockit.xdSetting.CreateElement("DockRule");
            XmlElement xeDock = Dockit.xdSetting.CreateElement("Dock");
            XmlElement xeTrigger = Dockit.xdSetting.CreateElement("Trigger");
            xeTrigger.SetAttribute("Top", tTop.ToString());
            xeTrigger.SetAttribute("Bottom", tBottom.ToString());
            xeTrigger.SetAttribute("Left", tLeft.ToString());
            xeTrigger.SetAttribute("Right", tRight.ToString());
            xeDock.SetAttribute("Top", (dTop != -1 ? dTop.ToString() : "-"));
            xeDock.SetAttribute("Bottom", (dBottom != -1 ? dBottom.ToString() : "-"));
            xeDock.SetAttribute("Left", (dLeft != -1 ? dLeft.ToString() : "-"));
            xeDock.SetAttribute("Right", (dRight != -1 ? dRight.ToString() : "-"));
            xeDockRule.AppendChild(xeTrigger);
            xeDockRule.AppendChild(xeDock);
            Dockit.xeDocks.AppendChild(xeDockRule);
            Dockit.xdSetting.Save(Application.StartupPath + @"\configure.xml");

            lstAction.Items.Add("触发：[ " + "上:" + tTop + " | 下:" + tBottom + " | 左:" + tLeft + " | 右:" + tRight + " ]  —  停靠：[ " + "上:" + (dTop != -1 ? dTop.ToString() : "-") + " | 下:" + (dBottom != -1 ? dBottom.ToString() : "-") + " | 左:" + (dLeft != -1 ? dLeft.ToString() : "-") + " | 右:" + (dRight != -1 ? dRight.ToString() : "-") + " ]");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (lstAction.SelectedItem != null)
            {
                int tTop = chkTriggerTop.Checked ? (int)numTriggerTop.Value : 0;
                int tBottom = chkTriggerBottom.Checked ? (int)numTriggerBottom.Value : 100;
                int tLeft = chkTriggerLeft.Checked ? (int)numTriggerLeft.Value : 0;
                int tRight = chkTriggerRight.Checked ? (int)numTriggerRight.Value : 100;

                if (tTop > tBottom || tLeft > tRight)
                {
                    MessageBox.Show("触发区域设置有误！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else if (tTop == 0 && tBottom == 100 && tLeft == 0 && tBottom == tRight)
                {
                    MessageBox.Show("触发区域不能为全屏区域！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int dTop = chkDockTop.Checked ? (int)numDockTop.Value : -1;
                int dBottom = chkDockBottom.Checked ? (int)numDockBottom.Value : -1;
                int dLeft = chkDockLeft.Checked ? (int)numDockLeft.Value : -1;
                int dRight = chkDockRight.Checked ? (int)numDockRight.Value : -1;

                if (((dTop != -1 && dBottom != -1) && (dTop + 10 > dBottom)) || ((dLeft != -1 && dRight != -1) && (dLeft + 10 > dRight)))
                {
                    MessageBox.Show("停靠边界跨度过小！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                XmlElement xeDockRule = Dockit.xdSetting.CreateElement("DockRule");
                XmlElement xeDock = Dockit.xdSetting.CreateElement("Dock");
                XmlElement xeTrigger = Dockit.xdSetting.CreateElement("Trigger");
                xeTrigger.SetAttribute("Top", tTop.ToString());
                xeTrigger.SetAttribute("Bottom", tBottom.ToString());
                xeTrigger.SetAttribute("Left", tLeft.ToString());
                xeTrigger.SetAttribute("Right", tRight.ToString());
                xeDock.SetAttribute("Top", (dTop != -1 ? dTop.ToString() : "-"));
                xeDock.SetAttribute("Bottom", (dBottom != -1 ? dBottom.ToString() : "-"));
                xeDock.SetAttribute("Left", (dLeft != -1 ? dLeft.ToString() : "-"));
                xeDock.SetAttribute("Right", (dRight != -1 ? dRight.ToString() : "-"));
                xeDockRule.AppendChild(xeTrigger);
                xeDockRule.AppendChild(xeDock);
                Dockit.xeDocks.ReplaceChild(xeDockRule, Dockit.xeDocks.ChildNodes[lstAction.SelectedIndex]);
                Dockit.xdSetting.Save(Application.StartupPath + @"\configure.xml");

                lstAction.Items[lstAction.SelectedIndex] = ("触发：[ " + "上:" + tTop + " | 下:" + tBottom + " | 左:" + tLeft + " | 右:" + tRight + " ]  —  停靠：[ " + "上:" + (dTop != -1 ? dTop.ToString() : "-") + " | 下:" + (dBottom != -1 ? dBottom.ToString() : "-") + " | 左:" + (dLeft != -1 ? dLeft.ToString() : "-") + " | 右:" + (dRight != -1 ? dRight.ToString() : "-") + " ]");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstAction.SelectedItem != null)
            {
                int index = lstAction.SelectedIndex;
                Dockit.xeDocks.RemoveChild(Dockit.xeDocks.ChildNodes[index]);
                lstAction.Items.RemoveAt(index);
                Dockit.xdSetting.Save(Application.StartupPath + @"\configure.xml");
                lstAction.SelectedIndex = index > lstAction.Items.Count - 1 ? lstAction.Items.Count - 1 : index;
            }
        }

        private void lstAction_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstAction.SelectedItem != null)
            {
                XmlElement xeTrigger = (XmlElement)(Dockit.xeDocks.ChildNodes[lstAction.SelectedIndex]).SelectSingleNode("Trigger");
                XmlElement xeDock = (XmlElement)(Dockit.xeDocks.ChildNodes[lstAction.SelectedIndex]).SelectSingleNode("Dock");

                numTriggerTop.Value = Convert.ToInt32(xeTrigger.GetAttribute("Top"));
                numTriggerBottom.Value = Convert.ToInt32(xeTrigger.GetAttribute("Bottom"));
                numTriggerLeft.Value = Convert.ToInt32(xeTrigger.GetAttribute("Left"));
                numTriggerRight.Value = Convert.ToInt32(xeTrigger.GetAttribute("Right"));

                numDockTop.Value = xeDock.GetAttribute("Top") != "-" ? Convert.ToInt32(xeDock.GetAttribute("Top")) : 0;
                numDockBottom.Value = xeDock.GetAttribute("Bottom") != "-" ? Convert.ToInt32(xeDock.GetAttribute("Bottom")) : 100;
                numDockLeft.Value = xeDock.GetAttribute("Left") != "-" ? Convert.ToInt32(xeDock.GetAttribute("Left")) : 0;
                numDockRight.Value = xeDock.GetAttribute("Right") != "-" ? Convert.ToInt32(xeDock.GetAttribute("Right")) : 100;

                if (xeDock.GetAttribute("Top") == "-")
                {
                    chkDockTop.Checked = false;
                }
                else
                {
                    chkDockTop.Checked = true;
                }

                if (xeDock.GetAttribute("Bottom") == "-")
                {
                    chkDockBottom.Checked = false;
                }
                else
                {
                    chkDockBottom.Checked = true;
                }

                if (xeDock.GetAttribute("Left") == "-")
                {
                    chkDockLeft.Checked = false;
                }
                else
                {
                    chkDockLeft.Checked = true;
                }

                if (xeDock.GetAttribute("Right") == "-")
                {
                    chkDockRight.Checked = false;
                }
                else
                {
                    chkDockRight.Checked = true;
                }

                chkTriggerTop.Checked = true;
                chkTriggerBottom.Checked = true;
                chkTriggerLeft.Checked = true;
                chkTriggerRight.Checked = true;

                if (isShowTriggerPreview)
                {
                    ShowTriggerPreview();
                }

                if (isShowDockPreview)
                {
                    ShowDockPreview();
                }

            }
        }

        private void lstAction_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstAction.SelectedIndex > 0)
                {
                    int index = lstAction.SelectedIndex;

                    XmlNode PreNode = Dockit.xeDocks.ChildNodes[index - 1].Clone();
                    Dockit.xeDocks.ReplaceChild(Dockit.xeDocks.ChildNodes[index].Clone(), Dockit.xeDocks.ChildNodes[index - 1]);
                    Dockit.xeDocks.ReplaceChild(PreNode, Dockit.xeDocks.ChildNodes[index]);

                    string temp = lstAction.Items[index - 1].ToString();
                    lstAction.Items[index - 1] = lstAction.SelectedItem.ToString(); ;
                    lstAction.Items[index] = temp;

                    Dockit.xdSetting.Save(Application.StartupPath + @"\configure.xml");
                }
            }
            else if (e.KeyCode == Keys.Down)
            {
                if (lstAction.SelectedIndex < lstAction.Items.Count - 1)
                {
                    int index = lstAction.SelectedIndex;

                    XmlNode NextNode = Dockit.xeDocks.ChildNodes[index + 1].Clone();
                    Dockit.xeDocks.ReplaceChild(Dockit.xeDocks.ChildNodes[index].Clone(), Dockit.xeDocks.ChildNodes[index + 1]);
                    Dockit.xeDocks.ReplaceChild(NextNode, Dockit.xeDocks.ChildNodes[index]);

                    string temp = lstAction.Items[index + 1].ToString();
                    lstAction.Items[index + 1] = lstAction.SelectedItem.ToString(); ;
                    lstAction.Items[index] = temp;

                    Dockit.xdSetting.Save(Application.StartupPath + @"\configure.xml");
                }
            }
        }


    }
}
