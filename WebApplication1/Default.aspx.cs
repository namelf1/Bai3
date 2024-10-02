using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Default : System.Web.UI.Page
    {
        private CaptchaGenerator captcha;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GenerateCaptcha();
            }
        }
        private void GenerateCaptcha()
        {
            captcha = new CaptchaGenerator();
            Session["CaptchaText"] = captcha.CaptchaText;
            imgCaptcha.ImageUrl = "data:image/jpeg;base64," + Convert.ToBase64String(captcha.GenerateCaptchaImage());
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtCaptcha.Text != Session["CaptchaText"].ToString())
            {
                lblMessage.Text = "Invalid CAPTCHA.";
                GenerateCaptcha();
                return;
            }

            string connectionString = ConfigurationManager.ConnectionStrings["YourConnectionString"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username AND Password = @Password";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                cmd.Parameters.AddWithValue("@Password", txtPassword.Text);

                int count = (int)cmd.ExecuteScalar();
                if (count > 0)
                {
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Text = "Login successful!";
                }
                else
                {
                    lblMessage.Text = "Invalid username or password.";
                }
            }
        }
    }

}