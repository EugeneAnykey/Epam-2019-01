using System.Collections.Generic;
using Awarder.Entities;

namespace Awarder.DAL
{
	public interface IAwardDAO
	{
		void Add(Award award);
		void Remove(Award award);
		void Update(Award award);

		IEnumerable<Award> GetList();
	}
}
