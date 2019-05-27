using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Awarder.BLL;
using Awarder.Entities;
using euWinHelp = EugeneAnykey.WinFormHelpers;

namespace Alyabiev.Task17.Awarder.PL.WinForms
{
	public partial class MainForm : Form
	{
		#region const: text.
		const string CapDeleteUser = "Delete user...";
		const string MesDeleteUser = "You are about to delete a user. Proceed?";

		const string CapDeleteAward = "Delete award...";
		const string MesDeleteAward = "You are about to delete a award. Proceed?";
		#endregion



		#region field
		readonly UsersBL usersBL;
		readonly AwardsBL awardsBL;

		int userLastColumn = 0;
		int awardLastColumn = 0;

		AwardForm awardForm = new AwardForm();

		SortOrder[] userSorts;
		SortOrder[] awardSorts;

		AwardedUser selectedUser = null;
		Award selectedAward = null;

		ToolStripMenuItem[] userSelectedMenus;
		ToolStripMenuItem[] awardSelectedMenus;
		#endregion



		#region init
		public MainForm(bool database)
		{
			InitializeComponent();
			Text = Application.ProductName;

			Init();
			InitEvent();

			awardsBL = new AwardsBL(database);
			usersBL = new UsersBL(awardsBL, database);

			bool testData = false;      // for test purpose it could be used at first run, while DB is empty.
			if (!database || database && testData)
				TestDataInit();

			UsersSortByColumn(userLastColumn, true);
			AwardsSortByColumn(awardLastColumn, true);
		}

		void TestDataInit()
		{
			awardsBL.MakeTestData();
			usersBL.MakeTestData();
		}

		void Init()
		{
			tabControl1.TabPages[0].Text = "Users";
			tabControl1.TabPages[1].Text = "Awards";

			UsersDataGrid_Setup();
			AwardsDataGrid_Setup();

			userSelectedMenus = new ToolStripMenuItem[] {
				contextUsersEditUser,
				contextUsersDeleteUser,
				contextUsersAlteringAwards,
				menuUsersEditUser,
				menuUsersDeleteUser,
				menuUsersAlteringAwards
			};

			awardSelectedMenus = new ToolStripMenuItem[] {
				contextAwardsEditAward,
				contextAwardsRemoveAward,
				menuAwardsEditAward,
				menuAwardsRemoveAward
			};

			euWinHelp.Menus.MenuEnabler(userSelectedMenus, false);
			euWinHelp.Menus.MenuEnabler(awardSelectedMenus, false);
		}

		void InitEvent()
		{
			menuExit.Click += (_, __) => Close();
			menuAbout.Click += (_, __) => euWinHelp.Messages.ShowAbout("2019-05-13", "Eugene Software");

			usersDataGridView.ColumnHeaderMouseClick += UsersGrid_ColumnHeaderMouseClick;
			usersDataGridView.CellMouseClick += UsersGrid_CellMouseClick;

			awardsDataGridView.ColumnHeaderMouseClick += AwardsGrid_ColumnHeaderMouseClick;
			awardsDataGridView.CellMouseClick += AwardsGrid_CellMouseClick;

			// Awards menus:
			euWinHelp.Menus.MenuClickInit(new[] { contextAwardsAddAward, menuAwardsAddAward }, AddAward);
			euWinHelp.Menus.MenuClickInit(new[] { contextAwardsEditAward, menuAwardsEditAward }, EditAward);
			euWinHelp.Menus.MenuClickInit(new[] { contextAwardsRemoveAward, menuAwardsRemoveAward }, RemoveAward);

			// Users menus:
			euWinHelp.Menus.MenuClickInit(new[] { contextUsersAddUser, menuUsersAddUser }, AddUser);
			euWinHelp.Menus.MenuClickInit(new[] { contextUsersEditUser, menuUsersEditUser }, EditUser);
			euWinHelp.Menus.MenuClickInit(new[] { contextUsersDeleteUser, menuUsersDeleteUser }, DeleteUser);
			euWinHelp.Menus.MenuClickInit(new[] { contextUsersAlteringAwards, menuUsersAlteringAwards }, AlteringAwards);
		}
		#endregion



		#region GetSort
		SortOrder GetUserSort(int index)
		{
			return 0 <= index && index < userSorts.Length ? userSorts[index] : SortOrder.None;
		}

