using WebApplication1.ViewModels;
using WebApplication1.Models;
using WebApplication1.Interfaces;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace WebApplication1.Repositories
{
    public class NhanvienRepository : INhanvienRepository
    {
        private readonly IMapper _mapper;
        private readonly ModelContext _context;
        public NhanvienRepository(IMapper mapper, ModelContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        
        public async Task<List<VM_Nhanvien>> GetAll()
        {
            var nv = await _context.Nhanviens.ToListAsync();
            return _mapper.Map<List<VM_Nhanvien>>(nv);

        }
        public async Task<VM_Nhanvien> GetById(decimal id)
        {
            var nv = await _context.Nhanviens.FindAsync(id);
            return _mapper.Map<VM_Nhanvien>(nv);
        }
        public async Task Add (VM_Nhanvien nhanvien)
        {
            var nv = new Nhanvien();
            nv.Manv = nhanvien.Manv;
            nv.Tennv = nhanvien.Tennv;
            nv.Chucvu = nhanvien.Chucvu;
            nv.Sdt = nhanvien.Sdt;
            _context.Nhanviens.Add(nv);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(decimal id)
        {
            var nv = _context.Nhanviens.SingleOrDefault(e => e.Manv == id);
            _context.Nhanviens.Remove(nv);
            await _context.SaveChangesAsync();
        }
        public async Task Update(VM_Nhanvien nhanvien)
        {
            var nv = _context.Nhanviens.SingleOrDefault(e => e.Manv == nhanvien.Manv);
            nv.Tennv = nhanvien.Tennv;
            nv.Chucvu = nhanvien.Chucvu;
            nv.Sdt = nhanvien.Sdt;
            _context.Nhanviens.Update(nv);
            await _context.SaveChangesAsync();
        }
    }
}
