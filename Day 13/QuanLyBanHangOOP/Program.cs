using System;
using System.Collections.Generic;

class Program
{
    static List<SanPham> danhSachSanPham = new List<SanPham>();

    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;
        while (true)
        {
            Console.WriteLine("\n--- Hệ thống quản lý bán hàng ---");
            Console.WriteLine("1. Thêm sản phẩm");
            Console.WriteLine("2. Hiển thị danh sách sản phẩm");
            Console.WriteLine("3. Tính tổng doanh thu");
            Console.WriteLine("4. Xóa sản phẩm");
            Console.WriteLine("5. Thoát");
            Console.Write("Vui lòng chọn chức năng: ");
            string chon = Console.ReadLine() ?? "";
            switch (chon)
            {
                case "1":
                    ThemSanPham();
                    break;
                case "2":
                    HienThiDanhSach();
                    break;
                case "3":
                    TinhTongDoanhThu();
                    break;
                case "4":
                    XoaSanPham();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Chức năng không hợp lệ!");
                    break;
            }
        }
    }

    static void ThemSanPham()
    {
        Console.WriteLine("\nChọn loại sản phẩm:");
        Console.WriteLine("1. Điện tử");
        Console.WriteLine("2. Thời trang");
        Console.WriteLine("3. Thực phẩm");
        Console.Write("Lựa chọn: ");
        string loai = Console.ReadLine() ?? "";
        Console.Write("Nhập mã sản phẩm: ");
        string ma = Console.ReadLine() ?? "";
        Console.Write("Nhập tên sản phẩm: ");
        string ten = Console.ReadLine() ?? "";
        Console.Write("Nhập giá gốc: ");
        double giaGoc = 0;
        double.TryParse(Console.ReadLine(), out giaGoc);
        switch (loai)
        {
            case "1":
                Console.Write("Nhập thuế bảo hành (%): ");
                double thue = 0;
                double.TryParse(Console.ReadLine(), out thue);
                danhSachSanPham.Add(new DienTu(ma, ten, giaGoc, thue));
                break;
            case "2":
                Console.Write("Nhập giảm giá (%): ");
                double giam = 0;
                double.TryParse(Console.ReadLine(), out giam);
                danhSachSanPham.Add(new ThoiTrang(ma, ten, giaGoc, giam));
                break;
            case "3":
                Console.Write("Nhập phí vận chuyển: ");
                double phi = 0;
                double.TryParse(Console.ReadLine(), out phi);
                danhSachSanPham.Add(new ThucPham(ma, ten, giaGoc, phi));
                break;
            default:
                Console.WriteLine("Loại sản phẩm không hợp lệ!");
                break;
        }
    }

    static void HienThiDanhSach()
    {
        Console.WriteLine("\nDanh sách sản phẩm:");
        foreach (var sp in danhSachSanPham)
        {
            sp.HienThiThongTin();
            Console.WriteLine();
        }
    }

    static void TinhTongDoanhThu()
    {
        double tong = 0;
        foreach (var sp in danhSachSanPham)
        {
            tong += sp.TinhGiaBan();
        }
        Console.WriteLine($"Tổng doanh thu dự kiến: {tong} VND");
    }

    static void XoaSanPham()
    {
        Console.Write("Nhập mã sản phẩm cần xóa: ");
        string ma = Console.ReadLine() ?? "";
        var sp = danhSachSanPham.Find(x => x.MaSanPham == ma);
        if (sp != null)
        {
            danhSachSanPham.Remove(sp);
            Console.WriteLine("Đã xóa sản phẩm.");
        }
        else
        {
            Console.WriteLine("Không tìm thấy sản phẩm với mã đã nhập.");
        }
    }
}
