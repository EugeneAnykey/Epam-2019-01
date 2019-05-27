namespace Alyabiev.Task14.Task1
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
			this.menuUsersAlteringRewards = new System.Windows.Forms.ToolStripMenuItem();
			this.rewardsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuRewardsAddReward = new System.Windows.Forms.ToolStripMenuItem();
			this.menuRewardsEditReward = new System.Windows.Forms.ToolStripMenuItem();
			this.menuRewardsRemoveReward = new System.Windows.Forms.ToolStripMenuItem();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPageUsers = new System.Windows.Forms.TabPage();
			this.panel1 = new System.Windows.Forms.Panel();
			this.dataGridViewUsers = new System.Windows.Forms.DataGridView();
			this.contextMenuStripUsers = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.contextUsersAddUser = new System.Windows.Forms.ToolStripMenuItem();
			this.contextUsersEditUser = new System.Windows.Forms.ToolStripMenuItem();
			this.contextUsersDeleteUser = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.contextUsersAlteringRewards = new System.Windows.Forms.ToolStripMenuItem();
			this.tabPageRewards = new System.Windows.Forms.TabPage();
			this.panel2 = new System.Windows.Forms.Panel();
			this.dataGridViewRewards = new System.Windows.Forms.DataGridView();
			this.contextMenuStripRewards = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.contextRewardsAddReward = new System.Windows.Forms.ToolStripMenuItem();
			this.contextRewardsEditReward = new System.Windows.Forms.ToolStripMenuItem();
			this.contextRewardsRemoveReward = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPageUsers.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsers)).BeginInit();
			this.contextMenuStripUsers.SuspendLayout();
			this.tabPageRewards.SuspendLayout();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewRewards)).BeginInit();
			this.contextMenuStripRewards.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.menuAbout,
            this.usersToolStripMenuItem,
            this.rewardsToolStripMenuItem});
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
			this.menuExit.Size = new System.Drawing.Size(92, 22);
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
            this.menuUsersAlteringRewards});
			this.usersToolStripMenuItem.Name = "usersToolStripMenuItem";
			this.usersToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
			this.usersToolStripMenuItem.Text = "Users";
			// 
			// menuUsersAddUser
			// 
			this.menuUsersAddUser.Name = "menuUsersAddUser";
			this.menuUsersAddUser.Size = new System.Drawing.Size(169, 22);
			this.menuUsersAddUser.Text = "Add &user...";
			// 
			// menuUsersEditUser
			// 
			this.menuUsersEditUser.Name = "menuUsersEditUser";
			this.menuUsersEditUser.Size = new System.Drawing.Size(169, 22);
			this.menuUsersEditUser.Text = "&Edit user...";
			// 
			// menuUsersDeleteUser
			// 
			this.menuUsersDeleteUser.Name = "menuUsersDeleteUser";
			this.menuUsersDeleteUser.Size = new System.Drawing.Size(169, 22);
			this.menuUsersDeleteUser.Text = "&Delete user";
			// 
			// toolStripMenuItem6
			// 
			this.toolStripMenuItem6.Name = "toolStripMenuItem6";
			this.toolStripMenuItem6.Size = new System.Drawing.Size(166, 6);
			// 
			// menuUsersAlteringRewards
			// 
			this.menuUsersAlteringRewards.Name = "menuUsersAlteringRewards";
			this.menuUsersAlteringRewards.Size = new System.Drawing.Size(169, 22);
			this.menuUsersAlteringRewards.Text = "&Altering rewards...";
			// 
			// rewardsToolStripMenuItem
			// 
			this.rewardsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuRewardsAddReward,
            this.menuRewardsEditReward,
            this.menuRewardsRemoveReward});
			this.rewardsToolStripMenuItem.Name = "rewardsToolStripMenuItem";
			this.rewardsToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
			this.rewardsToolStripMenuItem.Text = "Rewards";
			// 
			// menuRewardsAddReward
			// 
			this.menuRewardsAddReward.Name = "menuRewardsAddReward";
			this.menuRewardsAddReward.Size = new System.Drawing.Size(156, 22);
			this.menuRewardsAddReward.Text = "&Add reward...";
			// 
			// menuRewardsEditReward
			// 
			this.menuRewardsEditReward.Name = "menuRewardsEditReward";
			this.menuRewardsEditReward.Size = new System.Drawing.Size(156, 22);
			this.menuRewardsEditReward.Text = "&Edit reward...";
			// 
			// menuRewardsRemoveReward
			// 
			this.menuRewardsRemoveReward.Name = "menuRewardsRemoveReward";
			this.menuRewardsRemoveReward.Size = new System.Drawing.Size(156, 22);
			this.menuRewardsRemoveReward.Text = "&Remove reward";
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPageUsers);
			this.tabControl1.Controls.Add(this.tabPageRewards);
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
			this.panel1.Controls.Add(this.dataGridViewUsers);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(3, 3);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(5);
			this.panel1.Size = new System.Drawing.Size(786, 394);
			this.panel1.TabIndex = 3;
			// 
			// dataGridViewUsers
			// 
			this.dataGridViewUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewUsers.ContextMenuStrip = this.contextMenuStripUsers;
			this.dataGridViewUsers.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridViewUsers.Location = new System.Drawing.Point(5, 5);
			this.dataGridViewUsers.Name = "dataGridViewUsers";
			this.dataGridViewUsers.Size = new System.Drawing.Size(776, 384);
			this.dataGridViewUsers.TabIndex = 2;
			// 
			// contextMenuStripUsers
			// 
			this.contextMenuStripUsers.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextUsersAddUser,
            this.contextUsersEditUser,
            this.contextUsersDeleteUser,
            this.toolStripMenuItem1,
            this.contextUsersAlteringRewards});
			this.contextMenuStripUsers.Name = "contextMenuStripUsers";
			this.contextMenuStripUsers.Size = new System.Drawing.Size(170, 98);
			// 
			// contextUsersAddUser
			// 
			this.contextUsersAddUser.Name = "contextUsersAddUser";
			this.contextUsersAddUser.Size = new System.Drawing.Size(169, 22);
			this.contextUsersAddUser.Text = "Add &user...";
			// 
			// contextUsersEditUser
			// 
			this.contextUsersEditUser.Name = "contextUsersEditUser";
			this.contextUsersEditUser.Size = new System.Drawing.Size(169, 22);
			this.contextUsersEditUser.Text = "&Edit user...";
			// 
			// contextUsersDeleteUser
			// 
			this.contextUsersDeleteUser.Name = "contextUsersDeleteUser";
			this.contextUsersDeleteUser.Size = new System.Drawing.Size(169, 22);
			this.contextUsersDeleteUser.Text = "&Delete user";
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(166, 6);
			// 
			// contextUsersAlteringRewards
			// 
			this.contextUsersAlteringRewards.Name = "contextUsersAlteringRewards";
			this.contextUsersAlteringRewards.Size = new System.Drawing.Size(169, 22);
			this.contextUsersAlteringRewards.Text = "&Altering rewards...";
			// 
			// tabPageRewards
			// 
			this.tabPageRewards.Controls.Add(this.panel2);
			this.tabPageRewards.Location = new System.Drawing.Point(4, 22);
			this.tabPageRewards.Name = "tabPageRewards";
			this.tabPageRewards.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageRewards.Size = new System.Drawing.Size(792, 400);
			this.tabPageRewards.TabIndex = 1;
			this.tabPageRewards.Text = "Rewards";
			this.tabPageRewards.UseVisualStyleBackColor = true;
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.panel2.Controls.Add(this.dataGridViewRewards);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(3, 3);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new System.Windows.Forms.Padding(5);
			this.panel2.Size = new System.Drawing.Size(786, 394);
			this.panel2.TabIndex = 4;
			// 
			// dataGridViewRewards
			// 
			this.dataGridViewRewards.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewRewards.ContextMenuStrip = this.contextMenuStripRewards;
			this.dataGridViewRewards.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridViewRewards.Location = new System.Drawing.Point(5, 5);
			this.dataGridViewRewards.Name = "dataGridViewRewards";
			this.dataGridViewRewards.Size = new System.Drawing.Size(776, 384);
			this.dataGridViewRewards.TabIndex = 2;
			// 
			// contextMenuStripRewards
			// 
			this.contextMenuStripRewards.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextRewardsAddReward,
            this.contextRewardsEditReward,
            this.contextRewardsRemoveReward});
			this.contextMenuStripRewards.Name = "contextMenuStripRewards";
			this.contextMenuStripRewards.Size = new System.Drawing.Size(157, 70);
			// 
			// contextRewardsAddReward
			// 
			this.contextRewardsAddReward.Name = "contextRewardsAddReward";
			this.contextRewardsAddReward.Size = new System.Drawing.Size(156, 22);
			this.contextRewardsAddReward.Text = "&Add reward...";
			// 
			// contextRewardsEditReward
			// 
			this.contextRewardsEditReward.Name = "contextRewardsEditReward";
			this.contextRewardsEditReward.Size = new System.Drawing.Size(156, 22);
			this.contextRewardsEditReward.Text = "&Edit reward...";
			// 
			// contextRewardsRemoveReward
			// 
			this.contextRewardsRemoveReward.Name = "contextRewardsRemoveReward";
			this.contextRewardsRemoveReward.Size = new System.Drawing.Size(156, 22);
			this.contextRewardsRemoveReward.Text = "&Remove reward";
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
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsers)).EndInit();
			this.contextMenuStripUsers.ResumeLayout(false);
			this.tabPageRewards.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewRewards)).EndInit();
			this.contextMenuStripRewards.ResumeLayout(false);
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
		private System.Windows.Forms.TabPage tabPageRewards;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.DataGridView dataGridViewUsers;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.DataGridView dataGridViewRewards;
		private System.Windows.Forms.ContextMenuStrip contextMenuStripUsers;
		private System.Windows.Forms.ToolStripMenuItem contextUsersAddUser;
		private System.Windows.Forms.ToolStripMenuItem contextUsersDeleteUser;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem contextUsersAlteringRewards;
		private System.Windows.Forms.ContextMenuStrip contextMenuStripRewards;
		private System.Windows.Forms.ToolStripMenuItem contextRewardsAddReward;
		private System.Windows.Forms.ToolStripMenuItem contextRewardsRemoveReward;
		private System.Windows.Forms.ToolStripMenuItem usersToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem menuUsersAddUser;
		private System.Windows.Forms.ToolStripMenuItem menuUsersDeleteUser;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
		private System.Windows.Forms.ToolStripMenuItem menuUsersAlteringRewards;
		private System.Windows.Forms.ToolStripMenuItem rewardsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem menuRewardsAddReward;
		private System.Windows.Forms.ToolStripMenuItem menuRewardsRemoveReward;
		private System.Windows.Forms.ToolStripMenuItem menuUsersEditUser;
		private System.Windows.Forms.ToolStripMenuItem contextUsersEditUser;
		private System.Windows.Forms.ToolStripMenuItem menuRewardsEditReward;
		private System.Windows.Forms.ToolStripMenuItem contextRewardsEditReward;
	}
}