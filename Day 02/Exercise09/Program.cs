Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.WriteLine("Nhấn một ký tự tiếng Anh để phân loại, hoặc ESC để thoát.");
while (true)
{
    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
    char keyChar = keyInfo.KeyChar;
    if (keyInfo.Key == ConsoleKey.Escape)
    {
        Console.WriteLine("Kết thúc chương trình.");
        break;
    }
    if (char.IsLetter(keyChar))
    {
        char c = char.ToLower(keyChar);
        if ("aeiou".Contains(c))
        {
            Console.WriteLine($"{c} Là nguyên âm");
        }
        else
        {
            Console.WriteLine($"{c} Là phụ âm");
        }
    }
    else
    {
        Console.WriteLine("❌ Vui lòng nhấn một ký tự chữ cái tiếng Anh hợp lệ hoặc ESC để thoát.");
    }
}
