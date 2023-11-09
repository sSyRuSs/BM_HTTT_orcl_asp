using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Sanpham
    {
        public Sanpham()
        {
            Hoadons = new HashSet<Hoadon>();
        }

        public decimal Masp { get; set; }
        public string Tensp { get; set; } = null!;
        public decimal Giaban { get; set; }
        public decimal? Sltonkho { get; set; }
        public decimal Madong { get; set; }

        public virtual Dongsp MadongNavigation { get; set; } = null!;
        public virtual ICollection<Hoadon> Hoadons { get; set; }
    }
}
