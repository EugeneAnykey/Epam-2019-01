using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Awarder.Entities;

namespace Awarder.DAL
{
	public class AwardDAOdb : IAwardDAO
	{
		// field
		readonly DbCommandRunner commandRunner;

		// fix/cheat for speeding:

		/// <summary>
		/// true when changes made, otherwise (e.g. GetList) it is false.
		/// </summary>
		bool needToGetListFromDb = true;

		/// <summary>
		/// refills every time when needToGetListFromDb equals true.
		/// </summary>
		IEnumerable<Award> awards = new List<Award>();

		// init
		public AwardDAOdb()
		{
			commandRunner = new DbCommandRunner(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString);
		}



		#region Add
		public void Add(Award award)
		{
			commandRunner.Run(Add, award);
		}

		[Obsolete]
		void AddNonFunc(SqlCommand command, Award award)
		{
			if (award == null)
				throw new ArgumentException("award");

			const string AddLine = "INSERT INTO Awards (Title, Description) VALUES(@title, @description)";

			command.CommandText = string.Format(AddLine);

			command.Parameters.Add(new SqlParameter("@title", SqlDbType.NVarChar));
			command.Parameters.Add(new SqlParameter("@description", SqlDbType.NVarChar));

			command.Parameters[0].Value = award.Title;
			command.Parameters[1].Value = award.Description;

			command.Prepare();

			needToGetListFromDb = true;
			var count = command.ExecuteNonQuery();
		}

		void Add(SqlCommand command, Award award)
		{
			if (award == null)
				throw new ArgumentException("award");

			command.CommandText = DbNames.AwardFunc.funcAdd;
			command.CommandType = CommandType.StoredProcedure;

			command.Parameters.Add(new SqlParameter(DbNames.AwardFunc.paramTitle, SqlDbType.NVarChar, 50));
			command.Parameters.Add(new SqlParameter(DbNames.AwardFunc.paramDescription, SqlDbType.NVarChar, 150));

			command.Parameters[0].Value = award.Title;
			command.Parameters[1].Value = award.Description;

			command.Prepare();

			needToGetListFromDb = true;
			var count = command.ExecuteNonQuery();
		}
		#endregion



		#region Remove
		public void Remove(Award award)
		{
			// unlink awards from users, if linked.
			commandRunner.Run(UnAssignAward, award);

			// removing from table:
			commandRunner.Run(Remove, award);
		}

		void Remove(SqlCommand command, Award award)
		{
			if (award == null)
				throw new ArgumentException("award");

			command.CommandText = DbNames.AwardFunc.funcDelete;
			command.CommandType = CommandType.StoredProcedure;
			command.Parameters.AddWithValue(DbNames.AwardFunc.paramId, award.Id);
			command.Prepare();

			needToGetListFromDb = true;
			var count = command.ExecuteNonQuery();
		}

		void UnAssignAward(SqlCommand command, Award award)
		{
			if (award == null)
				throw new ArgumentException("award");

			command.CommandText = DbNames.AwardFunc.funcUnAssignAward;
			command.CommandType = CommandType.StoredProcedure;
			command.Parameters.AddWithValue(DbNames.AwardFunc.paramId, award.Id);
			command.Prepare();

			var count = command.ExecuteNonQuery();
		}
		#endregion



		#region Update
		public void Update(Award award)
		{
			commandRunner.Run(Update, award);
		}

		void Update(SqlCommand command, Award award)
		{
			if (award == null)
				throw new ArgumentException("award");

			command.CommandText = DbNames.AwardFunc.funcUpdate;
			command.CommandType = CommandType.StoredProcedure;

			command.Parameters.Add(new SqlParameter(DbNames.AwardFunc.paramTitle, SqlDbType.NVarChar, 50));
			command.Parameters.Add(new SqlParameter(DbNames.AwardFunc.paramDescription, SqlDbType.NVarChar, 150));
			command.Parameters.AddWithValue(DbNames.AwardFunc.paramId, award.Id);
			command.Parameters[0].Value = award.Title;
			command.Parameters[1].Value = award.Description;
			command.Prepare();

			needToGetListFromDb = true;
			var count = command.ExecuteNonQuery();
		}
		#endregion



		#region GetList
		public IEnumerable<Award> GetList()
		{
			if (needToGetListFromDb)
				GetListFromDb();

			return awards;
		}



		void GetListFromDb()
		{
			awards = commandRunner.Run(GetListFromDb);
		}

		IEnumerable<Award> GetListFromDb(SqlCommand command)
		{
			List<Award> res = new List<Award>();

			command.CommandText = DbNames.AwardFunc.funcGetList;
			command.CommandType = CommandType.StoredProcedure;

			var reader = command.ExecuteReader();
			if (reader.HasRows)
			{
				while (reader.Read())
				{
					var award = new Award(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
					res.Add(award);
				}
			}

			needToGetListFromDb = false;
			return res;
		}
		#endregion
	}
}
