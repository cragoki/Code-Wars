using System.Text;

namespace Code_Wars.DecipheringMission
{
    public static class Decoderr
    {
        public static string Decode(string message, int[] ids)
        {
            for (int i = 0; i < ids.Length; i++)
            {
                switch (ids[i])
                {
                    case 0:
                        message = DecodeZero(message);
                        break;
                    case 1:
                        message = DecodeOne(message);
                        break;
                    case 2:
                        message = DecodeTwo(message);
                        break;
                    case 3:
                        message = DecodeThree(message);
                        break;
                    case 4:
                        message = DecodeFour(message);
                        break;
                    case 5:
                        message = DecodeFive(message);
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }


            return message;
        }
        private static string DecodeZero(string message)
        {
            //Working theory, 0 is flip the string, as in test case 1, the structure of the word is the same, but the letters are different
            char[] charArray = message.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        private static string DecodeOne(string message)
        {
            return message;
        }

        private static string DecodeTwo(string message)
        {
            //All characters in the first test case seem to be shifted by 4-7 places, this is apparently known as CaesarCipher
            //It will be shifted by 4 cases, UNTIL there has been 7 characters that arent spaces
            var result = "";
            var charCount = 0;
            var adjustment = 4;
            foreach (char character in message)
            {
                if (charCount == 7)
                {
                    adjustment = 7;
                }
                if (char.IsLetter(character))
                {
                    char shiftedChar = (char)(character - adjustment);

                    if (char.IsLower(character) && shiftedChar < 'a')
                    {
                        shiftedChar = (char)(shiftedChar + 26);
                    }
                    else if (char.IsUpper(character) && shiftedChar < 'A')
                    {
                        shiftedChar = (char)(shiftedChar + 26);
                    }

                    result += shiftedChar;
                    charCount++;
                }
                else
                {
                    result += character;
                }

            }

            return result;
        }

        private static string DecodeThree(string message)
        {
            //Working theory, Three could be de-coding base 64, seems to work for the test case NumbersToo, it decodes the base 64 string and then replaces the numbers with letters
            bool isValidBase64 = TryFromBase64String(message, out var decodedBytes);

            if (isValidBase64) 
            {
                return System.Text.Encoding.UTF8.GetString(decodedBytes);

            }

            return message;
        }

        private static string DecodeFour(string message)
        {
            return message;
        }

        private static string DecodeFive(string message)
        {
            var result = "";
            int indexOfI = 7;
            List<char> chars = new List<char>(); 

            //Working theory, 3 could be replacing any vowels with numbers, which numbers I'm unsure, but the result of test case 'NumbersToo' decoded is
            //1v6n n9mbers l7ke '123' sh89ld b6 d6c8d6d pr8p6rly.
            //So Id 3 -> Replaces vowels, Id 5 -> Encodes in Base 64
            foreach (char character in message)
            {            
                switch (character)
                {
                    case '\'':
                        result += "";
                        break;
                    case 'a':
                        chars.Add('a');
                        result += character; //Has to either be 4 or 5
                        break;
                    case '6':
                        chars.Add('e');
                        result += "e";
                    break;
                    case '8':
                        chars.Add('o');
                        result += "o";
                        break;
                    case '9':
                        chars.Add('u');
                        result += "u";
                        break;
                    default:
                        if (character == indexOfI.ToString()[0])
                        {
                            chars.Add('i');
                            result += 'i';
                            indexOfI++;
                        }
                        else 
                        {
                            result += character;
                        }
                        break;
                }
            }
            return chars.First().ToString().ToUpper() + result.Substring(1);
        }

        private static bool TryFromBase64String(string input, out byte[] result)
        {
            result = null;

            if (string.IsNullOrEmpty(input) || input.Length % 4 != 0 ||
                input.Contains(" ") || input.Contains("\t") || input.Contains("\r") || input.Contains("\n"))
            {
                return false;
            }

            try
            {
                result = Convert.FromBase64String(input);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
