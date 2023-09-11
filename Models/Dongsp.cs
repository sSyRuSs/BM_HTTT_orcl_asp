
namespace WebApplication1.Models
{
    public partial class Dongsp
    {
        public Dongsp()
        {
            Sanphams = new HashSet<Sanpham>();
        }
        public decimal Madong { get; set; }
        public string Tendong { get; set; } = null!;
        public string? Loai { get; set; }

        public virtual ICollection<Sanpham> Sanphams { get; set; }
    }
}
