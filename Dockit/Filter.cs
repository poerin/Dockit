using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Xml;

namespace Dockit
{
    public partial class Filter : Form
    {
        internal bool Spying = false;

        public Filter()
        {
            InitializeComponent();
            picSpy.Image = Properties.Resources.Spy.ToBitmap();
            foreach (XmlElement xe in Dockit.xeFilters)
            {
                XmlElement xeWindowClass = (XmlElement)xe.SelectSingleNode("WindowClass");
                XmlElement xeWindowTitle = (XmlElement)xe.SelectSingleNode("WindowTitle");
                XmlElement xeFilePath = (XmlElement)xe.SelectSingleNode("FilePath");
                lstProcess.Items.Add("类名：[ " + xeWindowClass.GetAttribute("Text") + " ]  —  标题" + (xeWindowTitle.GetAttribute("Logic") == "Include" ? "包含" : "等于") + "：[ " + xeWindowTitle.GetAttribute("Text") + " ]  —  路径：[ " + xeFilePath.GetAttribute("Text") + " ]");
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            this.Visible = false;
            e.Cancel = true;
        }

        internal void FillInfo(IntPtr handle)
        {
            WindowsInfoHelper.WindowInfo currentWindow = new WindowsInfoHelper.WindowInfo(handle);
            lblHandle.Text = "句柄：" + currentWindow.Handle;
            txtWindowTitle.Text = currentWindow.WindowTitle;
            txtWindowClass.Text = currentWindow.WindowClass;
            txtFilePath.Text = currentWindow.FilePath;
        }

        private void picSpy_MouseDown(object sender, MouseEventArgs e)
        {
            Spying = true;
            picSpy.Image = Properties.Resources.SypBlank.ToBitmap();
            Dockit.shadow.ClearShadow();
            Dockit.shadow.Cursor = new Cursor(GetType(), "Resources.Spy.cur");
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (txtFilePath.Text != "")
            {
                string logic;
                XmlElement xeFilterRule = Dockit.xdSetting.CreateElement("FilterRule");
                XmlElement xeWindowClass = Dockit.xdSetting.CreateElement("WindowClass");
                XmlElement xeWindowTitle = Dockit.xdSetting.CreateElement("WindowTitle");
                XmlElement xeFilePath = Dockit.xdSetting.CreateElement("FilePath");
                xeWindowClass.SetAttribute("Text", txtWindowClass.Text);
                xeWindowTitle.SetAttribute("Text", txtWindowTitle.Text);
                if (rdoInclude.Checked)
                {
                    xeWindowTitle.SetAttribute("Logic", "Include");
                    logic = "包含";
                }
                else
                {
                    xeWindowTitle.SetAttribute("Logic", "Equal");
                    logic = "等于";
                }
                xeFilePath.SetAttribute("Text", txtFilePath.Text);
                xeFilterRule.AppendChild(xeWindowClass);
                xeFilterRule.AppendChild(xeWindowTitle);
                xeFilterRule.AppendChild(xeFilePath);
                Dockit.xeFilters.AppendChild(xeFilterRule);
                Dockit.xdSetting.Save(Application.StartupPath + @"\configure.xml");
                lstProcess.Items.Add("类名：[ " + txtWindowClass.Text + " ]  —  标题" + logic + "：[ " + txtWindowTitle.Text + " ]  —  路径：[ " + txtFilePath.Text + " ]");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstProcess.SelectedItem != null)
            {
                int index = lstProcess.SelectedIndex;
                Dockit.xeFilters.RemoveChild(Dockit.xeFilters.ChildNodes[index]);
                lstProcess.Items.RemoveAt(index);
                Dockit.xdSetting.Save(Application.StartupPath + @"\configure.xml");
                lstProcess.SelectedIndex = index > lstProcess.Items.Count - 1 ? lstProcess.Items.Count - 1 : index;
            }
        }


    }
}
