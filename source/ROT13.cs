using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class ROT13
    {
        public string ROT13_encrypt(string text)
        {
            char[] textArray = text.ToCharArray();
                        

            for(int i = 0; i < textArray.Length; i++)
            {
                int number = (int)textArray[i];

                if (number >= 'a' && number <= 'z')
                {
                    if (number > 'm')                    
                        number -= 13;
                    else                    
                        number += 13;                    
                }
                else if (number >= 'A' && number <= 'Z')
                {
                    if (number > 'M')                    
                        number -= 13;                    
                    else                    
                        number += 13;                    
                }

                textArray[i] = (char)number;
            }
            return new string(textArray);
        }
    }

}
