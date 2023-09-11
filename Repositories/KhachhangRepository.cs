using WebApplication1.ViewModels;
using WebApplication1.Models;
using WebApplication1.Interfaces;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace WebApplication1.Repositories
{
    public class Khachhangrepository : IKhachangRepository
    {
        private readonly IMapper _mapper;
        private readonly ModelContext _context;
        public Khachhangrepository(IMapper mapper, ModelContext context)
        {
            _mapper=mapper;
            _context = context;
        }
        
        public async Task<List<ViewModels.VM_Khachhang>> GetAll()
        {
            var kh = await _context.Khachhangs.ToListAsync();
            return _mapper.Map<List<ViewModels.VM_Khachhang>>(kh);

        }
        public async Task<ViewModels.VM_Khachhang> GetById(decimal id)
        {
            var nv = await _context.Khachhangs.FindAsync(id);
            return _mapper.Map<ViewModels.VM_Khachhang>(nv);
        }
        public async Task Add (ViewModels.VM_Khachhang khachhang)
        {
            var kh = new Khachhang();
            kh.Makh = khachhang.Makh;
            kh.Tenkh = khachhang.Tenkh;
            kh.Diachi = khachhang.Diachi;
            kh.Sdt = khachhang.Sdt;
            _context.Khachhangs.Add(kh);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(decimal id)
        {
            var kh = _context.Khachhangs.SingleOrDefault(e => e.Makh == id);
            _context.Khachhangs.Remove(kh);
            await _context.SaveChangesAsync();
        }
        public async Task Update(ViewModels.VM_Khachhang khachhang)
        {
            var nv = _context.Khachhangs.SingleOrDefault(e => e.Makh == khachhang.Makh);
            nv.Tenkh = khachhang.Tenkh;
            nv.Diachi = khachhang.Diachi;
            nv.Sdt = khachhang.Sdt;
            _context.Khachhangs.Update(nv);
            await _context.SaveChangesAsync();
        }
    }
}
