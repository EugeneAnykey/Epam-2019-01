using System;

namespace Epam.Task11.NetBasicsDemo
{
	public class TwoDPointWithHash : TwoDPoint
	{
		public TwoDPointWithHash(int x, int y) : base(x, y) { }

		public override int GetHashCode()
		{
            //return x ^ y; // ^ выполняет операцию логического исключающего XOR побитно

            /*
            int hashBase = 0x17;

            unchecked
            {
                hashBase = (hashBase * 7) + x;
                hashBase = (hashBase * 7) + y;
            }
            */

            //int hashBase = 0xD9AD;  // 1101 1001 1010 1101

            int hashBase = 0xAD;  // 1010 1101

            unchecked
            {
                hashBase = (hashBase * 0xb2) + x;   // 1011 0010
                hashBase = (hashBase * 0x9B) + y;   // 1001 1011
            }

            return hashBase;
        }
    }
}