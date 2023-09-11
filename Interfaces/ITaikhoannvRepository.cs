using WebApplication1.ViewModels;
using WebApplication1.Models;
namespace WebApplication1.Interfaces
{
    public interface ITaikhoannvRepository
    {
        public Task<List<ViewModels.VM_Taikhoannv>> GetAll();
        public Task<ViewModels.VM_Taikhoannv> GetById(decimal id);
        public Task Add(ViewModels.VM_Taikhoannv tknv);
        public Task Delete(decimal id);
        public Task Update(ViewModels.VM_Taikhoannv tknv);
    }
    
}