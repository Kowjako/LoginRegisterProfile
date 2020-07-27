using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProfileForm
{
    public partial class Form1 : Form
    {
        private User user;
        public Form1()
        {
            InitializeComponent();
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

        private void zeroitClassicRndButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void roundedImage2_Click(object sender, EventArgs e)
        {
            Profile form = new Profile();
            if (form.ShowDialog() == DialogResult.Cancel) user = form.user;
            UpdateInfo();
        }
        private void UpdateInfo()
        {
            label9.Text = user.univeristy == "University" ? label9.Text : user.univeristy;
            label10.Text = user.fields == "Fields" ? label10.Text : user.fields;
            label11.Text = user.facebook == "Facebook" ? label11.Text : user.facebook;
            label12.Text = user.telegram == "Telegram" ? label12.Text : user.telegram;
            label14.Text = user.phone == "Phone" ? label14.Text : user.phone;
            roundedImage1.Image = user.photo;
        }
    }
}
