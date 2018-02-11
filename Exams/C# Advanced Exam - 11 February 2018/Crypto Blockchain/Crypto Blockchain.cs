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
        var numberOfLines = int.Parse(ReadLine());

        var message = new StringBuilder();
        while (numberOfLines-- > 0)
            message.Append(ReadLine());

        var blocks = GetValidBlocks(message.ToString());

        var cryptoBlocks = GetValidCryptoBlocks(blocks);

        var decryptedMessage = GecryptMessage(cryptoBlocks);

        Write(decryptedMessage);
    }

    private static string GecryptMessage(List<KeyValuePair<string, string>> cryptoBlocks)
    {
        var sB = new StringBuilder();
        var innerSb = new StringBuilder();
        foreach (var cryptoMessage in cryptoBlocks)
        {
            var cryptoMessageLength = cryptoMessage.Value.Length;
            var code = cryptoMessage.Key;

            for (int i = 0; i < code.Length; i += 3)
            {
                for (int j = i; j < i + 3; j++)
                    innerSb.Append(code[j]);

                var digit = int.Parse(innerSb.ToString());
                var letter = (char)(digit - cryptoMessageLength);
                sB.Append(letter);
                innerSb.Clear();
            }
        }
        sB.AppendLine();

        return sB.ToString();
    }

    private static Queue<string> GetValidBlocks(string message) => new Queue<string>(Regex.Matches(message, @"(\[[^\{\}\[\]]+\])|(\{[^\{\}\[\]]+\})").Cast<Match>().Select(m => m.Value));

    private static List<KeyValuePair<string, string>> GetValidCryptoBlocks(Queue<string> blocks)
    {
        var pattern = new Regex(@"\d{3,}");
        var encryptedCode = new List<KeyValuePair<string, string>>();

        while (blocks.Count > 0)
        {
            var block = blocks.Dequeue();
            if (pattern.IsMatch(block))
            {
                var code = pattern.Match(block).Value;
                if (code.Length % 3 == 0)
                    encryptedCode.Add(new KeyValuePair<string, string>(code, block));
            }
        }

        return encryptedCode;
    }
}