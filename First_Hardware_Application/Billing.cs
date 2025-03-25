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

namespace First_Hardware_Application
{
    public partial class Billing: Form
    {
        private int GenerateUniqueBillId()
        {
            string query = "SELECT ISNULL(MAX(BillIId), 0) FROM BillTbl";
            DataTable result = Con.GetData(query);

            int maxBillId = 0;
            if (result.Rows.Count > 0 && result.Rows[0][0] != DBNull.Value)
            {
                maxBillId = Convert.ToInt32(result.Rows[0][0]);
            }

            return maxBillId + 1; // Генерируем новое уникальное значение
        }
        public Billing()
        {
            Con = new Function();
            InitializeComponent();
            DraggableForm.EnableDrag(this);
            ClientBill.Columns.Add("Column1", "№");
            ClientBill.Columns.Add("Column2", "Item");
            ClientBill.Columns.Add("Column3", "Price");
            ClientBill.Columns.Add("Column4", "Quantity");
            ClientBill.Columns.Add("Column5", "Total");
            ShowItems();
        }
        Function Con;
        private void ShowItems()
        {
            string Query = "select * from ItemsTbl";
            ItemList.DataSource = Con.GetData(Query);
        }
        int Key = 0;
        int Stock = 0;
        private void ItemList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var selectedRow = ItemList.Rows[e.RowIndex];

            ItemTb.Text = selectedRow.Cells[1].Value?.ToString() ?? "Не указано";
            PriceTb.Text = selectedRow.Cells[3].Value?.ToString() ?? "Не указано";
            Stock = Convert.ToInt32(selectedRow.Cells[4].Value?.ToString());
            //StockTb.Text = selectedRow.Cells[4].Value?.ToString() ?? "Не указано";
            //ManufacturerTb.Text = selectedRow.Cells[5].Value?.ToString() ?? "Не указано";

            if (!string.IsNullOrEmpty(selectedRow.Cells[0].Value?.ToString()))
            {
                Key = Convert.ToInt32(selectedRow.Cells[0].Value.ToString());
            }
            else
            {
                Key = 0;
            }
        }
        string PMethod = "";
        int n = 0;
        int GrdTotal = 0;
        int Promotion = 0;
        private void UpdateStock()
        {
            if (ItemTb.Text == "" || PriceTb.Text == "" || QtTb.Text == "")
                MessageBox.Show("Missing Data! ");

            else
                try
                {
                    int NewStock = Stock - Convert.ToInt32(QtTb.Text);
                    string Query = "update ItemsTbl set Stock = '{0}' where ItemCode = {1}";
                    Query = string.Format(Query, NewStock , Key);
                    Con.GetData(Query);
                    ShowItems();
                    MessageBox.Show("Stock Updeted!!");

                   
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
        }
        private void button_addItem_Click(object sender, EventArgs e)
        {
            if (ItemTb.Text == "" ||  PriceTb.Text == "" || QtTb.Text == "")
                MessageBox.Show("Missing Data! ");
            else if (Stock < Convert.ToInt32(QtTb.Text))
            {
                MessageBox.Show("Not Enough Stock!");
            }
            else

            {
                if (textBox_promotion.Text == "")
                    Promotion = 0;
                else
                    Promotion = Convert.ToInt32(textBox_promotion.Text);
                
                int Qte = Convert.ToInt32(QtTb.Text);
                int total = (int)(Convert.ToInt32(PriceTb.Text)*(1-(Promotion/100.0f))) * Qte;
                DataGridViewRow newRow = new DataGridViewRow();
                newRow.CreateCells(ClientBill);
                newRow.Cells[0].Value = n + 1;
                newRow.Cells[1].Value = ItemTb.Text;
                newRow.Cells[2].Value = PriceTb.Text;
                newRow.Cells[3].Value = QtTb.Text;
                newRow.Cells[4].Value = "Rs " + total;
                ClientBill.Rows.Add(newRow);
                n++;
                GrdTotal = GrdTotal + total;
                GrdTotallb.Text = "Rs " + GrdTotal;
                UpdateStock();
                ShowItems();
                

            }
                
        }
        private void button_delete_Click(object sender, EventArgs e)
        {
            ItemTb.Text = "";
            PriceTb.Text = "";
            textBox_promotion.Text = "";
            QtTb.Text = "";

            if (radioButton_mobile.Checked == true)
            {
                radioButton_mobile.Checked = false;
;            }
            else if (radioButton_Cash.Checked == true)
            {
                radioButton_Cash.Checked = false;

            }
            else
            {
                radioButton_card.Checked = false;
            }
            CustTb.Text = "";
            ClientBill.Rows.Clear();
        }
        
        private void PrintBill_button_Click(object sender, EventArgs e)
        {
            int Key = GenerateUniqueBillId();
            string formattedDate = DateTime.Today.Date.ToString("yyyy-MM-dd");
            int Phone = Convert.ToInt32(PhoneTb.Text);
            if (ItemTb.Text == "" || CustTb.Text == "")
                MessageBox.Show("Missing Data! ");
            else
                try
                {
                    if(radioButton_mobile.Checked ==true)
                    {
                        PMethod = "Mobile";
                    }
                    else if ( radioButton_card.Checked == true)
                    {
                        PMethod = "Card";

                    }
                    else
                    {
                        PMethod = "Cash";
                    }
                    
                    string Item = ItemTb.Text;
                    string Query = "insert into BillTbl values('{0}','{1}','{2}','{3}','{4}','{5}')";
                    Query = string.Format(Query, Key, formattedDate, CustTb.Text , Phone, GrdTotal, PMethod);
                    Con.GetData(Query);
                    ShowItems();
                    MessageBox.Show("Bill Added!!");
                    
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

                string Name = CustTb.Text;
                string Gender = GenderTb.SelectedItem.ToString();
                
                DateTime dateOfBirth = DateTime.Parse(textBox_dateBorn.Text);
                string formatedDate = dateOfBirth.ToString("yyyy-MM-dd");
                string Query1 = "insert into CustomerTbl values('{0}','{1}','{2}' ,'{3}')";
                Query1 = string.Format(Query1, Name, dateOfBirth, Gender, Phone);
                Con.GetData(Query1);
                

            

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

       

        private void label_category_Click(object sender, EventArgs e)
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

        private void panel_logout_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void label_logout_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PriceTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void label_price_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox_dateBorn_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
