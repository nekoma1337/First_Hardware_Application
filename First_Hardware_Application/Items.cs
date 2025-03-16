using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace First_Hardware_Application
{
    public partial class Items: Form
    {
        public Items()
        {
            InitializeComponent();
            Con = new Function();
            ShowItems();
            GetCategories();
        }
        Function Con;
        private void GetCategories()
        {
            string Query = "select * from CategoryTbl";
            CatCb.ValueMember = Con.GetData(Query).Columns["CatCode"].ToString();
            CatCb.DisplayMember = Con.GetData(Query).Columns["CatName"].ToString();
            CatCb.DataSource = Con.GetData(Query);
        }
        private void ShowItems()
        {
            string Query = "select * from ItemsTbl";
            ItemList.DataSource = Con.GetData(Query);
        }

        private void button_edit_Click(object sender, EventArgs e)
        {
            if (NameTb.Text == "" || CatCb.SelectedIndex == -1 || PriceTb.Text == "" || StockTb.Text == "" || ManufacturerTb.Text == "")
                MessageBox.Show("Missing Data! ");

            else
                try
                {
                    string Name = NameTb.Text;
                    string Cat = CatCb.SelectedValue.ToString();
                    string Price = PriceTb.Text;
                    string Stock = StockTb.Text;
                    string Man = ManufacturerTb.Text;
                    string Query = "update ItemsTbl set ItName = '{0}',ItCategory = '{1}',Price = '{2}',Stock = '{3}',Manufacturer = '{4}' where ItemCode = {5}";
                    Query = string.Format(Query, Name , Cat, Price , Stock, Man, Key);
                    Con.GetData(Query);
                    ShowItems();
                    MessageBox.Show("Items Updeted!!");
                    
                    NameTb.Text = "";
                    CatCb.SelectedIndex = -1;
                    PriceTb.Text = "";
                    StockTb.Text = "";
                    ManufacturerTb.Text = "";
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
        }

        private void button_addItem_Click(object sender, EventArgs e)
        {
            if (NameTb.Text == "" || CatCb.SelectedIndex == -1 || PriceTb.Text == "" || StockTb.Text == "" || ManufacturerTb.Text == "")
                MessageBox.Show("Missing Data! ");
            else
                try
                {
                    string Name = NameTb.Text;
                    string Cat = CatCb.SelectedValue.ToString();
                    string Price = PriceTb.Text;
                    string Stock = StockTb.Text;
                    string Man = ManufacturerTb.Text;
                    string Query = "insert into ItemsTbl values('{0}','{1}','{2}','{3}','{4}')";
                    Query = string.Format(Query, Name,Cat,Price,Stock,Man);
                    Con.GetData(Query);
                    ShowItems();
                    MessageBox.Show("Item Added!!");
                    NameTb.Text = "";
                    CatCb.SelectedIndex = -1;
                    PriceTb.Text = "";
                    StockTb.Text = "";
                    ManufacturerTb.Text = "";
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
        }
        int Key = 0;
        private void ItemList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            var selectedRow = ItemList.Rows[e.RowIndex];

            NameTb.Text = selectedRow.Cells[1].Value?.ToString() ?? "Не указано";
            CatCb.Text = selectedRow.Cells[2].Value?.ToString() ?? "Не указано";
            PriceTb.Text = selectedRow.Cells[3].Value?.ToString() ?? "Не указано";
            StockTb.Text = selectedRow.Cells[4].Value?.ToString() ?? "Не указано";
            ManufacturerTb.Text = selectedRow.Cells[5].Value?.ToString() ?? "Не указано";

            if (!string.IsNullOrEmpty(selectedRow.Cells[0].Value?.ToString()))
            {
                Key = Convert.ToInt32(selectedRow.Cells[0].Value.ToString());
            }
            else
            {
                Key = 0;

            }
        }
        
        private void button_delete_Click(object sender, EventArgs e)
        {
            if (NameTb.Text == "" )
                MessageBox.Show("Missing Data! ");
            else
                try
                {
                    string Name = NameTb.Text;
                    string Cat = CatCb.SelectedValue.ToString();
                    string Price = PriceTb.Text;
                    string Stock = StockTb.Text;
                    string Man = ManufacturerTb.Text;
                    string Query = "Delete from ItemsTbl where ItemCode = {0}";
                    Query = string.Format(Query,Key);
                    Con.GetData(Query);
                    ShowItems();
                    MessageBox.Show("Category Deleted!!");
                    NameTb.Text = "";
                    CatCb.SelectedIndex = -1;
                    PriceTb.Text = "";
                    StockTb.Text = "";
                    ManufacturerTb.Text = "";
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
        }
        private void Items_Load(object sender, EventArgs e)
        {

        }

        private void label_logout_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel_logout_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label_username_Click(object sender, EventArgs e)
        {

        }

        private void textbox_username_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void CategoryList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
    }
}
