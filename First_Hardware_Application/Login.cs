using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace First_Hardware_Application
{
    public partial class Login: Form
    {
        public Login()
        {
            InitializeComponent();
            DraggableForm.EnableDrag(this);
        }
        private void button_login_Click(object sender, EventArgs e)
        {
            if(textbox_username.Text == ""|| textbox_password.Text == "")
            {
                MessageBox.Show("Заповніть текстові поля!");
            }
            else if (textbox_username.Text == "Admin" && textbox_password.Text == "Admin")
            {
                Items Obj = new Items();
                Obj.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Не коректні дані входу!");
            }
        }
         private Region CreateRoundedRegion(Rectangle bounds, int radius)
         {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(bounds.X, bounds.Y, radius, radius, 180, 90); // Левый верхний угол
            path.AddArc(bounds.Right - radius, bounds.Y, radius, radius, 270, 90); // Правый верхний угол
            path.AddArc(bounds.Right - radius, bounds.Bottom - radius, radius, radius, 0, 90); // Правый нижний угол
            path.AddArc(bounds.X, bounds.Bottom - radius, radius, radius, 90, 90); // Левый нижний угол
            path.CloseFigure();
            return new Region(path);
         }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Region = CreateRoundedRegion(new Rectangle(0, 0, this.Width, this.Height), 20);
        }

        private void label4_Click(object sender, EventArgs e)
        {
            textbox_username.Text = "";
            textbox_password.Text = "";
            textbox_password.PasswordChar = '*';

        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_login_MouseMove(object sender, MouseEventArgs e)
        {
            button_login.BackColor = Color.FromArgb(45, 135, 204);
            button_login.ForeColor = Color.White;
        }

        private void button_login_MouseLeave(object sender, EventArgs e)
        {
            button_login.ForeColor = Color.FromArgb(45, 135, 204);
            button_login.BackColor = Color.White;
            button_login.FlatAppearance.BorderSize = 1;
            button_login.FlatAppearance.BorderColor = Color.FromArgb(45, 135, 204);
        }

        private void textbox_password_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textbox_password.Text))
            {
                button_pass_vis.Visible = true; 
            }
            else
            {

                button_pass_vis.Visible = false; 
            }
        }

        private void button_pass_vis_Click(object sender, EventArgs e)
        {

             if (textbox_password.PasswordChar == '\0')
                textbox_password.PasswordChar = '*';
             else
                textbox_password.PasswordChar = '\0';

           
        }

        private void pictureBox2_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            this.Region = CreateRoundedRegion(new Rectangle(0, 0, this.Width, this.Height), 20);

        }
    
    }
}
