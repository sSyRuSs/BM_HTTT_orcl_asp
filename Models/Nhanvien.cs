using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Nhanvien
    {
        public Nhanvien()
        {
            Hoadons = new HashSet<Hoadon>();
        }

        public decimal Manv { get; set; }
        public string? Tennv { get; set; } = null!;
        public string? Sdt { get; set; } = null!;
        public string? Chucvu { get; set; }

        public virtual Taikhoannv Taikhoannv { get; set; } = null!;
        public virtual ICollection<Hoadon> Hoadons { get; set; }
    }
}
