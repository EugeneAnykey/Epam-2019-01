using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

using Alyabiev.Task14.Task1.Controls;

namespace Alyabiev.Task14.Task1
{
	public partial class MainForm : Form
	{
		#region inner Helper: ShowAbout.
		void ShowAbout(object sender, EventArgs e)
		{
			var date = "2019-04-08";
			MessageBox.Show(
				$"{Application.ProductName}\n version: {Application.ProductVersion} from {date}\n Copyright (c) 2019 Eugene Software.\nAll Rights Reserved.",
				"About " + Application.ProductName,
				MessageBoxButtons.OK,
				MessageBoxIcon.Information
			);
		}
		#endregion

		#region const: text.
		const string CapDeleteUser = "Delete user...";
		const string MesDeleteUser = "You are about to delete a user. Proceed?";

		const string CapDeleteReward = "Delete reward...";
		const string MesDeleteReward = "You are about to delete a reward. Proceed?";
		#endregion

		#region field
		BindingList<RewardedUser> users = new BindingList<RewardedUser>();
		BindingList<Reward> rewards = new BindingList<Reward>();

		UserForm userForm = new UserForm();
		RewardForm rewardForm = new RewardForm();
		RewardsForm rewardsForm;

		SortOrder[] userSorts;
		SortOrder[] rewardSorts;
		
		RewardedUser selectedUser = null;
		Reward selectedReward = null;

		int selectedRewardIndex;
		int selectedUserIndex;

		ToolStripMenuItem[] userSelectedMenus;
		ToolStripMenuItem[] rewardSelectedMenus;
		#endregion

		#region init
		public MainForm()
		{
			InitializeComponent();

			Text = Application.ProductName;

			Init();
			InitEvent();

			TestData();
		}

		void Init()
		{
			tabControl1.TabPages[0].Text = "Users";
			tabControl1.TabPages[1].Text = "Rewards";

			DataGridUsers_Setup(dataGridViewUsers);
			DataGridRewards_Setup(dataGridViewRewards);

			rewardsForm = new RewardsForm(rewards);

			userSelectedMenus = new ToolStripMenuItem[] {
				contextUsersEditUser,
				contextUsersDeleteUser,
				contextUsersAlteringRewards,
				menuUsersEditUser,
				menuUsersDeleteUser,
				menuUsersAlteringRewards
			};

			rewardSelectedMenus = new ToolStripMenuItem[] {
				contextRewardsEditReward,
				contextRewardsRemoveReward,
				menuRewardsEditReward,
				menuRewardsRemoveReward
			};

			WinFormHelpers.MenuEnabler(userSelectedMenus, false);
			WinFormHelpers.MenuEnabler(rewardSelectedMenus, false);
		}

		void InitEvent()
		{
			menuExit.Click += (_, __) => Close();
			menuAbout.Click += ShowAbout;

			dataGridViewUsers.ColumnHeaderMouseClick += UserGrid_ColumnHeaderMouseClick;
			dataGridViewUsers.CellMouseClick += UsersGrid_CellMouseClick;
			
			dataGridViewRewards.ColumnHeaderMouseClick += RewardGrid_ColumnHeaderMouseClick;
			dataGridViewRewards.CellMouseClick += RewardsGrid_CellMouseClick;

			// Rewards menus:
			WinFormHelpers.MenuClickInit(new[] { contextRewardsAddReward, menuRewardsAddReward }, AddReward);
			WinFormHelpers.MenuClickInit(new[] { contextRewardsEditReward, menuRewardsEditReward }, EditReward);
			WinFormHelpers.MenuClickInit(new[] { contextRewardsRemoveReward, menuRewardsRemoveReward }, RemoveReward);

			// Users menus:
			WinFormHelpers.MenuClickInit(new[] { contextUsersAddUser, menuUsersAddUser }, AddUser);
			WinFormHelpers.MenuClickInit(new[] { contextUsersEditUser, menuUsersEditUser }, EditUser);
			WinFormHelpers.MenuClickInit(new[] { contextUsersDeleteUser, menuUsersDeleteUser }, DeleteUser);
			WinFormHelpers.MenuClickInit(new[] { contextUsersAlteringRewards, menuUsersAlteringRewards }, AlteringRewards);
		}
		#endregion

