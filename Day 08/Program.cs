using System.ComponentModel;
using System.Runtime.Intrinsics.Arm;
using System.Text.Json;

Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.InputEncoding = System.Text.Encoding.UTF8;

//Ứng dụng collection
/*
    Input: List<object> =
    {
        {maCongViec=1,tenCongViec = "CongViecA", trangThai: "False"},
        {maCongViec=2,tenCongViec = "CongViecB", trangThai: "True"},
        {maCongViec=3,tenCongViec = "CongViecC", trangThai: "False"},
        {"maCongViec":3,tenCongViec="CongViecC", trangThai:"False" }
    }
*/
List<object> lstTodo = new List<object>()
{
    new
    {
        maCongViec = 1,
        tenCongViec = "An Sang",
        trangThai = false
    },
    new
    {
        maCongViec = 2,
        tenCongViec = "An trua",
        trangThai = false
    }
};

// var ob1 = new { maCongViec = 1, tenCongViec = "An Sang", trangThai = false };
// Console.WriteLine($@"{ob1.tenCongViec}");
/*
[
    {"maCongViec":1,"tenCongViec":"An Sang","trangThai":false}, 0
    {"maCongViec":2,"tenCongViec":"An trua","trangThai":false} 1
]
*/


// Console.WriteLine($@"{JsonSerializer.Serialize(lstTodo)}");

while (true)
{
    Method.HienThiMenuChucNang();
    int chonChucNang = Convert.ToInt32(Console.ReadLine());
    switch (chonChucNang)
    {
        case 1:

            {
                Console.WriteLine($@"Chức năng thêm công việc vào danh sách");
                //Gọi hàm thực thi công việc
                Method.ThemCongViecVaoDanhSach(lstCongViec: ref lstTodo);
            }
            ;
            break;
        case 2:

            {
                Console.WriteLine($@"------Danh sách các công việc hiện tại -------");
                Method.hienThiCongViec(lstTodo);
            }
            ;
            break;
        case 3:

            {
                Method.capNhatThongTin(ref lstTodo);
            }
            ;
            break;
        case 4:

            {
                Method.xoaCongViec(ref lstTodo);
            }
            break;
        case 5:

            {
                Method.timKiemCongViecTheoTen(lstTodo);
            }
            ;
            break;
        case 6:

            {
                Method.tickHoanThanhCongViec(ref lstTodo);
            }
            ;
            break;
        case 7:
            Method.hienThiCongViecChuaHoanThanhTheoThuTu(lstTodo);
            break;
        case 8:
            Method.hienThiCongViecDaHoanThanhTheoThuTu(lstTodo);
            break;
        default:

            {
                Console.WriteLine($@"Có phải bạn muốn thoát ? Bấm phím 9 để thoát");
                chonChucNang = Convert.ToInt32(Console.ReadLine());
            }
            ;
            break;
    }
    if (chonChucNang == 9)
    {
        break;
    }
}

List<int> lst = new List<int>() { 9, 8, 4, 1, 2, 3 }; // 1 2 3 4 8 9

List<int> lstOrder = lst.OrderBy(item => item).Reverse().ToList();
List<string> lstText = new List<string>() { "11ABC", "21AAA", "19999", "1111" };

// 1111 11ABC 19999 21AAA
List<string> lstStringOrder = lstText.OrderBy(s => s).ToList();

List<object> lstTodo1 = new List<object>()
{
    new
    {
        maCongViec = 1,
        tenCongViec = "buoi trua",
        trangThai = false
    },
    new
    {
        maCongViec = 3,
        tenCongViec = "cn sang",
        trangThai = false
    },
    new
    {
        maCongViec = 2,
        tenCongViec = "an sang",
        trangThai = false
    }
};

List<object> lstTodoOrderTenCongViec = lstTodo1
    .OrderBy((dynamic item) => item.tenCongViec)
    .ToList();
List<object> lstTodoOrderTheoMa = lstTodo1.OrderBy((dynamic item) => item.maCongViec).ToList();

Console.WriteLine($@"{JsonSerializer.Serialize(lstTodoOrderTheoMa)}");
