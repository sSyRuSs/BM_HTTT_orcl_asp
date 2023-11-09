using System;
using System.Collections.Generic;

namespace WebApplication1.ViewModels
{
    public partial class VM_Khachhang
    {

        public decimal Makh { get; set; }
        public string Tenkh { get; set; } = null!;
        public string? Sdt { get; set; }
        public string? Diachi { get; set; }
    }
}
