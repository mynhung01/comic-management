using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoWinform
{
    class TruyenTranh
    {
        public TruyenTranh(int maTruyen, string namXuatBan, string tacGia, string tenTruyen, string nhaXuatBan, int soLuong)
        {
            MaTruyen = maTruyen;
            NamXuatBan = namXuatBan;
            TacGia = tacGia;
            TenTruyen = tenTruyen;
            NhaXuatBan = nhaXuatBan;
            SoLuong = soLuong;
        }

        public int MaTruyen { get; set; }
        public string NamXuatBan { get; set; }
        public string TacGia { get; set; }
        public string TenTruyen { get; set; }
        public string NhaXuatBan { get; set; }
        public int SoLuong { get; set; }

       
    }
}
