namespace Primakey;

/// <summary>
/// Algorithm to calculate a check character from the same character set as the input string.
/// </summary>
internal static class LuhnModNAlgorithm
{
    /// <summary>
    /// Calculates the check character for the input string.
    /// </summary>
    public static char Calculate(string input, string characterSet)
    {
        var sum = 0;
        for (var i = 0; i < input.Length; i++)
        {
            var index = input.Length - 1 - i;
            var codePoint = characterSet.IndexOf(input[index]);
            if (i % 2 == 0)
            {
                codePoint *= 2;
                if (codePoint > characterSet.Length - 1)
                {
                    codePoint -= characterSet.Length - 1;
                }
            }
            
            sum += codePoint;
        }
        
        var result = (characterSet.Length - sum % characterSet.Length) % characterSet.Length;

        return characterSet[result];
    }
}