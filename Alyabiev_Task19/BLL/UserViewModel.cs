using System;
using System.Collections.Generic;
using System.Linq;
using Awarder.Entities;

namespace Awarder.BLL
{
	public class UserViewModel : IUser
	{
		// field
		AwardedUser user;
		public AwardedUser User => user;

		public string Name => user.Name;
		public string Surname => user.Surname;
		public int Age => user.Age;
		public string AgeString => user.AgeString;
		public DateTime Birthdate => user.Birthdate;
		public string Awards => AwadsToString(user.Awards);



		public UserViewModel(AwardedUser user)
		{
			this.user = user ?? throw new ArgumentNullException("user");
		}



		static string AwadsToString(IList<Award> awards)
		{
			const string separator = ", ";

			return string.Join(
				separator,
				awards.Where(x => x != null).Select(x => x.Title) //.ToArray()
			);
		}
	}
}
