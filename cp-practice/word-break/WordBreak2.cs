using cp_practice.test;

namespace cp_practice.word_break;

public class WordBreak2
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

        var words = new List<string>();
        var output = Recursive(dictionary, s, words);
        if (output)
        {
            words.Reverse();
            Input.Print(words);
        }
        else
        {
            Console.WriteLine("No solution");
        }
    }

    private static bool Recursive(Dictionary<string,int> dictionary, string s, List<string> words)
    {
        for (var len = 1; len <= s.Length; len++)
        {
            var subStr = s.Substring(0, len);
            if (dictionary.ContainsKey(subStr))
            {
                if (len == s.Length)
                {
                    words.Add(subStr);
                    return true;
                }

                var nextStr = s.Substring(len);
                var endReached = Recursive(dictionary, nextStr, words);
                if (endReached)
                {
                    words.Add(subStr);
                    return true;
                }
            }
        }

        return false;
    }
}