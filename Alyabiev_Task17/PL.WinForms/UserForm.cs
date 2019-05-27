using System;
using System.ComponentModel;
using System.Windows.Forms;

using euHelp = EugeneAnykey.Helpers;
using Awarder.Entities;

namespace Alyabiev.Task17.Awarder.PL.WinForms
{
	public partial class UserForm : Form
	{
		// field
		AwardedUser user;
		public AwardedUser User
		{
			get => user;
			set => user = value;
		}



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



		void SetCaption(bool newUser)
		{
			Text = newUser ? "Add new user" : "Edit current user";
			buttonOk.Text = newUser ? "Add" : "Comfirm";
			buttonCancel.Text = "Discard";
		}



		public DialogResult CreateUser()
		{
			user = null;

			textBoxName.Text = string.Empty;
			textBoxSurname.Text = string.Empty;
			birthdatePicker.Value = DateTime.UtcNow;

			SetCaption(true);

			return ShowDialog();
		}



		public DialogResult EditUser(AwardedUser user)
		{
			this.user = user ?? throw new ArgumentNullException();

			textBoxName.Text = user.Name;
			textBoxSurname.Text = user.Surname;
			birthdatePicker.Value = user.Birthdate;

			SetCaption(false);

			return ShowDialog();
		}



		#region Validating events.
		void NameValidating(object sender, CancelEventArgs e)
		{
			var control = textBoxName;
			string input = control.Text.Trim();

			if (string.IsNullOrEmpty(input))
			{
				errorProvider.SetError(control, "Should not be empty!");
				e.Cancel = true;
			}
			else if (!euHelp.Names.IsNameGood(input))
			{
				errorProvider.SetError(control, "Not valid name");
				e.Cancel = true;
			}
			else
			{
				errorProvider.SetError(control, string.Empty);
				e.Cancel = false;
			}
		}

		void SurnameValidating(object sender, CancelEventArgs e)
		{
			var control = textBoxName;
			string input = control.Text.Trim();

			if (string.IsNullOrEmpty(input))
			{
				errorProvider.SetError(control, "Should not be empty!");
				e.Cancel = true;
			}
			else if (!euHelp.Names.IsNameGood(input))
			{
				errorProvider.SetError(control, "Not valid surname");
				e.Cancel = true;
			}
			else
			{
				errorProvider.SetError(control, string.Empty);
				e.Cancel = false;
			}
		}

		void BirthdateValidating(object sender, CancelEventArgs e)
		{
			var control = birthdatePicker;
			var input = control.Value;

			if (euHelp.Dates.YearsPassed(input) > 150)
			{
				errorProvider.SetError(control, "Should not be older 150 years!");
				e.Cancel = true;
			}
			else
			{
				errorProvider.SetError(control, string.Empty);
				e.Cancel = false;
			}
		}
		#endregion



		#region Ok, cancel events handlers
		void ButtonOkClick(object sender, EventArgs e)
		{
			if (user == null)
			{
				user = new AwardedUser(textBoxName.Text, textBoxSurname.Text, birthdatePicker.Value);
			}
			else
			{
				user.Name = textBoxName.Text;
				user.Surname = textBoxSurname.Text;
				user.Birthdate = birthdatePicker.Value;
			}

			//Hide();
		}

		void ButtonCancelClick(object sender, EventArgs e)
		{
			user = null;
			//Hide();
		}
		#endregion
	}
}
