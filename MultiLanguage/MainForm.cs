using System;
using System.Windows.Forms;

namespace MultiLanguage
{
    public partial class MainForm : Form
    {
        
            private const string APP_NAME = "记事本";
            private const int MAX_PATH = 256;

            private string appName;
            //窗体变量
            private string[] args = null;
            private string fileName = string.Empty;
            private string searchText = string.Empty;
            public MainForm()
            {
                InitializeComponent();
                appName = ML.GetText("INF_AppName", APP_NAME);
                ML.LoadFormLanguage(this);
                BuildLanguageMenuItems();
                
            }
            private void BuildLanguageMenuItems()
            {
                if (ML.LanguageLocalNames.Length == 0)
                {
                    miLanguage.Visible = false;
                    return;
                }

                for (int i = 0; i <= ML.LanguageLocalNames.Length - 1; i++)
                {
                    string ln = ML.LanguageLocalNames[i];
                    var menuItem = new ToolStripMenuItem(ln);
                    menuItem.Tag = i;
                    if (i == 0)
                        menuItem.Checked = true;
                    menuItem.Click += new EventHandler((sender, e) =>
                    {
                        foreach (ToolStripMenuItem item in miLanguage.DropDownItems)
                            item.Checked = (item == sender);
                        ML.LoadLanguageByIndex((int)(sender as ToolStripItem).Tag);
                        ML.LoadFormLanguage(this);
                    });
                    miLanguage.DropDownItems.Add(menuItem);
                }
            }          
            private void SetAppText(string text)
            {
                this.Text = text + " - " + APP_NAME;
            }

        private void button1_Click(object sender, EventArgs e)
        {
            ChildForm child = new ChildForm();
            child.Show();
        }
    }
}
