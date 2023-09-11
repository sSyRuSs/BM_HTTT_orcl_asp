using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Hoadon
    {
        public decimal Mahd { get; set; }
        public DateTime? Ngaymua { get; set; }
        public decimal Manv { get; set; }
        public decimal Makh { get; set; }
        public decimal Masp { get; set; }

        public virtual Khachhang MakhNavigation { get; set; } = null!;
        public virtual Nhanvien ManvNavigation { get; set; } = null!;
        public virtual Sanpham MaspNavigation { get; set; } = null!;
    }
}
