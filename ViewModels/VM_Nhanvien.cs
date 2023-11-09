using System;
using System.Collections.Generic;

namespace WebApplication1.ViewModels
{
    public partial class VM_Nhanvien
    {

        public decimal Manv { get; set; }
        public string Tennv { get; set; } = null!;
        public string Sdt { get; set; } = null!;
        public string? Chucvu { get; set; }

    }
}