		SortOrder GetAwardSort(int index)
		{
			return 0 <= index && index < awardSorts.Length ? awardSorts[index] : SortOrder.None;
		}
		#endregion



		#region DataGridView setups
		static DataGridViewColumn GetColumn(string text, string property, bool visible = true)
		{
			return new DataGridViewTextBoxColumn
			{
				AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
				DataPropertyName = property,
				HeaderText = text,
				Name = property,
				Visible = visible
				//CellTemplate = new DataGridViewTextBoxCell();
			};
		}

		void UsersDataGrid_Setup()
		{
			var d = usersDataGridView;
			d.AutoGenerateColumns = false;
			d.Columns.Clear();
			d.Columns.AddRange(
				new[] {
					//GetColumn("id", "Id", false),
					GetColumn("Name", "Name"),
					GetColumn("Surname", "Surname"),
					GetColumn("Birthdate", "Birthdate"),
					//GetColumn("Age", "Age"),
					GetColumn("Age", "AgeString"),
					GetColumn("Awards", "Awards")
				}
			);

			userSorts = new SortOrder[d.ColumnCount];
			//DisplayUsers();
		}

		void AwardsDataGrid_Setup()
		{
			var d = awardsDataGridView;
			d.AutoGenerateColumns = false;
			d.Columns.Clear();
			d.Columns.AddRange(
				new[] {
					//GetColumn("id", "Id", false),
					GetColumn("Title", "Title"),
					GetColumn("Description", "Description"),
				}
			);

			awardSorts = new SortOrder[d.ColumnCount];
			//DisplayAwards();
		}
		#endregion



		#region confirmation dialogs.
		bool AskDeleteUserConfirmed() => euWinHelp.Messages.AskDeleteSomethingConfirmed(CapDeleteUser, MesDeleteUser);
		bool AskDeleteAwardConfirmed() => euWinHelp.Messages.AskDeleteSomethingConfirmed(CapDeleteAward, MesDeleteAward);
		#endregion



		#region DisplayAwards
		void DisplayAwards()
		{
			AwardsSortByColumn(awardLastColumn);
		}

		void DisplayAwards(IEnumerable<Award> awards)
		{
			awardsDataGridView.DataSource = null;
			awardsDataGridView.DataSource = awards;
		}
		#endregion



		#region DisplayUsers
		void DisplayUsers(IEnumerable<IUser> users)
		{
			usersDataGridView.DataSource = null;
			usersDataGridView.DataSource = users;
		}

		void DisplayUsers()
		{
			UsersSortByColumn(userLastColumn);
		}
		#endregion



		#region event handlers: award (Add, Edit, Remove).
		void AddAward(object sender, EventArgs e)
		{
			awardForm.EditAward(null);

			if (DialogResult.OK != awardForm.DialogResult)
				return;

			awardsBL.Add(awardForm.Award);
			DisplayAwards();
		}

		void EditAward(object sender, EventArgs e)
		{
			if (DialogResult.OK != awardForm.EditAward(selectedAward))
				return;

			awardsBL.Update(selectedAward);
			DisplayAwards();
		}

		void RemoveAward(object sender, EventArgs e)
		{
			if (AskDeleteAwardConfirmed())
			{
				usersBL.UnAssignAward(selectedAward);
				awardsBL.Remove(selectedAward);
				DisplayAwards();
				DisplayUsers();
			}
		}
		#endregion



		#region event handlers: user (Add, Edit, Remove, AlterAwards).
		void AddUser(object sender, EventArgs e)
		{
			var uf = new UserForm();
			if (uf.CreateUser() == DialogResult.OK)
			{
				usersBL.Add(uf.User);
				DisplayUsers();
			}
		}

		void EditUser(object sender, EventArgs e)
		{
			var uf = new UserForm();
			if (uf.EditUser(selectedUser) == DialogResult.OK)
			{
				usersBL.Update(uf.User);
				DisplayUsers();
			}
		}

		void DeleteUser(object sender, EventArgs e)
		{
			if (AskDeleteUserConfirmed())
			{
				usersBL.Remove(selectedUser);
				DisplayUsers();
			}
		}

