using System;
using System.Collections.Generic;

namespace WebApplication1.ViewModels
{
    public partial class VM_Sanpham
    {
        public decimal Masp { get; set; }
        public string Tensp { get; set; } = null!;
        public decimal Giaban { get; set; }
        public decimal? Sltonkho { get; set; }
        public decimal Madong { get; set; }
    }
}
