namespace Primakey;

public sealed class LuhnModNAlgorithmTests
{
    [Theory]
    [InlineData("abcdef", "abcdef", 'e')]
    [InlineData("1234567890", "0123456789", '3')]
    [InlineData("1789372997", "0123456789", '4')]
    [InlineData("542523343010990", "0123456789", '3')]
    [InlineData("222300004841001", "0123456789", '0')]
    [InlineData("1134806pjfb000010013cd18", "0123456789abcdefghijklmnopqrstuvwxyz", 'd')]
    public void Calculates_check_character(string input, string characterSet, char expected)
    {
        // Act
        var actual = LuhnModNAlgorithm.Calculate(input, characterSet);

        // Assert
        Assert.Equal(expected, actual);
    }
}