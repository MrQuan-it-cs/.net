namespace frmDangKy_va_frmSanPham
{
	partial class frmAddOrder
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
			this.txtOrderID = new System.Windows.Forms.TextBox();
			this.txtProducID = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// txtOrderID
			// 
			this.txtOrderID.Location = new System.Drawing.Point(216, 48);
			this.txtOrderID.Name = "txtOrderID";
			this.txtOrderID.Size = new System.Drawing.Size(100, 22);
			this.txtOrderID.TabIndex = 0;
			// 
			// txtProducID
			// 
			this.txtProducID.Location = new System.Drawing.Point(216, 114);
			this.txtProducID.Name = "txtProducID";
			this.txtProducID.Size = new System.Drawing.Size(100, 22);
			this.txtProducID.TabIndex = 1;
			// 
			// frmAddOrder
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.txtProducID);
			this.Controls.Add(this.txtOrderID);
			this.Name = "frmAddOrder";
			this.Text = "frmAddOrder";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtOrderID;
		private System.Windows.Forms.TextBox txtProducID;
	}
}