using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Awarder.Entities;

namespace Awarder.DAL
{
	public class UserDAOdb : IUserDAO
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
		IEnumerable<AwardedUser> users = new List<AwardedUser>();



		// cheat for linking awards to user
		public delegate IEnumerable<Award> GetAwardsList(IEnumerable<int> ids);

		public GetAwardsList AwardsListGetter;



		// init
		public UserDAOdb()
		{
			commandRunner = new DbCommandRunner(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString);
		}



		#region Add
		public void Add(AwardedUser user)
		{
			commandRunner.Run(Add, user);
		}

		void Add(SqlCommand command, AwardedUser user)
		{
			if (user == null)
				throw new ArgumentNullException("user");

			command.CommandText = DbNames.UserFunc.funcAdd;
			command.CommandType = CommandType.StoredProcedure;

			command.Parameters.Add(new SqlParameter(DbNames.UserFunc.paramFirstName, SqlDbType.NVarChar, 50));
			command.Parameters.Add(new SqlParameter(DbNames.UserFunc.paramSurname, SqlDbType.NVarChar, 50));
			command.Parameters.AddWithValue(DbNames.UserFunc.paramBirthdate, user.Birthdate);
			command.Parameters[0].Value = user.Name;
			command.Parameters[1].Value = user.Surname;
			command.Prepare();

			needToGetListFromDb = true;
			var count = command.ExecuteNonQuery();
		}

		[Obsolete]
		void AddWithRels(SqlCommand command, AwardedUser user)
		{
			// currently not used.
			if (user == null)
				throw new ArgumentNullException("user");

			command.CommandText = DbNames.UserFunc.funcAddWithRels;
			command.CommandType = CommandType.StoredProcedure;

			command.Parameters.Add(new SqlParameter(DbNames.UserFunc.paramFirstName, SqlDbType.NVarChar, 50));
			command.Parameters.Add(new SqlParameter(DbNames.UserFunc.paramSurname, SqlDbType.NVarChar, 50));
			command.Parameters.Add(new SqlParameter(DbNames.UserFunc.paramBirthdate, SqlDbType.DateTime2));

			command.Parameters[0].Value = user.Name;
			command.Parameters[1].Value = user.Surname;
			command.Parameters[2].Value = user.Birthdate;

			// table of awards:
			var awards = new DataTable();
			awards.Columns.Add(new DataColumn("id", typeof(int)));
			foreach (var item in user.Awards)
			{
				awards.Rows.Add(item.Id);
			}

			command.Parameters.Add(new SqlParameter("@awardIds", SqlDbType.Structured));
			command.Parameters[3].Value = awards;

			command.Prepare();

			needToGetListFromDb = true;
			var count = command.ExecuteNonQuery();
		}
		#endregion



		#region AlterAwards.
		public void AlterAwards(AwardedUser user)
		{
			commandRunner.Run(AlterAwards, user);
		}

		void AlterAwards(SqlCommand command, AwardedUser user)
		{
			if (user == null)
				throw new ArgumentNullException("user");

			command.CommandText = DbNames.RelsFunc.funcAlterAwards;
			command.CommandType = CommandType.StoredProcedure;
			command.Parameters.AddWithValue(DbNames.RelsFunc.paramUserId, user.Id);

			// table of awards:
			var awards = new DataTable();
			awards.Columns.Add(new DataColumn(DbNames.RelsFunc.paramId, typeof(int)));
			foreach (var item in user.Awards)
			{
				awards.Rows.Add(item.Id);
			}
			command.Parameters.Add(new SqlParameter(DbNames.RelsFunc.paramIds, SqlDbType.Structured));
			command.Parameters[1].Value = awards;

			command.Prepare();

			needToGetListFromDb = true;     // however it could be only (GetAwardsListForUser, user), but not now.
			var count = command.ExecuteNonQuery();
		}
		#endregion



		#region Remove
		public void Remove(AwardedUser user)
		{
			commandRunner.Run(Remove, user);
		}

		void Remove(SqlCommand command, AwardedUser user)
		{
			if (user == null)
				throw new ArgumentNullException("user");

			command.CommandText = DbNames.UserFunc.funcDeleteWithRels;
			command.CommandType = CommandType.StoredProcedure;

			command.Parameters.AddWithValue(DbNames.UserFunc.paramId, user.Id);
			command.Prepare();

			needToGetListFromDb = true;
			var count = command.ExecuteNonQuery();
		}
		#endregion



		#region Update
		public void Update(AwardedUser user)
		{
			commandRunner.Run(Update, user);
		}

		void Update(SqlCommand command, AwardedUser user)
		{
			if (user == null)
				throw new ArgumentNullException("user");

			command.CommandText = DbNames.UserFunc.funcUpdate;
			command.CommandType = CommandType.StoredProcedure;

			command.Parameters.Add(new SqlParameter(DbNames.UserFunc.paramFirstName, SqlDbType.NVarChar, 50));
			command.Parameters.Add(new SqlParameter(DbNames.UserFunc.paramSurname, SqlDbType.NVarChar, 50));
			command.Parameters.AddWithValue(DbNames.UserFunc.paramBirthdate, user.Birthdate);
			command.Parameters.AddWithValue(DbNames.UserFunc.paramId, user.Id);

			command.Parameters[0].Value = user.Name;
			command.Parameters[1].Value = user.Surname;

			command.Prepare();

			needToGetListFromDb = true;
			var count = command.ExecuteNonQuery();
		}
		#endregion



		#region GetList
		public IEnumerable<AwardedUser> GetList()
		{
			if (needToGetListFromDb)
				GetListFromDb();

			return users;
		}

		void GetListFromDb()
		{
			users = commandRunner.Run(GetListFromDb);

			// getting awards for each user:
			foreach (var user in users)
			{
				commandRunner.Run(GetAwardsListForUser, user);
			}
		}

		IEnumerable<AwardedUser> GetListFromDb(SqlCommand command)
		{
			command.CommandText = DbNames.UserFunc.funcGetList;
			command.CommandType = CommandType.StoredProcedure;

			command.Prepare();

			var reader = command.ExecuteReader();

			var res = new List<AwardedUser>();
			while (reader.Read())
			{
				int id = (int)reader[DbNames.UserTable.colId];
				string firstName = (string)reader[DbNames.UserTable.colFirstName];
				string surname = (string)reader[DbNames.UserTable.colSurname];
				DateTime birthdate = (DateTime)reader[DbNames.UserTable.colBirthdate];

				res.Add(new AwardedUser(id, firstName, surname, birthdate));
			}

			needToGetListFromDb = false;
			return res;
		}

		void GetAwardsListForUser(SqlCommand command, AwardedUser user)
		{
			command.CommandText = DbNames.RelsFunc.funcGetUserAwardsIds;
			command.CommandType = CommandType.StoredProcedure;
			command.Parameters.AddWithValue(DbNames.RelsFunc.paramUserId, user.Id);
			command.Prepare();
			
			var reader = command.ExecuteReader();
			var awardsIds = new List<int>();
			while (reader.Read())
			{
				awardsIds.Add((int)reader[DbNames.RelsTable.colAwardId]);
			}

			var awards = AwardsListGetter(awardsIds);

			user.AlterAwards(awards);
		}
		#endregion



		// UnAssignAward
		public void UnAssignAward(Award r)
		{
			// not from here this time. It calls from Awards.DeleteAward.
			return;
		}
	}
}
