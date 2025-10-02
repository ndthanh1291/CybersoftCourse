Console.OutputEncoding = System.Text.Encoding.UTF8;

decimal income = -1;
while (true)
{
    Console.Write("Nhập thu nhập hàng tháng (VND): ");
    string? input = Console.ReadLine();
    if (!decimal.TryParse(input, out income))
    {
        Console.WriteLine("Vui lòng nhập số hợp lệ!");
        continue;
    }
    if (income < 0)
    {
        Console.WriteLine("Thu nhập phải là số dương!");
        continue;
    }
    break;
}

decimal tax = 0;
string message;
if (income <= 5000000)
{
    message = "✅ Miễn thuế";
}
else if (income <= 10000000)
{
    tax = income * 0.10m;
    message = $"💰 Thuế phải nộp: {tax:N0} VND";
}
else
{
    tax = income * 0.20m;
    message = $"💸 Thuế phải nộp: {tax:N0} VND";
}
Console.WriteLine(message);
