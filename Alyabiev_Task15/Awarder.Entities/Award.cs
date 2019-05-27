using System;

namespace Awarder.Entities
{
	public class Award
	{
		#region static helpers
		static bool IsTitleGood(string value, int maxLength = 0)
		{
			if (value == null)
				throw new ArgumentNullException();

			if (maxLength > 0 && value.Length > maxLength)
			{
				throw new ArgumentException($"Should be less or equal to {maxLength}.");
			}

			return true;
		}
		#endregion



		static int lastId = 1;



		#region field: Id, Title, Description.
		public int Id { get; private set; }

		string title;
		public string Title
		{
			get => title;
			set => title = IsTitleGood(value, 50) ? value : throw new ArgumentException();
		}

		string description;
		public string Description
		{
			get => description;
			set => description = value ?? string.Empty;
		}
		#endregion



		public Award(string title, string description)
		{
			Id = lastId++;
			Title = title;
			Description = description;
		}

		public override string ToString()
		{
			return Title;
		}
	}
}
