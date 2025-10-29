public class Method
{
    public static void HienThiMenuChucNang()
    {
        Console.WriteLine(
            $@"
        ------------- Hãy chọn 1 trong những chức năng sau của todoapp -----------------
            1. Thêm công việc vào danh sách.
            2. Hiển thị danh sách công việc.
            3. Cập nhật thông tin công việc (tên, mô tả, ngày đến hạn, trạng thái).
            4. Xóa công việc theo tên công việc.
            5. Tìm kiếm công việc theo tên công việc.
            6. Tick hoàn thành công việc
            7. Sắp xêp công việc hiển thị công việc chưa hoàn thành theo thứ tự.
            8. Sắp xêp công việc hiển thị công việc đã hoàn thành theo thứ tự.
            9. Thoát
        "
        );
    }

    public static void ThemCongViecVaoDanhSach(ref List<object> lstCongViec)
    {
        //thêm công việc vào list
        Console.WriteLine($@"Nhập vào mã công việc: ");
        int maCongViec = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine($@"Nhập vào tên việc: ");
        string tenCongViec = Console.ReadLine();
        bool trangThai = false; //Mặc định mới nhập là chưa làm
        //Sau khi đã có 3 thông tin từ người dùng nhập => đưa vào list
        var obCongViec = new
        {
            maCongViec = maCongViec,
            tenCongViec = tenCongViec,
            trangThai = trangThai
        };
        // obCongViec =  {"maCongViec":1,"tenCongViec":"An Sang","trangThai":false}

        //Đưa object công việc vào list
        lstCongViec.Add(obCongViec);
    }

    public static void hienThiCongViec(List<object> lstCongViec)
    {
        foreach (dynamic item in lstCongViec)
        {
            Console.WriteLine($@" {item.maCongViec} - {item.tenCongViec} - {item.trangThai}");
        }
    }

    //    List<object> lstTodo = new List<object>()
    //         {
    //             new { maCongViec = 1, tenCongViec = "An Sang", trangThai = false }, // index: 0
    //             new { maCongViec = 2, tenCongViec = "An trua", trangThai = false }, // 1
    //             new { maCongViec = 3, tenCongViec = "An toi", trangThai = false }, // 2
    //             new { maCongViec = 4, tenCongViec = "Di choi", trangThai = true }, //3
    //             new { maCongViec = 5, tenCongViec = "Lam bai tap", trangThai = false } //4
    //         };
    //  lstTodo.RemoveAt(4);
    // listToDo.findIndex(item => item.maCongViec == 5)
    public static void xoaCongViec(ref List<object> lstCongViec)
    {
        Console.WriteLine($@"Nhập vào mã công việc cần xoá: ");
        int maCongViecCanXoa = Convert.ToInt32(Console.ReadLine()); // 5
        //Dùng hàm find index để tìm ra index công việc cần xoá
        int indexXoa = lstCongViec.FindIndex((dynamic item) => item.maCongViec == maCongViecCanXoa);
        //Nếu tìm thấy thì index sẽ khác -1
        if (indexXoa != -1)
        {
            lstCongViec.RemoveAt(indexXoa);
            Console.WriteLine($@"Xoá thành công");
        }
        else
        {
            Console.WriteLine($@"Không tìm thấy mã công việc tương ứng");
        }
    }

    public static void capNhatThongTin(ref List<object> lstCongViec)
    {
        //Bước 1 tìm ra object trong list, hoặc tìm ra index trong list
        Console.WriteLine($@"Nhập mã công việc cần thay đổi");
        int maCongViecUpdate = Convert.ToInt32(Console.ReadLine());
        //Tìm ra object trong list dựa vào mã
        int indexUpdate = lstCongViec.FindIndex(
            (dynamic item) => item.maCongViec == maCongViecUpdate
        );
        if (indexUpdate != -1)
        { //Tìm ra index của thằng thay đổi
            bool trangThai = ((dynamic)lstCongViec[indexUpdate]).trangThai;

            //Cập nhật bằng cách lấy ra index của người dùng nhập để tìm phần tử trong list và gán nó lại = phần tử khác
            Console.WriteLine($@"Nhập vào tên công việc cần thay đổi");
            lstCongViec[indexUpdate] = new
            {
                maCongViec = maCongViecUpdate,
                tenCongViec = Console.ReadLine(),
                trangThai = trangThai
            };
        }
        else
        {
            Console.WriteLine($@"Không tìm thấy mã công việc tương ứng");
        }
    }

    public static void timKiemCongViecTheoTen(List<object> lstCongViec)
    {
        Console.Write($@"Nhập vào tên công việc cần tìm: ");
        string tuKhoa = Console.ReadLine(); // tap TAP => tap
        //Tìm các tên công việc trong list có chứa chữ tap (từ khoá người dùng nhập vào)
        List<object> lstCongViecTimKiem = lstCongViec.FindAll(
            (dynamic item) => item.tenCongViec.ToLower().Contains(tuKhoa)
        );
        if (lstCongViecTimKiem.Count() > 0)
        {
            foreach (dynamic item in lstCongViecTimKiem)
            {
                Console.WriteLine($@"{item.maCongViec} - {item.tenCongViec} - {item.trangThai}");
            }
        }
        else
        {
            Console.WriteLine($@" Không tìm thấy công việc nào chứa {tuKhoa}");
        }
    }

    public static void tickHoanThanhCongViec(ref List<object> lstCongViec)
    {
        //Bước 1 tìm ra object trong list, hoặc tìm ra index trong list
        Console.WriteLine($@"Nhập mã công việc đã hoàn thành");
        int maCongViecUpdate = Convert.ToInt32(Console.ReadLine());
        //Tìm ra object trong list dựa vào mã
        int indexUpdate = lstCongViec.FindIndex(
            (dynamic item) => item.maCongViec == maCongViecUpdate
        );
        if (indexUpdate != -1)
        { //Tìm ra index của thằng thay đổi
            bool trangThai = ((dynamic)lstCongViec[indexUpdate]).trangThai;
            //Cập nhật bằng cách lấy ra index của người dùng nhập để tìm phần tử trong list và gán nó lại = phần tử khác
            lstCongViec[indexUpdate] = new
            {
                maCongViec = maCongViecUpdate,
                tenCongViec = ((dynamic)lstCongViec[indexUpdate]).tenCongViec,
                trangThai = true
            };
        }
        else
        {
            Console.WriteLine($@"Không tìm thấy mã công việc tương ứng");
        }
    }

    // 7. Sắp xếp công việc chưa hoàn thành theo thứ tự tên công việc
    public static void hienThiCongViecChuaHoanThanhTheoThuTu(List<object> lstCongViec)
    {
        var lstChuaHoanThanh = lstCongViec
            .Where((dynamic item) => item.trangThai == false)
            .OrderBy((dynamic item) => item.tenCongViec)
            .ToList();
        if (lstChuaHoanThanh.Count > 0)
        {
            Console.WriteLine($@"--- Danh sách công việc chưa hoàn thành (theo thứ tự tên) ---");
            foreach (dynamic item in lstChuaHoanThanh)
            {
                Console.WriteLine($@"{item.maCongViec} - {item.tenCongViec} - {item.trangThai}");
            }
        }
        else
        {
            Console.WriteLine($@"Không có công việc chưa hoàn thành.");
        }
    }

    // 8. Sắp xếp công việc đã hoàn thành theo thứ tự tên công việc
    public static void hienThiCongViecDaHoanThanhTheoThuTu(List<object> lstCongViec)
    {
        var lstDaHoanThanh = lstCongViec
            .Where((dynamic item) => item.trangThai == true)
            .OrderBy((dynamic item) => item.tenCongViec)
            .ToList();
        if (lstDaHoanThanh.Count > 0)
        {
            Console.WriteLine($@"--- Danh sách công việc đã hoàn thành (theo thứ tự tên) ---");
            foreach (dynamic item in lstDaHoanThanh)
            {
                Console.WriteLine($@"{item.maCongViec} - {item.tenCongViec} - {item.trangThai}");
            }
        }
        else
        {
            Console.WriteLine($@"Không có công việc đã hoàn thành.");
        }
    }
}
