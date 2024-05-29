using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SinukovUP
{
    internal class CheckInputData
    {
        // Проверка нмоера телефона
        public bool checkInputPhoneNumber(string inputPhoneNumberExample)
        {
            // Допустимый формат номера: 8NNNNNNNNNN
            Regex outPlusPhoneNumberController = new Regex(
               "[8][0-9]{10}");

            return outPlusPhoneNumberController.IsMatch(inputPhoneNumberExample);
        }

        // Защита от SQLI
        public bool checkSQLI(string example)
        {
            if (example.Length == 0)
                return false;
            string[] incorrectSymbols = new string[3] { "'", "-", ";" };
            for (int symbolIndex = 0; symbolIndex < 3; symbolIndex++)
            {
                if (example.Contains(incorrectSymbols[symbolIndex]))
                    return false;
            }
            return true;
        }
    }
}
