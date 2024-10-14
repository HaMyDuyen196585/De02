using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    internal class LoaiS
    {
        private readonly SphamModel1 _context;

        public LoaiS()
        {
            _context = new SphamModel1(); // Khởi tạo context
        }

        public List<LoaiSP> GetAll()
        {
            return _context.LoaiSPs.ToList(); // Truy xuất danh sách loại sản phẩm
        }
    }
}
