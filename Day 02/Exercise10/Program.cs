Console.OutputEncoding = System.Text.Encoding.UTF8;
void ShowEconomyBenefits()
{
    Console.WriteLine("Economy: Ghế thường");
}

void ShowBusinessBenefits()
{
    Console.WriteLine("Business: Ghế rộng");
}

void ShowFirstClassBenefits()
{
    Console.WriteLine("FirstClass: Ghế sang trọng");
}

while (true)
{
    bool valid = false;
    do
    {
        Console.WriteLine("Chọn loại vé:");
        Console.WriteLine("1. Economy");
        Console.WriteLine("2. Business");
        Console.WriteLine("3. FirstClass");
        Console.Write("Vui lòng chọn loại vé (1, 2, 3): ");
        var keyInfo = Console.ReadKey(true);
        char keyChar = keyInfo.KeyChar;
        Console.WriteLine(keyChar);

        switch (keyChar)
        {
            case '1':
                ShowEconomyBenefits();
                valid = true;
                break;
            case '2':
                ShowBusinessBenefits();
                valid = true;
                break;
            case '3':
                ShowFirstClassBenefits();
                valid = true;
                break;
            default:
                Console.WriteLine("Số loại vé không hợp lệ. Vui lòng nhập 1, 2 hoặc 3.");
                break;
        }
    } while (!valid);

    Console.Write("Bạn có muốn chọn vé khác không? (y/n): ");
    var againKey = Console.ReadKey(true);
    Console.WriteLine(againKey.KeyChar); // Hiển thị phím vừa nhấn
    if (char.ToLower(againKey.KeyChar) != 'y')
    {
        break;
    }
}
