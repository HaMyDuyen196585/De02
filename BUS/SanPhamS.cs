using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace BUS
{
    public class SanPhamS
    {
      
            private readonly SphamModel1 _context;
            public SanPhamS()
            {
                _context = new SphamModel1(); // Khởi tạo context
            }
            public List<Sanpham> getAll()
            {
                SphamModel1 context = new SphamModel1();
                return context.Sanphams.ToList();

            }
        public void Add(Sanpham product)
        {
            _context.Sanphams.Add(product);
            _context.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu
        }


    }
}
