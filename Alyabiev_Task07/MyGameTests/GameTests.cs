using System;
using NUnit.Framework;

namespace Alyabiev.Task07.Task4.Tests
{
	[TestFixture]
	public class GameTests
	{
		[Test]
		public void Init_Good()
		{
			var game = new Game();
			
			Assert.IsNotNull(
				game
			);
		}
	}
}