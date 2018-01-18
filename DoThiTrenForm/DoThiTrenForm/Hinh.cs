using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DoThiTrenForm
{
    class Hinh
    {
        public Hinh()
        {
            TapDinh = new List<IDiem>();
            TapCanh = new List<Canh>();
        }
        public List<IDiem> TapDinh;
        public List<Canh> TapCanh;
    }
}
