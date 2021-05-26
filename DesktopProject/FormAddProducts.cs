using DesktopProject.Models;
using System;
using System.Windows.Forms;

namespace DesktopProject
{
    public partial class FormAddProducts : Form
    {
        public bool isTrue = false;
        public string cat, bra, mod, cls, subcls, desc;
        public int id, price, amount;

        public FormAddProducts()
        {
            InitializeComponent();
            
        }
        
        public void Clear()
        {
            txtCategory.Text = txtBrand.Text = txtModel.Text = 
            txtAmount.Text = txtClassification.Text = txtDescription.Text = 
            txtSubClassification.Text = txtPrice.Text = string.Empty;
        }

        private void FormAddProducts_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void productBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.Text == "Save")
            {
                Product product = new Product
                  (
                      txtCategory.Text.Trim(),
                      txtBrand.Text.Trim(),
                      txtModel.Text.Trim(),
                      txtClassification.Text.Trim(),
                      txtSubClassification.Text.Trim(),
                      txtDescription.Text.Trim(),
                      Convert.ToInt32(txtPrice.Text.Trim()),
                      Convert.ToInt32(txtAmount.Text.Trim())
                  );

                DbProduct.AddProduct(product);
                Clear();
            }
            if(btnSave.Text == "Update")
            {
                Product product = new Product
                  (
                      txtCategory.Text.Trim(),
                      txtBrand.Text.Trim(),
                      txtModel.Text.Trim(),
                      txtClassification.Text.Trim(),
                      txtSubClassification.Text.Trim(),
                      txtDescription.Text.Trim(),
                      Convert.ToInt32(txtPrice.Text.Trim()),
                      Convert.ToInt32(txtAmount.Text.Trim())
                  );

                DbProduct.UpdateProduct(product, id);
                Clear();
            }
        }
        public void UpdateInfo()
        {
            txtCategory.Text = cat;
            txtBrand.Text = bra;
            txtModel.Text = mod;
            txtClassification.Text = cls;
            txtSubClassification.Text = subcls;
            txtDescription.Text = desc;
            txtPrice.Text = price.ToString();
            txtAmount.Text = amount.ToString();
            lblTitle.Text = "Form Edit";
        }
        private void FormAddProducts_Load(object sender, EventArgs e)
        {
            UpdateInfo();
        }
        
    }
}
