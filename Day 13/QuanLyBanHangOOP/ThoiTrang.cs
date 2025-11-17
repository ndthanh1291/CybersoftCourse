class ThoiTrang : SanPham
{
    public double GiamGia { get; set; }

    public ThoiTrang(string ma, string ten, double giaGoc, double giamGia)
        : base(ma, ten, giaGoc)
    {
        GiamGia = giamGia;
    }

    public override double TinhGiaBan()
    {
        return GiaGoc - GiaGoc * GiamGia / 100.0;
    }

    public override void HienThiThongTin()
    {
        base.HienThiThongTin();
        Console.Write($", Giảm giá: {GiamGia}%\n");
    }
}
