using frmDangKy_va_frmSanPham.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace frmDangKy_va_frmSanPham
{
    public partial class frmDashboard : Form
    {
        private Dashboard model;

        public frmDashboard()
        {
            InitializeComponent();
            dtpStartDate.Value = DateTime.Today.AddDays(-7);
            dtpStartDate.Value = DateTime.Now;
            btn7Day.Select();

            model = new Dashboard();
            LoadData();
        }

        private void LoadData()
        {
            var refreshData  = model.LoadData(dtpStartDate.Value, dtpEndDate.Value);
            if(refreshData == true)
            {
                lblNumOrders.Text = model.NumOrders.ToString();
                lblTotalRevenue.Text = "$" + model.TotalRevenue.ToString();
                lblNumCustomers.Text = model.NumCustomers.ToString();
                lblNumProducts.Text = model.NumProducts.ToString();

                chartGrossRevenue.DataSource = model.GrossRevenueList;
                chartGrossRevenue.Series[0].XValueMember = "Date";
                chartGrossRevenue.Series[0].YValueMembers = "TotalAmount";
                chartGrossRevenue.DataBind();

                chartTop5.DataSource = model.TopProducts;
                chartTop5.Series[0].XValueMember = "Key";
                chartTop5.Series[0].YValueMembers = "Value";
                chartTop5.DataBind();
            }
        }


        private void DisableCustomDate()
        {
            dtpEndDate.Enabled = false;
            dtpStartDate.Enabled = false;
            btnOk.Visible = false;
        }

        private void btn7Day_Click(object sender, EventArgs e)
        {
            dtpStartDate.Value = DateTime.Today;
            dtpEndDate.Value = DateTime.Now;
            LoadData();
            DisableCustomDate();
        }

        private void btnToday_Click(object sender, EventArgs e)
        {
            dtpStartDate.Value = DateTime.Today.AddDays(-7);
            dtpEndDate.Value = DateTime.Now;
            LoadData();
            DisableCustomDate();
        }

        private void btn30Day_Click(object sender, EventArgs e)
        {
            dtpStartDate.Value = DateTime.Today.AddDays(-30);
            dtpEndDate.Value = DateTime.Now;
            LoadData();
            DisableCustomDate();
        }

        private void btnThismonth_Click(object sender, EventArgs e)
        {
            dtpStartDate.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dtpEndDate.Value = DateTime.Now;
            LoadData();
            DisableCustomDate();
        }

        private void btnCustom_Click(object sender, EventArgs e)
        {
            dtpEndDate.Enabled = true;
            dtpStartDate.Enabled = true;
            btnOk.Visible = true;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
