using System;
using System.Collections;
using System.Collections.Generic;

namespace Alyabiev.Task14.Task1
{
	public class RewardedUser : User
	{
		#region field
		readonly List<Reward> rewards;
		public List<Reward> Rewards => rewards;
		#endregion

		#region event
		public event EventHandler RewardsChanged;
		void OnRewardsChanged() => RewardsChanged?.Invoke(this, EventArgs.Empty);
		#endregion

		public RewardedUser(string name, string surname, DateTime birthdate) : base(name, surname, birthdate)
		{
			rewards = new List<Reward>();
		}

		#region Alter Rewards, Add, Remove.
		public void AlterRewards(IList<Reward> rews)
		{
			rewards.Clear();
			rewards.AddRange(rews);

			OnRewardsChanged();
		}

		public void AlterRewards(IList rews)
		{
			rewards.Clear();
			foreach (Reward item in rews)
			{
				rewards.Add(item);
			}

			OnRewardsChanged();
		}

		public void AddReward(Reward reward)
		{
			if (!rewards.Contains(reward))
			{
				rewards.Add(reward);
				OnRewardsChanged();
			}
		}

		public void RemoveReward(Reward reward)
		{
			if (rewards.Contains(reward))
			{
				rewards.Remove(reward);
				OnRewardsChanged();
			}
		}
		#endregion
	}
}
