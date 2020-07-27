using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Forgot : Form
    {
        public Forgot()
        {
            InitializeComponent();
            zeroitShinnyButton1.ForeColor = Color.FromArgb(0, 64, 0);
        }
        private Point lastpoint;
        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            lastpoint = new Point(e.X, e.Y);
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastpoint.X;
                this.Top += e.Y - lastpoint.Y;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void materialSingleLineTextField4_Enter(object sender, EventArgs e)
        {
            if (materialSingleLineTextField4.Text == "E-mail")
                materialSingleLineTextField4.Text = "";
        }

        private void materialSingleLineTextField4_Leave(object sender, EventArgs e)
        {
            if (materialSingleLineTextField4.Text == "")
                materialSingleLineTextField4.Text = "E-mail";
        }

        private void materialSingleLineTextField1_Enter(object sender, EventArgs e)
        {
            if (materialSingleLineTextField1.Text == "Code")
                materialSingleLineTextField1.Text = "";
        }

        private void materialSingleLineTextField1_Leave(object sender, EventArgs e)
        {
            if (materialSingleLineTextField1.Text == "")
                materialSingleLineTextField1.Text = "Code";
        }
        private string email = "";
        private string code = (rnd.Next(1001, 9999)).ToString();
        private static Random rnd = new Random();
        private void zeroitShinnyButton1_Click(object sender, EventArgs e)
        {
            if (zeroitShinnyButton1.Text == "SEND CODE")
            {
                email = materialSingleLineTextField4.Text;
                MailAddress from = new MailAddress("kowyako@yandex.ru", "HelperApp");
                MailAddress to = new MailAddress(email);
                MailMessage mes = new MailMessage(from, to);
                mes.Subject = "Verification Code";
                mes.Body = $"Your verification code is {code}";
                mes.IsBodyHtml = false;
                SmtpClient smtp = new SmtpClient("smtp.yandex.ru", 587);
                smtp.Credentials = new NetworkCredential("kowyako@yandex.ru", "vovka1336");
                smtp.EnableSsl = true;
                smtp.Send(mes);
                materialSingleLineTextField1.Visible = true;
                zeroitShinnyButton1.Text = "CHECK CODE";
            }
            if (materialSingleLineTextField1.Visible == true)
            {
                if (materialSingleLineTextField1.Text == code)
                {
                    DataBase db = new DataBase();
                    DataTable dt = new DataTable();
                    MySqlDataAdapter ad = new MySqlDataAdapter();
                    MySqlCommand com = new MySqlCommand("SELECT * FROM `users` WHERE `nickname`=@uMail", db.getConnection());
                    com.Parameters.Add("@uMail", MySqlDbType.VarChar).Value = materialSingleLineTextField2.Text;
                    ad.SelectCommand = com;
                    ad.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        Informer info = new Informer();
                        info.label1.Text = $"Your password is {dt.Rows[0]["pass"].ToString()}";
                        info.Show();
                    }
                    //string password = row[0]["pass"].ToString();
                }
            }
        }

        private void materialSingleLineTextField2_Enter(object sender, EventArgs e)
        {
            if (materialSingleLineTextField2.Text == "Nickname")
                materialSingleLineTextField2.Text = "";
        }

        private void materialSingleLineTextField2_Leave(object sender, EventArgs e)
        {
            if (materialSingleLineTextField2.Text == "")
                materialSingleLineTextField2.Text = "Nickname";
        }
    }
}
