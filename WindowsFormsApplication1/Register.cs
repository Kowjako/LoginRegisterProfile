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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
            zeroitShinnyButton1.ForeColor = Color.FromArgb(0, 64, 0);
        }
        private Point lastpoint;
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastpoint = new Point(e.X, e.Y);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
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

        private void materialSingleLineTextField1_Leave(object sender, EventArgs e)
        {
            if (materialSingleLineTextField1.Text == "") 
            materialSingleLineTextField1.Text = "Name";
        }

        private void materialSingleLineTextField1_Enter(object sender, EventArgs e)
        {
            if (materialSingleLineTextField1.Text == "Name")
            materialSingleLineTextField1.Text = "";
        }

        private void materialSingleLineTextField2_Enter(object sender, EventArgs e)
        {
            if (materialSingleLineTextField2.Text == "Surname")
                materialSingleLineTextField2.Text = "";
        }

        private void materialSingleLineTextField2_Leave(object sender, EventArgs e)
        {
            if (materialSingleLineTextField2.Text == "")
                materialSingleLineTextField2.Text = "Surname";
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
            if (checkInput() == 0)
            {
                DataBase db = new DataBase();
                string name = materialSingleLineTextField1.Text;
                string surname = materialSingleLineTextField2.Text;
                string nickname = materialSingleLineTextField3.Text;
                string email = materialSingleLineTextField4.Text;
                string pass = materialSingleLineTextField5.Text;
                int type = materialRadioButton1.Checked == true ? 1 : 0;
                MySqlCommand com = new MySqlCommand($"INSERT INTO `users` (`userID`, `name`, `surname`, `nickname`, `email`, `pass`, `type`) VALUES (NULL,@uName,@uSur,@uNick,@uMail,@uPass,@uType)", db.getConnection());
                com.Parameters.Add("@uMail", MySqlDbType.VarChar).Value = email;
                com.Parameters.Add("@uSur", MySqlDbType.VarChar).Value = surname;
                com.Parameters.Add("@uNick", MySqlDbType.VarChar).Value = nickname;
                com.Parameters.Add("@uType", MySqlDbType.VarChar).Value = type;
                com.Parameters.Add("@uName", MySqlDbType.VarChar).Value = name;
                com.Parameters.Add("@uPass", MySqlDbType.VarChar).Value = pass;
                db.startConnection();
                if (com.ExecuteNonQuery() == 1)
                {
                    Informer form = new Informer();
                    form.label1.Text = "User was added successfully";
                    if (form.ShowDialog() == DialogResult.Cancel)
                    {
                        Login form1 = new Login();
                        form1.Show();
                    }
                }
                db.closeConnection();
                this.Hide();
            }
        }
        private int checkInput()
        {
            if (materialSingleLineTextField1.Text == "Name") return 1;
            if (materialSingleLineTextField2.Text == "Surname") return 1;
            if (materialSingleLineTextField3.Text == "Nickname") return 1;
            if (IsValidEmail(materialSingleLineTextField4.Text) == false) return 1;
            if (materialSingleLineTextField5.Text == "Password") return 1;
            else return 0;
        }
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
