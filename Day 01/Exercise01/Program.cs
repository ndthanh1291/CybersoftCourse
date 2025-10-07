Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.Write("Nhập cân nặng (kg): ");
double weight = Convert.ToDouble(Console.ReadLine());

Console.Write("Nhập chiều cao (m): ");
double height = Convert.ToDouble(Console.ReadLine());

double bmi = weight / (height * height);

Console.WriteLine($"Chỉ số BMI của bạn là: {bmi:F2}");
