using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Awarder.DAL
{
	public class DbCommandRunner
	{
		// field
		readonly string connectionString;



		// init
		public DbCommandRunner(string connectionString)
		{
			this.connectionString = connectionString;
		}



		#region Run.
		public void Run<T>(Action<SqlCommand, T> workWithAward, T item)
		{
			using (SqlConnection con = new SqlConnection(connectionString))
			{
				con.Open();
				using (SqlCommand command = con.CreateCommand())
				{
					workWithAward(command, item);
				}
				con.Close();
			}
		}

		public IEnumerable<T> Run<T>(Func<SqlCommand, IEnumerable<T>> workWithItem)
		{
			IEnumerable<T> res = new List<T>();

			using (SqlConnection con = new SqlConnection(connectionString))
			{
				con.Open();
				using (SqlCommand command = con.CreateCommand())
				{
					res = workWithItem(command);
				}
				con.Close();
			}

			return res;
		}
		#endregion
	}
}
