/*
lstNumber = [20, 81, 97, 63, 72, 11, 20, 15, 33, 15, 41, 20]

Tính tổng các số lớn hơn 50 trong danh sách
Yêu cầu: Viết chương trình tính tổng các số trong lstNumber mà lớn hơn 50.
Đếm số phần tử lớn hơn 30
Yêu cầu: Viết chương trình đếm số phần tử trong danh sách lstNumber mà lớn hơn 30.
Tìm số lớn nhất trong danh sách
Yêu cầu: Viết chương trình để tìm số lớn nhất trong lstNumber.
Tính trung bình cộng của các số lẻ
Yêu cầu: Viết chương trình để tính trung bình cộng của các số lẻ trong danh sách lstNumber.
In ra các số chẵn trong danh sách
Yêu cầu: Viết chương trình để in ra tất cả các số chẵn trong lstNumber.
Tìm vị trí đầu tiên của số 20 trong danh sách
Yêu cầu: Viết chương trình để tìm vị trí đầu tiên của số 20 trong danh sách lstNumber.
Tìm số lượng phần tử bằng 15 trong danh sách
Yêu cầu: Viết chương trình để đếm số lượng phần tử bằng 15 trong lstNumber.
Tính tổng các số nhỏ hơn 40
Yêu cầu: Viết chương trình tính tổng các số trong danh sách lstNumber nhỏ hơn 40.
Đếm số lượng các số chia hết cho 5
Yêu cầu: Viết chương trình để đếm bao nhiêu số trong danh sách chia hết cho 5.
Tạo danh sách mới chỉ chứa các số nhỏ hơn 50
Yêu cầu: Viết chương trình để tạo một danh sách mới chỉ chứa các số nhỏ hơn 50 từ danh sách lstNumber.
*/


using System;
using System.Collections.Generic;
using System.Linq;

Console.OutputEncoding = System.Text.Encoding.UTF8;

List<int> lstNumber = new List<int> { 20, 81, 97, 63, 72, 11, 20, 15, 33, 15, 41, 20 };

// 1. Tính tổng các số lớn hơn 50
int sumGreater50 = lstNumber.Where(x => x > 50).Sum();
Console.WriteLine($"Tổng các số lớn hơn 50: {sumGreater50}");

// 2. Đếm số phần tử lớn hơn 30
int countGreater30 = lstNumber.Count(x => x > 30);
Console.WriteLine($"Số phần tử lớn hơn 30: {countGreater30}");

// 3. Tìm số lớn nhất trong danh sách
int maxNumber = lstNumber.Max();
Console.WriteLine($"Số lớn nhất: {maxNumber}");

// 4. Tính trung bình cộng của các số lẻ
var oddNumbers = lstNumber.Where(x => x % 2 != 0).ToList();
double avgOdd = oddNumbers.Count > 0 ? oddNumbers.Average() : 0;
Console.WriteLine($"Trung bình cộng các số lẻ: {avgOdd}");

// 5. In ra các số chẵn trong danh sách
var evenNumbers = lstNumber.Where(x => x % 2 == 0);
Console.WriteLine("Các số chẵn trong danh sách: " + string.Join(", ", evenNumbers));

// 6. Tìm vị trí đầu tiên của số 20 trong danh sách
int firstIndex20 = lstNumber.IndexOf(20);
Console.WriteLine($"Vị trí đầu tiên của số 20: {firstIndex20}");

// 7. Tìm số lượng phần tử bằng 15 trong danh sách
int count15 = lstNumber.Count(x => x == 15);
Console.WriteLine($"Số lượng phần tử bằng 15: {count15}");

// 8. Tính tổng các số nhỏ hơn 40
int sumLess40 = lstNumber.Where(x => x < 40).Sum();
Console.WriteLine($"Tổng các số nhỏ hơn 40: {sumLess40}");

// 9. Đếm số lượng các số chia hết cho 5
int countDiv5 = lstNumber.Count(x => x % 5 == 0);
Console.WriteLine($"Số lượng số chia hết cho 5: {countDiv5}");

// 10. Tạo danh sách mới chỉ chứa các số nhỏ hơn 50
var newListLess50 = lstNumber.Where(x => x < 50).ToList();
Console.WriteLine("Danh sách các số nhỏ hơn 50: " + string.Join(", ", newListLess50));
