Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.WriteLine("Nhập một chuỗi:");
string? s = Console.ReadLine();
if (string.IsNullOrWhiteSpace(s))
{
    Console.WriteLine("");
    return;
}
string LongestWordWithDigit(string input)
{
    var words = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
    string result = "";
    foreach (var word in words)
    {
        if (word.Any(char.IsDigit) && word.Length > result.Length)
        {
            result = word;
        }
    }
    return result;
}
string longest = LongestWordWithDigit(s);
Console.WriteLine(longest);
