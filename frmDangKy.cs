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
using System.Text.RegularExpressions;

namespace frmDangKy_va_frmSanPham
{
    public partial class frmDangKy : Form
    {

        public frmDangKy()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {

            string strCnn = System.Configuration.ConfigurationSettings.AppSettings["MyCNN"].ToString();
            SqlConnection cnn = new SqlConnection(strCnn);

            string strCmd = @"INSERT INTO " +
                "Customers(CustomerName, Email, Password, CustomerAddress, OtherDetails) " +
                "VALUES (@CustomerName, @Email, @Password, @CustomerAddress, @OtherDetails)";
            SqlCommand cmd = new SqlCommand(strCmd, cnn);

            cmd.Parameters.AddWithValue("@CustomerName", txtCustomerName.Text);
            cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
            cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
            cmd.Parameters.AddWithValue("@CustomerAddress", txtCustomerAddress.Text);
            cmd.Parameters.AddWithValue(@"OtherDetails", "");

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();

            txtCustomerName.Text = "";
            txtEmail.Text = "";
            txtPassword.Text = "";
            txtRePassword.Text = "";
            txtCustomerAddress.Text = "";

            MessageBox.Show("Đăng ký thành công!");
        }

        private void txtRePassword_Leave(object sender, EventArgs e)
        {
            if (txtRePassword.Text != txtPassword.Text)
            {
                MessageBox.Show("Mật khẩu không trùng khớp!");
                txtRePassword.Focus();
                return;
            }
        }
    }
}
