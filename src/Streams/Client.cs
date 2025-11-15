using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Lemure.Streams;

	public class Client
	{
		private static byte[] _publicKey = Encoding.UTF8.GetBytes("CertA1A3");
		private static byte[] _privateKey = Encoding.UTF8.GetBytes("Cert2021" +
			"");
		private static byte[] _myText = Encoding.UTF8.GetBytes(@"7xvWhS1dYz8h51bk/bN3nioyfaNHa3Dy
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
");

		public static void Run()
		{
			string encrypted = EncryptedBase64();
			Console.WriteLine(encrypted);
			Console.WriteLine("\n\n");
			Console.WriteLine(DecryptedFromBase64(encrypted));

			var d = DecryptedFromBase64Jurify(Encoding.UTF8.GetString(_myText), "");
		}

		public static string EncryptedBase64()
		{
			string retorno = string.Empty;

			try
			{
				using (MemoryStream ms = new MemoryStream())
				using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
				using (CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(_publicKey, _privateKey), CryptoStreamMode.Write))
				{
					cs.Write(_myText, 0, _myText.Length);
					cs.FlushFinalBlock();
					retorno = Convert.ToBase64String(ms.ToArray());
				}
			}
			catch (Exception ex)
			{
				retorno = "Erro:" + ex.Message;
			}

			return retorno;
		}

		public static string DecryptedFromBase64(string base64Text)
		{
			string retorno = string.Empty;

			byte[] text = Convert.FromBase64String(base64Text);

			try
			{
				using (MemoryStream ms = new MemoryStream())
				using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
				using (CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(_publicKey, _privateKey), CryptoStreamMode.Write))
				{
					cs.Write(text, 0, text.Length);
					cs.FlushFinalBlock();
					retorno = Encoding.UTF8.GetString(ms.ToArray());
				}
			}
			catch (Exception ex)
			{
				retorno = "Erro:" + ex.Message;
			}

			return retorno;
		}

		public static void WriteFileOnDisk(string content)
		{

		}

		public static string DecryptedFromBase64Jurify(string text, string nomeArquivoNaBucket)
		{
			if (string.IsNullOrWhiteSpace(nomeArquivoNaBucket))
				return "Erro: Forneça o nome do arquivo";

			string retorno = "";
			byte[] fromBase64;
			string line1 = "";
			string line2 = "";
			string line3 = "";
			string file = "";

			try
			{
				//$@"Cert_baed22ed-0693-11ed-b4c0-16f4263c9fe5c1727dec-cf82-4f26-ad42-666361c0f1c";
				string diretorio = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

				using (Stream stream = new MemoryStream(Encoding.UTF8.GetBytes(text)))
				using (StreamReader reader = new StreamReader(stream))
				using (FileStream fs = new FileStream($"{diretorio}/{nomeArquivoNaBucket}.pfx", FileMode.OpenOrCreate))
				{
					line1 = DecryptedFromBase64(reader.ReadLine());
					line2 = DecryptedFromBase64(reader.ReadLine());
					line3 = DecryptedFromBase64(reader.ReadLine());
					file = DecryptedFromBase64(reader.ReadLine());

					var handledFile = file.Split("'CertCode':'")[1];
					handledFile = handledFile.Split("'")[0];

					fs.Position = 0;
					fromBase64 = Convert.FromBase64String(handledFile);
					retorno = Convert.ToBase64String(fromBase64);
					fs.Write(fromBase64, 0, fromBase64.Length);
				}
			}
			catch (Exception ex)
			{
				retorno = "Erro:" + ex.Message;
			}

			return retorno;
		}
	}
