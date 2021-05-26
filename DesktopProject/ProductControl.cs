using System;
using System.Windows.Forms;

namespace DesktopProject
{
    public partial class ProductControl : UserControl
    {
        private static ProductControl _inctance;

        public static ProductControl Inctance
        {
            get
            {
                if (_inctance == null)
                    _inctance = new ProductControl();
                return _inctance;
            }
        }
        public ProductControl()
        {
            InitializeComponent();
            Display();
        }

        public void UpdateInfo()
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            DbProduct.DisplayAndSearch("SELECT Category, Brand, Model, Classification, SubClassification, Description, Price, Amount FROM Products WHERE ", dataGridView);
        }

        private void txtSearch_CursorChanged(object sender, EventArgs e)
        {
            txtSearch.Clear();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txtSearch_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtSearch.Text == "Search...")
                txtSearch.Clear();
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
                txtSearch.Text = "Search...";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            
            FormAddProducts form = new FormAddProducts();
            form.btnSave.Text = "Save";
            form.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
         
        }

        public void Display()
        {
            DbProduct.DisplayAndSearch("SELECT ProductId, Category, Brand, Model, Classification, SubClassification, Description, Price, Amount FROM Products", dataGridView);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Display();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            FormAddProducts form = new FormAddProducts();
            if (e.ColumnIndex == 0)
            {
                //Edit
                form.id = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[2].Value);
                form.cat = dataGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
                form.bra = dataGridView.Rows[e.RowIndex].Cells[4].Value.ToString();
                form.mod = dataGridView.Rows[e.RowIndex].Cells[5].Value.ToString();
                form.cls = dataGridView.Rows[e.RowIndex].Cells[6].Value.ToString();
                form.subcls = dataGridView.Rows[e.RowIndex].Cells[7].Value.ToString();
                form.desc = dataGridView.Rows[e.RowIndex].Cells[8].Value.ToString();
                form.price = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[9].Value);
                form.amount = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[10].Value);
                
                form.ShowDialog();
            }

            if(e.ColumnIndex == 1)
            {
                //Delete
                if(MessageBox.Show("Are you want to delete product record?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    DbProduct.Delete(Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[2].Value));
                    Display();
                }
            }
        }
    }
}
