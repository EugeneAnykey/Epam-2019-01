using System;
using System.Windows.Forms;

namespace EugeneAnykey.WinFormHelpers
{
	public static class Messages
	{
		public static bool AskDeleteSomethingConfirmed(string caption, string message)
		{
			return DialogResult.Yes ==
				MessageBox.Show(
					message,
					caption,
					MessageBoxButtons.YesNo,
					MessageBoxIcon.Warning,
					MessageBoxDefaultButton.Button2
				);
		}



		public static void ShowAbout(string date, string copyright)
		{
			MessageBox.Show(
				$"{Application.ProductName}\n version: {Application.ProductVersion} from {date}\n Copyright (c) 2019 {copyright}.\nAll Rights Reserved.",
				"About " + Application.ProductName,
				MessageBoxButtons.OK,
				MessageBoxIcon.Information
			);
		}
	}



	public static class Menus
	{
		public static void MenuEnabler(ToolStripMenuItem[] menus, bool enabled)
		{
			if (menus == null)
				return;

			foreach (var item in menus)
			{
				item.Enabled = enabled;
			}
		}

		public static void MenuClickInit(ToolStripItem[] items, EventHandler handler)
		{
			if (items == null)
				return;

			foreach (var item in items)
			{
				item.Click += handler;
			}
		}
	}



	public static class SortOrders
	{
		public static SortOrder Next(SortOrder current)
		{
			return
				SortOrder.None == current ? SortOrder.Ascending :
				SortOrder.Ascending == current ? SortOrder.Descending :
				SortOrder.None;
		}

		public static SortOrder Next(ref SortOrder current) => current = Next(current);
	}
}
