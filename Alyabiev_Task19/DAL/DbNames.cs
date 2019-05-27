using System.Collections.Generic;
using Awarder.Entities;

namespace Awarder.DAL
{
	#region Names struct
	public struct DbNames
	{
		// tables names
		public struct Tables
		{
			public const string Awards = "Awards";
			public const string Rels = "Relations"; 
			public const string Users = "Users";
		}



		// Awards table
		public struct AwardTable
		{
			public const string colId = "Id";
			public const string colTitle = "Title";
			public const string colDescription = "Description";
		}

		public struct AwardFunc
		{
			public const string paramId = "@id";
			public const string paramTitle = "@title";
			public const string paramDescription = "@description";

			public const string funcAdd = "AddAward";
			public const string funcDelete = "DeleteAward";
			public const string funcUpdate = "UpdateAward";
			public const string funcGetList = "GetAwards";

			public const string funcUnAssignAward = "UnAssignAward";
		}



		// User table
		public struct UserTable
		{
			public const string colId = "Id";
			public const string colFirstName = "FirstName";
			public const string colSurname = "Surname";
			public const string colBirthdate = "Birthdate";
		}

		public struct UserFunc
		{
			public const string paramId = "@id";
			public const string paramFirstName = "@firstName";
			public const string paramSurname = "@surname";
			public const string paramBirthdate = "@birthdate";

			public const string funcAdd = "AddUserSimple";
			public const string funcDelete = "DeleteUserSimple";
			public const string funcUpdate = "UpdateUserSimple";
			public const string funcGetList = "GetUsers";

			public const string funcAddWithRels = "AddUser";
			public const string funcDeleteWithRels = "DeleteUserWithRels";
		}



		// Relation table
		public struct RelsTable
		{
			public const string colId = "Id";
			public const string colUserId = "UserId";
			public const string colAwardId = "AwardId";
		}

		public struct RelsFunc
		{
			public const string paramId = "@id";
			public const string paramIds = "@awardIds";
			public const string paramUserId = "@userId";

			public const string funcAlterAwards = "AlterAwards";
			public const string funcGetUserAwardsIds = "GetUserAwardsIds";
			
		}



	}
	#endregion
}
