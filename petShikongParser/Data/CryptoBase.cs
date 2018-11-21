using System;
using System.Text;

namespace petShikongParser
{
	public class CryptoBase
	{
		public enum EncoderMode
		{
			Base64Encoder,
			HexEncoder
		}

		public static Encoding Encode = Encoding.Default;

		public CryptoBase.EncoderMode Mode = CryptoBase.EncoderMode.Base64Encoder;

		public string Encrypt(string data, string pass, CryptoBase.EncoderMode em)
		{
			bool flag = data == null || pass == null;
			string result;
			if (flag)
			{
				result = null;
			}
			else
			{
				bool flag2 = em == CryptoBase.EncoderMode.Base64Encoder;
				if (flag2)
				{
					result = Convert.ToBase64String(this.EncryptEx(CryptoBase.Encode.GetBytes(data), pass));
				}
				else
				{
					result = CryptoBase.ByteToHex(this.EncryptEx(CryptoBase.Encode.GetBytes(data), pass));
				}
			}
			return result;
		}

		public string Decrypt(string data, string pass, CryptoBase.EncoderMode em)
		{
			string result;
			try
			{
				bool flag = data == null || pass == null || data.Length <= 0;
				if (flag)
				{
					result = null;
				}
				else
				{
					bool flag2 = em == CryptoBase.EncoderMode.Base64Encoder;
					if (flag2)
					{
						result = CryptoBase.Encode.GetString(this.DecryptEx(Convert.FromBase64String(data), pass));
					}
					else
					{
						result = CryptoBase.Encode.GetString(this.DecryptEx(CryptoBase.HexToByte(data), pass));
					}
				}
			}
			catch
			{
				result = null;
			}
			return result;
		}

		public string Encrypt(string data, string pass)
		{
			return this.Encrypt(data, pass, this.Mode);
		}

		public string Decrypt(string data, string pass)
		{
			return this.Decrypt(data, pass, this.Mode);
		}

		public virtual byte[] EncryptEx(byte[] data, string pass)
		{
			return null;
		}

		public virtual byte[] DecryptEx(byte[] data, string pass)
		{
			return null;
		}

		public static byte[] HexToByte(string szHex)
		{
			int length = szHex.Length;
			bool flag = length <= 0 || length % 2 != 0;
			byte[] result;
			if (flag)
			{
				result = null;
			}
			else
			{
				int num = length / 2;
				byte[] array = new byte[num];
				for (int i = 0; i < num; i++)
				{
					uint num2 = (uint)(szHex[i * 2] - ((szHex[i * 2] >= 'A') ? '7' : '0'));
					bool flag2 = num2 >= 16u;
					if (flag2)
					{
						result = null;
						return result;
					}
					uint num3 = (uint)(szHex[i * 2 + 1] - ((szHex[i * 2 + 1] >= 'A') ? '7' : '0'));
					bool flag3 = num3 >= 16u;
					if (flag3)
					{
						result = null;
						return result;
					}
					array[i] = (byte)(num2 * 16u + num3);
				}
				result = array;
			}
			return result;
		}

		public static string ByteToHex(byte[] vByte)
		{
			bool flag = vByte == null || vByte.Length < 1;
			string result;
			if (flag)
			{
				result = null;
			}
			else
			{
				StringBuilder stringBuilder = new StringBuilder(vByte.Length * 2);
				for (int i = 0; i < vByte.Length; i++)
				{
					bool flag2 = vByte[i] < 0;
					if (flag2)
					{
						result = null;
						return result;
					}
					uint num = (uint)(vByte[i] / 16);
					stringBuilder.Append((char)((ulong)num + (ulong)((num > 9u) ? 55L : 48L)));
					num = (uint)(vByte[i] % 16);
					stringBuilder.Append((char)((ulong)num + (ulong)((num > 9u) ? 55L : 48L)));
				}
				result = stringBuilder.ToString();
			}
			return result;
		}
	}
}
