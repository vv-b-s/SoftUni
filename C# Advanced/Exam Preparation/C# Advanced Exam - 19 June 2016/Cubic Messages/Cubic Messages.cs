using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using static System.Console;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        var verificationCodeMessage = new List<KeyValuePair<string, string>>();

        var input = "";
        var encryptedMessage = "";
        for(long i=0;(input=ReadLine())!="Over!";i++)
        {
            if(i%2==0)
                encryptedMessage = input;
            else
            {
                var verificationNum = int.Parse(input);

                var match = Regex.Match(encryptedMessage, $@"^\d+(?<message>[A-Za-z]{'{'}{verificationNum}{'}'})[^A-Za-z]*$");
                if (match.Length > 0)
                {
                    var message = match.Groups["message"].Value;

                    var verificationCode = new StringBuilder();

                    foreach (var character in encryptedMessage)
                    {
                        if (char.IsDigit(character))
                        {
                            var index = (int)char.GetNumericValue(character);

                            verificationCode.Append(index < message.Length ? message[index] : ' ');
                        }
                    }

                    verificationCodeMessage.Add(new KeyValuePair<string, string>(verificationCode.ToString(), message));
                }
            }
        }

        foreach (var message in verificationCodeMessage)
            WriteLine($"{message.Value} == {message.Key}");
    }
}
