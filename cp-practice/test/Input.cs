namespace cp_practice.test;

public static class Input
{
    public static void PrintLn<TK>(IEnumerable<TK> inputs) where TK : notnull
    {
        foreach (var input in inputs)
        {
            Console.WriteLine(input.ToString());
        }
    }

    public static void PrintLn<TK>(List<TK> inputs) where TK : notnull
    {
        foreach (var input in inputs)
        {
            Console.WriteLine(input.ToString());
        }
    }

    public static void Print<TK>(List<TK> inputs) where TK : notnull
    {
        foreach (var input in inputs)
        {
            Console.Write(input + " ");
        }

        Console.WriteLine();
    }

    public static void PrintLn<TK>(TK input) where TK : notnull
    {
        Console.WriteLine(input.ToString());
    }

    public static void PrintLn<TK, TV>(Dictionary<TK, TV> dictionary) where TK : notnull
    {
        foreach (var (key, value) in dictionary)
        {
            Console.WriteLine($"{key.ToString()}: {value}");
        }
    }
}