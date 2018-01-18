using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoThiTrenForm
{
    public interface IThuatToanDoThi
    {
        List<IDiem> ThuTuDuyetDuyet(IDoThi doThi, string start);

        IDoThi TimDuong(string start, string end, IDoThi doThi);
    }


    class DuyetDfs
    {
        IDoThi dt;

        public DuyetDfs(IDoThi dT)
        {
            dt = dT;
        }

        int[,] Arr()
        {
            int[,] arr = new int[dt.SoDinhCuaDoThi, dt.SoDinhCuaDoThi];
            foreach (var canh in dt.TapCanh)
            {
                arr[int.Parse(canh.DiemDau.PointName), int.Parse(canh.DiemCuoi.PointName)] = arr[int.Parse(canh.DiemCuoi.PointName), int.Parse(canh.DiemDau.PointName)] = 1;
            }
            return arr;
        }

        List<Hinh> DemDoThi()
        {
            var soDothi = new List<Hinh>();
            var cacDinhDangDuyet = ThuTuDinhDuyet(0);
            if (cacDinhDangDuyet.TapDinh[0] != null)
                soDothi.Add(cacDinhDangDuyet);
            for (int i = 1; i < dt.SoDinhCuaDoThi; i++)
            {
                if (!KiemTraDinhDaDuyet(soDothi, i))
                {
                    cacDinhDangDuyet = ThuTuDinhDuyet(i);
                    if (cacDinhDangDuyet.TapDinh[0] != null)
                        soDothi.Add(cacDinhDangDuyet);
                }
            }

            return soDothi;
        }

        private bool KiemTraDinhDaDuyet(List<Hinh> soDothi, int i)
        {
            foreach (var hinh in soDothi)
                foreach (var Dinh in hinh.TapDinh)
                    if (Dinh.PointName == i.ToString())
                        return true;
            return false;
        }

        private Hinh ThuTuDinhDuyet(int p)
        {
            var hinh = new Hinh();
            var dinhDaDuyet = new int[dt.SoDinhCuaDoThi];
            DuyetDinh(p, hinh, dinhDaDuyet);
            return hinh;
        }


        private void DuyetDinh(int p, Hinh hinh, int[] dinhDaDuyet)
        {
            var dD = dt[p.ToString()];
            hinh.TapDinh.Add(dD);
            dinhDaDuyet[p] = -1;
            var arr = Arr();
            for (int i = 0; i < dt.SoDinhCuaDoThi; i++)
            {
                if (arr[p, i] == 1)
                {
                    var canh = new Canh(dt[i.ToString()], dD);
                    if (!hinh.TapCanh.Contains(canh))
                        hinh.TapCanh.Add(canh);
                    if (dinhDaDuyet[i] == 0)
                        DuyetDinh(i, hinh, dinhDaDuyet);
                }
            }
        }



        internal Hinh TimDuongMin(int bd, int kt)
        {
            var dothi = DoThiChuaDiemBatDauVaKetThuc(bd, kt);
            var cacLoaiDuongDi = new List<Hinh>();
            LayDuongDi(bd, kt, dothi, cacLoaiDuongDi, new Hinh(), new List<Canh>(), new List<int>());
            if (cacLoaiDuongDi.Count == 0)
            {
                return null;
            }
            var duongMin = cacLoaiDuongDi[0];
            foreach (var duong in cacLoaiDuongDi)
            {
                if (duongMin.TapCanh.Count >= duong.TapCanh.Count)
                    duongMin = duong;
            }
            return duongMin;
        }

        private Hinh DoThiChuaDiemBatDauVaKetThuc(int bd, int kt)
        {
            var hinh = DemDoThi();
            var ret = new Hinh();

            foreach (var item in hinh)
            {
                if (CoDiemBatVaketThu(item, bd) && CoDiemBatVaketThu(item, kt))
                {
                    ret = item;
                }
            }
            return ret;
        }

        void LayDuongDi(int bd, int kt, Hinh dothi, List<Hinh> tapDuongDi, Hinh duongMin, List<Canh> cacCanhKe, List<int> dinhDaDuyet)
        {
            var cacCanhKeDinhMoi = LayCanhTuHinh(dothi, bd, cacCanhKe);
            var dinhDuyet = DinhDaDuyet(dinhDaDuyet);
            foreach (var item in cacCanhKeDinhMoi)
            {
                var hinhMoi = new Hinh();
                int dinhMoi = LayTenDinh(item, bd);
                if (!duongMin.TapCanh.Contains(item))
                {
                    if (DinhDaDuocDuyet(dinhMoi, dinhDuyet))
                        continue;
                    dinhDuyet.Add(bd);
                    foreach (var dinh in duongMin.TapDinh)
                        hinhMoi.TapDinh.Add(dinh);
                    foreach (var canh in duongMin.TapCanh)
                        hinhMoi.TapCanh.Add(canh);
                    hinhMoi.TapDinh.Add(dt[bd.ToString()]);
                    hinhMoi.TapCanh.Add(item);
                    if (dinhMoi == kt)
                    {
                        hinhMoi.TapDinh.Add(dt[kt.ToString()]);
                        tapDuongDi.Add(hinhMoi);
                        continue;
                    }
                    LayDuongDi(dinhMoi, kt, dothi, tapDuongDi, hinhMoi, cacCanhKeDinhMoi, dinhDuyet);
                }
            }
        }
        private int LayTenDinh(Canh canh, int bd)
        {
            if (canh.DiemDau.PointName == bd.ToString())
                return int.Parse(canh.DiemCuoi.PointName);
            return int.Parse(canh.DiemDau.PointName);
        }
        private bool DinhDaDuocDuyet(int dinhMoi, List<int> dinhDaDuyet)
        {
            foreach (var item in dinhDaDuyet)
            {
                if (item == dinhMoi)
                    return true;
            }
            return false;
        }

        private List<Canh> LayCanhTuHinh(Hinh dothi, int ten, List<Canh> cacCanhKe)
        {
            var cacCanhKeDinhMoi = new List<Canh>();
            foreach (var item in dothi.TapCanh)
                if (item.DiemDau.PointName == ten.ToString() || item.DiemCuoi.PointName == ten.ToString())
                {
                    var canh = item;
                    if (!cacCanhKe.Contains(canh))
                        cacCanhKeDinhMoi.Add(canh);
                }
            return cacCanhKeDinhMoi;
        }

        private List<int> DinhDaDuyet(List<int> dinhDaDuyet)
        {
            var dinhDaDuyetMoi = new List<int>();
            foreach (var item in dinhDaDuyet)
            {
                dinhDaDuyetMoi.Add(item);
            }
            return dinhDaDuyetMoi;
        }

        private bool CoDiemBatVaketThu(Hinh dothi, int bd)
        {
            if (dothi.TapDinh.Count < 2)
                return false;

            foreach (var item in dothi.TapDinh)
                if (item.PointName == bd.ToString())
                    return true;
            return false;
        }
    }


    public class GraphAlo
    {
        IThuatToanDoThi ThuatToanDuyet { get; set; }

        public void TimDuong(string start, string end, IDoThi doThi)
        {
            var diTuDau = ThuatToanDuyet.ThuTuDuyetDuyet(doThi, start);
            var diTuCuoi = ThuatToanDuyet.ThuTuDuyetDuyet(doThi, end);
        }


        List<List<IDiem>> SoDoThi(int strart, IDoThi doThi)
        {
            var soDoThi = new List<List<IDiem>>();
            var cacDinhDaDuyet = ThuatToanDuyet.ThuTuDuyetDuyet(doThi, strart.ToString());
            if (cacDinhDaDuyet.Count > 0)
                soDoThi.Add(cacDinhDaDuyet);
            for (int i = 0; i < doThi.SoDinhCuaDoThi; i++)
            {
                if (!KiemTraDinhDaDuyet(soDoThi, i))
                {
                    cacDinhDaDuyet = ThuatToanDuyet.ThuTuDuyetDuyet(doThi, i.ToString());
                    if (cacDinhDaDuyet.Count > 0)
                        soDoThi.Add(cacDinhDaDuyet);
                }
            }
            return soDoThi;
        }

        private bool KiemTraDinhDaDuyet(List<List<IDiem>> soDoThi, int i)
        {
            foreach (var tapDinhDaDuyet in soDoThi)
            {
                foreach (var dinh in tapDinhDaDuyet)
                {
                    if (dinh.PointName == i.ToString())
                        return true;
                }
            }
            return false;
        }


        public void TimDuongNganNhat()
        {
        }
    }
}
