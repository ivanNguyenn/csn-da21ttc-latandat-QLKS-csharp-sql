using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeThongQuanLyKhachSan.All_User_Control
{
    public partial class UC_CustomerDetails : UserControl
    {

        function fn = new function();
        String query;
        public UC_CustomerDetails()
        {
            InitializeComponent();
        }

        private void txtSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(txtSearchBy.SelectedIndex == 0)
            {
                query = "select DANGKY_KHACHHANG.ID_KHACHHANG, DANGKY_KHACHHANG.TEN_KHACHHANG, DANGKY_KHACHHANG.SO_DIEN_THOAI, DANGKY_KHACHHANG.QUOC_TICH, DANGKY_KHACHHANG.GIOI_TINH, DANGKY_KHACHHANG.NGAY_SINH , DANGKY_KHACHHANG.MA_DINH_DANH, DANGKY_KHACHHANG.DIA_CHI, DANGKY_KHACHHANG.DANG_KY, DANGKY_KHACHHANG.SO_PHONG, THANHTOAN.MA_THANH_TOAN, THANHTOAN.THANH_TOAN, THANHTOAN.NGAY_THANH_TOAN from THANHTOAN inner join DANGKY_KHACHHANG on THANHTOAN.ID_KHACHHANG = DANGKY_KHACHHANG.ID_KHACHHANG";
                getRecord(query);
            }
            else if(txtSearchBy.SelectedIndex == 1)
            {
                query = "select DANGKY_KHACHHANG.ID_KHACHHANG, DANGKY_KHACHHANG.TEN_KHACHHANG, DANGKY_KHACHHANG.SO_DIEN_THOAI, DANGKY_KHACHHANG.QUOC_TICH, DANGKY_KHACHHANG.GIOI_TINH, DANGKY_KHACHHANG.NGAY_SINH , DANGKY_KHACHHANG.MA_DINH_DANH, DANGKY_KHACHHANG.DIA_CHI, DANGKY_KHACHHANG.DANG_KY, DANGKY_KHACHHANG.SO_PHONG, THANHTOAN.MA_THANH_TOAN, THANHTOAN.THANH_TOAN, THANHTOAN.NGAY_THANH_TOAN from THANHTOAN inner join DANGKY_KHACHHANG on THANHTOAN.ID_KHACHHANG = DANGKY_KHACHHANG.ID_KHACHHANG where THANH_TOAN = 'NO'";
                getRecord(query);
            }
            else if(txtSearchBy.SelectedIndex == 2)
            {
                query = "select DANGKY_KHACHHANG.ID_KHACHHANG, DANGKY_KHACHHANG.TEN_KHACHHANG, DANGKY_KHACHHANG.SO_DIEN_THOAI, DANGKY_KHACHHANG.QUOC_TICH, DANGKY_KHACHHANG.GIOI_TINH, DANGKY_KHACHHANG.NGAY_SINH , DANGKY_KHACHHANG.MA_DINH_DANH, DANGKY_KHACHHANG.DIA_CHI, DANGKY_KHACHHANG.DANG_KY, DANGKY_KHACHHANG.SO_PHONG, THANHTOAN.MA_THANH_TOAN, THANHTOAN.THANH_TOAN, THANHTOAN.NGAY_THANH_TOAN from THANHTOAN inner join DANGKY_KHACHHANG on THANHTOAN.ID_KHACHHANG = DANGKY_KHACHHANG.ID_KHACHHANG where THANH_TOAN = 'YES'";
                getRecord(query);
            }
        }

        private void getRecord(string query)
        {
            DataSet ds = fn.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }

        private void txt_FullName_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchBy.SelectedIndex == 0)
            {
                query = "select DANGKY_KHACHHANG.ID_KHACHHANG, DANGKY_KHACHHANG.TEN_KHACHHANG, DANGKY_KHACHHANG.SO_DIEN_THOAI, DANGKY_KHACHHANG.QUOC_TICH, DANGKY_KHACHHANG.GIOI_TINH, DANGKY_KHACHHANG.NGAY_SINH , DANGKY_KHACHHANG.MA_DINH_DANH, DANGKY_KHACHHANG.DIA_CHI, DANGKY_KHACHHANG.DANG_KY, DANGKY_KHACHHANG.SO_PHONG, THANHTOAN.MA_THANH_TOAN, THANHTOAN.THANH_TOAN, THANHTOAN.NGAY_THANH_TOAN from THANHTOAN inner join DANGKY_KHACHHANG on THANHTOAN.ID_KHACHHANG = DANGKY_KHACHHANG.ID_KHACHHANG where DANGKY_KHACHHANG.TEN_KHACHHANG like '%" + txt_FullName.Text + "%'";
                getRecord(query);
            }
            else if (txtSearchBy.SelectedIndex == 1)
            {
                query = "select DANGKY_KHACHHANG.ID_KHACHHANG, DANGKY_KHACHHANG.TEN_KHACHHANG, DANGKY_KHACHHANG.SO_DIEN_THOAI, DANGKY_KHACHHANG.QUOC_TICH, DANGKY_KHACHHANG.GIOI_TINH, DANGKY_KHACHHANG.NGAY_SINH , DANGKY_KHACHHANG.MA_DINH_DANH, DANGKY_KHACHHANG.DIA_CHI, DANGKY_KHACHHANG.DANG_KY, DANGKY_KHACHHANG.SO_PHONG, THANHTOAN.MA_THANH_TOAN, THANHTOAN.THANH_TOAN, THANHTOAN.NGAY_THANH_TOAN from THANHTOAN inner join DANGKY_KHACHHANG on THANHTOAN.ID_KHACHHANG = DANGKY_KHACHHANG.ID_KHACHHANG where DANGKY_KHACHHANG.TEN_KHACHHANG like '%" + txt_FullName.Text + "%' and THANH_TOAN = 'NO'";
                getRecord(query);
            }
            else if (txtSearchBy.SelectedIndex == 2)
            {
                query = "select DANGKY_KHACHHANG.ID_KHACHHANG, DANGKY_KHACHHANG.TEN_KHACHHANG, DANGKY_KHACHHANG.SO_DIEN_THOAI, DANGKY_KHACHHANG.QUOC_TICH, DANGKY_KHACHHANG.GIOI_TINH, DANGKY_KHACHHANG.NGAY_SINH , DANGKY_KHACHHANG.MA_DINH_DANH, DANGKY_KHACHHANG.DIA_CHI, DANGKY_KHACHHANG.DANG_KY, DANGKY_KHACHHANG.SO_PHONG, THANHTOAN.MA_THANH_TOAN, THANHTOAN.THANH_TOAN, THANHTOAN.NGAY_THANH_TOAN from THANHTOAN inner join DANGKY_KHACHHANG on THANHTOAN.ID_KHACHHANG = DANGKY_KHACHHANG.ID_KHACHHANG where DANGKY_KHACHHANG.TEN_KHACHHANG like '%" + txt_FullName.Text + "%' and THANH_TOAN = 'YES'";
                getRecord(query);
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }
    }
}
