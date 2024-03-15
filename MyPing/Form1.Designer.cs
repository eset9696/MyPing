namespace MyPing
{
	partial class Form1
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
			this.rtbIpAddress = new System.Windows.Forms.RichTextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnAddIp = new System.Windows.Forms.Button();
			this.btnDeleteIp = new System.Windows.Forms.Button();
			this.lvIpAddresses = new System.Windows.Forms.ListView();
			this.SuspendLayout();
			// 
			// rtbIpAddress
			// 
			this.rtbIpAddress.Location = new System.Drawing.Point(46, 12);
			this.rtbIpAddress.Name = "rtbIpAddress";
			this.rtbIpAddress.Size = new System.Drawing.Size(221, 28);
			this.rtbIpAddress.TabIndex = 0;
			this.rtbIpAddress.Text = "";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.Location = new System.Drawing.Point(12, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(28, 20);
			this.label1.TabIndex = 1;
			this.label1.Text = "IP:";
			// 
			// btnAddIp
			// 
			this.btnAddIp.Location = new System.Drawing.Point(274, 12);
			this.btnAddIp.Name = "btnAddIp";
			this.btnAddIp.Size = new System.Drawing.Size(75, 23);
			this.btnAddIp.TabIndex = 2;
			this.btnAddIp.Text = "Add";
			this.btnAddIp.UseVisualStyleBackColor = true;
			this.btnAddIp.Click += new System.EventHandler(this.btnAddIp_Click);
			// 
			// btnDeleteIp
			// 
			this.btnDeleteIp.Location = new System.Drawing.Point(355, 12);
			this.btnDeleteIp.Name = "btnDeleteIp";
			this.btnDeleteIp.Size = new System.Drawing.Size(75, 23);
			this.btnDeleteIp.TabIndex = 3;
			this.btnDeleteIp.Text = "Detele";
			this.btnDeleteIp.UseVisualStyleBackColor = true;
			this.btnDeleteIp.Click += new System.EventHandler(this.btnDeleteIp_Click);
			// 
			// lvIpAddresses
			// 
			this.lvIpAddresses.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lvIpAddresses.HideSelection = false;
			this.lvIpAddresses.Location = new System.Drawing.Point(12, 46);
			this.lvIpAddresses.Name = "lvIpAddresses";
			this.lvIpAddresses.Size = new System.Drawing.Size(424, 320);
			this.lvIpAddresses.TabIndex = 4;
			this.lvIpAddresses.UseCompatibleStateImageBehavior = false;
			this.lvIpAddresses.View = System.Windows.Forms.View.Details;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(448, 378);
			this.Controls.Add(this.lvIpAddresses);
			this.Controls.Add(this.btnDeleteIp);
			this.Controls.Add(this.btnAddIp);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.rtbIpAddress);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.RichTextBox rtbIpAddress;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnAddIp;
		private System.Windows.Forms.Button btnDeleteIp;
		private System.Windows.Forms.ListView lvIpAddresses;
	}
}

