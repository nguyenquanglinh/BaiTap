using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace TimDuongTrenForm
{
    public class Canh
    {
        public DiemHinhTron DiemDau { get; set; }
        public DiemHinhTron DiemCuoi { get; set; }
        public Canh(DiemHinhTron diemDau, DiemHinhTron diemCuoi)
        {
            DiemDau = diemDau;
            DiemCuoi = diemCuoi;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var canh = obj as Canh;
            if (canh == null)
                return false;
            if (this.DiemDau.Equals(canh.DiemDau) && this.DiemCuoi.Equals(canh.DiemCuoi) || (this.DiemDau.Equals(canh.DiemCuoi) && this.DiemCuoi.Equals(canh.DiemDau)))
                return true;
            return false;
        }
    }
}
