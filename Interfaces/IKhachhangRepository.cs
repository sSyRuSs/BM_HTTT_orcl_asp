using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebApplication1.Models;
using WebApplication1.ViewModels;
namespace WebApplication1.Interfaces
{
    public interface IKhachangRepository
    {
        public Task<List<ViewModels.VM_Khachhang>> GetAll();
        public Task<ViewModels.VM_Khachhang> GetById(decimal id);
        public Task Add (ViewModels.VM_Khachhang khachhang);
        public Task Delete(decimal id);
        public Task Update(ViewModels.VM_Khachhang khachhang);
    }
}
