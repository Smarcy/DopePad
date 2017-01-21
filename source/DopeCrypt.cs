using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class DopeCrypt
    {
        public string Dope_encrypt(string text)
        {
            ROT13 rot13 = new ROT13();
            Base64 base64 = new Engine.Base64();

            text = rot13.ROT13_encrypt(text);
            text = base64.Base64Encrypt(text);
            text = rot13.ROT13_encrypt(text);
            text = base64.Base64Encrypt(text);
            text = base64.Base64Encrypt(text);

            return text;
        }

        public string Dope_decrypt(string text)
        {
            ROT13 rot13 = new ROT13();
            Base64 base64 = new Engine.Base64();

            text = base64.Base64Decrypt(text);
            text = base64.Base64Decrypt(text);
            text = rot13.ROT13_encrypt(text);
            text = base64.Base64Decrypt(text);
            text = rot13.ROT13_encrypt(text);

            return text;
        }
    }
}
