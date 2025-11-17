abstract class SanPham
{
    public string MaSanPham { get; set; }
    public string TenSanPham { get; set; }
    public double GiaGoc { get; set; }

    public SanPham(string ma, string ten, double giaGoc)
    {
        MaSanPham = ma;
        TenSanPham = ten;
        GiaGoc = giaGoc;
    }

    public abstract double TinhGiaBan();

    public virtual void HienThiThongTin()
    {
        Console.Write($"Mã: {MaSanPham}, Tên: {TenSanPham}, Giá bán: {TinhGiaBan()} VND");
    }
}
