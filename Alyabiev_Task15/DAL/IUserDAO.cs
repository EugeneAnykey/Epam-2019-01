using System.Collections.Generic;
using Awarder.Entities;

namespace Awarder.DAL
{
	public interface IUserDAO
	{
		void Add(AwardedUser user);
		void Remove(AwardedUser user);

		void UnAssignAward(Award r);

		IEnumerable<AwardedUser> GetList();
	}
}
