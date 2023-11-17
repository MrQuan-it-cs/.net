using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace frmDangKy_va_frmSanPham
{
    public partial class LoginGS : Form
    {
        public LoginGS()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblPass_Click(object sender, EventArgs e)
        {

        }

        private void lblUser_Click(object sender, EventArgs e)
        {

        }

        private void abc(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string strUser = this.txtUser.Text;
            string strPass = this.txtPass.Text;
            /*string strMessage = String.Format("Bạn đã nhập user name {0}, "+"password {1}", strUser, strPass);

           DialogResult dr = MessageBox.Show(strMessage +"\n Bạn có muốn kiểm tra trong CSDL không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dr==DialogResult.Yes)*/
            //{
                //MessageBox.Show("Bạn bấm Yes!");
                CheckUserNamePassFromDB(strUser, strPass);
            //}
            //else
            //{
                //MessageBox.Show("Bạn bấm No!");
            //}    
        }
        private bool CheckUserNamePassFromDB(string strUser, string strPass)
        {
            try
            {
                //string strConnect = "Data Source=DD\\MSSQL;"
                    //+ "Initial Catalog=game_store;"
                    //+ "Integrated Security=True";

                string strConnect = System.Configuration.ConfigurationSettings.AppSettings["MyCNN"].ToString();

                string strCommand = "select * from Customers where CustomerName ='" + strUser + "' and Password = '" + strPass + "'";
                    

                SqlConnection cnn = new SqlConnection(strConnect);
                SqlCommand myCommand = new SqlCommand(strCommand, cnn);
                SqlDataAdapter da = new SqlDataAdapter(myCommand);
                DataSet ds = new DataSet();
                da.Fill(ds, "ABC");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Có dữ liệu!");

                    return true;
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu!");
                    return false;
                } 
                    
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Có lỗi xảy ra", ex.Message );
                return false;
            }
        }

        private void LoginGS_Load(object sender, EventArgs e)
        {

        }
    }
}
