namespace Alyabiev.Task14.Task1.Controls
{
	partial class RewardsForm
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
			this.buttonCancel = new System.Windows.Forms.Button();
			this.buttonOk = new System.Windows.Forms.Button();
			this.listBoxRewards = new System.Windows.Forms.ListBox();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.buttonCancel);
			this.panel1.Controls.Add(this.buttonOk);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 312);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(364, 52);
			this.panel1.TabIndex = 20;
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(277, 14);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 6;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			// 
			// buttonOk
			// 
			this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonOk.Location = new System.Drawing.Point(12, 14);
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.Size = new System.Drawing.Size(75, 23);
			this.buttonOk.TabIndex = 3;
			this.buttonOk.Text = "Ok";
			this.buttonOk.UseVisualStyleBackColor = true;
			// 
			// listBoxRewards
			// 
			this.listBoxRewards.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listBoxRewards.FormattingEnabled = true;
			this.listBoxRewards.Location = new System.Drawing.Point(0, 0);
			this.listBoxRewards.Name = "listBoxRewards";
			this.listBoxRewards.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
			this.listBoxRewards.Size = new System.Drawing.Size(364, 312);
			this.listBoxRewards.TabIndex = 22;
			// 
			// RewardsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(364, 364);
			this.ControlBox = false;
			this.Controls.Add(this.listBoxRewards);
			this.Controls.Add(this.panel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "RewardsForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "RewardsForm";
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Button buttonOk;
		private System.Windows.Forms.ListBox listBoxRewards;
	}
}