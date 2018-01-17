using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace DoThiTrenForm
{
    interface CacFile
    {
        void LuuFile(string fileName);
        void DocFile(string fileName);
    }
    public class FileText : CacFile
    {
        string pathDinh = "D:\\BaiTap1\\TimDuongTrenForm\\Data\\";
        string pathArr = "D:\\BaiTap1\\TimDuongTrenForm\\Data\\Arr\\";
        DoThi DT;
        DrawCanh draw;


        public FileText(DoThi dT, DrawCanh draw)
        {
            DT = dT;
            this.draw = draw;
        }

        public void LuuFile(string fileName)
        {
            LuuFileDinh(fileName);
            LuuFileCanh(fileName);
        }

        private void LuuFileCanh(string fileName)
        {
            string pathFileCanh = pathArr + fileName + ".txt";
            foreach (var canh in DT.tapCanh)
            {
                var appendTextCanh = canh + Environment.NewLine;
                File.AppendAllText(pathFileCanh, appendTextCanh);
            }

        }

        private void LuuFileDinh(string fileName)
        {
            string pathFileDinh = pathDinh + fileName + ".txt";
            foreach (var dinh in DT.tapDinh)
            {
                var appendTextDinh = dinh + Environment.NewLine;
                File.AppendAllText(pathFileDinh, appendTextDinh);
            }
        }

        public void DocFile(string fileName)
        {
            string path = pathDinh + fileName + ".txt";
            var toaDoDinh = DocFileText(path);
            for (int i = 0; i < toaDoDinh.Count; i += 2)
            {
                var dDiem = new Diem() { Location = new Point(int.Parse(toaDoDinh[i]), int.Parse(toaDoDinh[i + 1])) };
                dDiem.Color = Color.Blue;
                draw.f1.Controls.Add(dDiem);
                if (!DT.tapDinh.Contains(dDiem))
                    DT.ThemDinh(dDiem);
            }
            path = pathArr + fileName + ".txt";

            var cacTapCanh = DocFileText(path);
            for (int i = 0; i < cacTapCanh.Count; i += 2)
            {
                var dDau = DT.Lay1DiemTrongTapDinh(cacTapCanh[i]);

                var dCuoi = DT.Lay1DiemTrongTapDinh(cacTapCanh[i]);
                var canh = new Canh(dDau, dCuoi);
                if (!DT.tapCanh.Contains(canh))
                    DT.ThemCanh(canh);
            }
        }

        private List<string> DocFileText(string pathFileName)
        {
            var xx = File.ReadAllLines(pathFileName);
            var tapGiaTri = new List<string>();
            foreach (var dong in xx)
            {
                foreach (var item in dong.Split(' '))
                {
                    tapGiaTri.Add(item);
                }
            }
            return tapGiaTri;
        }


    }
}