		#region test data
		void TestData()
		{
			var testRewards = new Reward[] {
				new Reward("Nobel prize (phisics)", "присуждается один раз в год Шведской королевской академией наук."),
				new Reward("Nobel prize (chemistry)", "присуждается один раз в год Шведской королевской академией наук."),
				new Reward("Abel Prizen (math)", "Основана правительством Норвегии в 2002 году. Начиная с 2003 года, ежегодно присуждается выдающимся математикам современности."),
				new Reward("Praemium Imperiale", "Императорская премия. Японская награда деятелям искусства «за их достижения, международное влияние, которое они оказали на своё искусство, духовное обогащение всего мирового сообщества», учреждённая в 1989 году."),
				new Reward("Grammy", "Грэмми. Музыкальная премия Американской академии звукозаписи, существует с 1958 года"),
			};

			foreach (var item in testRewards)
				rewards.Add(item);

			var testUsers = new[] {
				new RewardedUser("Ivan", "Vasiliev", new DateTime(2001, 02, 03)),
				new RewardedUser("Boris", "Preobrazhenskiy", new DateTime(1982, 07, 21)),
				new RewardedUser("Mamoru", "Nakuoku", new DateTime(1959, 10, 17)),
				new RewardedUser("Sergey", "Skuratov", new DateTime(1974, 12, 25)),
				new RewardedUser("Stephen", "Hawk", new DateTime(1947, 12, 09)),
				new RewardedUser("Alexey", "Malyutin", new DateTime(1993, 09, 03)),
				new RewardedUser("Malek", "Miestovich", new DateTime(1999, 06, 05)),
			};

			foreach (var item in testUsers)
				users.Add(item);
		}
		#endregion

		#region DataGridView setups
		static DataGridViewColumn GetColumn(string text, string property, bool visible = true)
		{
			var res = new DataGridViewTextBoxColumn();

			res.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
			res.DataPropertyName = property;
			res.HeaderText = text;
			res.Name = property;
			//res.CellTemplate = new DataGridViewTextBoxCell();
			res.Visible = visible;

			return res;
		}

		void DataGridUsers_Setup(DataGridView d)
		{
			d.DataSource = users;
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
					GetColumn("Rewards", "Rewards")
				}
			);

