Console.OutputEncoding = System.Text.Encoding.UTF8;
int age;
while (true)
{
    Console.Write("Nhập tuổi công dân: ");
    string? input = Console.ReadLine();
    if (int.TryParse(input, out age) && age > 0)
    {
        break;
    }
    Console.WriteLine("Vui lòng nhập một số nguyên dương hợp lệ!");
}

if (age < 18)
{
    Console.WriteLine("❌ Chưa đủ tuổi tham gia NVQS");
}
else if (age <= 27)
{
    Console.WriteLine("✅ Đủ tuổi tham gia NVQS");
}
else
{
    Console.WriteLine("⛔ Quá tuổi tham gia NVQS");
}
