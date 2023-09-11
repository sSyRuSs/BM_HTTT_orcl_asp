using WebApplication1.ViewModels;
using WebApplication1.Models;
using WebApplication1.Interfaces;
using Microsoft.EntityFrameworkCore;
using AutoMapper;


namespace WebApplication1.Repositories
{
    public class HoadonRepository:IHoadonRepository
    {
        private readonly IMapper _mapper;
        private readonly ModelContext _context;
        public HoadonRepository(IMapper mapper, ModelContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<List<ViewModels.VM_Hoadon>> GetAll()
        {
            var hd = await _context.Hoadons.ToListAsync();
            return _mapper.Map<List<ViewModels.VM_Hoadon>>(hd);
        }
        public async Task<ViewModels.VM_Hoadon> GetById(decimal id)
        {
            var hd = await _context.Hoadons.FindAsync(id);
            return _mapper.Map<ViewModels.VM_Hoadon>(hd);
        }
        public async Task Add(ViewModels.VM_Hoadon hoadon)
        {
            var hd = new Hoadon();
            hd.Mahd = hoadon.Mahd;
            hd.Makh = hoadon.Makh;
            hd.Manv = hoadon.Manv;
            hd.Masp = hoadon.Masp;
            hd.Ngaymua = hoadon.Ngaymua;
            _context.Hoadons.Add(hd);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(decimal id)
        {
            var hd = _context.Hoadons.SingleOrDefault(e => e.Mahd == id);
            _context.Hoadons.Remove(hd);
            await _context.SaveChangesAsync();
        }
        public async Task Update(ViewModels.VM_Hoadon hoadon)
        {
            var hd = _context.Hoadons.SingleOrDefault(e => e.Mahd == hoadon.Mahd);
            hd.Makh = hoadon.Makh;
            hd.Manv= hoadon.Manv;
            hd.Masp= hoadon.Masp;
            hd.Ngaymua= hoadon.Ngaymua;
            _context.Hoadons.Update(hd);
            await _context.SaveChangesAsync();
        }
    }
}