			userSorts = new SortOrder[dataGridViewUsers.ColumnCount];
		}

		void DataGridRewards_Setup(DataGridView d)
		{
			d.DataSource = rewards;
			d.AutoGenerateColumns = false;
			d.Columns.Clear();
			d.Columns.AddRange(
				new[] {
					//GetColumn("id", "Id", false),
					GetColumn("Title", "Title"),
					GetColumn("Description", "Description"),
				}
			);

			rewardSorts = new SortOrder[dataGridViewRewards.ColumnCount];
		}
		#endregion

		#region confirmation dialogs.
		bool AskDeleteUserConfirmed() => WinFormHelpers.AskDeleteSomethingConfirmed(CapDeleteUser, MesDeleteUser);
		bool AskDeleteRewardConfirmed() => WinFormHelpers.AskDeleteSomethingConfirmed(CapDeleteReward, MesDeleteReward);
		#endregion

		#region event handlers: reward
		void AddReward(object sender, EventArgs e)
		{
			rewardForm.EditReward(null);
			if (DialogResult.OK == rewardForm.DialogResult)
			{
				rewards.Add(rewardForm.Reward);
			}
		}

		void EditReward(object sender, EventArgs e)
		{
			rewardForm.EditReward(selectedReward);
		}

		void RemoveReward(object sender, EventArgs e)
		{
			if (AskDeleteRewardConfirmed())
			{
				rewards.Remove(selectedReward);
				foreach (var u in users)
				{
					u.RemoveReward(selectedReward);
				}
			}
		}
		#endregion

		#region event handlers: user
		void AddUser(object sender, EventArgs e)
		{
			userForm.EditUser(null);
			if (userForm.DialogResult == DialogResult.OK)
			{
				users.Add(userForm.User);
			}
		}

		void EditUser(object sender, EventArgs e)
		{
			userForm.EditUser(selectedUser);
		}

		void DeleteUser(object sender, EventArgs e)
		{
			if (AskDeleteUserConfirmed())
				users.Remove(selectedUser);
		}

		void AlteringRewards(object sender, EventArgs e)
		{
			if (DialogResult.OK == rewardsForm.ChangeRewards(selectedUser))
				dataGridViewUsers.UpdateCellValue(0, selectedUserIndex);
		}
		#endregion

		#region sort: Rewards, Users.
		void RewardGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			//const int IdColumn = -1; 
			const int TitleColumn = 0;
			const int DescColumn = 1;

			switch (e.ColumnIndex)
			{
				//case IdColumn:
				//	RewardsSort(u => u.Id, SortOrderHelper.Next(ref rewardSorts[e.ColumnIndex]));
				//	break;
				case TitleColumn:
					RewardsSort(r => r.Title, SortOrderHelper.Next(ref rewardSorts[TitleColumn]));
					break;
				case DescColumn:
					RewardsSort(r => r.Description, SortOrderHelper.Next(ref rewardSorts[DescColumn]));
					break;
				default:
					break;
			}
		}

		void UserGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			//const int IdColumn = -1; 
			const int NameColumn = 0;
			const int SurnameColumn = 1;
			const int BirthColumn = 2;
			const int AgeColumn = 3;
			//const int RewardsColumn = 4;
			
			switch (e.ColumnIndex)
			{
				//case IdColumn:
				//	UsersSort(u => u.Id, SortOrderHelper.Next(ref userSorts[IdColumn]));
				//	break;
				case NameColumn:
					UsersSort(u => u.Name, SortOrderHelper.Next(ref userSorts[NameColumn]));
					break;
				case SurnameColumn:
					UsersSort(u => u.Surname, SortOrderHelper.Next(ref userSorts[SurnameColumn]));
					break;
				case BirthColumn:
					Func<RewardedUser, DateTime> funcBirth = u => u.Birthdate;      // left here just for example!
					UsersSort(funcBirth, SortOrderHelper.Next(ref userSorts[e.ColumnIndex]));
					break;
				case AgeColumn:
					UsersSort(u => u.Age, SortOrderHelper.Next(ref userSorts[e.ColumnIndex]));
					break;
				//case RewardsColumn:
				//	UsersSort(u => u.RewardsInString, SortOrderHelper.Next(ref userSorts[e.ColumnIndex]));
				//	break;
				default:
					break;
			}
		}

		void UsersSort<T>(Func<RewardedUser, T> func, SortOrder order)
		{
			switch (order)
			{
				case SortOrder.Asc:
					users = new BindingList<RewardedUser>(users.OrderBy(func).ToList());
					dataGridViewUsers.DataSource = users;
					break;
				case SortOrder.Desc:
					users = new BindingList<RewardedUser>(users.OrderByDescending(func).ToList());
					dataGridViewUsers.DataSource = users;
					break;
				default:
					break;
			}
		}

		void RewardsSort<T>(Func<Reward, T> func, SortOrder order)
		{
			switch (order)
			{
				case SortOrder.Asc:
					rewards = new BindingList<Reward>(rewards.OrderBy(func).ToList());
					dataGridViewRewards.DataSource = rewards;
					break;
				case SortOrder.Desc:
					rewards = new BindingList<Reward>(rewards.OrderByDescending(func).ToList());
					dataGridViewRewards.DataSource = rewards;
					break;
				default:
					break;
			}
		}
		#endregion

		#region DataGridView - CellMouseClick.
		void UsersGrid_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			WinFormHelpers.MenuEnabler(userSelectedMenus, e.RowIndex >= 0);

			if (e.RowIndex < 0)
				return;

			selectedUserIndex = e.RowIndex;
			selectedUser = users[e.RowIndex];
		}

		void RewardsGrid_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			WinFormHelpers.MenuEnabler(rewardSelectedMenus, e.RowIndex >= 0);

			if (e.RowIndex < 0)
				return;

			selectedRewardIndex = e.RowIndex;
			selectedReward = rewards[e.RowIndex];
		}
		#endregion
	}
}
