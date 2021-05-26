using DesktopProject.Models;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows;

namespace DesktopProject
{
    class DbProduct
    {
        public static MySqlConnection GetConnection()
        {
            string sql = "datasource=localhost;port=3306;username=root;password=112233;database=TestDb";
            MySqlConnection con = new MySqlConnection(sql);
            try
            {
                con.Open();
            }

            catch(MySqlException ex)
            {
                MessageBox.Show("MySql Connection! \n" + ex.Message, "Error", MessageBoxButton.OK);
            }

            return con;
        }

        public static void AddProduct(Product product)
        {
            string sql = "INSERT INTO products VALUES (NULL, @Category, @Brand, @Model, @Classification, @SubClassification, @Description, @Price, @Amount)";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@Category", MySqlDbType.VarChar).Value = product.Category;
            cmd.Parameters.Add("@Brand", MySqlDbType.VarChar).Value = product.Brand;
            cmd.Parameters.Add("@Model", MySqlDbType.VarChar).Value = product.Model;
            cmd.Parameters.Add("@Classification", MySqlDbType.VarChar).Value = product.Classification;
            cmd.Parameters.Add("@SubClassification", MySqlDbType.VarChar).Value = product.SubClassification;
            cmd.Parameters.Add("@Description", MySqlDbType.VarChar).Value = product.Description;
            cmd.Parameters.Add("@Price", MySqlDbType.Int32).Value = product.Price;
            cmd.Parameters.Add("@Amount", MySqlDbType.Int32).Value = product.Amount;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Added Successfully.", "Information", MessageBoxButton.OK);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Product not insert. \n" + ex.Message, "Error", MessageBoxButton.OK);
            }
            con.Close();
        }

        public static void UpdateProduct(Product product, int id)
        {
            string sql = "Update products SET Category=@Category, Brand=@Brand, Model=@Model, Classification=@Classification, SubClassification=@SubClassification, Description=@Description, Price=@Price, Amount=@Amount WHERE ProductId=" + id;
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@Category", MySqlDbType.VarChar).Value = product.Category;
            cmd.Parameters.Add("@Brand", MySqlDbType.VarChar).Value = product.Brand;
            cmd.Parameters.Add("@Model", MySqlDbType.VarChar).Value = product.Model;
            cmd.Parameters.Add("@Classification", MySqlDbType.VarChar).Value = product.Classification;
            cmd.Parameters.Add("@SubClassification", MySqlDbType.VarChar).Value = product.SubClassification;
            cmd.Parameters.Add("@Description", MySqlDbType.VarChar).Value = product.Description;
            cmd.Parameters.Add("@Price", MySqlDbType.Int32).Value = product.Price;
            cmd.Parameters.Add("@Amount", MySqlDbType.Int32).Value = product.Amount;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Updated Successfully.", "Information", MessageBoxButton.OK);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Product not updated. \n" + ex.Message, "Error", MessageBoxButton.OK);
            }
            con.Close();
        }

        public static void Delete(int id)
        {
            string sql = "DELETE FROM `testdb`.`products` WHERE ProductId=" + id;
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("ProductId", MySqlDbType.Int32).Value = id;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Deleted Successfully.", "Information", MessageBoxButton.OK);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Product not Deleted. \n" + ex.Message, "Error", MessageBoxButton.OK);
            }
            con.Close();
        }

        public static void DisplayAndSearch(string query, System.Windows.Forms.DataGridView dgv)
        {
            string sql = query;
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            dgv.DataSource = dt;
            con.Close();
        }
    }
}
