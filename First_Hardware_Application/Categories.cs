using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;

namespace First_Hardware_Application
{
    public partial class Categories : Form
    {
        public Categories()
        {
            InitializeComponent();
            DraggableForm.EnableDrag(this);
            Con = new Function();
            ShowCategories();
            panel4.BackColor = Color.FromArgb(45, 135, 204);
            panel4.ForeColor = Color.White;
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
        private void ShowCategories()
        {
            string Query = "select * from CategoryTbl";
            CategoryList.DataSource = Con.GetData(Query);
        }
      
        private void button_additem_Click(object sender, System.EventArgs e)
        {
            if (NameTb.Text == "" )
                MessageBox.Show("Заповніть текстове поле!");
            else
                try
                {
                    string Name = NameTb.Text;
                    string Query = "insert into CategoryTbl values('{0}')";
                    Query = string.Format(Query, Name);
                    Con.GetData(Query);
                    ShowCategories();
                    MessageBox.Show("Категорія додана!");
                    NameTb.Text = "";
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
        }
        int Key = 0;

        private void CategoryList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var selectedRow = CategoryList.Rows[e.RowIndex];

            NameTb.Text = selectedRow.Cells[1].Value?.ToString() ?? "Не указано";
           
            if (!string.IsNullOrEmpty(selectedRow.Cells[0].Value?.ToString()))
            {
                Key = Convert.ToInt32(selectedRow.Cells[0].Value.ToString());
            }
            else
            {
                Key = 0;

            }
        }
       
        private void button_edit_Click(object sender, System.EventArgs e)
        {
            
            if (NameTb.Text == "")
                MessageBox.Show("Заповніть текстове поле! ");

            else
                try
                {
                    string Name = NameTb.Text;
                    string Query = "update CategoryTbl set CatName = '{0}' where CatCode = {1}";
                    Query = string.Format(Query, Name,Key);
                    Con.GetData(Query);
                    ShowCategories();
                    MessageBox.Show("Категорія оновлена!");
                    NameTb.Text = "";
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
        }
        
        private void button_delete_Click(object sender, EventArgs e)
        {
            if (NameTb.Text == " ")
                MessageBox.Show("Заповніть текстове поле!");
            else
                try
                {
                    string Name = NameTb.Text;
                    string Query = "Delete from CategoryTbl where CatCode = {0}";
                    Query = string.Format(Query,  Key);
                    Con.GetData(Query);
                    ShowCategories();
                    MessageBox.Show("Категорія видалена!");
                    NameTb.Text = "";
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
        }
        private void Categories_Click(object sender, EventArgs e)
        {
            Categories Obj = new Categories();
            Obj.Show();
            this.Hide();
        }
        private void Items_Click(object sender, EventArgs e)
        {
            Items Obj = new Items();
            Obj.Show();
            this.Hide();
        }

        private void Customers_Click(object sender, EventArgs e)
        {
            Customers Obj = new Customers();
            Obj.Show();
            this.Hide();
        }

        private void Billing_Click(object sender, EventArgs e)
        {
            Billing Obj = new Billing();
            Obj.Show();
            this.Hide();
        }

        private void logout_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }

        
    }
}
