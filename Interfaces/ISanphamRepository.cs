using WebApplication1.Models;
using WebApplication1.ViewModels;
namespace WebApplication1.Interfaces
{
    public interface ISanphamRepository
    {
        public Task<List<ViewModels.VM_Sanpham>> GetAll();
        public Task<ViewModels.VM_Sanpham> GetById(decimal id);
        public Task Add(ViewModels.VM_Sanpham dongsp);
        public Task Delete(decimal id);
        public Task Update(ViewModels.VM_Sanpham dongsp);
    }
}
