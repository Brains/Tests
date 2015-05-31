using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

// ReSharper disable InconsistentNaming

namespace PrivatBank
{
	class Program
	{
		static void Main()
		{
			var responce = SendString();
		}

		private static string CalculateSignature(string data)
		{
			var md5 = GetHexString(CalculateMD5(data));
			var sha1 = GetHexString(CalculateSHA(md5));

			return sha1;
		}

		private static string SendFile()
		{
//			var url = "https://api.privatbank.ua/p24api/balance";
			var url = "https://api.privatbank.ua/p24api/rest_fiz";
			string xml = "Request.xml";

			WebClient client = new WebClient();
			var responce = client.UploadFile(url, xml);

			return LoadXML(responce).InnerXml;
		}

		private static string SendString()
		{
//			var url = "https://api.privatbank.ua/p24api/balance";
			var url = "https://api.privatbank.ua/p24api/rest_fiz";
			string xml = Fix("Request.xml");
			xml = Format(xml);

			WebClient client = new WebClient();
			client.Encoding = Encoding.UTF8;

			return client.UploadString(url, xml);
		}

		private static string Format(string xml)
		{
			var password = null;

			var data = ExtractData(xml);
			var signature = CalculateSignature(data + password);
			var file = InsertSignature(xml, signature);

			return file.ToString(SaveOptions.DisableFormatting);
		}

		private static XElement InsertSignature(string xml, string signature)
		{
			XElement file = XElement.Parse(xml);
			var signatureElement = file.Element("merchant").Element("signature");
			signatureElement.SetValue(signature);

			return file;
		}

		private static string ExtractData(string xml)
		{
			XElement file = XElement.Parse(xml);

			var data = new StringBuilder();

			foreach (var element in file.Element("data").Nodes())
				data.Append(element.ToString(SaveOptions.DisableFormatting));

			return data.ToString();
		}

		public static string Fix(string text)
		{
			XElement file = XElement.Load(@"Request.xml");

			return Regex.Replace(file.ToString(SaveOptions.DisableFormatting), @"[^\x20-\x7e]", string.Empty);
		}

		public static XmlDocument LoadXML(byte[] input)
		{
//			XElement file = XElement.Load(@"Request.xml");

			XmlDocument doc = new XmlDocument();
			MemoryStream ms = new MemoryStream(input);
			doc.Load(ms);

			return doc;
		}

		public static byte[] CalculateMD5(string input)
		{
			MD5 md5 = System.Security.Cryptography.MD5.Create();
			byte[] inputBytes = System.Text.Encoding.UTF8.GetBytes(input);

			return md5.ComputeHash(inputBytes);
		}

		public static byte[] CalculateSHA(string input)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(input);

			return CalculateSHA(bytes);
		}

		public static byte[] CalculateSHA(byte[] input)
		{
			SHA1 sha1 = System.Security.Cryptography.SHA1.Create();

			return sha1.ComputeHash(input);
		}

		public static string GetHexString(byte[] bytes)
		{
			var sb = new StringBuilder();

			foreach (byte b in bytes)
			{
				var hex = b.ToString("x2");
				sb.Append(hex);
			}

			return sb.ToString();
		}
	}
}
