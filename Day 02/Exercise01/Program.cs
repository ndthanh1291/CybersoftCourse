Console.OutputEncoding = System.Text.Encoding.UTF8;

double temp;
while (true)
{
    Console.Write("Nhập nhiệt độ (°C): ");
    string? input = Console.ReadLine();
    if (input != null && double.TryParse(input, out temp))
    {
        break;
    }
    Console.WriteLine("Giá trị nhập không hợp lệ! Vui lòng nhập lại.");
}

if (temp > 0)
{
    Console.WriteLine("🌤️ Trời ấm");
}
else if (temp < 0)
{
    Console.WriteLine("❄️ Trời lạnh, có thể có băng giá!");
}
else
{
    Console.WriteLine("🌫️ Trời rất lạnh, đúng 0°C!");
}
