using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoWinform
{
    public partial class frmTT : Form
    {
        private DanhSachTruyenTranh ds;
        public frmTT()
        {
            InitializeComponent();
            ds = new DanhSachTruyenTranh();
        }

         void Reset()
        {
            txtMatruyen.Text = "";
            txtNamXuatBan.Text = "";
            txtNhaXuatBan.Text = "";
            txtSoluong.Text = "";
            txtTacgia.Text = "";
            txtTentruyen.Text = "";
        }

        
        void CapNhatListView()
        {
            lvData.Items.Clear();
            for(int i = 0; i < ds.SoPhanTu; i++)
            {
                TruyenTranh tempData = ds.LayThongTinTuVitri(i);
                lvData.Items.Add(new ListViewItem(new string[] {"" +tempData.MaTruyen
                , tempData.NamXuatBan, tempData.NhaXuatBan, tempData.SoLuong.ToString(), tempData.TacGia,
                tempData.TenTruyen}));
            }
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmTT_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult d;
            d = MessageBox.Show("Bạn có thật sự muốn thoát hay không?", "Quản lí thông tin truyện tranh",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (d == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        private void frmTT_Load(object sender, EventArgs e)
        {

        }
       
        private void btnThem_Click(object sender, EventArgs e)
        {
            Reset();
            if (btnThem.Text.Equals("Thêm"))
            {
                for(int i = 0; i < lvData.SelectedItems.Count; i++)
                {
                    lvData.SelectedItems[i].Selected = false;
                }
                btnThem.Text = "Hủy";
                txtMatruyen.Enabled = true;
                txtNamXuatBan.Enabled = true;
                txtNhaXuatBan.Enabled = true;
                txtSoluong.Enabled = true;
                txtTacgia.Enabled = true;
                txtTentruyen.Enabled = true;
                btnLuu.Enabled = true;
                txtMatruyen.Focus();
            }
            else
            {
                btnThem.Text = "Thêm";
                txtMatruyen.Enabled = false;
                txtNamXuatBan.Enabled = false;
                txtNhaXuatBan.Enabled = false;
                txtSoluong.Enabled = false;
                txtTacgia.Enabled = false;
                txtTentruyen.Enabled = false;
                btnLuu.Enabled = false;
                
            }

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                TruyenTranh truyenTranh = new TruyenTranh(int.Parse(txtMatruyen.Text), txtNamXuatBan.Text, txtTacgia.Text, txtTentruyen.Text, txtNamXuatBan.Text, int.Parse(txtSoluong.Text));
                if (ds.ThemTruyenTranh(truyenTranh))
                {
                    CapNhatListView();
                    Reset();
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi dữ liệu", "Quản lí thông tin truyện tranh - Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                txtMatruyen.Focus();
                txtMatruyen.SelectAll();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult d;
            d = MessageBox.Show("Bạn có thật sự muốn xóa không?", "Quản lí thông tin truyện tranh-Xóa dữ liệu",
                (MessageBoxButtons)MessageBoxDefaultButton.Button1);
            for (int i = 0; i < lvData.SelectedItems.Count; i++)
            {
                int maSo = int.Parse(lvData.SelectedItems[i].SubItems[0].Text);
                if(d == DialogResult.OK)
                {
                    ds.Xoa(maSo);
                }
            }
            CapNhatListView();
        }
    }
}
