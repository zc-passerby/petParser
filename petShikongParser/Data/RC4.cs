using System;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace petShikongParser
{
	public class RC4
	{
		public static string EncryptRC4wq(string str, string ckey)
		{
			RC4Crypto rC4Crypto = new RC4Crypto();
			return rC4Crypto.Encrypt(str, ckey, CryptoBase.EncoderMode.HexEncoder);
		}

		public static bool 是否为数值(string value)
		{
			bool flag = value == null;
			return !flag && Regex.IsMatch(value, "^[+-]?\\d*[.]?\\d*$");
		}

		public static string get_uft8(string unicodeString)
		{
			UTF8Encoding uTF8Encoding = new UTF8Encoding();
			byte[] bytes = uTF8Encoding.GetBytes(unicodeString);
			return uTF8Encoding.GetString(bytes);
		}

		public static string DecryptRC4wq(string str, string ckey)
		{
			string result;
			try
			{
				bool flag = str.IndexOf("O19A87") != -1;
				if (flag)
				{
					str = str.Split(new string[]
					{
						"O19A87"
					}, StringSplitOptions.None)[0];
				}
				RC4Crypto rC4Crypto = new RC4Crypto();
				string text = rC4Crypto.Decrypt(str, ckey, CryptoBase.EncoderMode.HexEncoder);
				result = text;
			}
			catch (Exception var_4_46)
			{
				result = null;
			}
			return result;
		}

		private static byte[] strToToHexByte(string hexString)
		{
			hexString = hexString.Replace(" ", "");
			bool flag = hexString.Length % 2 != 0;
			if (flag)
			{
				hexString += " ";
			}
			byte[] array = new byte[hexString.Length / 2];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
			}
			return array;
		}

		public static string byteToHexStr(byte[] bytes)
		{
			string text = "";
			bool flag = bytes != null;
			if (flag)
			{
				for (int i = 0; i < bytes.Length; i++)
				{
					text += bytes[i].ToString("X2");
				}
			}
			return text;
		}

		public static string ToHex(string s, string charset, bool fenge)
		{
			bool flag = s.Length % 2 != 0;
			if (flag)
			{
				s += " ";
			}
			Encoding encoding = Encoding.GetEncoding(charset);
			byte[] bytes = encoding.GetBytes(s);
			string text = "";
			for (int i = 0; i < bytes.Length; i++)
			{
				text += string.Format("{0:X}", bytes[i]);
				bool flag2 = fenge && i != bytes.Length - 1;
				if (flag2)
				{
					text += string.Format("{0}", ",");
				}
			}
			return text.ToLower();
		}

		public static string UnHex(string hex, string charset)
		{
			bool flag = hex == null;
			if (flag)
			{
				throw new ArgumentNullException("hex");
			}
			hex = hex.Replace(",", "");
			hex = hex.Replace("\n", "");
			hex = hex.Replace("\\", "");
			hex = hex.Replace(" ", "");
			bool flag2 = hex.Length % 2 != 0;
			if (flag2)
			{
				hex += "20";
			}
			byte[] array = new byte[hex.Length / 2];
			for (int i = 0; i < array.Length; i++)
			{
				try
				{
					array[i] = byte.Parse(hex.Substring(i * 2, 2), NumberStyles.HexNumber);
				}
				catch
				{
					throw new ArgumentException("hex is not a valid hex number!", "hex");
				}
			}
			Encoding encoding = Encoding.GetEncoding(charset);
			return encoding.GetString(array);
		}
	}
}
