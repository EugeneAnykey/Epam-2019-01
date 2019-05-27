using System;
using System.Collections.Generic;
using System.Linq;
using Awarder.Entities;
using Awarder.DAL;

namespace Awarder.BLL
{
	public class AwardsBL
	{
		// field
		readonly IAwardDAO awardsDAO;

		// init
		public AwardsBL()
		{
			awardsDAO = new AwardDAO();
		}

		// test data
		public void MakeTestData()
		{
			var testAwards = new[] {
				new Award("The Creator", "Awarded for creating the wiki!"),
				new Award("Welcome to the Wiki", "Awarded for joining the wiki!"),
				new Award("Making a Difference", "Awarded for making 1 edit on an article!"),
				new Award("Just the Beginning", "Awarded for making 5 edits on articles!"),
				new Award("Snapshot", "Awarded for adding 1 picture to an article!"),
			};

			foreach (var item in testAwards)
			{
				awardsDAO.Add(item);
			}
		}

		#region sort
		public IEnumerable<Award> SortAscBy<T>(Func<Award, T> func)
		{
			return GetList().Select(i => i).OrderBy(func).ToList();
		}

		public IEnumerable<Award> SortDescBy<T>(Func<Award, T> func)
		{
			return GetList().Select(i => i).OrderByDescending(func).ToList();
		}
		#endregion

		#region Add, Remove.
		public void Add(string title, string description)
		{
			Add(new Award(title, description));
		}

		public void Add(Award award)
		{
			awardsDAO.Add(award ?? throw new ArgumentNullException());
		}

		public void Remove(Award award)
		{
			awardsDAO.Remove(award ?? throw new ArgumentNullException());
		}
		#endregion

		// short funcs
		public IEnumerable<Award> GetList() => awardsDAO.GetList();
	}
}
