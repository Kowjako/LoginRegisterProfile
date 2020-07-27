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
    public partial class Profile : Form
    {
        public Profile()
        {
            InitializeComponent();
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

        private void zeroitClassicRndButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void materialSingleLineTextField1_Enter(object sender, EventArgs e)
        {
            if (materialSingleLineTextField1.Text == "University")
                materialSingleLineTextField1.Text = "";
        }

        private void materialSingleLineTextField1_Leave(object sender, EventArgs e)
        {
            if (materialSingleLineTextField1.Text == "")
                materialSingleLineTextField1.Text = "University";
        }

        private void materialSingleLineTextField2_Enter(object sender, EventArgs e)
        {
            if (materialSingleLineTextField2.Text == "Fields")
                materialSingleLineTextField2.Text = "";
        }

        private void materialSingleLineTextField2_Leave(object sender, EventArgs e)
        {
            if (materialSingleLineTextField2.Text == "")
                materialSingleLineTextField2.Text = "Fields";
        }

        private void materialSingleLineTextField3_Enter(object sender, EventArgs e)
        {
            if (materialSingleLineTextField3.Text == "Facebook")
                materialSingleLineTextField3.Text = "";
        }

        private void materialSingleLineTextField3_Leave(object sender, EventArgs e)
        {
            if (materialSingleLineTextField3.Text == "")
                materialSingleLineTextField3.Text = "Facebook";
        }

        private void materialSingleLineTextField4_Enter(object sender, EventArgs e)
        {
            if (materialSingleLineTextField4.Text == "Telegram")
                materialSingleLineTextField4.Text = "";
        }

        private void materialSingleLineTextField4_Leave(object sender, EventArgs e)
        {
            if (materialSingleLineTextField4.Text == "")
                materialSingleLineTextField4.Text = "Telegram";
        }

        private void materialSingleLineTextField5_Enter(object sender, EventArgs e)
        {
            if (materialSingleLineTextField5.Text == "Phone")
                materialSingleLineTextField5.Text = "";
        }

        private void materialSingleLineTextField5_Leave(object sender, EventArgs e)
        {
            if (materialSingleLineTextField5.Text == "")
                materialSingleLineTextField5.Text = "Phone";
        }
        public User user;
        private void zeroitKuzaButton1_Click(object sender, EventArgs e)
        {
            user = new User(materialSingleLineTextField5.Text, materialSingleLineTextField4.Text, materialSingleLineTextField3.Text, materialSingleLineTextField1.Text, materialSingleLineTextField2.Text);
            this.Close();
            user.changePhoto(new Bitmap(roundedImage1.Image));
        }

        private void zeroitClassicRndButton2_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Title = "Open Image";
            dialog.Filter = "";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                roundedImage1.Image = new Bitmap(dialog.FileName);
                roundedImage1.SizeMode = PictureBoxSizeMode.Zoom;
            }
            dialog.Dispose();
        }
    }
}
