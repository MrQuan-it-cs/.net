using frmDangKy_va_frmSanPham;
using FontAwesome.Sharp;
using System.Drawing;
using System.Windows.Forms;
using Color = System.Drawing.Color;

namespace frmDangKy_va_frmSanPham
{
    public partial class frmSideBar : Form
    {

        // Declare fields
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private Form currentChildForm;


        public frmSideBar()
        {
            InitializeComponent();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 60);
            panelMenu.Controls.Add(leftBorderBtn);
            OpenChildForm(new frmDashboard());
        }
        // Methods
        private void ActivateButton(object senderBtn)
        {

            if (senderBtn != null)
            {
                DisableButton();
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.DarkGray;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign= ContentAlignment.MiddleRight;

                //Icon title
                icCurrChildForm.IconChar= currentBtn.IconChar;
            }
        }
        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.Gray;
                currentBtn.ForeColor = Color.Gainsboro;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = Color.Gainsboro;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        private void OpenChildForm(Form childForm)
        {
            if(currentChildForm != null)
            {
                // Open only one form
                currentChildForm.Close();
            }
            currentChildForm= childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelMainView.Controls.Add(childForm);
            panelMainView.Tag= childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitChildForm.Text= childForm.Text;
        }

        private void btnDashboard_Click(object sender, System.EventArgs e)
        {
            ActivateButton(sender);
            OpenChildForm(new frmDashboard());
        }

        private void btnOrders_Click(object sender, System.EventArgs e)
        {
            ActivateButton(sender);
            OpenChildForm(new frmViewOrders());
        }

        private void btnProducts_Click(object sender, System.EventArgs e)
        {
            ActivateButton(sender);
            OpenChildForm(new frmSanPham());
        }

        private void btnCustomers_Click(object sender, System.EventArgs e)
        {
            ActivateButton(sender);
            //OpenChildForm(new frmCustomer());
        }

        private void icCurrChildForm_Click(object sender, System.EventArgs e)
        {

        }

        private void btnSettings_Click(object sender, System.EventArgs e)
        {

        }
    }
}
