using System;

namespace Alyabiev.Task06.Task1
{
	public static class RusNumeralsFollowingWord
	{
		public enum LangRusNumericEndingFormats { OneItem, EndsFromTwoToFour, ManyItems }

		public static LangRusNumericEndingFormats LangRusNumericEndingFormat(int value)
		{
			var res =
				10 < value && value < 19 ? LangRusNumericEndingFormats.ManyItems :
				2 <= value % 10 && value % 10 <= 4 ? LangRusNumericEndingFormats.EndsFromTwoToFour :
				value % 10 == 1 ? LangRusNumericEndingFormats.OneItem :
				LangRusNumericEndingFormats.ManyItems;

			return res;
		}

		public static string StringEndingForNumeric(int value, string[] variants)
		{
			switch (LangRusNumericEndingFormat(value))
			{
				case LangRusNumericEndingFormats.OneItem:
					return variants[0];
				case LangRusNumericEndingFormats.EndsFromTwoToFour:
					return variants[1];
				case LangRusNumericEndingFormats.ManyItems:
					return variants[2];
				default:
					return string.Empty;
			}
		}
	}
}