using System;
using System.Collections.Generic;
using Awarder.Entities;

namespace Awarder.DAL
{
	public class AwardDAO : IAwardDAO
	{
		private List<Award> awards = new List<Award>();

		public void Add(Award award)
		{
			if (award == null)
				throw new ArgumentException("award");

			awards.Add(award);
		}

		public void Remove(Award award)
		{
			awards.Remove(award);
		}

		public IEnumerable<Award> GetList()
		{
			return awards;
		}
	}
}
