using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace frmDangKy_va_frmSanPham
{
    public partial class frmSanPham : Form
    {
        string strCnn = System.Configuration.ConfigurationSettings.AppSettings["MyCNN"].ToString();

        public frmSanPham()
        {
            InitializeComponent();
        }

        private void frmSanPham3_Load(object sender, EventArgs e)
        {
            LoadProducts();

            string strCnn = System.Configuration.ConfigurationSettings.AppSettings["MyCNN"].ToString();

            SqlConnection cnn = new SqlConnection(strCnn);
            string strCmd = @"SELECT * FROM ProductTypes";

            SqlCommand cmd = new SqlCommand(strCmd, cnn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();

            cbbPTC.DataSource = ds.Tables[0];
            cbbPTC.ValueMember = "ProductTypeCode";
            cbbPTC.DisplayMember = "ProductTypeCode";
        }

        private void LoadProducts()
        {
            string strCmd = "SELECT * FROM Products";

            SqlConnection cnn = new SqlConnection(strCnn);
            SqlCommand cmd = new SqlCommand(strCmd, cnn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);
            this.dgvProducts.DataSource = dt;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string strCmd = "SELECT * FROM Products";

            string strCd = "";
            if (this.txtProductName.Text.Length > 0)
            {
                strCd = " WHERE ProductName LIKE N'%" + txtProductName.Text + "%'";
            }

            if (strCmd.Length > 0)
            {
                strCmd += strCd;
            }

            SqlConnection cnn= new SqlConnection(strCnn);
            SqlCommand cmd = new SqlCommand(strCmd, cnn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);
            this.dgvProducts.DataSource = dt;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            SqlConnection cnn = new SqlConnection(strCnn);

            string strCmd = @"INSERT INTO Products(PTC, ProductName, ProductPrice, ProductDescription) " +
                "VALUES (@PTC, @ProductName, @ProductPrice, @ProductDescription)";
            SqlCommand cmd = new SqlCommand(strCmd, cnn);

            cmd.Parameters.AddWithValue("@PTC", cbbPTC.GetItemText(cbbPTC.SelectedItem));
            cmd.Parameters.AddWithValue("@ProductName", txtProductName.Text);
            cmd.Parameters.AddWithValue("@ProductPrice", decimal.Parse(txtProductPrice.Text));
            cmd.Parameters.AddWithValue("@ProductDescription", txtProductDescription.Text);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();

            cbbPTC.Text = "";
            txtProductName.Text = "";
            txtProductPrice.Text = "";
            txtProductDescription.Text = "";

            MessageBox.Show("Thêm thành công!");

            LoadProducts();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            SqlConnection cnn = new SqlConnection(strCnn);
            string strCmd = @"DELETE FROM Products WHERE ProductID = @ProductID";
            SqlCommand cmd = new SqlCommand(strCmd, cnn);

            if (dgvProducts.SelectedRows.Count > 0)
            {
                //dgvProducts.Rows.RemoveAt(dgvProducts.CurrentRow.Index);
                cmd.Parameters.AddWithValue("@ProductID", dgvProducts.CurrentRow.Cells[0].Value.ToString());

                cnn.Open();
                cmd.ExecuteNonQuery();
                cnn.Close();

                LoadProducts();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public int productID;
        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            productID = Int32.Parse(dgvProducts.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtProductName.Text = dgvProducts.Rows[e.RowIndex].Cells[2].Value.ToString();
            cbbPTC.Text = dgvProducts.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtProductPrice.Text = dgvProducts.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtProductDescription.Text = dgvProducts.Rows[e.RowIndex].Cells[4].Value.ToString();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            SqlConnection cnn = new SqlConnection(strCnn);

            string strCmd = @"UPDATE Products " +
                "SET PTC=@PTC, ProductName=@ProductName, ProductPrice=@ProductPrice, ProductDescription=@ProductDescription " +
                "WHERE ProductID = @ProductID";
            SqlCommand cmd = new SqlCommand(strCmd, cnn);

            cmd.Parameters.AddWithValue("@PTC", cbbPTC.GetItemText(cbbPTC.SelectedItem));
            cmd.Parameters.AddWithValue("@ProductName", txtProductName.Text);
            cmd.Parameters.AddWithValue("@ProductPrice", decimal.Parse(txtProductPrice.Text));
            cmd.Parameters.AddWithValue("@ProductDescription", txtProductDescription.Text);
            cmd.Parameters.AddWithValue("@ProductID", productID);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();

            cbbPTC.Text = "";
            txtProductName.Text = "";
            txtProductPrice.Text = "";
            txtProductDescription.Text = "";

            MessageBox.Show("Sửa thành công!");

            LoadProducts();
        }
    }
}
