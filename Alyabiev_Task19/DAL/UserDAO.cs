using System;
using System.Collections.Generic;
using Awarder.Entities;

namespace Awarder.DAL
{
	public class UserDAO : IUserDAO
	{
		private List<AwardedUser> users = new List<AwardedUser>();

		public void Add(AwardedUser user)
		{
			if (user == null)
				throw new ArgumentException("user");

			users.Add(user);
		}

		public void Remove(AwardedUser user)
		{
			users.Remove(user);
		}

		public void Update(AwardedUser user)
		{
			// not necessary, cause it maked direct.
		}

		public void AlterAwards(AwardedUser user)
		{
			// not necessary, cause it maked direct.
		}



		public IEnumerable<AwardedUser> GetList()
		{
			return users;
		}

		public void UnAssignAward(Award r)
		{
			foreach (var u in users)
			{
				u.RemoveAward(r);
			}
		}
	}
}
