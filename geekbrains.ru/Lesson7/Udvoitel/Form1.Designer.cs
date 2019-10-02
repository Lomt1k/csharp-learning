namespace Udvoitel
{
    partial class Udvoitel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Udvoitel));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelScore = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.labelTarget = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelTurns = new System.Windows.Forms.Label();
            this.buttonPlus = new System.Windows.Forms.Button();
            this.buttonMult = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.pictureFail = new System.Windows.Forms.PictureBox();
            this.pictureWin = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureFail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureWin)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(84, 168);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(119, 43);
            this.button1.TabIndex = 0;
            this.button1.Text = "Играть";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(84, 217);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(119, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Выход";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBox1.Location = new System.Drawing.Point(12, 34);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(260, 64);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.Window;
            this.label1.Location = new System.Drawing.Point(71, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "СЧЕТ:";
            // 
            // labelScore
            // 
            this.labelScore.AutoSize = true;
            this.labelScore.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.labelScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelScore.ForeColor = System.Drawing.SystemColors.Window;
            this.labelScore.Location = new System.Drawing.Point(140, 48);
            this.labelScore.Name = "labelScore";
            this.labelScore.Size = new System.Drawing.Size(36, 37);
            this.labelScore.TabIndex = 4;
            this.labelScore.Text = "0";
            this.labelScore.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pictureBox2.Location = new System.Drawing.Point(12, 13);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(260, 22);
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(16, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "ЦЕЛЬ:";
            // 
            // labelTarget
            // 
            this.labelTarget.AutoSize = true;
            this.labelTarget.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.labelTarget.ForeColor = System.Drawing.SystemColors.Window;
            this.labelTarget.Location = new System.Drawing.Point(56, 18);
            this.labelTarget.Name = "labelTarget";
            this.labelTarget.Size = new System.Drawing.Size(97, 13);
            this.labelTarget.TabIndex = 7;
            this.labelTarget.Text = "Нажмите \'Играть\'";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(189, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "ХОДОВ:";
            // 
            // labelTurns
            // 
            this.labelTurns.AutoSize = true;
            this.labelTurns.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.labelTurns.ForeColor = System.Drawing.SystemColors.Window;
            this.labelTurns.Location = new System.Drawing.Point(241, 18);
            this.labelTurns.Name = "labelTurns";
            this.labelTurns.Size = new System.Drawing.Size(13, 13);
            this.labelTurns.TabIndex = 9;
            this.labelTurns.Text = "0";
            // 
            // buttonPlus
            // 
            this.buttonPlus.Location = new System.Drawing.Point(20, 105);
            this.buttonPlus.Name = "buttonPlus";
            this.buttonPlus.Size = new System.Drawing.Size(75, 38);
            this.buttonPlus.TabIndex = 10;
            this.buttonPlus.Text = "+1";
            this.buttonPlus.UseVisualStyleBackColor = true;
            this.buttonPlus.Click += new System.EventHandler(this.buttonPlus_Click);
            // 
            // buttonMult
            // 
            this.buttonMult.Location = new System.Drawing.Point(101, 105);
            this.buttonMult.Name = "buttonMult";
            this.buttonMult.Size = new System.Drawing.Size(75, 38);
            this.buttonMult.TabIndex = 11;
            this.buttonMult.Text = "x2";
            this.buttonMult.UseVisualStyleBackColor = true;
            this.buttonMult.Click += new System.EventHandler(this.buttonMult_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(192, 104);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 39);
            this.buttonCancel.TabIndex = 12;
            this.buttonCancel.Text = "<<";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // pictureFail
            // 
            this.pictureFail.Image = ((System.Drawing.Image)(resources.GetObject("pictureFail.Image")));
            this.pictureFail.Location = new System.Drawing.Point(5, 8);
            this.pictureFail.Name = "pictureFail";
            this.pictureFail.Size = new System.Drawing.Size(273, 150);
            this.pictureFail.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureFail.TabIndex = 13;
            this.pictureFail.TabStop = false;
            this.pictureFail.Visible = false;
            // 
            // pictureWin
            // 
            this.pictureWin.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pictureWin.ErrorImage")));
            this.pictureWin.Image = ((System.Drawing.Image)(resources.GetObject("pictureWin.Image")));
            this.pictureWin.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureWin.InitialImage")));
            this.pictureWin.Location = new System.Drawing.Point(5, 8);
            this.pictureWin.Name = "pictureWin";
            this.pictureWin.Size = new System.Drawing.Size(273, 150);
            this.pictureWin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureWin.TabIndex = 14;
            this.pictureWin.TabStop = false;
            this.pictureWin.Visible = false;
            // 
            // Udvoitel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.pictureWin);
            this.Controls.Add(this.pictureFail);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonMult);
            this.Controls.Add(this.buttonPlus);
            this.Controls.Add(this.labelTurns);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelTarget);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.labelScore);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Udvoitel";
            this.Text = "Удвоитель";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureFail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureWin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label labelScore;
        public System.Windows.Forms.Label labelTarget;
        public System.Windows.Forms.Label labelTurns;
        private System.Windows.Forms.Button buttonPlus;
        private System.Windows.Forms.Button buttonMult;
        private System.Windows.Forms.Button buttonCancel;
        public System.Windows.Forms.PictureBox pictureFail;
        public System.Windows.Forms.PictureBox pictureWin;
    }
}

