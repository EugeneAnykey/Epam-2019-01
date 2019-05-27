using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Alyabiev.Task14.Task1.Controls
{
	public partial class RewardForm : Form
	{
		const int maxTitleLength = 50;

		#region field
		Reward reward;
		public Reward Reward
		{
			get => reward;
			set => reward = value;
		}
		#endregion

		public RewardForm()
		{
			InitializeComponent();

			// init events:
			buttonOk.Click += ButtonOkClick;
			buttonCancel.Click += ButtonCancelClick;
			textBoxTitle.Validating += TitleValidating;
		}

		#region Validating event.
		private void TitleValidating(object sender, CancelEventArgs e)
		{
			string input = textBoxTitle.Text.Trim();

			if (string.IsNullOrEmpty(input))
			{
				errorProvider.SetError(textBoxTitle, "Wrong value!");
				e.Cancel = true;
			}
			else if (input.Length > maxTitleLength)
			{
				errorProvider.SetError(textBoxTitle, "Should be less or equal to 50 symbols!");
				e.Cancel = true;
			}
			else
			{
				errorProvider.SetError(textBoxTitle, string.Empty);
				e.Cancel = false;
			}
		}
		#endregion

		#region events handlers
		void ButtonOkClick(object sender, EventArgs e)
		{
			if (reward == null)
			{
				reward = new Reward(textBoxTitle.Text.Trim(), textBoxDescription.Text);
			}
			else
			{
				reward.Title = textBoxTitle.Text.Trim();
				reward.Description = textBoxDescription.Text;
			}

			Hide();
		}

		void ButtonCancelClick(object sender, EventArgs e)
		{
			reward = null;
			Hide();
		}
		#endregion

		internal void EditReward(Reward reward)
		{
			this.reward = reward;

			if (reward == null)
			{
				textBoxTitle.Text = string.Empty;
				textBoxDescription.Text = string.Empty;
			}
			else
			{
				textBoxTitle.Text = reward.Title;
				textBoxDescription.Text = reward.Description;
			}

			ShowDialog();
		}
	}
}
