using System;
using System.Collections.Generic;

namespace Awarder.Entities
{
	public class AwardedUser : User
	{
		// field
		readonly List<Award> awards;
		public List<Award> Awards => awards;



		// event
		public event EventHandler AwardsChanged;
		void OnAwardsChanged() => AwardsChanged?.Invoke(this, EventArgs.Empty);



		// init
		public AwardedUser(string name, string surname, DateTime birthdate) : base(name, surname, birthdate)
		{
			awards = new List<Award>();
		}

		public AwardedUser(int id, string name, string surname, DateTime birthdate) : base(id, name, surname, birthdate)
		{
			awards = new List<Award>();
		}



		#region Awards: Alter, Add, Remove.
		public void AlterAwards(IList<Award> aws)
		{
			awards.Clear();
			awards.AddRange(aws);

			OnAwardsChanged();
		}

		public void AlterAwards(IEnumerable<Award> aws)
		{
			awards.Clear();
			awards.AddRange(aws);

			OnAwardsChanged();
		}

		public void AddAward(Award award)
		{
			if (!awards.Contains(award))
			{
				awards.Add(award);
				OnAwardsChanged();
			}
		}

		public void RemoveAward(Award award)
		{
			if (awards.Contains(award))
			{
				awards.Remove(award);
				OnAwardsChanged();
			}
		}
		#endregion
	}
}
