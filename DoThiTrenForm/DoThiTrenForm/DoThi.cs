using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoThiTrenForm
{
    public class DoThi : IDoThi
    {
        public IDiem this[string name]
        {
            get
            {
                return TapDinh.FirstOrDefault(x => x.PointName.Equals(name));
            }
        }

        private List<IDiem> tapDinh = new List<IDiem>();
        private List<ICanh> tapCanh = new List<ICanh>();

        public IEnumerable<IDiem> TapDinh
        {
            get
            {
                return tapDinh;
            }
        }

        public IEnumerable<ICanh> TapCanh
        {
            get
            {
                return tapCanh;
            }
        }


        //int demDinh = 0;
        //DrawCanh draw;

        //public DoThi(DrawCanh draw)
        //{
        //    //this.draw = draw;
        //    tapDinh = new List<IDiem>();
        //    tapCanh = new List<Canh>();
        //}

        public void ThemCanh(Canh canh)
        {
            if (!tapCanh.Contains(canh))
            {
                tapCanh.Add(canh);
                NotifyChanged();
            }
        }

        //private void GhiTenHinh()
        //{
        //    demDinh = 0;
        //    foreach (var ht in tapDinh)
        //    {
        //        ht.PointName = demDinh.ToString();
        //        demDinh++;
        //    }
        //}

        public void ThemDinh(IDiem diemDinh)
        {
            if (tapDinh.Contains(diemDinh))
                return;
            tapDinh.Add(diemDinh);
            diemDinh.OnDoubleClick += diemDinh_OnDoubleClick;
            NotifyChanged();
        }

        void diemDinh_OnDoubleClick(object sender, DiemDoubleClickedArgs e)
        {
            XoaMotDiem(this[e.Name]);
        }

        public void XoaMotDiem(IDiem diemClick)
        {
            this.tapDinh.Remove(this[diemClick.PointName]);

            foreach (var item in tapCanh.ToArray())
            {
                if (item.DiemDau.Equals(diemClick) || item.DiemCuoi.Equals(diemClick))
                {
                    tapCanh.Remove(item);
                }
            }

            NotifyChanged();
        }


        void NotifyChanged()
        {
            if (this.OnGraphChanged != null)
                OnGraphChanged(this, new EventArgs());
        }

        //public IDiem Lay1DiemTrongTapDinh(string tenDinh)
        //{
        //    foreach (var dinh in tapDinh)
        //    {
        //        if (dinh.PointName == tenDinh)
        //            return dinh;
        //    }
        //    return null;
        //}


        public event EventHandler OnGraphChanged;
    }
}
