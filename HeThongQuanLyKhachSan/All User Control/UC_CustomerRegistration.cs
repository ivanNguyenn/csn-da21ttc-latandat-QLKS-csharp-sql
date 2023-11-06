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
                    cmb.Items.Add(sdr.GetString(i));
                }
            }
            sdr.Close();
        }

        private void UC_CustomerRegistration_Load(object sender, EventArgs e)
        {

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
            query = "select SO_PHONG from THEMPHONG where LOAI_GIUONG = N'" + txtBed.Text + "' and LOAI_PHONG = '" + txtRoomType.Text + "' and TRANG_THAI = 'NO' ";
            setComboBox(query, txtRoomNumber);
        }

        int rid;
        private void txtRoomNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            query = "select GIA_TIEN, ID_PHONG from THEMPHONG where SO_PHONG = '" + txtRoomNumber.Text + "' ";
            DataSet ds = fn.getData(query);
            txtPrice.Text = ds.Tables[0].Rows[0][0].ToString();
            rid = int.Parse(ds.Tables[0].Rows[0][1].ToString());
        }

        private void button_CustomerRegistration_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "" && txtContact.Text != "" && txtAddress.Text != "" && txtGender.Text != "" && txtDateOfBirth.Text != "" && txtNationality.Text != "" && txtIDProof.Text != "" && txtCheckIn.Text != "" && txtPrice.Text != "") 
            {
                String name = txtName.Text;
                Int64 contact = Int64.Parse(txtContact.Text);
                String address = txtAddress.Text;
                String gender = txtGender.Text;
                String dob = txtDateOfBirth.Text;
                String nationality = txtNationality.Text;
                String idproof = txtIDProof.Text;
                String checkin = txtCheckIn.Text;

                query = "insert into DANGKY_KHACHHANG (TEN_KHACHHANG, SO_DIEN_THOAI, DIA_CHI, GIOI_TINH, NGAY_SINH, QUOC_TICH, MA_DINH_DANH, DANG_KY, ID_PHONG) values ('" + name + "','" + contact + "','" + address +  "','" + gender + "','" + dob + "','" + nationality + "','" + idproof + "','" + checkin + "'," + rid + ") update THEMPHONG set TRANG_THAI = 'YES' where SO_PHONG = '" + txtRoomNumber.Text + "'";
                fn.setData(query, " Số Phòng " + txtRoomNumber.Text + " Đăng Ký Khách Hàng Thành Công! ");
                clearAll();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}
