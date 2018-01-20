using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoThiTrenForm
{
    public interface ThuatToan
    {
        List<IDiem> ThuTuDuyet(int viTriDuyet);
        List<IDiem> TimDuongMin(int bd, int kt);
    }
    class DuyetBfs : ThuatToan
    {
        int[,] arr;
        IDoThi doThi;
        public DuyetBfs(IDoThi doThi)
        {
            this.doThi = doThi;
            Arr();
        }
        private void Arr()
        {
            arr = new int[doThi.SoDinhCuaDoThi, doThi.SoDinhCuaDoThi];
            foreach (var canh in doThi.TapCanh)
            {
                arr[int.Parse(canh.DiemDau.PointName), int.Parse(canh.DiemCuoi.PointName)] = arr[int.Parse(canh.DiemCuoi.PointName), int.Parse(canh.DiemDau.PointName)] = 1;
            }
        }

        public List<IDiem> ThuTuDuyet(int dinh)
        {
            var dinhDaDuyet = new int[arr.GetLength(0)];
            var que = new Queue<int>();
            que.Enqueue(dinh);
            dinhDaDuyet[dinh] = -1;
            var result = new List<IDiem>();
            var xx = new Dictionary<IDiem, IDiem>();
            while (que.Count != 0)
            {
                dinh = que.Dequeue();
                result.Add(doThi[dinh.ToString()]);
                for (int i = 0; i < arr.GetLength(0); i++)
                    if (arr[dinh, i] != 0 && dinhDaDuyet[i] == 0)
                    {
                        dinhDaDuyet[i] = 1;
                        xx.Add(doThi[i.ToString()], doThi[dinh.ToString()]);
                        que.Enqueue(i);
                    }
            }
            return result;
        }

        public List<IDiem> TimDuongMin(int bd, int kt)
        {
            throw new NotImplementedException();
        }

    }

    class DuyetDfs : ThuatToan
    {
        IDoThi doThi;
        public DuyetDfs(IDoThi doThi)
        {
            this.doThi = doThi;
            Arr();
        }
        int[,] arr;

        private void Arr()
        {
            arr = new int[doThi.SoDinhCuaDoThi, doThi.SoDinhCuaDoThi];
            foreach (var canh in doThi.TapCanh)
            {
                arr[int.Parse(canh.DiemDau.PointName), int.Parse(canh.DiemCuoi.PointName)] = arr[int.Parse(canh.DiemCuoi.PointName), int.Parse(canh.DiemDau.PointName)] = 1;
            }
        }

        public List<IDiem> ThuTuDuyet(int viTriDuyet)
        {
            var result = new List<IDiem>();
            DuyetDinh(viTriDuyet, new List<int>(), result);
            return result;
        }

        void DuyetDinh(int p, List<int> dinhDaDuyet, List<IDiem> result)
        {
            var dD = doThi[p.ToString()];
            result.Add(dD);
            dinhDaDuyet[p] = -1;
            for (int i = 0; i < doThi.SoDinhCuaDoThi; i++)
            {
                if (arr[p, i] == 1 && dinhDaDuyet[i] == 0)
                {
                    var diem = doThi[i.ToString()];
                    result.Add(diem);
                    DuyetDinh(i, dinhDaDuyet, result);
                }
            }
        }


        public List<IDiem> TimDuongMin(int bd, int kt)
        {
            throw new NotImplementedException();
        }
    }

    class PhanChung
    {
        public PhanChung(ThuatToan thuatToan, IDoThi dothi)
        {
            this.thuatToan = thuatToan;
            this.DoThi = dothi;
        }

        public List<List<IDiem>> DemDoThi()
        {
            var soDoThi = new List<List<IDiem>>();
            var dinhDaDuyet = new List<int>();
            var dothi = thuatToan.ThuTuDuyet(0);
            DinhDaDuyet(dinhDaDuyet, dothi);
            if (dothi.Count != 0)
                soDoThi.Add(dothi);
            List<int> listNSo = Enumerable.Range(0, arr.GetLength(0)).ToList();
            var list = listNSo.Except(dinhDaDuyet).ToList();
            while (list.Count != 0)
            {
                foreach (int item in list)
                {
                    dothi = thuatToan.ThuTuDuyet(item);
                    if (dothi.Count != 0)
                        soDoThi.Add(dothi);
                    DinhDaDuyet(dinhDaDuyet, dothi);
                    list = list.Except(dinhDaDuyet).ToList();
                }
            }
            return soDoThi;
        }

        void LayDoThiDung(int bd, int kt, List<IDiem> result)
        {
            var soDoThi = DemDoThi();
            var strart = DoThi[bd.ToString()];
            var finish = DoThi[kt.ToString()];
            foreach (var dothi in soDoThi)
            {
                int dem = 0;
                foreach (var diem in dothi)
                {
                    if (diem.Equals(strart) || diem.Equals(finish))
                        dem++;
                    if (dem == 2)
                    {
                        result = dothi;
                        return;
                    }
                }
            }
        }



        List<IDiem> TimDuong(int bd, int kt)
        {
            var doThiDung = new List<IDiem>();
            LayDoThiDung(bd, kt, doThiDung);
            if (doThiDung.Count == 0)
                return null;
            var dic = LayTatCaCacCanh();


            throw new NotImplementedException();
        }
        Dictionary<int, int> LayTatCaCacCanh()
        {
            var dic = new Dictionary<int, int>();
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (arr[i, j] != 0)
                    {
                        dic.Add(i, j);
                        arr[j, i] = 0;
                    }
                }
            }
            return dic;
        }

        KeyValuePair<int, int> CanhDung(Dictionary<int, int> dic, int dinh)
        {
            foreach (var giaTri in dic)
            {
                if (giaTri.Value == dinh || giaTri.Key == dinh)
                    return giaTri;
            }
            return new KeyValuePair<int, int>();
        }

        private void DinhDaDuyet(List<int> tapDinhDaDuyet, List<IDiem> doThi)
        {
            foreach (var dinh in doThi)
            {
                tapDinhDaDuyet.Add(int.Parse(dinh.PointName));
            }
        }


        ThuatToan thuatToan;
        private int[,] arr;

        public IDoThi DoThi { get; set; }
    }

}
