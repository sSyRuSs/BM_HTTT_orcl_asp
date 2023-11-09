using System.Globalization;

namespace WebApplication1.ViewModels
{
    public class RefreshToken
    {
        public required string Token { get; set; }
        public DateTime Create{get;set;} = DateTime.Now;
        public DateTime Expire{get; set;} 
    }
}