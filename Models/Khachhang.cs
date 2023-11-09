using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Khachhang
    {
        public Khachhang()
        {
            Hoadons = new HashSet<Hoadon>();
        }

        public decimal Makh { get; set; }
        public string Tenkh { get; set; } = null!;
        public string? Sdt { get; set; }
        public string? Diachi { get; set; }

        public virtual ICollection<Hoadon> Hoadons { get; set; }
    }
}
