using System;
using System.Collections.Generic;

namespace KT.Models;

public partial class HocPhan
{
    public string MaHp { get; set; } = null!;

    public string TenHp { get; set; } = null!;

    public int? SoTinChi { get; set; }

    public virtual ICollection<DangKy> MaDks { get; set; } = new List<DangKy>();
    public virtual ICollection<ChiTietDangKy> ChiTietDangKies { get; set; } = new HashSet<ChiTietDangKy>();
}
