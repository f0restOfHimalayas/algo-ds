using cp_practice.test;

namespace cp_practice.word_break;

public static class WordBreak
{
    public static void Solve()
    {
        var input = File.ReadAllLines("word-break\\input.txt");
        var testCaseCount = int.Parse(input[0]);
        for (var i = 1; i <= testCaseCount; i++)
        {
            var inputStart = 1 + (i - 1) * 3;
            var wordList = input[inputStart].Split(' ');
            var str = input[inputStart + 1];
            Solve(wordList, str);
        }
    }

    private static void Solve(string[] wordlist, string s)
    {
        var dictionary = new Dictionary<string, int>();
        foreach (var word in wordlist)
        {
            if (!dictionary.ContainsKey(word))
            {
                dictionary.Add(word, 0);
            }
        }

        var output = Recursive(dictionary, s, 0, 1);
        Input.PrintLn(output);
    }

    private static bool Recursive(Dictionary<string, int> wordList, string s, int startIndex, int length)
    {
        if (string.IsNullOrWhiteSpace(s))
        {
            return false;
        }

        if (startIndex + length > s.Length)
        {
            return false;
        }

        var substring = s.Substring(startIndex, length);
        if (wordList.ContainsKey(substring))
        {
            var index = startIndex + length;
            if (index  == s.Length)
            {
                return true;
            }
            var endOfSentenceReached = Recursive(wordList, s, index, 1);
            if (endOfSentenceReached)
            {
                return true;
            }
        }

        return Recursive(wordList, s, startIndex, length + 1);
    }
}