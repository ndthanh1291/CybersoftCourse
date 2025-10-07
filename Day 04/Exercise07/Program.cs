using System.Text.RegularExpressions;

Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.Write("Nhập chuỗi: ");
string? input = Console.ReadLine();
if (!string.IsNullOrWhiteSpace(input))
{
    string output = Regex.Replace(input, @"[^a-zA-Z0-9\s]", "");
    Console.WriteLine(output);
}
else
{
    Console.WriteLine("Input is null or empty.");
}
