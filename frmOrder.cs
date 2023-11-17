using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace frmDangKy_va_frmSanPham
{
	public partial class frmOrder : Form
	{
		SqlConnection con = new SqlConnection(@"Data Source = DESKTOP-US13QR0\SQLEXPRESS; Initial Catalog = game_store; User ID = sa; Password = 123;");
		SqlCommand cm = new SqlCommand();
		SqlDataReader dr;
		public frmOrder()
		{
			InitializeComponent();
			LoadCustomer();
			LoadProduct();
		}

		public void LoadProduct()
		{
			int i = 0;
			dataGridView1.Rows.Clear();
			cm = new SqlCommand("SELECT * FROM Products", con);
			con.Open();
			dr = cm.ExecuteReader();
			while (dr.Read())
			{
				i++;
				dataGridView1.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString());
			}
			dr.Close();
			con.Close();
		}
		public void LoadCustomer()
		{
			int i = 0;
			dataGridView2.Rows.Clear();
			cm = new SqlCommand("SELECT CustomerID, CustomerName, Email FROM Customers", con);
			con.Open();
			dr = cm.ExecuteReader();
			while (dr.Read())
			{
				i++;
				dataGridView2.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString());
			}
			dr.Close();
			con.Close();
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			try
			{

				if (MessageBox.Show("Are you sure you want to save this order?", "Saving Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					cm = new SqlCommand("OrderAdd", con);
					cm.CommandType = CommandType.StoredProcedure;

					cm.Parameters.AddWithValue("@CustomerID", Int32.Parse(txtCustomerID.Text));
					cm.Parameters.AddWithValue("@OrderDate", txtOrderDate.Value);
					cm.Parameters.AddWithValue("@ShipDate", txtShipDate.Value);
					cm.Parameters.AddWithValue("@OtherDetails", txtDetails.Text);

					cm.Parameters.Add(new SqlParameter("OrderID", SqlDbType.Int));
					cm.Parameters["OrderID"].Direction = ParameterDirection.Output;

					con.Open();
					cm.ExecuteNonQuery();
					this.txtOrderID.Text = cm.Parameters["OrderID"].Value.ToString();
					con.Close();
					addOrder();


				}

			}
			catch (Exception ex)
			{

				MessageBox.Show(ex.Message);
			}
		}
		private void addOrder()
		{
			cm = new SqlCommand("INSERT INTO OrderDetails (OrderID, ProductID, Quantity, UnitCost) VALUES (@orderID, @productID, @quantity, @cost)", con);

			cm.Parameters.AddWithValue("@orderID", Int32.Parse(txtOrderID.Text));
			cm.Parameters.AddWithValue("@productID", Int32.Parse(txtProductID.Text));
			cm.Parameters.AddWithValue("@quantity", Int32.Parse(txtQuantity.Text));

			decimal quantityValue;
			if (decimal.TryParse(txtCost.Text, out quantityValue))
			{
			cm.Parameters.AddWithValue("@cost", quantityValue);
			}

			con.Open();
			cm.ExecuteNonQuery();
			con.Close();
			MessageBox.Show("Đơn hàng đã được lưu thành công.");
		}
		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			this.txtProductID.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
			this.txtCost.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
		}

		private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			this.txtCustomerID.Text = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
		}
	}
}
