using WebApplication1.ViewModels;
using WebApplication1.Models;
using WebApplication1.Interfaces;
using Microsoft.EntityFrameworkCore;
using AutoMapper;


namespace WebApplication1.Repositories
{
    public class TaikhoannvRepository : ITaikhoannvRepository
    {
        private readonly IMapper _mapper;
        private readonly ModelContext _context;
        public TaikhoannvRepository(IMapper mapper, ModelContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ViewModels.VM_Taikhoannv>> GetAll()
        {
            var tknv = await _context.Taikhoannvs.ToListAsync();
            return _mapper.Map<List<ViewModels.VM_Taikhoannv>>(tknv);
        }
        public async Task<ViewModels.VM_Taikhoannv> GetById(decimal id)
        {
            var tknv = await _context.Taikhoannvs.FindAsync(id);
            return _mapper.Map<ViewModels.VM_Taikhoannv>(tknv);
        }
        public async Task Add(VM_Taikhoannv taikhoannv)
        {
            var tknv = new Taikhoannv();
            tknv.Manv = taikhoannv.Manv;
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(taikhoannv.Matkhau);
            tknv.Matkhau = passwordHash;
            _context.Taikhoannvs.Add(tknv);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(decimal id)
        {
            var tknv = _context.Taikhoannvs.SingleOrDefault(e => e.Manv == id);
            _context.Taikhoannvs.Remove(tknv);
            await _context.SaveChangesAsync();
        }
        public async Task Update(ViewModels.VM_Taikhoannv taikhoannv)
        {
            var tknv = _context.Taikhoannvs.SingleOrDefault(e => e.Manv == taikhoannv.Manv);
            tknv.Matkhau = taikhoannv.Matkhau;
            _context.Taikhoannvs.Update(tknv);
            await _context.SaveChangesAsync();
        }

        
    }
}