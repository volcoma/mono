// Vector2ul.cs
//
// Author:
//   Rodrigo Kumpera (rkumpera@novell.com)
//
// (C) 2008 Novell, Inc. (http://www.novell.com)
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//
using System;
using System.Runtime.InteropServices;

namespace Mono.Simd
{
	[StructLayout(LayoutKind.Sequential, Pack = 0, Size = 16)]
	[CLSCompliant(false)]
	public struct Vector2ul
	{
		private ulong x;
		private ulong y;

		public ulong X { get { return x; } set { x = value; } }
		public ulong Y { get { return y; } set { y = value; } }

		public Vector2ul (ulong x, ulong y)
		{
			this.x = x;
			this.y = y;
		}

		public static Vector2ul operator + (Vector2ul v1, Vector2ul v2)
		{
			return new Vector2ul (v1.x + v2.x, v1.y + v2.y);
		}

		public static Vector2ul operator - (Vector2ul v1, Vector2ul v2)
		{
			return new Vector2ul (v1.x - v2.x, v1.y - v2.y);
		}

		public static unsafe Vector2ul operator << (Vector2ul v1, int amount)
		{
			return new Vector2ul (v1.x << amount, v1.y << amount);
		}

		public static unsafe Vector2ul operator >> (Vector2ul v1, int amount)
		{
			return new Vector2ul (v1.x >> amount, v1.y >> amount);
		}
		public static Vector2ul operator & (Vector2ul v1, Vector2ul v2)
		{
			return new Vector2ul (v1.x & v2.x, v1.y & v2.y);
		}

		public static Vector2ul operator | (Vector2ul v1, Vector2ul v2)
		{
			return new Vector2ul (v1.x | v2.x, v1.y | v2.y);
		}

		public static Vector2ul operator ^ (Vector2ul v1, Vector2ul v2)
		{
			return new Vector2ul (v1.x ^ v2.x, v1.y ^ v2.y);
		}

		public static Vector2ul UnpackLow (Vector2ul v1, Vector2ul v2)
		{
			return new Vector2ul (v1.x, v2.x);
		}

		public static Vector2ul UnpackHigh (Vector2ul v1, Vector2ul v2)
		{
			return new Vector2ul (v1.y, v2.y);
		}

		public static unsafe int ExtractByteMask (Vector2ul va) {
			int res = 0;
			byte *a = (byte*)&va;
			for (int i = 0; i < 16; ++i)
				res |= (*a++ & 0x80) >> 7 << i;
			return res;
		}

		/*Requires SSE 4.1*/
		public static Vector2ul CompareEqual (Vector2ul v1, Vector2ul v2)
		{
			return new Vector2ul ((ulong)(v1.x ==  v2.x ? -1 : 0), (ulong)(v1.y ==  v2.y ? -1 : 0));
		}

  		public static unsafe explicit operator Vector4f (Vector2ul v1)
		{
			Vector4f* p = (Vector4f*)&v1;
			return *p;
		}

 		public static unsafe explicit operator Vector8us (Vector2ul v1)
		{
			Vector8us* p = (Vector8us*)&v1;
			return *p;
		}

  		public static unsafe explicit operator Vector16b (Vector2ul v1)
		{
			Vector16b* p = (Vector16b*)&v1;
			return *p;
		}

		public static Vector2ul LoadAligned (ref Vector2ul v)
		{
			return v;
		}

		public static void StoreAligned (ref Vector2ul res, Vector2ul val)
		{
			res = val;
		}

		public static unsafe Vector2ul LoadAligned (Vector2ul *v)
		{
			return *v;
		}

		public static unsafe void StoreAligned (Vector2ul *res, Vector2ul val)
		{
			*res = val;
		}
	}
}
