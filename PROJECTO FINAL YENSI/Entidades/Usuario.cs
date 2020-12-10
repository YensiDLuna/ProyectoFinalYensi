using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace PROJECTO_FINAL_YENSI.Entidades
{
	public class Usuario
	{
		public int UsuarioID { get; set; }
		public string Nombre { get; set; }
		public string UserName { get; set; }
		public string PassWord { get; set; }
		public string TipoUsuario { get; set; }

		public Usuario(int usuarioID, string nombre, string userName, string passWord, string tipoUsuario)
		{
			UsuarioID = usuarioID;
			Nombre = nombre;
			UserName = userName;
			PassWord = getHashSha256(passWord);
			TipoUsuario = tipoUsuario;
		}
		public Usuario()
		{
			
		}
		public static string getHashSha256(string text)
		{
			byte[] bytes = Encoding.Unicode.GetBytes(text);
			SHA256Managed hashstring = new SHA256Managed();
			byte[] hash = hashstring.ComputeHash(bytes);
			string hashString = string.Empty;
			foreach (byte x in hash)
			{
				hashString += String.Format("{0:x2}", x);
			}
			return hashString;
		}
	}
}
