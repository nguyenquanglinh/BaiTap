using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimDuongTrenForm
{
    public class Hinh
    {
        public Hinh()
        {
            tapDinh = new List<DiemHinhTron>();
            tapCanh = new List<Canh>();
        }
        public List<DiemHinhTron> tapDinh;
        public List<Canh> tapCanh;
    }
}
