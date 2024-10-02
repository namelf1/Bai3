using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        private string captchaText;
        public Form1()
        {
            InitializeComponent();
            GenerateAndDisplayCaptcha();
        }

        private void GenerateAndDisplayCaptcha()
        {
            string captchaText = GenerateRandomText(6);
            Bitmap captchaImage = GenerateCaptchaImage(captchaText);

            // Display the image in the PictureBox
            pictureBox1.Image = captchaImage;
        }

        private string GenerateRandomText(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random random = new Random();
            char[] result = new char[length];

            for (int i = 0; i < length; i++)
            {
                result[i] = chars[random.Next(chars.Length)];
            }

            return new string(result);
        }

        private Bitmap GenerateCaptchaImage(string captchaText)
        {
            Bitmap bitmap = new Bitmap(200, 50);
            Graphics graphics = Graphics.FromImage(bitmap);
            Font font = new Font("Arial", 20, FontStyle.Bold);
            Rectangle rect = new Rectangle(0, 0, 200, 50);

            // Fill the background with a color
            graphics.Clear(Color.White);

            // Draw the CAPTCHA text
            graphics.DrawString(captchaText, font, Brushes.Black, rect);

            // Add some noise
            Random random = new Random();
            for (int i = 0; i < 1000; i++)
            {
                int x = random.Next(200);
                int y = random.Next(50);
                bitmap.SetPixel(x, y, Color.Gray);
            }

            return bitmap;
        }
        private void validateButton_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == captchaText)
            {
                MessageBox.Show("CAPTCHA validation successful!");
            }
            else
            {
                MessageBox.Show("CAPTCHA validation failed. Please try again.");
            }
            
        }
        private void refreshButton_Click(object sender, EventArgs e)
        {
            GenerateAndDisplayCaptcha();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
