using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Validation
{
    public sealed class DomainExceptionValidation : Exception
    {
        public DomainExceptionValidation(string error) :base(error)
        {}
        public static void When(bool hasError, string error)
        {
            if (hasError)
            {
                throw new DomainExceptionValidation(error);
            }
        }
        public static bool ValidateInvalidCharacters(string stringValue)
        {
            char[] stringValueToArray = stringValue.ToCharArray();
            char[] invalidCharacters = new char[] {
            '\0', '\a', '\b', '\f', '\n', '\r', '\t', '\v' // Caracteres de escape
            , '!', '"', '#', '$', '%', '&', '\'', '(', ')', '*', '+', ',', '-', '.', '/', // Caracteres especiais
            ':', ';', '<', '=', '>', '?', '@', '[', '\\', ']', '^', '_', '`', '{', '|', '}', '~', // Outros caracteres especiais
            '¨', '§', '°', 'ª', 'º', '´', '`', '£', '¢', '¬', '¦', 'ª', '¯', '·', 'Ç', 'ç' // Caracteres especiais diversos
            };
            foreach (char character in stringValueToArray)
            {
                foreach (char invalidCharacter in invalidCharacters)
                {
                    if (character.Equals(invalidCharacter))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
