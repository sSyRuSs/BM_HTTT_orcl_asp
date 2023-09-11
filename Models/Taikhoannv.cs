using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Taikhoannv
    {
        public decimal Manv { get; set; }
        public string Matkhau { get; set; } = null!;

        public virtual Nhanvien ManvNavigation { get; set; } = null!;
    }
}
