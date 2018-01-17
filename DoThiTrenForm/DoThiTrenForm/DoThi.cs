using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoThiTrenForm
{
    public class DoThi : DoThiTrenForm.IDoThi
    {
        public List<IDiem> tapDinh;
        public List<Canh> tapCanh;
        int demDinh = 0;
        DrawCanh draw;

        public DoThi(DrawCanh draw)
        {
            this.draw = draw;
            tapDinh = new List<IDiem>();
            tapCanh = new List<Canh>();
        }

        public void ThemCanh(Canh canh)
        {
            if (!tapCanh.Contains(canh))
                tapCanh.Add(canh);

        }
        private void GhiTenHinh()
        {
            demDinh = 0;
            foreach (var ht in tapDinh)
            {
                ht.PointName = demDinh.ToString();
                demDinh++;
            }
        }

        public void ThemDinh(IDiem diemDinh)
        {
            if (!tapDinh.Contains(diemDinh))
                tapDinh.Add(diemDinh);
            GhiTenHinh();
        }

        public void XoaMotDiem(IDiem diemClick)
        {
            XoaDinh(diemClick);
            XoaCanh(diemClick);
        }

        void XoaCanh(IDiem diemClick)
        {
            foreach (var item in tapCanh)
            {
                if (item.DiemDau.Equals(diemClick) || item.DiemCuoi.Equals(diemClick))
                {
                    tapCanh.Remove(item);
                    break;
                }
            }
            GhiTenHinh();
        }

        void XoaDinh(IDiem diemClick)
        {
            foreach (var item in tapDinh)
            {
                if (item.Equals(item))
                {
                    tapDinh.Remove(item);
                    break;
                }

            }

        }

        public IDiem Lay1DiemTrongTapDinh(string tenDinh)
        {
            foreach (var dinh in tapDinh)
            {
                if (dinh.PointName == tenDinh)
                    return dinh;
            }
            return null;
        }



    }
}
