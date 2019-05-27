using System;
using System.Windows.Forms;

namespace Alyabiev.Task14.Task1
{
	public static class WinFormHelpers
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

		public static void MenuEnabler(ToolStripMenuItem[] menus, bool enabled)
		{
			foreach (var item in menus)
			{
				item.Enabled = enabled;
			}
		}

		public static void MenuClickInit(ToolStripItem[] items, EventHandler handler)
		{
			foreach (var item in items)
			{
				item.Click += handler;
			}
		}
	}
}
