using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KT.Models
{
    public class ChiTietDangKy
    {
        [Key, Column(Order = 0)]
        public int MaDk { get; set; }
        [Key, Column(Order = 1)]
        public string MaHp { get; set; }

        [ForeignKey("MaDk")]
        public virtual DangKy DangKy { get; set; }

        [ForeignKey("MaHp")]
        public virtual HocPhan HocPhan { get; set; }
    }
}
