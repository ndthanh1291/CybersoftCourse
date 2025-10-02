Console.OutputEncoding = System.Text.Encoding.UTF8;
void ShowStandardBenefits()
{
    Console.WriteLine("Standard: Ghế ngồi thường, không có đồ uống");
}

void ShowPremiumBenefits()
{
    Console.WriteLine("Premium: Ghế ngồi thoải mái, có đồ uống miễn phí");
}

void ShowVIPBenefits()
{
    Console.WriteLine("VIP: Ghế ngồi hạng sang, có đồ uống và bỏng ngô miễn phí");
}

while (true)
{
    string? input = null;
    bool valid = false;
    do
    {
        Console.WriteLine("Chọn hạng vé:");
        Console.WriteLine("1. Standard");
        Console.WriteLine("2. Premium");
        Console.WriteLine("3. VIP");
        Console.Write("Nhập số hạng vé (1, 2, 3): ");
        input = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Vui lòng nhập số hạng vé.");
            continue;
        }

        switch (input.Trim())
        {
            case "1":
                ShowStandardBenefits();
                valid = true;
                break;
            case "2":
                ShowPremiumBenefits();
                valid = true;
                break;
            case "3":
                ShowVIPBenefits();
                valid = true;
                break;
            default:
                Console.WriteLine("Số hạng vé không hợp lệ. Vui lòng nhập 1, 2 hoặc 3.");
                break;
        }
    } while (!valid);

    Console.Write("Bạn có muốn chọn vé khác không? (y/n): ");
    string? again = Console.ReadLine();
    if (again == null || again.Trim().ToLower() != "y")
    {
        break;
    }
}
