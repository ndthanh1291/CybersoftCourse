/*
lstStrings = ["apple", "banana", "orange", "kiwi", "mango", "pineapple", "grape", "melon"]

Tính độ dài của mảng
Yêu cầu: Viết chương trình để đếm số phần tử trong mảng lstStrings.
In ra các chuỗi dài hơn 5 ký tự
Yêu cầu: Viết chương trình để in ra các chuỗi trong lstStrings có độ dài lớn hơn 5 ký tự.
Tìm chuỗi dài nhất trong mảng
Yêu cầu: Viết chương trình để tìm chuỗi có độ dài lớn nhất trong mảng lstStrings.
In ra các chuỗi có chứa chữ 'a'
Yêu cầu: Viết chương trình để in ra tất cả các chuỗi trong lstStrings có chứa chữ cái 'a'.
Tìm chuỗi bắt đầu bằng chữ 'm'
Yêu cầu: Viết chương trình để tìm tất cả các chuỗi trong lstStrings bắt đầu bằng chữ 'm'.
Đếm số chuỗi có độ dài nhỏ hơn 6 ký tự
Yêu cầu: Viết chương trình để đếm số chuỗi có độ dài nhỏ hơn 6 ký tự trong lstStrings.
In ra chuỗi dài thứ hai trong mảng
Yêu cầu: Viết chương trình để tìm và in ra chuỗi dài thứ hai trong mảng lstStrings.
Sắp xếp mảng theo thứ tự bảng chữ cái
Yêu cầu: Viết chương trình để sắp xếp mảng lstStrings theo thứ tự bảng chữ cái (A-Z).
Chuyển tất cả các chuỗi thành chữ hoa
Yêu cầu: Viết chương trình để chuyển tất cả các chuỗi trong lstStrings thành chữ in hoa.
Thay thế chuỗi "banana" bằng "pear"
Yêu cầu: Viết chương trình để thay thế chuỗi "banana" bằng "pear" trong lstStrings.
*/
using System;
using System.Collections.Generic;
using System.Linq;

Console.OutputEncoding = System.Text.Encoding.UTF8;

var lstStrings = new List<string>
{
    "apple",
    "banana",
    "orange",
    "kiwi",
    "mango",
    "pineapple",
    "grape",
    "melon"
};

// 1. Đếm số phần tử trong mảng
Console.WriteLine($"Số phần tử trong mảng: {lstStrings.Count}");

// 2. In ra các chuỗi dài hơn 5 ký tự
Console.WriteLine("Các chuỗi dài hơn 5 ký tự:");
foreach (var str in lstStrings)
{
    if (str.Length > 5)
        Console.WriteLine(str);
}

// 3. Tìm chuỗi dài nhất trong mảng
var longest = lstStrings.OrderByDescending(s => s.Length).First();
Console.WriteLine($"Chuỗi dài nhất: {longest}");

// 4. In ra các chuỗi có chứa chữ 'a'
Console.WriteLine("Các chuỗi chứa chữ 'a':");
foreach (var str in lstStrings)
{
    if (str.Contains('a'))
        Console.WriteLine(str);
}

// 5. Tìm chuỗi bắt đầu bằng chữ 'm'
Console.WriteLine("Các chuỗi bắt đầu bằng chữ 'm':");
foreach (var str in lstStrings)
{
    if (str.StartsWith("m"))
        Console.WriteLine(str);
}

// 6. Đếm số chuỗi có độ dài nhỏ hơn 6 ký tự
int countShort = lstStrings.Count(s => s.Length < 6);
Console.WriteLine($"Số chuỗi có độ dài nhỏ hơn 6 ký tự: {countShort}");

// 7. In ra chuỗi dài thứ hai trong mảng
var secondLongest = lstStrings.OrderByDescending(s => s.Length).Skip(1).First();
Console.WriteLine($"Chuỗi dài thứ hai: {secondLongest}");

// 8. Sắp xếp mảng theo thứ tự bảng chữ cái
var sorted = lstStrings.OrderBy(s => s).ToList();
Console.WriteLine("Mảng sau khi sắp xếp theo thứ tự bảng chữ cái:");
foreach (var str in sorted)
    Console.WriteLine(str);

// 9. Chuyển tất cả các chuỗi thành chữ hoa
var upperList = lstStrings.Select(s => s.ToUpper()).ToList();
Console.WriteLine("Các chuỗi chuyển thành chữ hoa:");
foreach (var str in upperList)
    Console.WriteLine(str);

// 10. Thay thế chuỗi "banana" bằng "pear"
var replacedList = lstStrings.Select(s => s == "banana" ? "pear" : s).ToList();
Console.WriteLine("Mảng sau khi thay thế 'banana' bằng 'pear':");
foreach (var str in replacedList)
    Console.WriteLine(str);
