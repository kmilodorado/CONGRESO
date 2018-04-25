using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace CongresoTIC.Models
{
    public class Security
    {
        public byte[] Clave = Encoding.ASCII.GetBytes("dnos_#$%a.9630");
        public byte[] IV = Encoding.ASCII.GetBytes("Devjoker7.37hAES");

        private string[] inj = new string[11] {
         "' or 1=1 or \"='",
        "' or 1=1--",
        "' or 1=1#",
        "' or 1=1/*",
        "') or '1'='1--",
        "') or ('1'='1--",
        "' or 1=1--",
        "or 1=1--",
        "or 1=1",
        "' or 1=1 or '",
        "aaaa' OR 'a'='a"};

        public bool ValidarIngreso(string user, string pass)
        {
            return Validar(user, pass);
        }
        public bool Validar(string email, string clave)
        {
            if ((email = email.Trim()).Length > 0
                    && (clave = clave.Trim()).Trim().Length > 0)
            {
                string aux_email = RegularEspacios(email);
                string aux_clave = RegularEspacios(clave);
                foreach (string inj1 in inj)
                {
                    if (inj1.Equals(aux_email)
                            || inj1.Equals(Comilla_to_simple(aux_email))
                            || inj1.Equals(aux_clave)
                            || inj1.Equals(Comilla_to_simple(aux_clave))
                        || email.Contains(inj1)
                        || clave.Contains(inj1))
                    {
                        return false;
                    }
                }
            }
            return ValidacionEmail(email);
        }

        private String Comilla_to_simple(String sql_)
        {
            return sql_.Replace("'", "\"");
        }

        private String RegularEspacios(String sql)
        {
            String aux_sql = "";
            sql = sql.Trim();
            for (int i = 0; i < sql.Length; i++)
            {
                if (sql[i] == ' ' && sql[i] == sql[i + 1])
                {
                    continue;
                }
                aux_sql += sql[i];
            }
            return aux_sql;
        }

        public bool ValidacionEmail(string input)
        {
            input = input.Trim();

            Regex regex = new Regex(@"[-\\w\\.]+@\\w+\\.\\w+");
            Match match = regex.Match(input);
            if (match.Success)
            {
                return false;
            }
            regex = new Regex(@"^www.");
            match = regex.Match(input);
            if (match.Success)
            {
                return false;
            }
            regex = new Regex(@"[^A-Za-z0-9.@_-~#]+");
            match = regex.Match(input);
            if (match.Success)
            {
                return false;
            }

            return true;
        }

        public string Encripta(string Cadena)
        {

            byte[] inputBytes = Encoding.ASCII.GetBytes(Cadena);
            byte[] encripted;
            RijndaelManaged cripto = new RijndaelManaged();
            using (MemoryStream ms = new MemoryStream(inputBytes.Length))
            {
                using (CryptoStream objCryptoStream = new CryptoStream(ms, cripto.CreateEncryptor(Clave, IV), CryptoStreamMode.Write))
                {
                    objCryptoStream.Write(inputBytes, 0, inputBytes.Length);
                    objCryptoStream.FlushFinalBlock();
                    objCryptoStream.Close();
                }
                encripted = ms.ToArray();
            }
            return Convert.ToBase64String(encripted);
        }

        public string Desencripta(string Cadena)
        {
            byte[] inputBytes = Convert.FromBase64String(Cadena);
            byte[] resultBytes = new byte[inputBytes.Length];
            string textoLimpio = String.Empty;
            RijndaelManaged cripto = new RijndaelManaged();
            using (MemoryStream ms = new MemoryStream(inputBytes))
            {
                using (CryptoStream objCryptoStream = new CryptoStream(ms, cripto.CreateDecryptor(Clave, IV), CryptoStreamMode.Read))
                {
                    using (StreamReader sr = new StreamReader(objCryptoStream, true))
                    {
                        textoLimpio = sr.ReadToEnd();
                    }
                }
            }
            return textoLimpio;
        }

    }
}