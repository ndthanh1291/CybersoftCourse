Console.OutputEncoding = System.Text.Encoding.UTF8;
int kWh;
while (true)
{
    Console.Write("Nhập số điện tiêu thụ trong tháng (kWh): ");
    if (int.TryParse(Console.ReadLine(), out kWh) && kWh >= 0)
    {
        break;
    }
    Console.WriteLine("Giá trị nhập không hợp lệ. Vui lòng nhập lại!");
}

int total = 0;
if (kWh < 100)
{
    total = kWh * 1500;
}
else if (kWh <= 200)
{
    total = 99 * 1500 + (kWh - 99) * 2000;
}
else
{
    total = 99 * 1500 + 101 * 2000 + (kWh - 200) * 2500;
}

Console.WriteLine($"Tiền điện phải trả: {total:N0} VND");
