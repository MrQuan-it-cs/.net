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

namespace frmDangKy_va_frmSanPham
{
    public partial class frmViewOrders : Form
    {
        string strCnn = System.Configuration.ConfigurationSettings.AppSettings["MyCNN"].ToString();
        public frmViewOrders()
        {
            InitializeComponent();
        }

        private void frmViewOrders_Load(object sender, EventArgs e)
        {
            LoadOrders();

            string strCnn = System.Configuration.ConfigurationSettings.AppSettings["MyCNN"].ToString();

            SqlConnection cnn = new SqlConnection(strCnn);
            string strCmd = @"SELECT * FROM Orders";

            SqlCommand cmd = new SqlCommand(strCmd, cnn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();

            cboOrdID.DataSource = ds.Tables[0];
            cboOrdID.ValueMember = "OrderID";
            cboOrdID.DisplayMember = "OrderID";
        }

        private void LoadOrders()
        {
            string strCmd = "SELECT * FROM Orders";

            SqlConnection cnn = new SqlConnection(strCnn);
            SqlCommand cmd = new SqlCommand(strCmd, cnn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);
            this.dgvOrders.DataSource = dt;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            string strCmd = "SELECT * FROM Orders";

            string strCd = "";
            if (this.txtCusID.Text.Length > 0)
            {
                strCd = " WHERE CustomerID LIKE " + txtCusID.Text + "";
            }

            if (strCmd.Length > 0)
            {
                strCmd += strCd;
            }

            SqlConnection cnn = new SqlConnection(strCnn);
            SqlCommand cmd = new SqlCommand(strCmd, cnn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);
            this.dgvOrders.DataSource = dt;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlConnection cnn = new SqlConnection(strCnn);

            string strCmd = @"INSERT INTO Orders(CustomerID, OrderDate, ShipDate, OtherDetails) " +
                "VALUES (@CustomerID, @OrderDate, @ShipDate, @OtherDetails)";
            SqlCommand cmd = new SqlCommand(strCmd, cnn);

            cmd.Parameters.AddWithValue("@OrderID", cboOrdID.GetItemText(cboOrdID.SelectedItem));
            cmd.Parameters.AddWithValue("@CustomerID", txtCusID.Text);           
            cmd.Parameters.AddWithValue("@OrderDate", this.dtpOrderDate.Value.ToString());
            cmd.Parameters.AddWithValue("@ShipDate", this.dtpShipDate.Value.ToString());
            cmd.Parameters.AddWithValue("@OtherDetails", txtDetail.Text);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();

            cboOrdID.Text = "";
            txtCusID.Text = "";
            dtpOrderDate.Text ="";
            dtpShipDate.Text ="";
            txtDetail.Text = "";
         

            MessageBox.Show("Thêm thành công!");

            LoadOrders();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection cnn = new SqlConnection(strCnn);
            string strCmd = @"DELETE FROM Orders WHERE OrderID = @OrderID";
            SqlCommand cmd = new SqlCommand(strCmd, cnn);

            if (dgvOrders.SelectedRows.Count > 0)
            {
                
                cmd.Parameters.AddWithValue("@OrderID", dgvOrders.CurrentRow.Cells[0].Value.ToString());

                cnn.Open();
                cmd.ExecuteNonQuery();
                cnn.Close();

                LoadOrders();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public int OrderID;

        private void dgvCellClick(object sender, DataGridViewCellEventArgs e)
        {
            cboOrdID.Text = dgvOrders.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtCusID.Text = dgvOrders.Rows[e.RowIndex].Cells[1].Value.ToString();

            dtpOrderDate.Text = dgvOrders.Rows[e.RowIndex].Cells[2].Value.ToString();
            dtpShipDate.Text = dgvOrders.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtDetail.Text = dgvOrders.Rows[e.RowIndex].Cells[4].Value.ToString();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            SqlConnection cnn = new SqlConnection(strCnn);

            string strCmd = @"UPDATE Orders " +
                "SET CustomerID=@CustomerID, OrderDate=@OrderDate, ShipDate=@ShipDate, OtherDetails=@OtherDetails " +
                "WHERE OrderID =@OrderID";
            SqlCommand cmd = new SqlCommand(strCmd, cnn);

            cmd.Parameters.AddWithValue("@CustomerID", txtCusID.Text);
            cmd.Parameters.AddWithValue("@OrderDate", this.dtpOrderDate.Value.ToString());
            cmd.Parameters.AddWithValue("@ShipDate", this.dtpShipDate.Value.ToString());
            cmd.Parameters.AddWithValue("@OtherDetails", txtDetail.Text);
            cmd.Parameters.AddWithValue("@OrderID", cboOrdID.SelectedValue);


            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();

            cboOrdID.Text = "";
            dtpOrderDate.Text = "";
            dtpShipDate.Text = "";
            txtDetail.Text = "";

            MessageBox.Show("Sửa thành công!");

            LoadOrders();
        }
    }
}
