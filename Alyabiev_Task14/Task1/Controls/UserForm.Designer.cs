namespace Alyabiev.Task14.Task1.Controls
{
	partial class UserForm
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
			this.components = new System.ComponentModel.Container();
			this.panel1 = new System.Windows.Forms.Panel();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.buttonOk = new System.Windows.Forms.Button();
			this.textBoxSurname = new System.Windows.Forms.TextBox();
			this.labelSurname = new System.Windows.Forms.Label();
			this.textBoxName = new System.Windows.Forms.TextBox();
			this.labelName = new System.Windows.Forms.Label();
			this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.birthdatePicker = new System.Windows.Forms.DateTimePicker();
			this.labelBirthdate = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.buttonCancel);
			this.panel1.Controls.Add(this.buttonOk);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 113);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(234, 52);
			this.panel1.TabIndex = 19;
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(147, 14);
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
			// textBoxSurname
			// 
			this.textBoxSurname.Location = new System.Drawing.Point(72, 39);
			this.textBoxSurname.Name = "textBoxSurname";
			this.textBoxSurname.Size = new System.Drawing.Size(100, 20);
			this.textBoxSurname.TabIndex = 18;
			// 
			// labelSurname
			// 
			this.labelSurname.AutoSize = true;
			this.labelSurname.Location = new System.Drawing.Point(8, 42);
			this.labelSurname.Name = "labelSurname";
			this.labelSurname.Size = new System.Drawing.Size(52, 13);
			this.labelSurname.TabIndex = 17;
			this.labelSurname.Text = "Surname:";
			// 
			// textBoxName
			// 
			this.textBoxName.Location = new System.Drawing.Point(72, 3);
			this.textBoxName.Name = "textBoxName";
			this.textBoxName.Size = new System.Drawing.Size(100, 20);
			this.textBoxName.TabIndex = 16;
			// 
			// labelName
			// 
			this.labelName.AutoSize = true;
			this.labelName.Location = new System.Drawing.Point(8, 6);
			this.labelName.Name = "labelName";
			this.labelName.Size = new System.Drawing.Size(38, 13);
			this.labelName.TabIndex = 15;
			this.labelName.Text = "Name:";
			// 
			// errorProvider
			// 
			this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink;
			this.errorProvider.ContainerControl = this;
			// 
			// birthdatePicker
			// 
			this.birthdatePicker.Location = new System.Drawing.Point(72, 76);
			this.birthdatePicker.Name = "birthdatePicker";
			this.birthdatePicker.Size = new System.Drawing.Size(141, 20);
			this.birthdatePicker.TabIndex = 21;
			// 
			// labelBirthdate
			// 
			this.labelBirthdate.AutoSize = true;
			this.labelBirthdate.Location = new System.Drawing.Point(8, 82);
			this.labelBirthdate.Name = "labelBirthdate";
			this.labelBirthdate.Size = new System.Drawing.Size(52, 13);
			this.labelBirthdate.TabIndex = 20;
			this.labelBirthdate.Text = "Birthdate:";
			// 
			// UserForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(234, 165);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.textBoxSurname);
			this.Controls.Add(this.labelSurname);
			this.Controls.Add(this.textBoxName);
			this.Controls.Add(this.labelName);
			this.Controls.Add(this.birthdatePicker);
			this.Controls.Add(this.labelBirthdate);
			this.Name = "UserForm";
			this.Text = "UserForm";
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Button buttonOk;
		private System.Windows.Forms.TextBox textBoxSurname;
		private System.Windows.Forms.Label labelSurname;
		private System.Windows.Forms.TextBox textBoxName;
		private System.Windows.Forms.Label labelName;
		private System.Windows.Forms.ErrorProvider errorProvider;
		private System.Windows.Forms.DateTimePicker birthdatePicker;
		private System.Windows.Forms.Label labelBirthdate;
	}
}