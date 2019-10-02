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

namespace ColoredTableGenerator2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            GenerateColorTable();
        }

        public void GenerateColorTable()
        {
            labelSaved.Hide();
            Program.count = 0;

            label1.Text = Program.GetRandomColorText();
            label1.ForeColor = Program.GetRandomColor();

            label2.Text = Program.GetRandomColorText();
            label2.ForeColor = Program.GetRandomColor();

            label3.Text = Program.GetRandomColorText();
            label3.ForeColor = Program.GetRandomColor();

            label4.Text = Program.GetRandomColorText();
            label4.ForeColor = Program.GetRandomColor();

            label5.Text = Program.GetRandomColorText();
            label5.ForeColor = Program.GetRandomColor();

            label6.Text = Program.GetRandomColorText();
            label6.ForeColor = Program.GetRandomColor();

            label7.Text = Program.GetRandomColorText();
            label7.ForeColor = Program.GetRandomColor();

            label8.Text = Program.GetRandomColorText();
            label8.ForeColor = Program.GetRandomColor();

            label9.Text = Program.GetRandomColorText();
            label9.ForeColor = Program.GetRandomColor();

            label10.Text = Program.GetRandomColorText();
            label10.ForeColor = Program.GetRandomColor();

            label11.Text = Program.GetRandomColorText();
            label11.ForeColor = Program.GetRandomColor();

            label12.Text = Program.GetRandomColorText();
            label12.ForeColor = Program.GetRandomColor();

            label13.Text = Program.GetRandomColorText();
            label13.ForeColor = Program.GetRandomColor();

            label14.Text = Program.GetRandomColorText();
            label14.ForeColor = Program.GetRandomColor();

            label15.Text = Program.GetRandomColorText();
            label15.ForeColor = Program.GetRandomColor();

            label16.Text = Program.GetRandomColorText();
            label16.ForeColor = Program.GetRandomColor();

            label17.Text = Program.GetRandomColorText();
            label17.ForeColor = Program.GetRandomColor();

            label18.Text = Program.GetRandomColorText();
            label18.ForeColor = Program.GetRandomColor();

            label19.Text = Program.GetRandomColorText();
            label19.ForeColor = Program.GetRandomColor();

            label20.Text = Program.GetRandomColorText();
            label20.ForeColor = Program.GetRandomColor();
        }

        //сохранить в виде картинки
        void SaveImage()
        {
            Rectangle bounds = this.Bounds;
            bounds.X += 10;
            bounds.Width -= 20;
            bounds.Y += 30;
            bounds.Height -= 295;
            using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                     g.CopyFromScreen(new Point(bounds.Left, bounds.Top), Point.Empty, bounds.Size);
                }
                Random rnd = new Random();
                if (!Directory.Exists("Images")) Directory.CreateDirectory("Images");
                string name = $"img_{(char)rnd.Next(97, 122)}{(char)rnd.Next(97, 122)}{(char)rnd.Next(97, 122)}{(char)rnd.Next(97, 122)}{(char)rnd.Next(97, 122)}{(char)rnd.Next(97, 122)}{(char)rnd.Next(97, 122)}.jpg";
                bitmap.Save("Images\\" + name, System.Drawing.Imaging.ImageFormat.Jpeg);
                labelSaved.Text = "Сохранено " + name;
                labelSaved.Show();
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GenerateColorTable();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveImage();
        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void bgBox_Click(object sender, EventArgs e)
        {

        }

        private void pictureboxBG_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            pictureboxBG.BackColor = Color.FromName(comboBoxBGColor.Text);
            labelHeader.BackColor = Color.FromName(comboBoxBGColor.Text);
            labelFooter.BackColor = Color.FromName(comboBoxBGColor.Text);
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            Color color = Color.FromName(comboBox1.Text);
            Program.colors[0] = color;
            pictureBoxCol1.BackColor = color;

            if (Program.labelColorID[1] == 0) label1.ForeColor = color;
            if (Program.labelColorID[2] == 0) label2.ForeColor = color;
            if (Program.labelColorID[3] == 0) label3.ForeColor = color;
            if (Program.labelColorID[4] == 0) label4.ForeColor = color;
            if (Program.labelColorID[5] == 0) label5.ForeColor = color;
            if (Program.labelColorID[6] == 0) label6.ForeColor = color;
            if (Program.labelColorID[7] == 0) label7.ForeColor = color;
            if (Program.labelColorID[8] == 0) label8.ForeColor = color;
            if (Program.labelColorID[9] == 0) label9.ForeColor = color;
            if (Program.labelColorID[10] == 0) label10.ForeColor = color;
            if (Program.labelColorID[11] == 0) label11.ForeColor = color;
            if (Program.labelColorID[12] == 0) label12.ForeColor = color;
            if (Program.labelColorID[13] == 0) label13.ForeColor = color;
            if (Program.labelColorID[14] == 0) label14.ForeColor = color;
            if (Program.labelColorID[15] == 0) label15.ForeColor = color;
            if (Program.labelColorID[16] == 0) label16.ForeColor = color;
            if (Program.labelColorID[17] == 0) label17.ForeColor = color;
            if (Program.labelColorID[18] == 0) label18.ForeColor = color;
            if (Program.labelColorID[19] == 0) label19.ForeColor = color;
            if (Program.labelColorID[20] == 0) label20.ForeColor = color;
        }

        private void textBoxColor1_TextChanged(object sender, EventArgs e)
        {
            Program.colorNames[0] = textBoxColor1.Text;

            if (Program.labelTextID[1] == 0) label1.Text = textBoxColor1.Text;
            if (Program.labelTextID[2] == 0) label2.Text = textBoxColor1.Text;
            if (Program.labelTextID[3] == 0) label3.Text = textBoxColor1.Text;
            if (Program.labelTextID[4] == 0) label4.Text = textBoxColor1.Text;
            if (Program.labelTextID[5] == 0) label5.Text = textBoxColor1.Text;
            if (Program.labelTextID[6] == 0) label6.Text = textBoxColor1.Text;
            if (Program.labelTextID[7] == 0) label7.Text = textBoxColor1.Text;
            if (Program.labelTextID[8] == 0) label8.Text = textBoxColor1.Text;
            if (Program.labelTextID[9] == 0) label9.Text = textBoxColor1.Text;
            if (Program.labelTextID[10] == 0) label10.Text = textBoxColor1.Text;
            if (Program.labelTextID[11] == 0) label11.Text = textBoxColor1.Text;
            if (Program.labelTextID[12] == 0) label12.Text = textBoxColor1.Text;
            if (Program.labelTextID[13] == 0) label13.Text = textBoxColor1.Text;
            if (Program.labelTextID[14] == 0) label14.Text = textBoxColor1.Text;
            if (Program.labelTextID[15] == 0) label15.Text = textBoxColor1.Text;
            if (Program.labelTextID[16] == 0) label16.Text = textBoxColor1.Text;
            if (Program.labelTextID[17] == 0) label17.Text = textBoxColor1.Text;
            if (Program.labelTextID[18] == 0) label18.Text = textBoxColor1.Text;
            if (Program.labelTextID[19] == 0) label19.Text = textBoxColor1.Text;
            if (Program.labelTextID[20] == 0) label20.Text = textBoxColor1.Text;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Color color = Color.FromName(comboBox2.Text);
            Program.colors[1] = color;
            pictureBoxCol2.BackColor = color;

            if (Program.labelColorID[1] == 1) label1.ForeColor = color;
            if (Program.labelColorID[2] == 1) label2.ForeColor = color;
            if (Program.labelColorID[3] == 1) label3.ForeColor = color;
            if (Program.labelColorID[4] == 1) label4.ForeColor = color;
            if (Program.labelColorID[5] == 1) label5.ForeColor = color;
            if (Program.labelColorID[6] == 1) label6.ForeColor = color;
            if (Program.labelColorID[7] == 1) label7.ForeColor = color;
            if (Program.labelColorID[8] == 1) label8.ForeColor = color;
            if (Program.labelColorID[9] == 1) label9.ForeColor = color;
            if (Program.labelColorID[10] == 1) label10.ForeColor = color;
            if (Program.labelColorID[11] == 1) label11.ForeColor = color;
            if (Program.labelColorID[12] == 1) label12.ForeColor = color;
            if (Program.labelColorID[13] == 1) label13.ForeColor = color;
            if (Program.labelColorID[14] == 1) label14.ForeColor = color;
            if (Program.labelColorID[15] == 1) label15.ForeColor = color;
            if (Program.labelColorID[16] == 1) label16.ForeColor = color;
            if (Program.labelColorID[17] == 1) label17.ForeColor = color;
            if (Program.labelColorID[18] == 1) label18.ForeColor = color;
            if (Program.labelColorID[19] == 1) label19.ForeColor = color;
            if (Program.labelColorID[20] == 1) label20.ForeColor = color;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Program.colorNames[1] = textBox1.Text;

            if (Program.labelTextID[1] == 1) label1.Text = textBox1.Text;
            if (Program.labelTextID[2] == 1) label2.Text = textBox1.Text;
            if (Program.labelTextID[3] == 1) label3.Text = textBox1.Text;
            if (Program.labelTextID[4] == 1) label4.Text = textBox1.Text;
            if (Program.labelTextID[5] == 1) label5.Text = textBox1.Text;
            if (Program.labelTextID[6] == 1) label6.Text = textBox1.Text;
            if (Program.labelTextID[7] == 1) label7.Text = textBox1.Text;
            if (Program.labelTextID[8] == 1) label8.Text = textBox1.Text;
            if (Program.labelTextID[9] == 1) label9.Text = textBox1.Text;
            if (Program.labelTextID[10] == 1) label10.Text = textBox1.Text;
            if (Program.labelTextID[11] == 1) label11.Text = textBox1.Text;
            if (Program.labelTextID[12] == 1) label12.Text = textBox1.Text;
            if (Program.labelTextID[13] == 1) label13.Text = textBox1.Text;
            if (Program.labelTextID[14] == 1) label14.Text = textBox1.Text;
            if (Program.labelTextID[15] == 1) label15.Text = textBox1.Text;
            if (Program.labelTextID[16] == 1) label16.Text = textBox1.Text;
            if (Program.labelTextID[17] == 1) label17.Text = textBox1.Text;
            if (Program.labelTextID[18] == 1) label18.Text = textBox1.Text;
            if (Program.labelTextID[19] == 1) label19.Text = textBox1.Text;
            if (Program.labelTextID[20] == 1) label20.Text = textBox1.Text;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            Color color = Color.FromName(comboBox3.Text);
            Program.colors[2] = color;
            pictureBoxCol3.BackColor = color;

            if (Program.labelColorID[1] == 2) label1.ForeColor = color;
            if (Program.labelColorID[2] == 2) label2.ForeColor = color;
            if (Program.labelColorID[3] == 2) label3.ForeColor = color;
            if (Program.labelColorID[4] == 2) label4.ForeColor = color;
            if (Program.labelColorID[5] == 2) label5.ForeColor = color;
            if (Program.labelColorID[6] == 2) label6.ForeColor = color;
            if (Program.labelColorID[7] == 2) label7.ForeColor = color;
            if (Program.labelColorID[8] == 2) label8.ForeColor = color;
            if (Program.labelColorID[9] == 2) label9.ForeColor = color;
            if (Program.labelColorID[10] == 2) label10.ForeColor = color;
            if (Program.labelColorID[11] == 2) label11.ForeColor = color;
            if (Program.labelColorID[12] == 2) label12.ForeColor = color;
            if (Program.labelColorID[13] == 2) label13.ForeColor = color;
            if (Program.labelColorID[14] == 2) label14.ForeColor = color;
            if (Program.labelColorID[15] == 2) label15.ForeColor = color;
            if (Program.labelColorID[16] == 2) label16.ForeColor = color;
            if (Program.labelColorID[17] == 2) label17.ForeColor = color;
            if (Program.labelColorID[18] == 2) label18.ForeColor = color;
            if (Program.labelColorID[19] == 2) label19.ForeColor = color;
            if (Program.labelColorID[20] == 2) label20.ForeColor = color;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Program.colorNames[2] = textBox2.Text;

            if (Program.labelTextID[1] == 2) label1.Text = textBox2.Text;
            if (Program.labelTextID[2] == 2) label2.Text = textBox2.Text;
            if (Program.labelTextID[3] == 2) label3.Text = textBox2.Text;
            if (Program.labelTextID[4] == 2) label4.Text = textBox2.Text;
            if (Program.labelTextID[5] == 2) label5.Text = textBox2.Text;
            if (Program.labelTextID[6] == 2) label6.Text = textBox2.Text;
            if (Program.labelTextID[7] == 2) label7.Text = textBox2.Text;
            if (Program.labelTextID[8] == 2) label8.Text = textBox2.Text;
            if (Program.labelTextID[9] == 2) label9.Text = textBox2.Text;
            if (Program.labelTextID[10] == 2) label10.Text = textBox2.Text;
            if (Program.labelTextID[11] == 2) label11.Text = textBox2.Text;
            if (Program.labelTextID[12] == 2) label12.Text = textBox2.Text;
            if (Program.labelTextID[13] == 2) label13.Text = textBox2.Text;
            if (Program.labelTextID[14] == 2) label14.Text = textBox2.Text;
            if (Program.labelTextID[15] == 2) label15.Text = textBox2.Text;
            if (Program.labelTextID[16] == 2) label16.Text = textBox2.Text;
            if (Program.labelTextID[17] == 2) label17.Text = textBox2.Text;
            if (Program.labelTextID[18] == 2) label18.Text = textBox2.Text;
            if (Program.labelTextID[19] == 2) label19.Text = textBox2.Text;
            if (Program.labelTextID[20] == 2) label20.Text = textBox2.Text;
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            Color color = Color.FromName(comboBox4.Text);
            Program.colors[3] = color;
            pictureBoxCol4.BackColor = color;

            if (Program.labelColorID[1] == 3) label1.ForeColor = color;
            if (Program.labelColorID[2] == 3) label2.ForeColor = color;
            if (Program.labelColorID[3] == 3) label3.ForeColor = color;
            if (Program.labelColorID[4] == 3) label4.ForeColor = color;
            if (Program.labelColorID[5] == 3) label5.ForeColor = color;
            if (Program.labelColorID[6] == 3) label6.ForeColor = color;
            if (Program.labelColorID[7] == 3) label7.ForeColor = color;
            if (Program.labelColorID[8] == 3) label8.ForeColor = color;
            if (Program.labelColorID[9] == 3) label9.ForeColor = color;
            if (Program.labelColorID[10] == 3) label10.ForeColor = color;
            if (Program.labelColorID[11] == 3) label11.ForeColor = color;
            if (Program.labelColorID[12] == 3) label12.ForeColor = color;
            if (Program.labelColorID[13] == 3) label13.ForeColor = color;
            if (Program.labelColorID[14] == 3) label14.ForeColor = color;
            if (Program.labelColorID[15] == 3) label15.ForeColor = color;
            if (Program.labelColorID[16] == 3) label16.ForeColor = color;
            if (Program.labelColorID[17] == 3) label17.ForeColor = color;
            if (Program.labelColorID[18] == 3) label18.ForeColor = color;
            if (Program.labelColorID[19] == 3) label19.ForeColor = color;
            if (Program.labelColorID[20] == 3) label20.ForeColor = color;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            Program.colorNames[3] = textBox3.Text;

            if (Program.labelTextID[1] == 3) label1.Text = textBox3.Text;
            if (Program.labelTextID[2] == 3) label2.Text = textBox3.Text;
            if (Program.labelTextID[3] == 3) label3.Text = textBox3.Text;
            if (Program.labelTextID[4] == 3) label4.Text = textBox3.Text;
            if (Program.labelTextID[5] == 3) label5.Text = textBox3.Text;
            if (Program.labelTextID[6] == 3) label6.Text = textBox3.Text;
            if (Program.labelTextID[7] == 3) label7.Text = textBox3.Text;
            if (Program.labelTextID[8] == 3) label8.Text = textBox3.Text;
            if (Program.labelTextID[9] == 3) label9.Text = textBox3.Text;
            if (Program.labelTextID[10] == 3) label10.Text = textBox3.Text;
            if (Program.labelTextID[11] == 3) label11.Text = textBox3.Text;
            if (Program.labelTextID[12] == 3) label12.Text = textBox3.Text;
            if (Program.labelTextID[13] == 3) label13.Text = textBox3.Text;
            if (Program.labelTextID[14] == 3) label14.Text = textBox3.Text;
            if (Program.labelTextID[15] == 3) label15.Text = textBox3.Text;
            if (Program.labelTextID[16] == 3) label16.Text = textBox3.Text;
            if (Program.labelTextID[17] == 3) label17.Text = textBox3.Text;
            if (Program.labelTextID[18] == 3) label18.Text = textBox3.Text;
            if (Program.labelTextID[19] == 3) label19.Text = textBox3.Text;
            if (Program.labelTextID[20] == 3) label20.Text = textBox3.Text;
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            Color color = Color.FromName(comboBox5.Text);
            Program.colors[4] = color;
            pictureBoxCol5.BackColor = color;

            if (Program.labelColorID[1] == 4) label1.ForeColor = color;
            if (Program.labelColorID[2] == 4) label2.ForeColor = color;
            if (Program.labelColorID[3] == 4) label3.ForeColor = color;
            if (Program.labelColorID[4] == 4) label4.ForeColor = color;
            if (Program.labelColorID[5] == 4) label5.ForeColor = color;
            if (Program.labelColorID[6] == 4) label6.ForeColor = color;
            if (Program.labelColorID[7] == 4) label7.ForeColor = color;
            if (Program.labelColorID[8] == 4) label8.ForeColor = color;
            if (Program.labelColorID[9] == 4) label9.ForeColor = color;
            if (Program.labelColorID[10] == 4) label10.ForeColor = color;
            if (Program.labelColorID[11] == 4) label11.ForeColor = color;
            if (Program.labelColorID[12] == 4) label12.ForeColor = color;
            if (Program.labelColorID[13] == 4) label13.ForeColor = color;
            if (Program.labelColorID[14] == 4) label14.ForeColor = color;
            if (Program.labelColorID[15] == 4) label15.ForeColor = color;
            if (Program.labelColorID[16] == 4) label16.ForeColor = color;
            if (Program.labelColorID[17] == 4) label17.ForeColor = color;
            if (Program.labelColorID[18] == 4) label18.ForeColor = color;
            if (Program.labelColorID[19] == 4) label19.ForeColor = color;
            if (Program.labelColorID[20] == 4) label20.ForeColor = color;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            Program.colorNames[4] = textBox4.Text;

            if (Program.labelTextID[1] == 4) label1.Text = textBox4.Text;
            if (Program.labelTextID[2] == 4) label2.Text = textBox4.Text;
            if (Program.labelTextID[3] == 4) label3.Text = textBox4.Text;
            if (Program.labelTextID[4] == 4) label4.Text = textBox4.Text;
            if (Program.labelTextID[5] == 4) label5.Text = textBox4.Text;
            if (Program.labelTextID[6] == 4) label6.Text = textBox4.Text;
            if (Program.labelTextID[7] == 4) label7.Text = textBox4.Text;
            if (Program.labelTextID[8] == 4) label8.Text = textBox4.Text;
            if (Program.labelTextID[9] == 4) label9.Text = textBox4.Text;
            if (Program.labelTextID[10] == 4) label10.Text = textBox4.Text;
            if (Program.labelTextID[11] == 4) label11.Text = textBox4.Text;
            if (Program.labelTextID[12] == 4) label12.Text = textBox4.Text;
            if (Program.labelTextID[13] == 4) label13.Text = textBox4.Text;
            if (Program.labelTextID[14] == 4) label14.Text = textBox4.Text;
            if (Program.labelTextID[15] == 4) label15.Text = textBox4.Text;
            if (Program.labelTextID[16] == 4) label16.Text = textBox4.Text;
            if (Program.labelTextID[17] == 4) label17.Text = textBox4.Text;
            if (Program.labelTextID[18] == 4) label18.Text = textBox4.Text;
            if (Program.labelTextID[19] == 4) label19.Text = textBox4.Text;
            if (Program.labelTextID[20] == 4) label20.Text = textBox4.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog1 = new FontDialog();
            fontDialog1.ShowColor = false;
            fontDialog1.Font = label1.Font;

            if (fontDialog1.ShowDialog() != DialogResult.Cancel)
            {
                //textBox1.Font = fontDialog1.Font;
                //textBox1.ForeColor = fontDialog1.Color;

                label1.Font = fontDialog1.Font;
                label2.Font = fontDialog1.Font;
                label3.Font = fontDialog1.Font;
                label4.Font = fontDialog1.Font;
                label5.Font = fontDialog1.Font;
                label6.Font = fontDialog1.Font;
                label7.Font = fontDialog1.Font;
                label8.Font = fontDialog1.Font;
                label9.Font = fontDialog1.Font;
                label10.Font = fontDialog1.Font;
                label11.Font = fontDialog1.Font;
                label12.Font = fontDialog1.Font;
                label13.Font = fontDialog1.Font;
                label14.Font = fontDialog1.Font;
                label15.Font = fontDialog1.Font;
                label16.Font = fontDialog1.Font;
                label17.Font = fontDialog1.Font;
                label18.Font = fontDialog1.Font;
                label19.Font = fontDialog1.Font;
                label20.Font = fontDialog1.Font;
            }
        }
    }
}
