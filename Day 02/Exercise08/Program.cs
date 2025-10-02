Console.OutputEncoding = System.Text.Encoding.UTF8;
double soKm = 0;
while (true)
{
    Console.Write("Nhập số km đã đi: ");
    string? input = Console.ReadLine();
    if (double.TryParse(input, out soKm) && soKm > 0)
    {
        break;
    }
    Console.WriteLine("Số km không hợp lệ. Vui lòng nhập lại!");
}

double tienCuoc = 0;
if (soKm <= 1)
{
    tienCuoc = soKm * 10000;
}
else if (soKm <= 5)
{
    tienCuoc = 10000 + (soKm - 1) * 8000;
}
else
{
    tienCuoc = 10000 + 4 * 8000 + (soKm - 5) * 6000;
}

Console.WriteLine($"Tiền cước taxi: {tienCuoc:N0} VND");
