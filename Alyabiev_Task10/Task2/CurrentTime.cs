using System;

namespace Alyabiev.Task10.Task2
{
	public static class CurrentTime
	{
		#region init
		static CurrentTime()
		{
			var d = DateTime.UtcNow;
			Now = new DateTime(d.Year, d.Month, d.Day, 0, 0, 0);
		}
		#endregion

		#region offset
		public static int Offset { get; set; }

		static DayTime DayTimeByOffset(int offset = 0)
		{
			var t = (Now.Hour + offset) / 6;
			return (DayTime)(t > 3 ? 0 : t < 0 ? 3 : t);
		}
		#endregion

		public static DayTime DayTime => DayTimeByOffset(Offset);	// strange, with offset.

		//public static DayTime DayTime => (DayTime)(Now.Hour / 6);	// normal, wo offset.

		public static DateTime Now { get; private set; }

		public static void AddHours(double hours)
		{
			Now = Now.AddHours(hours);
		}

		public static string GetTimeInString()
		{
			return string.Format($"{Now:HH:mm:ss}");
		}
	}
}