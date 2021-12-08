using System;

namespace InformationSercurity.SymmetricKey
{
    /// <summary>
    /// Mật mã <see cref="Playfair"/> sẽ thay thế từng cặp 2 kí tự trong bản rõ bởi 2 kí tự tương ứng 
    /// trong ma trận khoá 5x5.
    /// </summary>
    internal class Playfair
    {
        public static string RemoveDuplicateCharacter(string text)
        {
            var newText = string.Empty;  
            foreach (var character in text)
            {
                if (!newText.Contains(character))
                {
                    newText += character;
                }    
            }
            return newText;
        }

        public static string FillAlphabetCharacters(string text)
        {
            foreach (var alphabetCharacter in Enum.GetNames(typeof(Alphabet)))
            {
                if (!text.ToUpper().Contains(alphabetCharacter))
                {
                    if (!alphabetCharacter.Equals('J'))
                    {
                        text += alphabetCharacter;
                    }    
                }    
            }   
            return text;
        }

        public static char[,] GetKeyMatrix(string key)
        {
            if (key.Length < 25) 
                key = FillAlphabetCharacters(key);

            var index = 0;
            var maxtrix = new char[5, 5];
            for (var i = 0; i < maxtrix.GetLength(0); i++)
            {
                for (var j = 0; j < maxtrix.GetLength(1); j++)
                {
                    maxtrix[i, j] = key[index];
                    index++;
                }    
            }    
            return maxtrix;
        }    

        public static string Encode(string plainText, string key)
        {
            return "";
        }    
    }
}
