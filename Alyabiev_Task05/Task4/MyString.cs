/*
 * Написать свой собственный класс MyString, описывающий строку как массив символов.
 * Перегрузить для этого класса типовые операторы: 
 * 	+	– добавляет строку в конец текущей
 *  -	– удаляет подстроку из текущей строки
 *  ==	– сравнивает два объекта MyString
 *  
 *	ToString
 */

using System;
using System.Text;

namespace Alyabiev.Task05.Task4
{
	public class MyString
	{
		#region field
		public int Len
		{
			get { return array.Length; }
		}

		readonly char[] array;
		public char[] Array
		{
			get { return array; }
		}
		#endregion

		#region init
		public MyString()
		{
			array = new char[0];
		}

		public MyString(char[] chars)
		{
			if (chars == null)
				throw new ArgumentNullException();

			array = chars;
		}
		#endregion

		#region operator + -.
		public static MyString operator +(MyString left, MyString right)
		{
			if (left == null)
			{
				return right == null ? new MyString() : new MyString(right.array);
			}

			if (right == null)
			{
				return new MyString(left.array);
			}

			var chars = new char[left.Len + right.Len];

			left.array.CopyTo(chars, 0);
			right.array.CopyTo(chars, left.Len);

			return new MyString(chars);
		}

		public static MyString operator -(MyString left, MyString right)
		{
			if (left == null)
				throw new ArgumentNullException("left", "Левая часть должна быть объявлена.");

			var pos = left.Pos(right);

			if (pos == -1)
				return new MyString(left.array);

			var chars = new char[left.Len - right.Len];

			int i = 0;
			int j = 0;

			while (j < chars.Length)
			{
				if (pos == i)
					i += right.Len;

				chars[j++] = left.array[i++];
			}

			return new MyString(chars);
		}
		#endregion

		#region Equals, GetHashCode.
		public override int GetHashCode()
		{
			int hashCode = 0x0b12cd98;
			unchecked
			{
				if (array != null)
				{
					var a = 0;
					for (int i = 0; i < array.Length; i++)
					{
						a += (int)array[i];
					}
					hashCode += 0x0c23de87 * array.Length;
					hashCode += 0x0d34ef76 * a;
				}
			}
			return hashCode;
		}

		public override bool Equals(object obj)
		{
			var other = obj as MyString;
			return other != null ?
				this.GetHashCode() == other.GetHashCode() && Equals(other) : false;
		}

		bool Equals(MyString other)
		{
			if (other == null || Len != other.Len)
				return false;

			for (int i = 0; i < Len; i++)
			{
				if (array[i] != other.array[i])
					return false;
			}

			return true;
		}
		#endregion

		#region operator ==, !=
		public static bool operator ==(MyString lhs, MyString rhs)
		{
			if (ReferenceEquals(lhs, rhs))
				return true;
			if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null))
				return false;
			return lhs.Equals(rhs);
		}

		public static bool operator !=(MyString lhs, MyString rhs)
		{
			return !(lhs == rhs);
		}
		#endregion

		#region Pos.
		public int Pos(MyString s)
		{
			if (s == null)
				return -1;

			var equals = false;
			int end = array.Length - s.array.Length + 1;

			for (int i = 0; i < end; i++)
			{
				for (int j = 0; j < s.array.Length; j++)
				{
					equals = array[i + j] == s.array[j];
					if (!equals)
						break;
				}
				if (equals)
					return i;
			}

			return -1;
		}
		#endregion

		#region ToString
		public override string ToString()
		{
			var sb = new StringBuilder(array.Length);
			for (int i = 0; i < array.Length; i++)
			{
				sb.Append(array[i]);
			}

			return sb.ToString();
		}
		#endregion
	}
}