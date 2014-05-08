using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wiki.Common.Util;
using System.Text;

namespace Wiki.Web.Classes.Util
{
    public class URLParams
    {

        #region Codificar y decodificar parametros en URL

        public string EncodeParam(string value)
        {
            value = Encryption.Encrypt(value);
            value = HttpUtility.UrlEncode(value, Encoding.ASCII);
            return value;
        }

        public string DecodeParam(string value)
        {
            value = HttpUtility.UrlDecode(value, Encoding.ASCII);
            if (value.Contains(' '))
            {
                value = value.Replace(' ', '+');
            }
            value = Encryption.Decrypt(value);
            return value;
        }

        #endregion

    }
}