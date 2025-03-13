using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace First_Hardware_Application
{
    public partial class Categories : Form
    {
        public Categories()
        {
            InitializeComponent();
            Con = new Function();
            ShowCategories();
        }

        Function Con;

        private void ShowCategories()
        {
            string Query = "select * from CategoryTbl";
            CategoryList.DataSource = Con.GetData(Query);
        }
      
        private void button_additem_Click(object sender, System.EventArgs e)
        {
            if (NameTb.Text == "" )
                MessageBox.Show("Missing Data! ");
            else
                try
                {
                    string Name = NameTb.Text;
                    string Query = "insert into CategoryTbl values('{0}')";
                    Query = string.Format(Query, Name);
                    Con.GetData(Query);
                    ShowCategories();
                    MessageBox.Show("Category Added!!");
                    NameTb.Text = "";
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
        }
        int Key = 0;

        private void CategoryList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            NameTb.Text = CategoryList.SelectedRows[0].Cells[1].Value.ToString();

            if (NameTb.Text == "")
            {
                Key = 0;
            }
            else
                Key = Convert.ToInt32(CategoryList.SelectedRows[0].Cells[0].Value.ToString());
        }

        private void button_edit_Click(object sender, System.EventArgs e)
        {
            
            if (NameTb.Text == "")
                MessageBox.Show("Missing Data! ");

            else
                try
                {
                    string Name = NameTb.Text;
                    string Query = "Update CategoryTbl set CatName = '{0}' where CatCode = {1}";
                    Query = string.Format(Query, Name,Key);
                    Con.GetData(Query);
                    ShowCategories();
                    MessageBox.Show("Category Updeted!!");
                    NameTb.Text = "";
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            if (NameTb.Text == "")
                MessageBox.Show("Missing Data! ");
            else
                try
                {
                    string Name = NameTb.Text;
                    string Query = "Delete from CategoryTbl where CatCode = {0}";
                    Query = string.Format(Query, Name);
                    Con.GetData(Query);
                    ShowCategories();
                    MessageBox.Show("Category Deleted!!");
                    NameTb.Text = "";
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
        }
    }
}
