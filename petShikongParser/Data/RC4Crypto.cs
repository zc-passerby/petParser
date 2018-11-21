using System;

namespace petShikongParser
{
	public class RC4Crypto : CryptoBase
	{
		public static RC4Crypto RC4 = new RC4Crypto();

		public override byte[] EncryptEx(byte[] data, string pass)
		{
			bool flag = data == null || pass == null;
			byte[] result;
			if (flag)
			{
				result = null;
			}
			else
			{
				byte[] array = new byte[data.Length];
				long num = 0L;
				long num2 = 0L;
				byte[] key = RC4Crypto.GetKey(CryptoBase.Encode.GetBytes(pass), 256);
				for (long num3 = 0L; num3 < (long)data.Length; num3 += 1L)
				{
					num = (num + 1L) % (long)key.Length;
					num2 = (num2 + (long)((ulong)key[(int)(checked((IntPtr)num))])) % (long)key.Length;
					checked
					{
						byte b = key[(int)((IntPtr)num)];
						key[(int)((IntPtr)num)] = key[(int)((IntPtr)num2)];
						key[(int)((IntPtr)num2)] = b;
						byte b2 = data[(int)((IntPtr)num3)];
						byte b3 = key[(int)(unchecked(key[(int)(checked((IntPtr)num))] + key[(int)(checked((IntPtr)num2))])) % key.Length];
						array[(int)((IntPtr)num3)] = (byte)(b2 ^ b3);
					}
				}
				result = array;
			}
			return result;
		}

		public override byte[] DecryptEx(byte[] data, string pass)
		{
			return this.EncryptEx(data, pass);
		}

		private static byte[] GetKey(byte[] pass, int kLen)
		{
			byte[] array = new byte[kLen];
			for (long num = 0L; num < (long)kLen; num += 1L)
			{
				array[(int)(checked((IntPtr)num))] = (byte)num;
			}
			long num2 = 0L;
			for (long num3 = 0L; num3 < (long)kLen; num3 += 1L)
			{
				num2 = (num2 + (long)((ulong)array[(int)(checked((IntPtr)num3))]) + (long)((ulong)pass[(int)(checked((IntPtr)(num3 % unchecked((long)pass.Length))))])) % (long)kLen;
				checked
				{
					byte b = array[(int)((IntPtr)num3)];
					array[(int)((IntPtr)num3)] = array[(int)((IntPtr)num2)];
					array[(int)((IntPtr)num2)] = b;
				}
			}
			return array;
		}
	}
}
