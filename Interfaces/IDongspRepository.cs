using WebApplication1.Models;
using WebApplication1.ViewModels;
namespace WebApplication1.Interfaces
{
    public interface IDongspRepository
    {
        public Task<List<VM_Dongsp>> GetAll();
        public Task<VM_Dongsp> GetById(decimal id);
        public Task Add(VM_Dongsp dongsp);
        public Task Delete(decimal id);
        public Task Update(VM_Dongsp dongsp);
        public Task UpdatePatch(VM_Dongsp dongsp);
    }
}
