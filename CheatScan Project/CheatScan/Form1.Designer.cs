namespace CheatScan
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.versionLabel = new MetroFramework.Controls.MetroLabel();
            this.button_MAIN = new MetroFramework.Controls.MetroButton();
            this.button_CLEO = new MetroFramework.Controls.MetroButton();
            this.button_ASI = new MetroFramework.Controls.MetroButton();
            this.button_SF = new MetroFramework.Controls.MetroButton();
            this.button_OTHER = new MetroFramework.Controls.MetroButton();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.Label_Lifetime = new MetroFramework.Controls.MetroLabel();
            this.openFolderButton = new MetroFramework.Controls.MetroButton();
            this.ScanStatus = new MetroFramework.Controls.MetroLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // versionLabel
            // 
            this.versionLabel.AutoSize = true;
            this.versionLabel.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.versionLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.versionLabel.Location = new System.Drawing.Point(136, 26);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(66, 25);
            this.versionLabel.TabIndex = 0;
            this.versionLabel.Text = "version";
            this.versionLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.versionLabel.Click += new System.EventHandler(this.metroLabel1_Click);
            // 
            // button_MAIN
            // 
            this.button_MAIN.Location = new System.Drawing.Point(309, 28);
            this.button_MAIN.Name = "button_MAIN";
            this.button_MAIN.Size = new System.Drawing.Size(75, 23);
            this.button_MAIN.TabIndex = 2;
            this.button_MAIN.Text = "ГЛАВНОЕ";
            this.button_MAIN.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.button_MAIN.UseSelectable = true;
            this.button_MAIN.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // button_CLEO
            // 
            this.button_CLEO.Enabled = false;
            this.button_CLEO.Location = new System.Drawing.Point(399, 28);
            this.button_CLEO.Name = "button_CLEO";
            this.button_CLEO.Size = new System.Drawing.Size(75, 23);
            this.button_CLEO.TabIndex = 3;
            this.button_CLEO.Text = "CLEO";
            this.button_CLEO.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.button_CLEO.UseSelectable = true;
            this.button_CLEO.Click += new System.EventHandler(this.button_CLEO_Click);
            // 
            // button_ASI
            // 
            this.button_ASI.Enabled = false;
            this.button_ASI.Location = new System.Drawing.Point(490, 28);
            this.button_ASI.Name = "button_ASI";
            this.button_ASI.Size = new System.Drawing.Size(75, 23);
            this.button_ASI.TabIndex = 4;
            this.button_ASI.Text = "ASI";
            this.button_ASI.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.button_ASI.UseSelectable = true;
            this.button_ASI.Click += new System.EventHandler(this.button_ASI_Click);
            // 
            // button_SF
            // 
            this.button_SF.Enabled = false;
            this.button_SF.Location = new System.Drawing.Point(581, 28);
            this.button_SF.Name = "button_SF";
            this.button_SF.Size = new System.Drawing.Size(75, 23);
            this.button_SF.TabIndex = 5;
            this.button_SF.Text = "SF";
            this.button_SF.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.button_SF.UseSelectable = true;
            this.button_SF.Click += new System.EventHandler(this.button_SF_Click);
            // 
            // button_OTHER
            // 
            this.button_OTHER.Enabled = false;
            this.button_OTHER.Location = new System.Drawing.Point(672, 28);
            this.button_OTHER.Name = "button_OTHER";
            this.button_OTHER.Size = new System.Drawing.Size(75, 23);
            this.button_OTHER.TabIndex = 6;
            this.button_OTHER.Text = "ПРОЧЕЕ";
            this.button_OTHER.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.button_OTHER.UseSelectable = true;
            this.button_OTHER.Click += new System.EventHandler(this.metroButton5_Click);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(309, 73);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(678, 402);
            this.webBrowser1.TabIndex = 8;
            this.webBrowser1.Url = new System.Uri("", System.UriKind.Relative);
            this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            this.webBrowser1.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.webBrowser1_Navigated);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel1.Location = new System.Drawing.Point(128, 86);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(136, 25);
            this.metroLabel1.TabIndex = 10;
            this.metroLabel1.Text = "Игра запущена";
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // Label_Lifetime
            // 
            this.Label_Lifetime.AutoSize = true;
            this.Label_Lifetime.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.Label_Lifetime.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.Label_Lifetime.Location = new System.Drawing.Point(128, 113);
            this.Label_Lifetime.Name = "Label_Lifetime";
            this.Label_Lifetime.Size = new System.Drawing.Size(137, 25);
            this.Label_Lifetime.TabIndex = 11;
            this.Label_Lifetime.Text = "10 минут назад";
            this.Label_Lifetime.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // openFolderButton
            // 
            this.openFolderButton.Location = new System.Drawing.Point(127, 145);
            this.openFolderButton.Name = "openFolderButton";
            this.openFolderButton.Size = new System.Drawing.Size(136, 34);
            this.openFolderButton.TabIndex = 12;
            this.openFolderButton.Text = "ОТКРЫТЬ ПАПКУ";
            this.openFolderButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.openFolderButton.UseSelectable = true;
            this.openFolderButton.Click += new System.EventHandler(this.openFolderButton_Click);
            // 
            // ScanStatus
            // 
            this.ScanStatus.AutoSize = true;
            this.ScanStatus.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.ScanStatus.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.ScanStatus.Location = new System.Drawing.Point(18, 453);
            this.ScanStatus.Name = "ScanStatus";
            this.ScanStatus.Size = new System.Drawing.Size(184, 25);
            this.ScanStatus.TabIndex = 14;
            this.ScanStatus.Text = "Идет сканирование...";
            this.ScanStatus.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CheatScan.Properties.Resources.gta_san_andreas_icon;
            this.pictureBox1.Location = new System.Drawing.Point(22, 93);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(80, 80);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(22, 179);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(80, 23);
            this.metroButton1.TabIndex = 16;
            this.metroButton1.Text = "ChatLog";
            this.metroButton1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click_2);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1010, 498);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.ScanStatus);
            this.Controls.Add(this.openFolderButton);
            this.Controls.Add(this.Label_Lifetime);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.button_OTHER);
            this.Controls.Add(this.button_SF);
            this.Controls.Add(this.button_ASI);
            this.Controls.Add(this.button_CLEO);
            this.Controls.Add(this.button_MAIN);
            this.Controls.Add(this.versionLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Purple;
            this.Text = "CheatScan";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel versionLabel;
        private MetroFramework.Controls.MetroButton button_MAIN;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel Label_Lifetime;
        private MetroFramework.Controls.MetroButton openFolderButton;
        public System.Windows.Forms.WebBrowser webBrowser1;
        public MetroFramework.Controls.MetroButton button_CLEO;
        public MetroFramework.Controls.MetroLabel ScanStatus;
        private MetroFramework.Controls.MetroButton metroButton1;
        public MetroFramework.Controls.MetroButton button_ASI;
        public MetroFramework.Controls.MetroButton button_SF;
        public MetroFramework.Controls.MetroButton button_OTHER;
    }
}

