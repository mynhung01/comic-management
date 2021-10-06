using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace DemoWinform
{
    class DanhSachTruyenTranh
    {
        private LinkedList<TruyenTranh> tt;

        public DanhSachTruyenTranh()
        {
            tt = new LinkedList<TruyenTranh>();
        }

        public int SoPhanTu { get { return tt.Count; } }

        public TruyenTranh LayThongTin(int maTruyen)
        {
            foreach(TruyenTranh truyenTranh in tt)
            {
                if(truyenTranh.MaTruyen == maTruyen)
                {
                    return truyenTranh;
                }
            }
            return null;
        }

        public bool ThemTruyenTranh(TruyenTranh item)
        {
            if(LayThongTin(item.MaTruyen) != null)
            {
                MessageBox.Show("Mã truyện đã tồn tại !", "Quản lí thông tin truyện tranh-Lỗi dữ liệu",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                tt.AddLast(item);
            }
            return true;
        }
        public bool Xoa(int maTruyen)
        {
            TruyenTranh truyen = LayThongTin(maTruyen);
            if(truyen == null)
            {
                return false;
            }
            else
            {
                tt.Remove(truyen);
            }
            return true;
        }

        public TruyenTranh LayThongTinTuVitri(int index)
        {
            if(index < 0 || index >= SoPhanTu)
            {
                return null;
            }
            else
            {
                LinkedListNode<TruyenTranh> tam = tt.First;
                for(int i=0; i < index; i++)
                {
                    tam = tam.Next;
                }
                return tam.Value;
            }
        }
    }
}
