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
            throw new NotImplementedException();
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
            //foreach (var item in MTAThreadAttribute )
            //{

            //}
            //var thuTuDuyet = ThuatToanDuyet.Duyet(null, "0");

        }

        public void TimDuongNganNhat()
        {

        }
    }
}
