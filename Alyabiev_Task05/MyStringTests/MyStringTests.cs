using System;

using NUnit.Framework;

namespace Alyabiev.Task05.Task4.Tests
{
    [TestFixture]
    public class MyStringTests
    {
        #region init
        [Test]
        public void Init_Chars_Good()
        {
            var expected = new[] { 'a', 'b', 'c' };
            var s1 = new MyString("abc".ToCharArray());

            Assert.AreEqual(
                expected,
                s1.Array
            );
        }


        [Test]
        public void Init_Chars_Good2()
        {
            var expected = new[] { 'a', 'b', 'c' };
            var input = new[] { 'a', 'b', 'c' };
            var s1 = new MyString(input);
            input = new[] { 'd', 'e' };

            Assert.AreEqual(
                expected,
                s1.Array
            );
        }


        [Test]
        public void Init_Zero_Good()
        {
            var expected = new char[0];
            var s1 = new MyString();

            Assert.AreEqual(
                expected,
                s1.Array
            );
        }


        [Test]
        public void Init_Null_Throw()
        {
            Assert.Catch<ArgumentNullException>(() => new MyString(null));
        }
        #endregion



        #region Pos
        [TestCase(0, "abc tuv xyz", "a")]
        [TestCase(0, "abc tuv xyz", "ab")]
        [TestCase(1, "abc tuv xyz", "bc")]
        [TestCase(4, "abc tuv xyz", "tuv")]
        [TestCase(8, "abc tuv xyz", "xyz")]
        [TestCase(8, "abc tuv xyz", "xy")]
        [TestCase(10, "abc tuv xyz", "z")]
        [TestCase(-1, "abc tuv xyz", "xyzw")]
        [TestCase(-1, "abc tuv xyz", "dfg")]
        [TestCase(-1, "a", "abc")]
        public void Pos_NormalInput_Good(int expected, string line1, string line2)
        {
            var s1 = new MyString(line1.ToCharArray());
            var s2 = new MyString(line2.ToCharArray());

            Assert.AreEqual(
                expected,
                s1.Pos(s2)
            );
        }


        [Test]
        public void Pos_NullInput_Good()
        {
            const int expected = -1;
            var s1 = new MyString("abc".ToCharArray());

            Assert.AreEqual(
                expected,
                s1.Pos(null)
            );
        }
        #endregion



        #region add
        [TestCase("ab", "a", "b")]
        [TestCase("ab c", "ab", " c")]
        [TestCase("ab c", "a", "b c")]
        [TestCase("abc", "abc", "")]
        [TestCase("abc", "", "abc")]
        public void Add_NormalInput_Good(string expected, string line1, string line2)
        {
            var s1 = new MyString(line1.ToCharArray());
            var s2 = new MyString(line2.ToCharArray());

            Assert.AreEqual(
                expected.ToCharArray(),
                (s1 + s2).Array
            );
        }


        [Test]
        public void Add_NullInput0_Good()
        {
            var expected = new char[0];
            MyString s1 = null;
            MyString s2 = null;

            Assert.AreEqual(
                expected,
                (s1 + s2).Array
            );
        }


        [Test]
        public void Add_NullInput1_Good()
        {
            var expected = new[] { 'a' };
            var s1 = new MyString(new[] { 'a' });
            MyString s2 = null;

            Assert.AreEqual(
                expected,
                (s1 + s2).Array
            );
        }


        [Test]
        public void Add_NullInput2_Good()
        {
            var expected = new[] { 'b' };
            var s2 = new MyString(new[] { 'b' });
            MyString s1 = null;

            Assert.AreEqual(
                expected,
                (s1 + s2).Array
            );
        }
        #endregion



        #region Exclude
        [TestCase("abc", "abc", "-d")]
        [TestCase("abc", "abc", "-bcd")]
        [TestCase("abc", "abc", "")]
        [TestCase("", "", "-a")]
        public void Exclude_NormalNoDelete_Good(string expected, string line1, string line2)
        {
            var s1 = new MyString(line1.ToCharArray());
            var s2 = new MyString(line2.ToCharArray());

            Assert.AreEqual(
                expected.ToCharArray(),
                (s1 - s2).Array
            );
        }


        [TestCase("fd", "-ab.fd", "-ab.")]
        [TestCase("fdgh", "-ab.fdgh", "-ab.")]
        public void Exclude_NormalLeftDelete_Good(string expected, string line1, string line2)
        {
            var s1 = new MyString(line1.ToCharArray());
            var s2 = new MyString(line2.ToCharArray());
            var res = s1 - s2;

            Assert.AreEqual(
                expected.ToCharArray(),
                res.Array
            );
        }


        [TestCase("ab.d", "ab-c.d", "-c")]
        public void Exclude_NormalMiddleDelete_Good(string expected, string line1, string line2)
        {
            var s1 = new MyString(line1.ToCharArray());
            var s2 = new MyString(line2.ToCharArray());
            var res = s1 - s2;

            Assert.AreEqual(
                expected.ToCharArray(),
                res.Array
            );
        }


        [TestCase("a", "ab", "b")]
        [TestCase("a", "a-b", "-b")]
        [TestCase("ab", "ab-fd", "-fd")]
        public void Exclude_NormalRightDelete_Good(string expected, string line1, string line2)
        {
            var s1 = new MyString(line1.ToCharArray());
            var s2 = new MyString(line2.ToCharArray());

            Assert.AreEqual(
                expected.ToCharArray(),
                (s1 - s2).Array
            );
        }


        [Test]
        public void Exclude_NullInput_Good()
        {
            MyString s1 = null;
            MyString res;
            Assert.Catch<ArgumentNullException>(() => res = s1 - new MyString(null));
        }
        #endregion



        #region Equals, NotEquals.
        [TestCase("a", "a")]
        [TestCase("ab", "ab")]
        [TestCase("ab cd ef", "ab cd ef")]
        public void Equals_NormalInput_Good(string line1, string line2)
        {
            var s1 = new MyString(line1.ToCharArray());
            var s2 = new MyString(line2.ToCharArray());

            Assert.IsTrue(
                s1 == s2
            );
        }


        [TestCase("abc", "")]
        [TestCase("abc", "ab")]
        [TestCase("abc", "bc")]
        [TestCase("ab", "abc")]
        [TestCase("bc", "abc")]
        [TestCase("", "def")]
        [TestCase("abc", "def")]
        public void NotEquals_NormalInput_Good(string line1, string line2)
        {
            var s1 = new MyString(line1.ToCharArray());
            var s2 = new MyString(line2.ToCharArray());

            Assert.IsTrue(
                s1 != s2
            );
        }
        #endregion
    }
}