using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Windows;
using System.Net.NetworkInformation;
using System.Windows.Documents;
using System.Xml.Linq;
using MessageBox = System.Windows.Forms.MessageBox;

namespace HeThongQuanLyKhachSan.All_User_Control
{
    public partial class UC_CustomerRegistration : UserControl
    {
        function fn = new function();
        string query;
        public UC_CustomerRegistration()
        {
            InitializeComponent();
        }
        public void setComboBox(string query, ComboBox cmb)
        {
            SqlDataReader sdr = fn.getForCombo(query);
            while (sdr.Read())
            {
                for (int i = 0; i < sdr.FieldCount; i++)
                {
                    cmb.Items.Add(sdr.GetInt32(i));
                }
            }
            sdr.Close();
        }

        private void txtBed_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtRoomType.SelectedIndex = -1;
            txtRoomNumber.Items.Clear();
            txtPrice.Clear();
        }

        private void txtRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtRoomNumber.Items.Clear();
            query = "select SO_PHONG from THEMPHONG where LOAI_GIUONG = N'" + txtBed.Text + "' and LOAI_PHONG = N'" + txtRoomType.Text + "' and TRANG_THAI = 'NO'";
            setComboBox(query, txtRoomNumber);
        }

        int roomnum;
        private void txtRoomNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            query = "select GIA_TIEN from THEMPHONG where SO_PHONG = '" + txtRoomNumber.Text + "'";
            DataSet ds = fn.getData(query);
            roomnum = int.Parse(ds.Tables[0].Rows[0][0].ToString());
            txtPrice.Text = ds.Tables[0].Rows[0][0].ToString();
        }

        private void button_CustomerRegistration_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "" && txtContact.Text != "" && txtAddress.Text != "" && txtGender.Text != "" && txtDateOfBirth.Text != "" && txtNationality.Text != "" && txtIDProof.Text != "" && txtCheckIn.Text != "" && txtPrice.Text != "") 
            {
                if (txtContact.Text.Length <= 10 && txtIDProof.Text.Length <= 12)
                {
                    String name = txtName.Text;
                    Int64 contact = Int64.Parse(txtContact.Text);
                    String address = txtAddress.Text;
                    String gender = txtGender.Text;
                    String dob = txtDateOfBirth.Text;
                    String nationality = txtNationality.Text;
                    String idproof = txtIDProof.Text;
                    DateTime checkin = DateTime.Parse(txtCheckIn.Text);
                    int mathanhtoan = new Random().Next(1, 1000);
                    int number = new Random().Next(DateTime.Now.Millisecond);
                    query = "insert into DANGKY_KHACHHANG (TEN_KHACHHANG, SO_DIEN_THOAI, DIA_CHI, GIOI_TINH, NGAY_SINH, QUOC_TICH, MA_DINH_DANH, DANG_KY, SO_PHONG, ID_KHACHHANG) values (N'" + name + "','" + contact + "',N'" + address + "',N'" + gender + "','" + dob + "','" + nationality + "','" + idproof + "','" + checkin + "','" + txtRoomNumber.Text + "'," + number + ") update THEMPHONG set TRANG_THAI = 'YES' where SO_PHONG = '" + txtRoomNumber.Text + "' insert into THANHTOAN (MA_THANH_TOAN, ID_KHACHHANG) values ('" + mathanhtoan + "','" + number + "')";
                    fn.setData(query, " Số Phòng " + txtRoomNumber.Text + " Đăng Ký Khách Hàng Thành Công!");
                    UC_CustomerRegistration_Load(this, null);
                    clearAll();
                }
                else
                {
                    MessageBox.Show("Số điện thoại không được quá tối đa 10 ký tự và mã định danh không vượt quá 12 số", "Thông báo", (MessageBoxButtons)MessageBoxButton.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Thiếu thông tin.Vui lòng nhập lại", "Thông báo", (MessageBoxButtons)MessageBoxButton.OK, MessageBoxIcon.Information);
            }    
        }

        public void clearAll()
        {
            txtName.Clear();
            txtContact.Clear();
            txtAddress.Clear();
            txtGender.SelectedIndex = -1;
            txtDateOfBirth.ResetText();
            txtNationality.Clear();
            txtIDProof.Clear();
            txtCheckIn.ResetText();
            txtBed.SelectedIndex = -1;
            txtRoomNumber.Items.Clear();
            txtRoomType.SelectedIndex = -1;
            txtPrice.Clear();
        }

        private void UC_CustomerRegistration_Leave(object sender, EventArgs e)
        {
            clearAll();
        }

        private void txtContact_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Từ chối ký tự bị nhập vào
                e.Handled = true; 
            }   
        }

        private void txtIDProof_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }    
        }

        private void UC_CustomerRegistration_Load(object sender, EventArgs e)
        {

        }
    }
}
