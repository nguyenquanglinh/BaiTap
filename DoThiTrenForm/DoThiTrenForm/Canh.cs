using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoThiTrenForm
{
    public class Canh : DoThiTrenForm.ICanh
    {
        public Canh(IDiem dDau, IDiem dCuoi)
        {
            DiemDau = dDau;
            DiemCuoi = dCuoi;
        }

        public override string ToString()
        {
            return DiemDau.PointName + " " + DiemCuoi.PointName;
        }

        public override int GetHashCode()
        {
            return DiemDau.PointName.GetHashCode() ^ DiemDau.Center.GetHashCode() ^ DiemCuoi.PointName.GetHashCode() ^ DiemCuoi.Center.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return this.GetHashCode() == (obj as Canh).GetHashCode();
        }

        public IDiem DiemDau { get; set; }

        public IDiem DiemCuoi { get; set; }
    }
}
