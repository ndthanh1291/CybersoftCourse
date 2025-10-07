Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.InputEncoding = System.Text.Encoding.UTF8;

Console.WriteLine("Nhập chuỗi:");
string? input = Console.ReadLine();

if (string.IsNullOrWhiteSpace(input))
{
    Console.WriteLine("Chuỗi nhập vào không được để trống.");
}
else
{
    string longest = FindLongestWord(input);
    Console.WriteLine($"Từ dài nhất: {longest}");
}

static string FindLongestWord(string s)
{
    if (string.IsNullOrWhiteSpace(s))
        return "";
    var words = s.Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
    string longest = words.OrderByDescending(w => w.Length).First();
    return longest;
}
