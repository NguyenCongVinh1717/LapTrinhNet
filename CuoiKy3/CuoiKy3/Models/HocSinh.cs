using System;
using System.Collections.Generic;

namespace CuoiKy3.Models;

public partial class HocSinh
{
    public string MaHs { get; set; } = null!;

    public string? HoTen { get; set; }

    public DateOnly? NgaySinh { get; set; }

    public string? GioiTinh { get; set; }

    public string? ConTbls { get; set; }

    public string? MaLop { get; set; }

    public virtual Lop? MaLopNavigation { get; set; }
}
