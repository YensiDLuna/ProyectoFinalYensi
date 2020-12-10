using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace PROJECTO_FINAL_YENSI.BLL
{
	public class Utilidades
	{
        public static int ToInt(string valor)

        {

            int retorno = 0;



            int.TryParse(valor, out retorno);



            return retorno;

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
        public static decimal ToDecimal(string value)
        {
            decimal return_ = 0;

            decimal.TryParse(value, out return_);

            return return_;
        }

    }
}
