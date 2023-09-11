using WebApplication1.ViewModels;
using WebApplication1.Models;
namespace WebApplication1.Interfaces
{
    public interface IHoadonRepository
    {
        public Task<List<ViewModels.VM_Hoadon>> GetAll();
        public Task<ViewModels.VM_Hoadon> GetById(decimal id);
        public Task Add(ViewModels.VM_Hoadon hoadon);
        public Task Delete(decimal id);
        public Task Update(ViewModels.VM_Hoadon hoadon);
    }
}
