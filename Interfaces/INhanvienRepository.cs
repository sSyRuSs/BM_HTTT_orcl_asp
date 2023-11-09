using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebApplication1.Models;
using WebApplication1.ViewModels;
namespace WebApplication1.Interfaces
{
    public interface INhanvienRepository
    {
        public Task<List<VM_Nhanvien>> GetAll();
        public Task<VM_Nhanvien> GetById(decimal id);
        public Task Add (VM_Nhanvien nhanvien);
        public Task Delete(decimal id);
        public Task Update(VM_Nhanvien nhanvien);
    }
}
