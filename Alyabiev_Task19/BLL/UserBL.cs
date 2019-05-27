using System;
using System.Collections.Generic;
using System.Linq;
using Awarder.Entities;
using Awarder.DAL;

namespace Awarder.BLL
{
	public class UsersBL
	{
		// field
		readonly IUserDAO usersDAO;

		// fix/cheat
		readonly AwardsBL awardsBL;



		// init
		public UsersBL(AwardsBL awards, bool server = false)
		{
			awardsBL = awards;

			if (server)
			{
				usersDAO = new UserDAOdb() { AwardsListGetter = awards.GetListFromIds<Award> };
			}
			else
				usersDAO = new UserDAO();
		}



		// test data
		public void MakeTestData()
		{
			var testUsers = new[] {
				new AwardedUser("Ivan", "Vasiliev", new DateTime(2001, 02, 03)),
				new AwardedUser("Boris", "Preobrazhenskiy", new DateTime(1982, 07, 21)),
				new AwardedUser("Mamoru", "Nakuoku", new DateTime(1959, 10, 17)),
				new AwardedUser("Sergey", "Skuratov", new DateTime(1974, 12, 25)),
				new AwardedUser("Stephen", "Hawk", new DateTime(1947, 12, 09)),
				new AwardedUser("Alexey", "Malyutin", new DateTime(1993, 09, 03)),
				new AwardedUser("Malek", "Miestovich", new DateTime(1999, 06, 05)),
			};

			foreach (var item in testUsers)
			{
				usersDAO.Add(item);
			}
		}



		#region sort
		/*
		public IEnumerable<IUser> SortUsersAscBy<T>(Func<IUser, T> func)
		{
			return GetList().Select(u => u).OrderBy(func).ToList();
		}

		public IEnumerable<IUser> SortUsersDescBy<T>(Func<IUser, T> func)
		{
			return GetList().Select(u => u).OrderByDescending(func).ToList();
		}
		*/

		public IEnumerable<AwardedUser> SortUsersAscBy<T>(Func<AwardedUser, T> func)
		{
			return GetList().Select(u => u).OrderBy(func).ToList();
		}

		public IEnumerable<AwardedUser> SortUsersDescBy<T>(Func<AwardedUser, T> func)
		{
			return GetList().Select(u => u).OrderByDescending(func).ToList();
		}

		public IEnumerable<UserViewModel> SortUsersAscBy<T>(Func<UserViewModel, T> func)
		{
			return GetUsersViewModel().Select(u => u).OrderBy(func).ToList();
		}

		public IEnumerable<UserViewModel> SortUsersDescBy<T>(Func<UserViewModel, T> func)
		{
			return GetUsersViewModel().Select(u => u).OrderByDescending(func).ToList();
		}
		#endregion



		#region Add, AlterAwards, Remove, UnAssignAward.
		public void Add(string name, string surname, DateTime birthdate)
		{
			Add(new AwardedUser(name, surname, birthdate));
		}

		public void Add(AwardedUser user)
		{
			usersDAO.Add(user ?? throw new ArgumentNullException());
		}

		public void AlterAwards(AwardedUser user)
		{
			usersDAO.AlterAwards(user ?? throw new ArgumentNullException());
		}

		public void Remove(AwardedUser user)
		{
			usersDAO.Remove(user ?? throw new ArgumentNullException());
		}

		public void UnAssignAward(Award r)
		{
			usersDAO.UnAssignAward(r);
		}
		#endregion



		// short funcs
		public IEnumerable<AwardedUser> GetList()
		{
			var list = usersDAO.GetList();

			return list;
		}

		public List<UserViewModel> GetUsersViewModel()
		{
			return GetList().Select(u => new UserViewModel(u)).ToList();
		}

		public void Update(AwardedUser user)
		{
			usersDAO.Update(user ?? throw new ArgumentNullException());
		}
	}
}
