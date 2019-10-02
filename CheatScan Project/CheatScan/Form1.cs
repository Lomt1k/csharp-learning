using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace CheatScan
{
    public partial class Form1 : MetroForm
    {
        public static Form1 Instance;
        public static bool NeedScrollToBottom;

        public Form1()
        {
            Theme = MetroFramework.MetroThemeStyle.Dark;
            Style = MetroFramework.MetroColorStyle.Purple;  
            InitializeComponent();
            Instance = this;

            versionLabel.Text = Program.version;
            Label_Lifetime.Text = $"{Program.lifetimeInMinutes:0} минут назад";

            //--- Создаем логи
            Log.mainLog = new Log("index.html");
            Log.openedLog = Log.mainLog;
            webBrowser1.Navigate(Log.openedLog.Path);

            if (Program.Using_CLEO)
            {
                Log.cleoLog = new Log("cleo.html");
                button_CLEO.Enabled = true;
            }
            if (Program.Using_ASI)
            {
                Log.asiLog = new Log("asi.html");
                button_ASI.Enabled = true;
                button_ASI.Text = $"ASI ({Program.Modules_ASI.Count})";
            }
            if (Program.Using_SAMPFUNCS)
            {
                Log.sfLog = new Log("sf.html");
                button_SF.Enabled = true;
                button_SF.Text = $"SF ({Program.Modules_SF.Count})";
            }
            if (Program.Using_OTHER)
            {
                Log.otherLog = new Log("other.html");
                button_OTHER.Enabled = true;
                button_OTHER.Text = $"ПРОЧЕЕ ({Program.Modules_OTHER.Count})";
            }
            //--- Создаем логи

        }


        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private void metroLabel1_Click(object sender, EventArgs e)
        {

        }

        private void ConsoleBox_Click(object sender, EventArgs e)
        {
        }

        private void openFolderButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", Program.gta_path);
            //System.Diagnostics.Process.Start("explorer.exe", "shell:recent");
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            Log.openedLog = Log.mainLog;
            webBrowser1.Navigate(Log.openedLog.Path);
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            Log.openedLog = Log.otherLog;
            webBrowser1.Navigate(Log.openedLog.Path);
        }

        private void button_CLEO_Click(object sender, EventArgs e)
        {
            Log.openedLog = Log.cleoLog;
            webBrowser1.Navigate(Log.openedLog.Path);
        }

        private void button_ASI_Click(object sender, EventArgs e)
        {
            Log.openedLog = Log.asiLog;
            webBrowser1.Navigate(Log.openedLog.Path);
        }

        private void button_SF_Click(object sender, EventArgs e)
        {
            Log.openedLog = Log.sfLog;
            webBrowser1.Navigate(Log.openedLog.Path);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.threadScan.Abort();
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            if (NeedScrollToBottom)
            {
                HtmlDocument document = webBrowser1.Document;
                int top = document.GetElementsByTagName("HTML")[0].ScrollTop; //Vertical scroll
                webBrowser1.Document.Window.ScrollTo(0, webBrowser1.Document.Body.ScrollRectangle.Height); //Scroll to the bottom
                NeedScrollToBottom = false;
            }            
        }


        private void metroButton1_Click_2(object sender, EventArgs e)
        {
            string myDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            System.Diagnostics.Process.Start("explorer.exe", myDocuments + "\\GTA San Andreas User Files\\SAMP\\chatlog.txt");
            //System.Diagnostics.Process.Start("explorer.exe", "shell:recent"); //недавние документы
        }
    }
}
