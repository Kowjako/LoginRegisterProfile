using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            zeroitShinnyButton1.ForeColor = Color.FromArgb(0, 64, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void materialSingleLineTextField3_Enter(object sender, EventArgs e)
        {
            if (materialSingleLineTextField3.Text == "Nickname")
                materialSingleLineTextField3.Text = "";
        }

        private void materialSingleLineTextField3_Leave(object sender, EventArgs e)
        {
            if (materialSingleLineTextField3.Text == "")
                materialSingleLineTextField3.Text = "Nickname";
        }

        private void materialSingleLineTextField5_Enter(object sender, EventArgs e)
        {
            if (materialSingleLineTextField5.Text == "Password")
            {
                materialSingleLineTextField5.PasswordChar = '*';
                materialSingleLineTextField5.Text = "";
            }
        }

        private void materialSingleLineTextField5_Leave(object sender, EventArgs e)
        {
            if (materialSingleLineTextField5.Text == "")
            {
                materialSingleLineTextField5.PasswordChar = '\0';
                materialSingleLineTextField5.Text = "Password";
            }
        }

        private void zeroitShinnyButton1_Click(object sender, EventArgs e)
        {
            DataBase db = new DataBase();
            DataTable dt = new DataTable();
            string nick = materialSingleLineTextField3.Text;
            string pass = materialSingleLineTextField5.Text;
            MySqlDataAdapter ad = new MySqlDataAdapter();
            MySqlCommand com = new MySqlCommand("SELECT * FROM `users` WHERE `nickname`=@uNick AND `pass`=@uPass", db.getConnection());
            com.Parameters.Add("@uNick", MySqlDbType.VarChar).Value = nick;
            com.Parameters.Add("@uPass", MySqlDbType.VarChar).Value = pass; 
            ad.SelectCommand = com;
            ad.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Informer form = new Informer();
                form.label1.Text = "Login successful";
                form.Show();
            }
            else
            {
                Informer form = new Informer();
                form.label1.Text = "Login denied";
                form.Show();
            }
        }

        private void materialLabel1_Click(object sender, EventArgs e)
        {
            Forgot form = new Forgot();
            form.Show();
        }

        private void materialLabel2_Click(object sender, EventArgs e)
        {
            Register form = new Register();
            form.Show();
        }
    }
}
