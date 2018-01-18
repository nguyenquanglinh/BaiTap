using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoThiTrenForm
{
    public interface IThuatToanDoThi
    {
        List<IDiem> Duyet(IDoThi doThi, string start);
        void TimDuong(string start, string end);
    }

    class Bfs : IThuatToanDoThi
    {
        public List<IDiem> Duyet(IDoThi doThi, string start)
        {
            throw new NotImplementedException();
        }

        public void TimDuong(string start, string end)
        {
            throw new NotImplementedException();
        }
    }

    class Dfs : IThuatToanDoThi
    {
        public List<IDiem> Duyet(IDoThi doThi, string start)
        {
            return null;
        }

        private void Duyet(IDoThi doThi,string start,List<Diem>result)
        {
            //var Ddau = dt.Lay1DiemTrongTapDinh(dinh.ToString());
            //hinh.tapDinh.Add(Ddau);
            //tapDinhDaDuyet[dinh] = -1;
            //for (int i = 0; i < arr.GetLength(0); i++)
            //{
            //    if (arr[dinh, i] != 0)
            //    {
            //        var canh = new Canh(Ddau, dt.Lay1DiemTrongTapDinh(i.ToString()));
            //        if (!hinh.tapCanh.Contains(canh))
            //            hinh.tapCanh.Add(canh);
            //        if (tapDinhDaDuyet[i] == 0)
            //            ThuTuDuyetDinh(i, hinh, tapDinhDaDuyet);
            //    }
            //}

        }


        public void TimDuong(string start, string end)
        {
            throw new NotImplementedException();
        }
    }


    public class GraphAlo
    {
        IThuatToanDoThi ThuatToanDuyet { get; set; }

        public void TimDuong(string start, string end)
        {
            ThuatToanDuyet.TimDuong(start, end);
        }

        public void DemDoThi()
        {
        }

        public void TimDuongNganNhat()
        {
        }
    }
}
