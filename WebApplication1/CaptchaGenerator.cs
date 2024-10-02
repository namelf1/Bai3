using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

public class CaptchaGenerator
{
    public static void Main()
    {
        string captchaText = GenerateRandomText(6);
        Bitmap captchaImage = GenerateCaptchaImage(captchaText);

        // Save the image to a file
        captchaImage.Save("captcha.jpg", ImageFormat.Jpeg);

        Console.WriteLine("CAPTCHA generated and saved as captcha.jpg");
    }

    private static string GenerateRandomText(int length)
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

    private static Bitmap GenerateCaptchaImage(string captchaText)
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
}