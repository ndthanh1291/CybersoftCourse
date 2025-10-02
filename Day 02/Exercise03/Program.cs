Console.OutputEncoding = System.Text.Encoding.UTF8;
int month;
while (true)
{
    Console.Write("Nhập số tháng (1-12): ");
    string? input = Console.ReadLine();
    if (input != null && int.TryParse(input, out month) && month >= 1 && month <= 12)
    {
        break;
    }
    Console.WriteLine("Tháng không hợp lệ. Vui lòng nhập số từ 1 đến 12.");
}

string season = GetSeason(month);
Console.WriteLine($"Tháng {month} thuộc mùa {season}.");

static string GetSeason(int month)
{
    if (month >= 1 && month <= 3)
        return "Xuân";
    else if (month >= 4 && month <= 6)
        return "Hạ";
    else if (month >= 7 && month <= 9)
        return "Thu";
    else
        return "Đông";
}
