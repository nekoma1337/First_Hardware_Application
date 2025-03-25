using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;

namespace First_Hardware_Application
{
    public partial class Customers : Form
    {
        public Customers()
        {
            InitializeComponent();
            DraggableForm.EnableDrag(this);
            Con = new Function();
            ShowCustomers();
            panel5.BackColor = Color.FromArgb(45, 135, 204);
            panel5.ForeColor = Color.White;
        }
        Function Con;
        private void Button_MouseMove(object sender, MouseEventArgs e)
        {
            if (sender is Button button)
            {
                button.BackColor = Color.FromArgb(45, 135, 204);
                button.ForeColor = Color.White;
            }
        }

        private void Button_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.ForeColor = Color.FromArgb(45, 135, 204);
                button.BackColor = Color.White;
                button.FlatAppearance.BorderSize = 1;
                button.FlatAppearance.BorderColor = Color.FromArgb(45, 135, 204);
            }
        }
        private void ShowCustomers()
        {
            string Query = "select * from CustomerTbl";
            CustomerList.DataSource = Con.GetData(Query);
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            if (NameTb.Text == "" || PhoneTb.Text == "" || GenderTb.SelectedIndex == -1 || textBox_dateBorn.Text == "")
                MessageBox.Show("Заповніть всі поля! ");
            else
                try
                {
                    string Name = NameTb.Text;
                    string Gender = GenderTb.SelectedItem.ToString();
                    string Phone = PhoneTb.Text;
                    DateTime dateOfBirth = DateTime.Parse(textBox_dateBorn.Text);
                    string formattedDate = dateOfBirth.ToString("yyyy-MM-dd");
                    string Query = "insert into CustomerTbl values('{0}','{1}','{2}' ,'{3}')";
                    Query = string.Format(Query,  Name, dateOfBirth, Gender, Phone);
                    Con.GetData(Query);
                    ShowCustomers();
                    MessageBox.Show("Покупець доданий!");
                    NameTb.Text = "";
                    PhoneTb.Text = "";
                    GenderTb.SelectedIndex = -1;
                    textBox_dateBorn.Text = "";

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
        }
        int Key = 0;
        private void CustomerList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var selectedRow = CustomerList.Rows[e.RowIndex];

                NameTb.Text = selectedRow.Cells[1].Value?.ToString() ?? "Не указано";
                if (selectedRow.Cells[2].Value != null && DateTime.TryParse(selectedRow.Cells[2].Value.ToString(), out DateTime dateOfBirth))
                {
                    textBox_dateBorn.Text = dateOfBirth.ToString("dd.MM.yyyy"); // Форматируем дату
                }
                else
                {
                    textBox_dateBorn.Text = ""; // Оставляем пустым, если дата отсутствует
                }
                GenderTb.Text = selectedRow.Cells[3].Value?.ToString() ?? "Не указано";
                PhoneTb.Text = selectedRow.Cells[4].Value?.ToString() ?? "Не указано";

                if (!string.IsNullOrEmpty(selectedRow.Cells[0].Value?.ToString()))
                {
                    Key = Convert.ToInt32(selectedRow.Cells[0].Value.ToString());
                }
                else
                {
                    Key = 0;

                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show($"Произошла ошибка: {ex.Message}");
            }
        }
        private void button_edit_Click_1(object sender, EventArgs e)
        {
            if (NameTb.Text == "")
                MessageBox.Show("Заповніть всі поля! ");

            else
                try
                {
                    string Name = NameTb.Text;
                    string Gender = GenderTb.SelectedItem.ToString();
                    string Phone = PhoneTb.Text;
                    DateTime dateOfBirth = DateTime.Parse(textBox_dateBorn.Text);
                    string formattedDate = dateOfBirth.ToString("yyyy-MM-dd");
                    string Query = "update CustomerTbl set Name = '{0}',DateOfBirth = '{1}', DateGender = '{2}',Phone = '{3}' where CustCode = {4}";
                    Query = string.Format(Query, Name, dateOfBirth, Gender, Phone, Key);
                    Con.GetData(Query);
                    ShowCustomers();
                    MessageBox.Show("Покупець змінений!");
                    NameTb.Text = "";
                    PhoneTb.Text = "";
                    GenderTb.SelectedIndex = -1;
                    textBox_dateBorn.Text = "";
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

        }
        private void button_delete_Click_1(object sender, EventArgs e)
        {
            if (NameTb.Text == "" || PhoneTb.Text == "" || GenderTb.SelectedIndex == -1)
                MessageBox.Show("Заповніть всі поля! ");
            else
                try
                {

                    string Name = NameTb.Text;
                    string Gender = GenderTb.SelectedItem.ToString();
                    string Phone = PhoneTb.Text;
                    DateTime dateOfBirth = DateTime.Parse(textBox_dateBorn.Text);
                    string Query = "Delete from CustomerTbl where CustCode = {0}";
                    Query = string.Format(Query, Key);
                    Con.GetData(Query);
                    ShowCustomers();
                    MessageBox.Show("Покупець видалений!");
                    NameTb.Text = "";
                    PhoneTb.Text = "";
                    GenderTb.SelectedIndex = -1;
                    textBox_dateBorn.Text = "";
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

        }

        private void login_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }
        private void categories_Click(object sender, EventArgs e)
        {
            Categories Obj = new Categories();
            Obj.Show();
            this.Hide();
        }

        private void customer_Click(object sender, EventArgs e)
        {
            Customers Obj = new Customers();
            Obj.Show();
            this.Hide();
        }

        private void billing_Click(object sender, EventArgs e)
        {
            Billing Obj = new Billing();
            Obj.Show();
            this.Hide();
        }
        private void items_Click(object sender, EventArgs e)
        {
            Items Obj = new Items();
            Obj.Show();
            this.Hide();
        }
    }
}
