using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Alyabiev.Task14.Task1.Controls
{
	public partial class UserForm : Form
	{
		#region field
		RewardedUser user;
		public RewardedUser User
		{
			get => user;
			set => user = value;
		}
		#endregion

		public UserForm()
		{
			InitializeComponent();

			// init events:
			buttonOk.Click += ButtonOkClick;
			buttonCancel.Click += ButtonCancelClick;

			textBoxName.Validating += NameValidating;
			textBoxSurname.Validating += SurnameValidating;
			birthdatePicker.Validating += BirthdateValidating;
		}

		internal void EditUser(RewardedUser user)
		{
			this.user = user;

			if (user == null)
			{
				textBoxName.Text = string.Empty;
				textBoxSurname.Text = string.Empty;
				birthdatePicker.Value = DateTime.UtcNow;
			}
			else
			{
				textBoxName.Text = user.Name;
				textBoxSurname.Text = user.Surname;
				birthdatePicker.Value = user.Birthdate;
			}

			ShowDialog();
		}

		#region Validating event.
		void NameValidating(object sender, CancelEventArgs e)
		{
			TextBox tb = textBoxName;
			string input = tb.Text.Trim();

			if (string.IsNullOrEmpty(input))
			{
				errorProvider.SetError(tb, "Should not be empty!");
				e.Cancel = true;
			}
			else if (!Helpers.IsNameGood(input))
			{
				errorProvider.SetError(tb, "Not valid name");
				e.Cancel = true;
			}
			else
			{
				errorProvider.SetError(tb, string.Empty);
				e.Cancel = false;
			}
		}

		void SurnameValidating(object sender, CancelEventArgs e)
		{
			TextBox tb = textBoxName;
			string input = tb.Text.Trim();

			if (string.IsNullOrEmpty(input))
			{
				errorProvider.SetError(tb, "Should not be empty!");
				e.Cancel = true;
			}
			else if (!Helpers.IsNameGood(input))
			{
				errorProvider.SetError(tb, "Not valid surname");
				e.Cancel = true;
			}
			else
			{
				errorProvider.SetError(tb, string.Empty);
				e.Cancel = false;
			}
		}

		void BirthdateValidating(object sender, CancelEventArgs e)
		{
			DateTimePicker dtp = birthdatePicker;
			var input = dtp.Value;

			if (Helpers.YearsPassed(input) > 150)
			{
				errorProvider.SetError(dtp, "Should not be empty more than 150 years!");
				e.Cancel = true;
			}
			else
			{
				errorProvider.SetError(dtp, string.Empty);
				e.Cancel = false;
			}
		}
		#endregion

		#region events handlers
		void ButtonOkClick(object sender, EventArgs e)
		{
			if (user == null)
			{
				user = new RewardedUser(textBoxName.Text, textBoxSurname.Text, birthdatePicker.Value);
			}
			else
			{
				user.Name = textBoxName.Text;
				user.Surname = textBoxSurname.Text;
				user.Birthdate = birthdatePicker.Value;
			}

			Hide();
		}

		void ButtonCancelClick(object sender, EventArgs e)
		{
			user = null;
			Hide();
		}
		#endregion
	}
}
