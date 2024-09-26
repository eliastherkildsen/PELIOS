using System.Text.RegularExpressions;

namespace WPF_MVVM_TEMPLATE.Infrastructure;

public static partial class WordService
{
    [GeneratedRegex(@"^[a-zA-ZæøåÆØÅ]+$", RegexOptions.Compiled)]
    private static partial Regex MyRegex();

    /// <summary>
    /// Checks if the input is one word without numbers using Regex
    /// </summary>
    /// <param name="input"></param>
    /// <returns>bool</returns>
    public static bool CheckOneWord(string input)
    {
        var regex = MyRegex();
        return regex.IsMatch(input);
    }
    
}