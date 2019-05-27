using System.Collections.Generic;
using System.Linq;
using Awarder.Entities;

namespace Awarder.BLL
{
	public static class UsersViewModelBL
	{
		public static List<UserViewModel> GetUsersViewModel(this IEnumerable<AwardedUser> list)
		{
			return list.Select(u => new UserViewModel(u)).ToList();
		}
	}
}
