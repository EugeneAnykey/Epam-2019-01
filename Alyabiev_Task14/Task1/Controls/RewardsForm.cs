using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Alyabiev.Task14.Task1.Controls
{
	public partial class RewardsForm : Form
	{
		BindingList<Reward> rewards = new BindingList<Reward>();

		RewardedUser user;

		public RewardsForm(BindingList<Reward> rewards)
		{
			InitializeComponent();

			this.rewards = rewards ?? throw new ArgumentNullException();
			listBoxRewards.DataSource = rewards;

			// events:
			buttonOk.Click += ButtonOkClick;
			buttonCancel.Click += ButtonCancelClick;
		}

		internal DialogResult ChangeRewards(RewardedUser user)
		{
			listBoxRewards.SelectedItems.Clear();

			this.user = user ?? throw new ArgumentNullException();

			Text = $"Altering rewards for {user.IF}";

			SelectRewards();

			return ShowDialog();
		}

		void SelectRewards()
		{
			foreach (var item in user.Rewards)
			{
				listBoxRewards.SelectedItems.Add(item);
			}
		}

		#region events handlers
		void ButtonOkClick(object sender, EventArgs e)
		{
			//Reward[] rews = new Reward[listBoxRewards.SelectedItems.Count];
			//listBoxRewards.SelectedItems.CopyTo(rews, 0);

			user.AlterRewards(listBoxRewards.SelectedItems);
		}

		void ButtonCancelClick(object sender, EventArgs e) { }
		#endregion
	}
}
