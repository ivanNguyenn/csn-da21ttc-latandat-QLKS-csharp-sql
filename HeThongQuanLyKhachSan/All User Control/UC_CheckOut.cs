using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HeThongQuanLyKhachSan.All_User_Control;
using Xamarin.Forms.Xaml;
using static Xamarin.Forms.Internals.Profile;

namespace HeThongQuanLyKhachSan.All_User_Control
{
    public partial class UC_CheckOut : UserControl
    {
        function fn = new function();
        String query;
        public UC_CheckOut()
        {
            InitializeComponent();
            DateTime today = DateTime.Now;
            dtpCheckOutDate.Value = today;
        }

        DateTime NgayDangKy = new DateTime();
        private void UC_CheckOut_Load(object sender, EventArgs e)
        {
            query = "select DANGKY_KHACHHANG.ID_KHACHHANG, DANGKY_KHACHHANG.TEN_KHACHHANG, DANGKY_KHACHHANG.SO_DIEN_THOAI, DANGKY_KHACHHANG.QUOC_TICH, DANGKY_KHACHHANG.GIOI_TINH, DANGKY_KHACHHANG.NGAY_SINH , DANGKY_KHACHHANG.MA_DINH_DANH, DANGKY_KHACHHANG.DIA_CHI, DANGKY_KHACHHANG.DANG_KY, DANGKY_KHACHHANG.SO_PHONG, THEMPHONG.LOAI_GIUONG, THEMPHONG.LOAI_PHONG, THEMPHONG.GIA_TIEN from THANHTOAN inner join DANGKY_KHACHHANG on THANHTOAN.ID_KHACHHANG = DANGKY_KHACHHANG.ID_KHACHHANG inner join THEMPHONG on THEMPHONG.SO_PHONG = DANGKY_KHACHHANG.SO_PHONG where THANH_TOAN = 'NO'";
            DataSet ds = fn.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }

        private void txtID_KHACHHHANG_TextChanged(object sender, EventArgs e)
        {
            query = "select DANGKY_KHACHHANG.ID_KHACHHANG, DANGKY_KHACHHANG.TEN_KHACHHANG, DANGKY_KHACHHANG.SO_DIEN_THOAI, DANGKY_KHACHHANG.QUOC_TICH, DANGKY_KHACHHANG.GIOI_TINH, DANGKY_KHACHHANG.NGAY_SINH , DANGKY_KHACHHANG.MA_DINH_DANH, DANGKY_KHACHHANG.DIA_CHI, DANGKY_KHACHHANG.DANG_KY, THEMPHONG.SO_PHONG, THEMPHONG.LOAI_GIUONG, THEMPHONG.LOAI_PHONG, THEMPHONG.GIA_TIEN from THANHTOAN inner join DANGKY_KHACHHANG on THANHTOAN.ID_KHACHHANG = DANGKY_KHACHHANG.ID_KHACHHANG inner join THEMPHONG on THEMPHONG.SO_PHONG = DANGKY_KHACHHANG.SO_PHONG where DANGKY_KHACHHANG.TEN_KHACHHANG like N'%" + txtID_KHACHHHANG.Text + "%' and THANH_TOAN = 'NO'";
            DataSet ds = fn.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }

        int id;
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (guna2DataGridView1.Rows[e.RowIndex].Cells[e.RowIndex].Value != null)
            {
                id = int.Parse(guna2DataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                txtName.Text = (guna2DataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                txtRoomNumber.Text = (guna2DataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                NgayDangKy = DateTime.Parse(guna2DataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString());
            }    
        }

        private void button_CheckOut_Click(object sender, EventArgs e)
        {
            if(txtName.Text != "")
            {
                if (MessageBox.Show("Bạn có chắc chắn không ?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    DateTime ngayThanhToan = new DateTime(dtpCheckOutDate.Value.Year, dtpCheckOutDate.Value.Month, dtpCheckOutDate.Value.Day);
                    int result = NgayDangKy.CompareTo(ngayThanhToan);
                    // Phương thức này trả về một giá trị nguyên dương nếu biến thứ nhất lớn hơn biến thứ hai
                    if (result > 0 )
                    {
                        MessageBox.Show("Ngày thanh toán không được nhỏ hơn ngày đăng ký");
                    }    
                    else
                    {
                        query = "update THEMPHONG set THEMPHONG.TRANG_THAI = 'NO' from DANGKY_KHACHHANG inner join THEMPHONG on DANGKY_KHACHHANG.SO_PHONG = THEMPHONG.SO_PHONG where ID_KHACHHANG = '" + id + "' update THANHTOAN set THANH_TOAN = 'YES', NGAY_THANH_TOAN = '" + ngayThanhToan + "' from DANGKY_KHACHHANG inner join THANHTOAN on THANHTOAN.ID_KHACHHANG = DANGKY_KHACHHANG.ID_KHACHHANG  where THANHTOAN.ID_KHACHHANG = " + id + "";
                        fn.setData(query, "Thanh toán thành công!");
                    }      
                    UC_CheckOut_Load(this, null);
                    clearAll();
                }
            }    
            else
            {
                MessageBox.Show("Không tìm được khách hàng để thanh toán", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }    
        }
        
        public void clearAll()
        {
            txtName.Clear();
            txtRoomNumber.Clear();
            txtID_KHACHHHANG.Clear();
            dtpCheckOutDate.ResetText();
        }

        private void UC_CheckOut_Leave(object sender, EventArgs e)
        {
            clearAll();
            UC_CheckOut_Load(this, null );
        }

        private void btn_RefeshTT_Click(object sender, EventArgs e)
        {
            UC_CheckOut_Load(this, null);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }
    }
}
