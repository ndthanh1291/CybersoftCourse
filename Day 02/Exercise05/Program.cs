Console.OutputEncoding = System.Text.Encoding.UTF8;

bool IsPrime(int n, int divisor = 2)
{
    if (n < 2)
        return false;
    if (n == 2)
        return true;
    if (n % divisor == 0)
        return false;
    if (divisor * divisor > n)
        return true;
    return IsPrime(n, divisor + 1);
}

int number;
while (true)
{
    Console.Write("Nhập một số nguyên: ");
    string? input = Console.ReadLine();
    if (int.TryParse(input, out number) && number >= 0)
        break;
    Console.WriteLine("Vui lòng nhập một số nguyên không âm hợp lệ.");
}

if (IsPrime(number, 2))
    Console.WriteLine($"{number} là số nguyên tố.");
else
    Console.WriteLine($"{number} không phải là số nguyên tố.");
