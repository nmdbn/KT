using System;
using System.Collections.Generic;

namespace KT.Models;

public partial class NganhHoc
{
    public string MaNganh { get; set; } = null!;

    public string? TenNganh { get; set; }

    public virtual ICollection<SinhVien> SinhViens { get; set; } = new List<SinhVien>();
}
