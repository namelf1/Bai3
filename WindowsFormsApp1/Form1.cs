using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private string captchaText;
        public Form1()
        {
            InitializeComponent();
            GenerateCaptcha();
        }
        private void GenerateCaptcha()
        {
            // Tạo một bitmap
            Bitmap bitmap = new Bitmap(150, 50);

            // Vẽ chữ ngẫu nhiên
            Random random = new Random();
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.Clear(Color.White);
                string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                captchaText = "";
                for (int i = 0; i < 5; i++)
                {
                    int charIndex = random.Next(0, chars.Length);
                    char c = chars[charIndex];
                    captchaText += c;
                    g.DrawString(c.ToString(), new Font("Arial", 20), Brushes.Black, i * 30, 5);
                }

                // Thêm nhiễu (ví dụ)
                for (int i = 0; i < 100; i++)
                {
                    bitmap.SetPixel(random.Next(bitmap.Width), random.Next(bitmap.Height), Color.Black);
                }
            }

            pictureBox1.Image = bitmap;
        }
     
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            if (textBox1.Text.ToUpper() == captchaText)
            {
                MessageBox.Show("Xác thực thành công!");
            }
            else
            {
                MessageBox.Show("Xác thực thất bại!");
                GenerateCaptcha();
            }
        }
    }
}
