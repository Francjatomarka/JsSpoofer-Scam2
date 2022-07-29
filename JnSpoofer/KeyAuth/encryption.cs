using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

namespace KeyAuth
{
	// Token: 0x0200000E RID: 14
	public static class encryption
	{
		// Token: 0x0600007F RID: 127 RVA: 0x000040E8 File Offset: 0x000022E8
		public static string byte_arr_to_str(byte[] ba)
		{
			StringBuilder stringBuilder = new StringBuilder(ba.Length * 2);
			foreach (byte b in ba)
			{
				stringBuilder.AppendFormat("{0:x2}", b);
			}
			return stringBuilder.ToString();
		}

		// Token: 0x06000080 RID: 128 RVA: 0x00004134 File Offset: 0x00002334
		public static byte[] str_to_byte_arr(string hex)
		{
			byte[] result;
			try
			{
				int length = hex.Length;
				byte[] array = new byte[length / 2];
				for (int i = 0; i < length; i += 2)
				{
					array[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
				}
				result = array;
			}
			catch
			{
				Console.WriteLine("\n\n  The session has ended, open program again.");
				Thread.Sleep(3500);
				Environment.Exit(0);
				result = null;
			}
			return result;
		}

		// Token: 0x06000081 RID: 129 RVA: 0x000041B4 File Offset: 0x000023B4
		public static string encrypt_string(string plain_text, byte[] key, byte[] iv)
		{
			Aes aes = Aes.Create();
			aes.Mode = CipherMode.CBC;
			aes.Key = key;
			aes.IV = iv;
			string result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (ICryptoTransform cryptoTransform = aes.CreateEncryptor())
				{
					using (CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoTransform, CryptoStreamMode.Write))
					{
						byte[] bytes = Encoding.Default.GetBytes(plain_text);
						cryptoStream.Write(bytes, 0, bytes.Length);
						cryptoStream.FlushFinalBlock();
						byte[] ba = memoryStream.ToArray();
						result = encryption.byte_arr_to_str(ba);
					}
				}
			}
			return result;
		}

		// Token: 0x06000082 RID: 130 RVA: 0x0000427C File Offset: 0x0000247C
		public static string decrypt_string(string cipher_text, byte[] key, byte[] iv)
		{
			Aes aes = Aes.Create();
			aes.Mode = CipherMode.CBC;
			aes.Key = key;
			aes.IV = iv;
			string @string;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (ICryptoTransform cryptoTransform = aes.CreateDecryptor())
				{
					using (CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoTransform, CryptoStreamMode.Write))
					{
						byte[] array = encryption.str_to_byte_arr(cipher_text);
						cryptoStream.Write(array, 0, array.Length);
						cryptoStream.FlushFinalBlock();
						byte[] array2 = memoryStream.ToArray();
						@string = Encoding.Default.GetString(array2, 0, array2.Length);
					}
				}
			}
			return @string;
		}

		// Token: 0x06000083 RID: 131 RVA: 0x00004348 File Offset: 0x00002548
		public static string iv_key()
		{
			return Guid.NewGuid().ToString().Substring(0, Guid.NewGuid().ToString().IndexOf("-", StringComparison.Ordinal));
		}

		// Token: 0x06000085 RID: 133 RVA: 0x0000438C File Offset: 0x0000258C
		public static string encrypt(string message, string enc_key, string iv)
		{
			Encoding.Default;
			byte[] bytes = enc_key.GetBytes(new SHA256Managed().Substring(0, 32));
			Encoding.Default;
			byte[] bytes2 = iv.GetBytes(new SHA256Managed().Substring(0, 16));
			return encryption.encrypt_string(message, bytes, bytes2);
		}

		// Token: 0x06000086 RID: 134 RVA: 0x000043D8 File Offset: 0x000025D8
		public static string decrypt(string message, string enc_key, string iv)
		{
			Encoding.Default;
			byte[] bytes = enc_key.GetBytes(new SHA256Managed().Substring(0, 32));
			Encoding.Default;
			byte[] bytes2 = iv.GetBytes(new SHA256Managed().Substring(0, 16));
			return encryption.decrypt_string(message, bytes, bytes2);
		}
	}
}
