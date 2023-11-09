using WebApplication1.Interfaces;
using WebApplication1.ViewModels;
using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
namespace WebApplication1.Repositories
{
    public class SanphamRepository : ISanphamRepository
    {
        private readonly IMapper _mapper;
        private readonly ModelContext _context;
        public SanphamRepository(IMapper mapper, ModelContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<List<VM_Sanpham>> GetAll()
        {
            var dsp = await _context.Sanphams.ToListAsync();
            return _mapper.Map<List<VM_Sanpham>>(dsp);
        }
        public async Task<VM_Sanpham> GetById(decimal id)
        {
            var dsp = await _context.Sanphams.FindAsync(id);
            return _mapper.Map<VM_Sanpham>(dsp);
        }
        public async Task Add(VM_Sanpham dongsp)
        {
            var dsp = new Sanpham();
            dsp.Masp = dongsp.Masp;
            dsp.Madong = dongsp.Madong;
            dsp.Tensp = dongsp.Tensp;
            dsp.Giaban = dongsp.Giaban;
            dsp.Sltonkho = dongsp.Sltonkho;
            _context.Sanphams.Add(dsp);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(decimal id)
        {
            var dsp = _context.Sanphams.SingleOrDefault(e => e.Masp == id);
            _context.Sanphams.Remove(dsp);
            await _context.SaveChangesAsync();
        }
        public async Task Update(VM_Sanpham sanpham)
        {
            var dsp = _context.Sanphams.SingleOrDefault(e => e.Masp == sanpham.Masp);
            dsp.Tensp = sanpham.Tensp;
            dsp.Madong = sanpham.Madong;
            dsp.Giaban = dsp.Giaban;
            dsp.Sltonkho = dsp.Sltonkho;
            _context.Sanphams.Update(dsp);
            await _context.SaveChangesAsync();
        }
    }
}
