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
    public partial class UC_Staff : UserControl
    {
        function fn = new function();
        String query;
        public UC_Staff()
        {
            InitializeComponent();
        }

        private void UC_Staff_Load(object sender, EventArgs e)
        {
            txtPasswd.UseSystemPasswordChar = true;
        }

        private void button_StaffRegistration_Click(object sender, EventArgs e)
        {
            if(txtMaNhanVien.Text != "" && txtStaffName.Text != "" && txtMobile.Text != "" && txtGender.Text != "" && txtEmail.Text != "" && txtUserName.Text != "" && txtPasswd.Text != "" && cmb_Quyen.Text != "")
            {
                if (txtMobile.Text.Length <= 10)
                {
                    String manv = txtMaNhanVien.Text;
                    String sname = txtStaffName.Text;
                    Int64 mobile = Int64.Parse(txtMobile.Text);
                    String gender = txtGender.Text;
                    String email = txtEmail.Text;
                    String username = txtUserName.Text;
                    String passwd = txtPasswd.Text;
                    String quyen = cmb_Quyen.Text;
                    query = "insert into NHANVIEN (ID_NHANVIEN, TEN_NHANVIEN, SO_DIEN_THOAI, GIOI_TINH, EMAIL, TEN_DANG_NHAP, MAT_KHAU, QUYEN) values (N'" + manv + "', N'" + sname + "','" + mobile + "',N'" + gender + "','" + email + "','" + username + "','" + passwd + "','" + quyen + "')";
                    fn.setData(query, "Đăng ký nhân viên thành công");
                    UC_Staff_Load(this, null);
                    clearAll();
                }
                else
                {
                    MessageBox.Show("Số điện thoại không vượt quá 10 số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } 
            
        }

        private void clearAll()
        {
            txtStaffName.Clear();
            txtMobile.Clear();
            txtGender.ResetText();
            txtEmail.Clear();
            txtUserName.Clear();
            txtPasswd.Clear();
        }

        private void tabStaff_SelectedIndexChanged(object sender, EventArgs e)
        {
           if(tabStaff.SelectedIndex == 1) 
           {
                setStaff(guna2DataGridView1);
           }    
           else if(tabStaff.SelectedIndex == 2)
           {
                setStaff(guna2DataGridView2);   
           }    
        }

        public void setStaff(DataGridView dgv)
        {
            query = "select * from NHANVIEN";
            DataSet ds = fn.getData(query);
            dgv.DataSource = ds.Tables[0];
        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
            if(txtID.Text != "")
            {
                if (MessageBox.Show("Bạn có chắc chắn không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    if (txtID.Text != "NV000")
                    {
                        query = "delete from NHANVIEN where ID_NHANVIEN = '" + txtID.Text + "' and QUYEN = 'NhanVien'";
                        fn.setData(query, "Thông tin nhân viên đã được xóa");
                        tabStaff_SelectedIndexChanged(this, null);
                    }
                    else 
                    {
                        MessageBox.Show("Không thể xóa admin!","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }  
                else
                {
                    MessageBox.Show("Không có nhân viên nào được xóa!","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }    
            }   
            else
            {
                MessageBox.Show("Vui lòng chọn nhân viên để xóa");
            }    
        }

        private void UC_Staff_Leave(object sender, EventArgs e)
        {
            clearAll();
        }

        private void ckb_passwd_CheckedChanged(object sender, EventArgs e)
        {
            if (!ckb_passwd.Checked)
                txtPasswd.UseSystemPasswordChar = true;
            if (ckb_passwd.Checked)
                txtPasswd.UseSystemPasswordChar = false;
        }
    }
}
