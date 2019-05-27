using System;
using System.ComponentModel;
using System.Windows.Forms;

using Awarder.Entities;

namespace Alyabiev.Task17.Awarder.PL.WinForms
{
	public partial class AwardForm : Form
	{
		const int maxTitleLength = 50;

		// field
		Award award;
		public Award Award
		{
			get => award;
			set => award = value;
		}



		public AwardForm()
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
			const string ErrMesWrongValue = "Wrong value!";
			const string ErrMesLess50Syms = "Should be less or equal to 50 symbols!";

			string input = textBoxTitle.Text.Trim();

			if (string.IsNullOrEmpty(input))
			{
				errorProvider.SetError(textBoxTitle, ErrMesWrongValue);
				e.Cancel = true;
			}
			else if (input.Length > maxTitleLength)
			{
				errorProvider.SetError(textBoxTitle, ErrMesLess50Syms);
				e.Cancel = true;
			}
			else
			{
				errorProvider.SetError(textBoxTitle, string.Empty);
				e.Cancel = false;
			}
		}
		#endregion



		#region button events handlers
		void ButtonOkClick(object sender, EventArgs e)
		{
			if (award == null)
			{
				award = new Award(textBoxTitle.Text.Trim(), textBoxDescription.Text);
			}
			else
			{
				award.Title = textBoxTitle.Text.Trim();
				award.Description = textBoxDescription.Text;
			}

			Hide();
		}

		void ButtonCancelClick(object sender, EventArgs e)
		{
			Close();
			errorProvider.Clear();
			award = null;
			Hide();
		}
		#endregion



		public DialogResult EditAward(Award award)
		{
			this.award = award;

			if (award == null)
			{
				textBoxTitle.Text = string.Empty;
				textBoxDescription.Text = string.Empty;
			}
			else
			{
				textBoxTitle.Text = award.Title;
				textBoxDescription.Text = award.Description;
			}

			SetCaptions(award == null);

			return ShowDialog();
		}



		void SetCaptions(bool newAward)
		{
			Text = newAward ? "Add new award" : "Edit current award";
			buttonOk.Text = "Ok";
		}
	}
}
