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
            Con = new Function();
            ShowCustomers();
        }
        Function Con;
        private void ShowCustomers()
        {
            string Query = "select * from CustomerTbl";
            CustomerList.DataSource = Con.GetData(Query);
        }
        private void button_add_Click(object sender, EventArgs e)
        {
            if (NameTb.Text == "" || PhoneTb.Text == "" || GenderTb.SelectedIndex == -1)
                MessageBox.Show("Missing Data! ");
            else
                try
                {
                    string Name = NameTb.Text;
                    string Gender = GenderTb.SelectedItem.ToString();
                    string Phone = PhoneTb.Text;
                    string Query = "insert into CustomerTbl values('{0}','{1}','{2}')";
                    Query = string.Format(Query, Name, Gender, Phone);
                    Con.GetData(Query);
                    ShowCustomers();
                    MessageBox.Show("Customer Added!!");
                    NameTb.Text = "";
                    PhoneTb.Text = "";
                    GenderTb.SelectedIndex = -1;

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
                GenderTb.Text = selectedRow.Cells[2].Value?.ToString() ?? "Не указано";
                PhoneTb.Text = selectedRow.Cells[3].Value?.ToString() ?? "Не указано";

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
                MessageBox.Show("Missing Data! ");

            else
                try
                {
                    string Name = NameTb.Text;
                    string Gender = GenderTb.SelectedItem.ToString();
                    string Phone = PhoneTb.Text;
                    string Query = "update CustomerTbl set Item = '{0}',Gender = '{1}',Phone = '{2}' where CustCode = {3}";
                    Query = string.Format(Query, Name, Gender, Phone, Key);
                    Con.GetData(Query);
                    ShowCustomers();
                    MessageBox.Show("Customers Updated!!");
                    NameTb.Text = "";
                    PhoneTb.Text = "";
                    GenderTb.SelectedIndex = -1;
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

        }
        private void button_delete_Click_1(object sender, EventArgs e)
        {
            if (NameTb.Text == "" || PhoneTb.Text == "" || GenderTb.SelectedIndex == -1)
                MessageBox.Show("Missing Data! ");
            else
                try
                {

                    string Name = NameTb.Text;
                    string Gender = GenderTb.SelectedItem.ToString();
                    string Phone = PhoneTb.Text;
                    string Query = "Delete from CustomerTbl where CustCode = {0}";
                    Query = string.Format(Query, Key);
                    Con.GetData(Query);
                    ShowCustomers();
                    MessageBox.Show("Customer Deleted!!");
                    NameTb.Text = "";
                    PhoneTb.Text = "";
                    GenderTb.SelectedIndex = -1;
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

        }

        private void label_items_Click(object sender, EventArgs e)
        {
            Items Obj = new Items();
            Obj.Show();
            this.Hide();
        }

        private void label_categories_Click(object sender, EventArgs e)
        {
            Categories Obj = new Categories();
            Obj.Show();
            this.Hide();
        }

        private void label_customer_Click(object sender, EventArgs e)
        {
            Customers Obj = new Customers();
            Obj.Show();
            this.Hide();
        }

        private void label_billing_Click(object sender, EventArgs e)
        {
            Billing Obj = new Billing();
            Obj.Show();
            this.Hide();
        }

        private void panel_logout_Paint(object sender, PaintEventArgs e)
        {


        }

        private void label_logout_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }
    }
}
