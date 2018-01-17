using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoThiTrenForm
{
    //interface IThuatToan
    //{
    //    Hinh ThuTuDuyetDinh(int dinh);
    //}

    //public class Dfs : IThuatToan
    //{
    //    int[,] arr { get; set; }
    //    DoThi dt { get; set; }

    //    public Dfs(DoThi dT)
    //    {
    //        dt = dT;
    //    }

    //    public Hinh ThuTuDuyetDinh(int dinh)
    //    {
    //        var hinh = new Hinh();
    //        var dinhDaDuyet = new int[dt.tapDinh.Count];
    //        if (dt != null || arr == null)
    //            arr = Arr();
    //        ThuTuDuyetDinh(dinh, hinh, dinhDaDuyet);
    //        return hinh;
    //    }

    //    int[,] Arr()
    //    {
    //        var ret = new int[dt.tapDinh.Count, dt.tapDinh.Count];
    //        foreach (var canh in dt.tapCanh)
    //        {
    //            ret[int.Parse(canh.DiemDau.PointName), int.Parse(canh.DiemCuoi.PointName)] = ret[int.Parse(canh.DiemCuoi.PointName), int.Parse(canh.DiemDau.PointName)] = 1;
    //        }
    //        return ret;
    //    }

    //    private void ThuTuDuyetDinh(int dinh, Hinh hinh, int[] tapDinhDaDuyet)
    //    {
    //        var Ddau = dt.Lay1DiemTrongTapDinh(dinh.ToString());
    //        hinh.tapDinh.Add(Ddau);
    //        tapDinhDaDuyet[dinh] = -1;
    //        for (int i = 0; i < arr.GetLength(0); i++)
    //        {
    //            if (arr[dinh, i] != 0)
    //            {
    //                var canh = new Canh(Ddau, dt.Lay1DiemTrongTapDinh(i.ToString()));
    //                if (!hinh.tapCanh.Contains(canh))
    //                    hinh.tapCanh.Add(canh);
    //                if (tapDinhDaDuyet[i] == 0)
    //                    ThuTuDuyetDinh(i, hinh, tapDinhDaDuyet);
    //            }
    //        }
    //    }

    //    public List<Hinh> DemDoThi()
    //    {
    //        var soDoThi = new List<Hinh>();
    //        var cacDinhDangDuyet = ThuTuDuyetDinh(0);
    //        if (cacDinhDangDuyet.tapDinh[0] != null)
    //            soDoThi.Add(cacDinhDangDuyet);
    //        for (int i = 1; i < dt.tapDinh.Count; i++)
    //        {

    //            if (!KiemTraDinhDaDuyet(soDoThi, i))
    //            {
    //                cacDinhDangDuyet = ThuTuDuyetDinh(i);
    //                if (cacDinhDangDuyet.tapDinh[0] != null)
    //                    soDoThi.Add(cacDinhDangDuyet);
    //            }
    //        }
    //        return soDoThi;
    //    }

    //    private bool KiemTraDinhDaDuyet(List<Hinh> soDothi, int i)
    //    {
    //        foreach (var hinh in soDothi)
    //            foreach (var Dinh in hinh.tapDinh)
    //                if (Dinh.PointName == i.ToString())
    //                    return true;
    //        return false;
    //    }

    //    private bool DinhDaDuyet(List<int> dinhDaDuyet, int dinhDangXet)
    //    {
    //        foreach (var dinh in dinhDaDuyet)
    //        {
    //            if (dinh == dinhDangXet)
    //                return true;
    //        }
    //        dinhDaDuyet.Add(dinhDangXet);
    //        return false;
    //    }

    //    public Hinh TimDuongMin(int bd, int kt)
    //    {
    //        var hinhDung = LayHinhDung(bd, kt);
    //        if (hinhDung != null)
    //        {
    //            var cacLoaiDuongDi = new List<Hinh>();
    //            TimDuongDi(bd, kt, hinhDung, cacLoaiDuongDi, new Hinh(), new List<Canh>(), new List<int>());
    //            var duongMin = cacLoaiDuongDi[0];
    //            foreach (var duong in cacLoaiDuongDi)
    //            {
    //                if (duong.tapDinh.Count < duongMin.tapDinh.Count || duong.tapCanh.Count < duongMin.tapCanh.Count)
    //                    duongMin = duong;
    //            }
    //            return duongMin;
    //        }
    //        return null;
    //    }

    //    private void TimDuongDi(int bd, int kt, Hinh dothi, List<Hinh> tapDuongDi, Hinh duongMin, List<Canh> cacCanhKe, List<int> dinhDaDuyet)
    //    {
    //        var cacCanhKeDinhMoi = LayCanhTuHinh(dothi, bd, cacCanhKe);
    //        var dinhDuyet = DinhDaDuyet(dinhDaDuyet);
    //        foreach (var item in cacCanhKeDinhMoi)
    //        {
    //            var hinhMoi = new Hinh();
    //            int dinhMoi = LayTenDinh(item, bd);
    //            if (!duongMin.tapCanh.Contains(item))
    //            {
    //                if (dinhDaDuyet.Contains(dinhMoi))
    //                    continue;
    //                dinhDuyet.Add(bd);
    //                foreach (var dinh in duongMin.tapDinh)
    //                    hinhMoi.tapDinh.Add(dinh);
    //                foreach (var canh in duongMin.tapCanh)
    //                    hinhMoi.tapCanh.Add(canh);
    //                hinhMoi.tapDinh.Add(dt.Lay1DiemTrongTapDinh(bd.ToString()));
    //                hinhMoi.tapCanh.Add(item);
    //                if (dinhMoi == kt)
    //                {
    //                    hinhMoi.tapDinh.Add(dt.Lay1DiemTrongTapDinh(kt.ToString()));
    //                    tapDuongDi.Add(hinhMoi);
    //                    continue;
    //                }
    //                TimDuongDi(dinhMoi, kt, dothi, tapDuongDi, hinhMoi, cacCanhKeDinhMoi, dinhDuyet);
    //            }
    //        }
    //    }

    //    private int LayTenDinh(Canh item, int bd)
    //    {
    //        if (item.DiemDau.PointName == bd.ToString())
    //            return int.Parse(item.DiemCuoi.PointName);
    //        return int.Parse(item.DiemDau.PointName);
    //    }

    //    private List<int> DinhDaDuyet(List<int> dinhDaDuyet)
    //    {
    //        var dinhDaDuyetMoi = new List<int>();
    //        foreach (var item in dinhDaDuyet)
    //        {
    //            dinhDaDuyetMoi.Add(item);
    //        }
    //        return dinhDaDuyetMoi;
    //    }

    //    private List<Canh> LayCanhTuHinh(Hinh dothi, int bd, List<Canh> cacCanhKe)
    //    {
    //        var cacCanhKeDinhMoi = new List<Canh>();
    //        foreach (var item in dothi.tapCanh)
    //            if (item.DiemDau.PointName == bd.ToString() || item.DiemCuoi.PointName == bd.ToString())
    //            {
    //                var canh = item;
    //                if (!cacCanhKe.Contains(canh))
    //                    cacCanhKeDinhMoi.Add(canh);
    //            }
    //        return cacCanhKeDinhMoi;
    //    }

    //    private Hinh LayHinhDung(int bd, int kt)
    //    {
    //        var dothi = DemDoThi();
    //        foreach (var hinh in dothi)
    //        {
    //            if (HinhCoChuaDiemDauVaDiemCuoi(hinh, bd) && HinhCoChuaDiemDauVaDiemCuoi(hinh, kt))
    //                return hinh;
    //        }
    //        return null;
    //    }

    //    private bool HinhCoChuaDiemDauVaDiemCuoi(Hinh hinh, int bd)
    //    {
    //        foreach (var dinh in hinh.tapDinh)
    //        {
    //            if (dinh.PointName == bd.ToString())
    //                return true;
    //        }
    //        return false;
    //    }
    //}

    //class Bfs : IThuatToan
    //{
    //    public Hinh ThuTuDuyetDinh(int dinh)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}

}
