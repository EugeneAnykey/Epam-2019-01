using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Awarder.Entities;

namespace Alyabiev.Task15.Awarder.PL.WinForms
{
	public partial class AwardsForm : Form
	{
		AwardedUser user;

		public AwardsForm(IEnumerable<Award> awards, AwardedUser user)
		{
			InitializeComponent();

			if (awards == null)
				throw new ArgumentNullException();

			this.user = user ?? throw new ArgumentNullException();

			foreach (var item in awards)
			{
				checkedListBox.Items.Add(item, user.Awards.Contains(item));
			}

			Init();
		}

		void Init()
		{
			// events:
			buttonOk.Click += ButtonOkClick;
			buttonCancel.Click += ButtonCancelClick;
		}

		Award[] GetCheckedAwards()
		{
			var res = new Award[checkedListBox.CheckedItems.Count];
			int i = 0;
			foreach (Award item in checkedListBox.CheckedItems)
			{
				res[i++] = item;
			}
			return res;
		}

		#region events handlers
		void ButtonOkClick(object sender, EventArgs e)
		{
			user.AlterAwards(GetCheckedAwards());
		}

		void ButtonCancelClick(object sender, EventArgs e) { }
		#endregion
	}
}
