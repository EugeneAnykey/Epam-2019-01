namespace Alyabiev.Task15.Awarder.PL.WinForms
{
	partial class MainForm
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
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuExit = new System.Windows.Forms.ToolStripMenuItem();
			this.menuAbout = new System.Windows.Forms.ToolStripMenuItem();
			this.usersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuUsersAddUser = new System.Windows.Forms.ToolStripMenuItem();
			this.menuUsersEditUser = new System.Windows.Forms.ToolStripMenuItem();
			this.menuUsersDeleteUser = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
			this.menuUsersAlteringAwards = new System.Windows.Forms.ToolStripMenuItem();
			this.awardsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuAwardsAddAward = new System.Windows.Forms.ToolStripMenuItem();
			this.menuAwardsEditAward = new System.Windows.Forms.ToolStripMenuItem();
			this.menuAwardsRemoveAward = new System.Windows.Forms.ToolStripMenuItem();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPageUsers = new System.Windows.Forms.TabPage();
			this.panel1 = new System.Windows.Forms.Panel();
			this.usersDataGridView = new System.Windows.Forms.DataGridView();
			this.contextMenuStripUsers = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.contextUsersAddUser = new System.Windows.Forms.ToolStripMenuItem();
			this.contextUsersEditUser = new System.Windows.Forms.ToolStripMenuItem();
			this.contextUsersDeleteUser = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.contextUsersAlteringAwards = new System.Windows.Forms.ToolStripMenuItem();
			this.tabPageAwards = new System.Windows.Forms.TabPage();
			this.panel2 = new System.Windows.Forms.Panel();
			this.awardsDataGridView = new System.Windows.Forms.DataGridView();
			this.contextMenuStripAwards = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.contextAwardsAddAward = new System.Windows.Forms.ToolStripMenuItem();
			this.contextAwardsEditAward = new System.Windows.Forms.ToolStripMenuItem();
			this.contextAwardsRemoveAward = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPageUsers.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.usersDataGridView)).BeginInit();
			this.contextMenuStripUsers.SuspendLayout();
			this.tabPageAwards.SuspendLayout();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.awardsDataGridView)).BeginInit();
			this.contextMenuStripAwards.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.menuAbout,
            this.usersToolStripMenuItem,
            this.awardsToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(800, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuExit});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// menuExit
			// 
			this.menuExit.Name = "menuExit";
			this.menuExit.Size = new System.Drawing.Size(180, 22);
			this.menuExit.Text = "Exit";
			// 
			// menuAbout
			// 
			this.menuAbout.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.menuAbout.Name = "menuAbout";
			this.menuAbout.Size = new System.Drawing.Size(52, 20);
			this.menuAbout.Text = "About";
			// 
			// usersToolStripMenuItem
			// 
			this.usersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuUsersAddUser,
            this.menuUsersEditUser,
            this.menuUsersDeleteUser,
            this.toolStripMenuItem6,
            this.menuUsersAlteringAwards});
			this.usersToolStripMenuItem.Name = "usersToolStripMenuItem";
			this.usersToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
			this.usersToolStripMenuItem.Text = "Users";
			// 
			// menuUsersAddUser
			// 
			this.menuUsersAddUser.Name = "menuUsersAddUser";
			this.menuUsersAddUser.Size = new System.Drawing.Size(180, 22);
			this.menuUsersAddUser.Text = "Add &user...";
			// 
			// menuUsersEditUser
			// 
			this.menuUsersEditUser.Name = "menuUsersEditUser";
			this.menuUsersEditUser.Size = new System.Drawing.Size(180, 22);
			this.menuUsersEditUser.Text = "&Edit user...";
			// 
			// menuUsersDeleteUser
			// 
			this.menuUsersDeleteUser.Name = "menuUsersDeleteUser";
			this.menuUsersDeleteUser.Size = new System.Drawing.Size(180, 22);
			this.menuUsersDeleteUser.Text = "&Delete user";
			// 
			// toolStripMenuItem6
			// 
			this.toolStripMenuItem6.Name = "toolStripMenuItem6";
			this.toolStripMenuItem6.Size = new System.Drawing.Size(177, 6);
			// 
			// menuUsersAlteringAwards
			// 
			this.menuUsersAlteringAwards.Name = "menuUsersAlteringAwards";
			this.menuUsersAlteringAwards.Size = new System.Drawing.Size(180, 22);
			this.menuUsersAlteringAwards.Text = "&Altering awards...";
			// 
			// awardsToolStripMenuItem
			// 
			this.awardsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAwardsAddAward,
            this.menuAwardsEditAward,
            this.menuAwardsRemoveAward});
			this.awardsToolStripMenuItem.Name = "awardsToolStripMenuItem";
			this.awardsToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
			this.awardsToolStripMenuItem.Text = "Awards";
			// 
			// menuAwardsAddAward
			// 
			this.menuAwardsAddAward.Name = "menuAwardsAddAward";
			this.menuAwardsAddAward.Size = new System.Drawing.Size(180, 22);
			this.menuAwardsAddAward.Text = "&Add award...";
			// 
			// menuAwardsEditAward
			// 
			this.menuAwardsEditAward.Name = "menuAwardsEditAward";
			this.menuAwardsEditAward.Size = new System.Drawing.Size(180, 22);
			this.menuAwardsEditAward.Text = "&Edit award...";
			// 
			// menuAwardsRemoveAward
			// 
			this.menuAwardsRemoveAward.Name = "menuAwardsRemoveAward";
			this.menuAwardsRemoveAward.Size = new System.Drawing.Size(180, 22);
			this.menuAwardsRemoveAward.Text = "&Remove award";
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPageUsers);
			this.tabControl1.Controls.Add(this.tabPageAwards);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 24);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(800, 426);
			this.tabControl1.TabIndex = 1;
			// 
			// tabPageUsers
			// 
			this.tabPageUsers.Controls.Add(this.panel1);
			this.tabPageUsers.Location = new System.Drawing.Point(4, 22);
			this.tabPageUsers.Name = "tabPageUsers";
			this.tabPageUsers.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageUsers.Size = new System.Drawing.Size(792, 400);
			this.tabPageUsers.TabIndex = 0;
			this.tabPageUsers.Text = "Users";
			this.tabPageUsers.UseVisualStyleBackColor = true;
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.panel1.Controls.Add(this.usersDataGridView);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(3, 3);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(5);
			this.panel1.Size = new System.Drawing.Size(786, 394);
			this.panel1.TabIndex = 3;
			// 
			// usersDataGridView
			// 
			this.usersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.usersDataGridView.ContextMenuStrip = this.contextMenuStripUsers;
			this.usersDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.usersDataGridView.Location = new System.Drawing.Point(5, 5);
			this.usersDataGridView.Name = "usersDataGridView";
			this.usersDataGridView.Size = new System.Drawing.Size(776, 384);
			this.usersDataGridView.TabIndex = 2;
			// 
			// contextMenuStripUsers
			// 
			this.contextMenuStripUsers.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextUsersAddUser,
            this.contextUsersEditUser,
            this.contextUsersDeleteUser,
            this.toolStripMenuItem1,
            this.contextUsersAlteringAwards});
			this.contextMenuStripUsers.Name = "contextMenuStripUsers";
			this.contextMenuStripUsers.Size = new System.Drawing.Size(166, 98);
			// 
			// contextUsersAddUser
			// 
			this.contextUsersAddUser.Name = "contextUsersAddUser";
			this.contextUsersAddUser.Size = new System.Drawing.Size(165, 22);
			this.contextUsersAddUser.Text = "Add &user...";
			// 
			// contextUsersEditUser
			// 
			this.contextUsersEditUser.Name = "contextUsersEditUser";
			this.contextUsersEditUser.Size = new System.Drawing.Size(165, 22);
			this.contextUsersEditUser.Text = "&Edit user...";
			// 
			// contextUsersDeleteUser
			// 
			this.contextUsersDeleteUser.Name = "contextUsersDeleteUser";
			this.contextUsersDeleteUser.Size = new System.Drawing.Size(165, 22);
			this.contextUsersDeleteUser.Text = "&Delete user";
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(162, 6);
			// 
			// contextUsersAlteringAwards
			// 
			this.contextUsersAlteringAwards.Name = "contextUsersAlteringAwards";
			this.contextUsersAlteringAwards.Size = new System.Drawing.Size(165, 22);
			this.contextUsersAlteringAwards.Text = "&Altering awards...";
			// 
			// tabPageAwards
			// 
			this.tabPageAwards.Controls.Add(this.panel2);
			this.tabPageAwards.Location = new System.Drawing.Point(4, 22);
			this.tabPageAwards.Name = "tabPageAwards";
			this.tabPageAwards.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageAwards.Size = new System.Drawing.Size(792, 400);
			this.tabPageAwards.TabIndex = 1;
			this.tabPageAwards.Text = "Awards";
			this.tabPageAwards.UseVisualStyleBackColor = true;
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.panel2.Controls.Add(this.awardsDataGridView);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(3, 3);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new System.Windows.Forms.Padding(5);
			this.panel2.Size = new System.Drawing.Size(786, 394);
			this.panel2.TabIndex = 4;
			// 
			// awardsDataGridView
			// 
			this.awardsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.awardsDataGridView.ContextMenuStrip = this.contextMenuStripAwards;
			this.awardsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.awardsDataGridView.Location = new System.Drawing.Point(5, 5);
			this.awardsDataGridView.Name = "awardsDataGridView";
			this.awardsDataGridView.Size = new System.Drawing.Size(776, 384);
			this.awardsDataGridView.TabIndex = 2;
			// 
			// contextMenuStripAwards
			// 
			this.contextMenuStripAwards.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextAwardsAddAward,
            this.contextAwardsEditAward,
            this.contextAwardsRemoveAward});
			this.contextMenuStripAwards.Name = "contextMenuStripRewards";
			this.contextMenuStripAwards.Size = new System.Drawing.Size(181, 92);
			// 
			// contextAwardsAddAward
			// 
			this.contextAwardsAddAward.Name = "contextAwardsAddAward";
			this.contextAwardsAddAward.Size = new System.Drawing.Size(180, 22);
			this.contextAwardsAddAward.Text = "&Add award...";
			// 
			// contextAwardsEditAward
			// 
			this.contextAwardsEditAward.Name = "contextAwardsEditAward";
			this.contextAwardsEditAward.Size = new System.Drawing.Size(180, 22);
			this.contextAwardsEditAward.Text = "&Edit award...";
			// 
			// contextAwardsRemoveAward
			// 
			this.contextAwardsRemoveAward.Name = "contextAwardsRemoveAward";
			this.contextAwardsRemoveAward.Size = new System.Drawing.Size(180, 22);
			this.contextAwardsRemoveAward.Text = "&Remove award";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "MainForm";
			this.Text = "MainForm";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.tabControl1.ResumeLayout(false);
			this.tabPageUsers.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.usersDataGridView)).EndInit();
			this.contextMenuStripUsers.ResumeLayout(false);
			this.tabPageAwards.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.awardsDataGridView)).EndInit();
			this.contextMenuStripAwards.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem menuExit;
		private System.Windows.Forms.ToolStripMenuItem menuAbout;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPageUsers;
		private System.Windows.Forms.TabPage tabPageAwards;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.DataGridView usersDataGridView;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.DataGridView awardsDataGridView;
		private System.Windows.Forms.ContextMenuStrip contextMenuStripUsers;
		private System.Windows.Forms.ToolStripMenuItem contextUsersAddUser;
		private System.Windows.Forms.ToolStripMenuItem contextUsersDeleteUser;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem contextUsersAlteringAwards;
		private System.Windows.Forms.ContextMenuStrip contextMenuStripAwards;
		private System.Windows.Forms.ToolStripMenuItem contextAwardsAddAward;
		private System.Windows.Forms.ToolStripMenuItem contextAwardsRemoveAward;
		private System.Windows.Forms.ToolStripMenuItem usersToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem menuUsersAddUser;
		private System.Windows.Forms.ToolStripMenuItem menuUsersDeleteUser;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
		private System.Windows.Forms.ToolStripMenuItem menuUsersAlteringAwards;
		private System.Windows.Forms.ToolStripMenuItem awardsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem menuAwardsAddAward;
		private System.Windows.Forms.ToolStripMenuItem menuAwardsRemoveAward;
		private System.Windows.Forms.ToolStripMenuItem menuUsersEditUser;
		private System.Windows.Forms.ToolStripMenuItem contextUsersEditUser;
		private System.Windows.Forms.ToolStripMenuItem menuAwardsEditAward;
		private System.Windows.Forms.ToolStripMenuItem contextAwardsEditAward;
	}
}