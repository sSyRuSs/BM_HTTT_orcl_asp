using AutoMapper;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1
{
    public class AutoMapper : Profile
    {
        public AutoMapper() 
        {
            CreateMap<Dongsp, VM_Dongsp>();
            CreateMap<Sanpham, VM_Sanpham>();
            CreateMap<Nhanvien, VM_Nhanvien>();
            CreateMap<Taikhoannv, VM_Taikhoannv>();
            CreateMap<Hoadon, VM_Hoadon>();
            CreateMap<Khachhang, VM_Khachhang>();
        }
    }
}
