using WebApplication1.Interfaces;
using WebApplication1.ViewModels;
using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
namespace WebApplication1.Repositories
{
    public class DongspRepository : IDongspRepository
    {
        private readonly IMapper _mapper;
        private readonly ModelContext _context;
        public DongspRepository(IMapper mapper, ModelContext context) 
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<List<VM_Dongsp>> GetAll()
        {
            var dsp = await _context.Dongsps.ToListAsync();
            return _mapper.Map<List<VM_Dongsp>>(dsp);
        }
        public async Task<VM_Dongsp> GetById(decimal id)
        {
            var dsp = await _context.Dongsps.FindAsync(id);
            return _mapper.Map<VM_Dongsp>(dsp);
        }
        public async Task Add(VM_Dongsp dongsp)
        {
            var dsp = new Dongsp();
            dsp.Madong = dongsp.Madong;
            dsp.Tendong = dongsp.Tendong;
            dsp.Loai = dongsp.Loai;
            _context.Dongsps.Add(dsp);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(decimal id)
        {
            var dsp = _context.Dongsps.SingleOrDefault(e=>e.Madong == id);
            _context.Dongsps.Remove(dsp);
            await _context.SaveChangesAsync();
        }
        public async Task Update(VM_Dongsp dongsp)
        {
            var dsp = _context.Dongsps.SingleOrDefault(e => e.Madong == dongsp.Madong);
            dsp.Tendong = dongsp.Tendong;
            dsp.Loai = dongsp.Loai;
            _context.Dongsps.Update(dsp);
            await _context.SaveChangesAsync();
        }
    }
}
