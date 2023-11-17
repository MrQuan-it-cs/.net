namespace frmDangKy_va_frmSanPham
{
	partial class frmOrder
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.dataGridView2 = new System.Windows.Forms.DataGridView();
			this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.btnAdd = new System.Windows.Forms.Button();
			this.txtOrderDate = new System.Windows.Forms.DateTimePicker();
			this.txtShipDate = new System.Windows.Forms.DateTimePicker();
			this.txtCustomerID = new System.Windows.Forms.TextBox();
			this.txtQuantity = new System.Windows.Forms.TextBox();
			this.txtProductID = new System.Windows.Forms.TextBox();
			this.txtOrderID = new System.Windows.Forms.TextBox();
			this.txtDetails = new System.Windows.Forms.TextBox();
			this.txtCost = new System.Windows.Forms.TextBox();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.dataGridView1);
			this.panel1.Location = new System.Drawing.Point(13, 13);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(811, 262);
			this.panel1.TabIndex = 0;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.dataGridView2);
			this.panel2.Location = new System.Drawing.Point(855, 13);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(427, 262);
			this.panel2.TabIndex = 1;
			// 
			// dataGridView1
			// 
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column9,
            this.Column10,
            this.Column2,
            this.Column3,
            this.Column4});
			this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridView1.Location = new System.Drawing.Point(0, 0);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowHeadersWidth = 51;
			this.dataGridView1.RowTemplate.Height = 24;
			this.dataGridView1.Size = new System.Drawing.Size(811, 262);
			this.dataGridView1.TabIndex = 0;
			this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
			// 
			// dataGridView2
			// 
			this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8});
			this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridView2.Location = new System.Drawing.Point(0, 0);
			this.dataGridView2.Name = "dataGridView2";
			this.dataGridView2.RowHeadersWidth = 51;
			this.dataGridView2.RowTemplate.Height = 24;
			this.dataGridView2.Size = new System.Drawing.Size(427, 262);
			this.dataGridView2.TabIndex = 0;
			this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
			// 
			// Column5
			// 
			this.Column5.HeaderText = "Column5";
			this.Column5.MinimumWidth = 6;
			this.Column5.Name = "Column5";
			this.Column5.Width = 125;
			// 
			// Column6
			// 
			this.Column6.HeaderText = "Column6";
			this.Column6.MinimumWidth = 6;
			this.Column6.Name = "Column6";
			this.Column6.Width = 125;
			// 
			// Column7
			// 
			this.Column7.HeaderText = "Column7";
			this.Column7.MinimumWidth = 6;
			this.Column7.Name = "Column7";
			this.Column7.Width = 125;
			// 
			// Column8
			// 
			this.Column8.HeaderText = "Column8";
			this.Column8.MinimumWidth = 6;
			this.Column8.Name = "Column8";
			this.Column8.Width = 125;
			// 
			// Column1
			// 
			this.Column1.HeaderText = "Column1";
			this.Column1.MinimumWidth = 6;
			this.Column1.Name = "Column1";
			this.Column1.Width = 125;
			// 
			// Column9
			// 
			this.Column9.HeaderText = "Column9";
			this.Column9.MinimumWidth = 6;
			this.Column9.Name = "Column9";
			this.Column9.Width = 125;
			// 
			// Column10
			// 
			this.Column10.HeaderText = "Column10";
			this.Column10.MinimumWidth = 6;
			this.Column10.Name = "Column10";
			this.Column10.Width = 125;
			// 
			// Column2
			// 
			this.Column2.HeaderText = "Column2";
			this.Column2.MinimumWidth = 6;
			this.Column2.Name = "Column2";
			this.Column2.Width = 125;
			// 
			// Column3
			// 
			this.Column3.HeaderText = "Column3";
			this.Column3.MinimumWidth = 6;
			this.Column3.Name = "Column3";
			this.Column3.Width = 125;
			// 
			// Column4
			// 
			this.Column4.HeaderText = "Column4";
			this.Column4.MinimumWidth = 6;
			this.Column4.Name = "Column4";
			this.Column4.Width = 125;
			// 
			// btnAdd
			// 
			this.btnAdd.Location = new System.Drawing.Point(13, 528);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(113, 23);
			this.btnAdd.TabIndex = 2;
			this.btnAdd.Text = "Add Order";
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// txtOrderDate
			// 
			this.txtOrderDate.Location = new System.Drawing.Point(306, 328);
			this.txtOrderDate.Name = "txtOrderDate";
			this.txtOrderDate.Size = new System.Drawing.Size(200, 22);
			this.txtOrderDate.TabIndex = 3;
			// 
			// txtShipDate
			// 
			this.txtShipDate.Location = new System.Drawing.Point(306, 387);
			this.txtShipDate.Name = "txtShipDate";
			this.txtShipDate.Size = new System.Drawing.Size(200, 22);
			this.txtShipDate.TabIndex = 4;
			// 
			// txtCustomerID
			// 
			this.txtCustomerID.Location = new System.Drawing.Point(663, 327);
			this.txtCustomerID.Name = "txtCustomerID";
			this.txtCustomerID.Size = new System.Drawing.Size(100, 22);
			this.txtCustomerID.TabIndex = 5;
			// 
			// txtQuantity
			// 
			this.txtQuantity.Location = new System.Drawing.Point(663, 386);
			this.txtQuantity.Name = "txtQuantity";
			this.txtQuantity.Size = new System.Drawing.Size(100, 22);
			this.txtQuantity.TabIndex = 6;
			// 
			// txtProductID
			// 
			this.txtProductID.Location = new System.Drawing.Point(663, 450);
			this.txtProductID.Name = "txtProductID";
			this.txtProductID.Size = new System.Drawing.Size(100, 22);
			this.txtProductID.TabIndex = 7;
			// 
			// txtOrderID
			// 
			this.txtOrderID.Location = new System.Drawing.Point(306, 470);
			this.txtOrderID.Name = "txtOrderID";
			this.txtOrderID.Size = new System.Drawing.Size(100, 22);
			this.txtOrderID.TabIndex = 8;
			// 
			// txtDetails
			// 
			this.txtDetails.Location = new System.Drawing.Point(51, 327);
			this.txtDetails.Name = "txtDetails";
			this.txtDetails.Size = new System.Drawing.Size(100, 22);
			this.txtDetails.TabIndex = 9;
			// 
			// txtCost
			// 
			this.txtCost.Location = new System.Drawing.Point(663, 510);
			this.txtCost.Name = "txtCost";
			this.txtCost.Size = new System.Drawing.Size(100, 22);
			this.txtCost.TabIndex = 10;
			// 
			// frmOrder
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1347, 563);
			this.Controls.Add(this.txtCost);
			this.Controls.Add(this.txtDetails);
			this.Controls.Add(this.txtOrderID);
			this.Controls.Add(this.txtProductID);
			this.Controls.Add(this.txtQuantity);
			this.Controls.Add(this.txtCustomerID);
			this.Controls.Add(this.txtShipDate);
			this.Controls.Add(this.txtOrderDate);
			this.Controls.Add(this.btnAdd);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Name = "frmOrder";
			this.Text = "frmOrder";
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.DataGridView dataGridView2;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
		private System.Windows.Forms.Button btnAdd;
		public System.Windows.Forms.DateTimePicker txtOrderDate;
		public System.Windows.Forms.DateTimePicker txtShipDate;
		public System.Windows.Forms.TextBox txtCustomerID;
		public System.Windows.Forms.TextBox txtQuantity;
		public System.Windows.Forms.TextBox txtProductID;
		private System.Windows.Forms.TextBox txtOrderID;
		private System.Windows.Forms.TextBox txtDetails;
		private System.Windows.Forms.TextBox txtCost;
	}
}