using System;
using System.Collections.Generic;

namespace KT.Models
{
    public class DangKyViewModel
    {
        public IEnumerable<dynamic> RegisteredCourses { get; set; }
        public string MaSv { get; set; }
        public string HoTen { get; set; }
        public DateTime NgayDk { get; set; }
        public DateTime? NgaySinh { get; set; } // Cập nhật kiểu dữ liệu thành DateTime?
        public string NganhHoc { get; set; }
        public int? MaDK { get; set; }
    }
}