		void AlteringAwards(object sender, EventArgs e)
		{
			var rf = new AwardsForm(awardsBL.GetList(), selectedUser);
			if (DialogResult.OK == rf.ShowDialog())
			{
				usersBL.AlterAwards(selectedUser);
				DisplayUsers();
			}
		}
		#endregion



		#region sort: Users.
		void UsersGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			UsersSortByColumn(userLastColumn = e.ColumnIndex, true);
		}

		void UsersSortByColumn(int column, bool next = false)
		{
			//const int IdColumn = -1;
			const int NameColumn = 0;
			const int SurnameColumn = 1;
			const int BirthColumn = 2;
			const int AgeColumn = 3;
			//const int AwardsColumn = 4;

			if (next)
				euWinHelp.SortOrders.Next(ref userSorts[column]);

			switch (column)
			{
				case NameColumn:
					UsersSort(column, u => u.Name);
					break;
				case SurnameColumn:
					UsersSort(column, u => u.Surname);
					break;
				case BirthColumn:
					Func<AwardedUser, DateTime> funcBirth = u => u.Birthdate;
					UsersSort(column, funcBirth);
					break;
				case AgeColumn:
					UsersSort(column, u => u.Age);
					break;
				default:
					break;
			}
		}

		void UsersSort<T>(int sortOrderIndex, Func<AwardedUser, T> func)
		{
			switch (userSorts[sortOrderIndex])
			{
				case SortOrder.Ascending:
					//DisplayUsers(usersBL.SortUsersAscBy(func));						// for AwardedUser
					DisplayUsers(usersBL.SortUsersAscBy(func).GetUsersViewModel());     // for [Awarded]UserViewModel
					break;
				case SortOrder.Descending:
					DisplayUsers(usersBL.SortUsersDescBy(func).GetUsersViewModel());
					break;
				default:
					DisplayUsers(usersBL.GetList().GetUsersViewModel());
					break;
			}

			ShowUsersSortDirection();
		}
		#endregion



		#region SortDirection
		void ShowUsersSortDirection()
		{
			usersDataGridView.Columns[userLastColumn].HeaderCell.SortGlyphDirection = userSorts[userLastColumn];
		}

		void ShowAwardsSortDirection()
		{
			awardsDataGridView.Columns[awardLastColumn].HeaderCell.SortGlyphDirection = awardSorts[awardLastColumn];
		}
		#endregion



		#region sort: Award.
		void AwardsGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			AwardsSortByColumn(awardLastColumn = e.ColumnIndex, true);
		}

		void AwardsSortByColumn(int column, bool next = false)
		{
			//const int IdColumn = -1; 
			const int TitleColumn = 0;
			const int DescColumn = 1;

			if (next)
				euWinHelp.SortOrders.Next(ref awardSorts[column]);

			switch (column)
			{
				case TitleColumn:
					AwardsSort(column, r => r.Title);
					break;
				case DescColumn:
					AwardsSort(column, r => r.Description);
					break;
				default:
					break;
			}
		}

		void AwardsSort<T>(int sortOrderIndex, Func<Award, T> func)
		{
			switch (awardSorts[sortOrderIndex])
			{
				case SortOrder.Ascending:
					DisplayAwards(awardsBL.SortAscBy(func));
					break;
				case SortOrder.Descending:
					DisplayAwards(awardsBL.SortDescBy(func));
					break;
				default:
					DisplayAwards(awardsBL.GetList());
					break;
			}

			ShowAwardsSortDirection();
		}
		#endregion



		#region DataGridView - CellMouseClick.
		void UsersGrid_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			euWinHelp.Menus.MenuEnabler(userSelectedMenus, e.RowIndex >= 0);

			if (e.RowIndex < 0)
				return;

			selectedUser = ((UserViewModel)usersDataGridView.SelectedCells[0].OwningRow.DataBoundItem).User;
			//selectedUser = (AwardedUser)usersDataGridView.SelectedCells[0].OwningRow.DataBoundItem;
		}

		void AwardsGrid_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			euWinHelp.Menus.MenuEnabler(awardSelectedMenus, e.RowIndex >= 0);

			if (e.RowIndex < 0)
				return;

			selectedAward = (Award)awardsDataGridView.SelectedCells[0].OwningRow.DataBoundItem;
		}
		#endregion
	}
}
