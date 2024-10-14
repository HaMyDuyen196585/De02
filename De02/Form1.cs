using BUS;
using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace De02
{
    public partial class frmSampham : Form
    {
        private SanPhamS sanphamS;
        
        public frmSampham()
        {
            InitializeComponent();
            sanphamS = new SanPhamS();
          


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadSP();
          

        }

        private void LoadSP()
        {
            var sanpham = sanphamS.getAll();
            dataGridView1.DataSource = sanpham; // Đổ dữ liệu vào DataGridView
        }



        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtM.Text) || string.IsNullOrWhiteSpace(txtT.Text) || cmbL.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin sản phẩm!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var newProduct = new Sanpham
            {
                MaSP = txtM.Text,
                TenSP = txtT.Text,
                Ngaynhap = dateTimePicker1.Value,
                MaLoai = cmbL.SelectedValue.ToString()
            };

            try
            {
                sanphamS.Add(newProduct);
                LoadSP(); // Tải lại danh sách sản phẩm
                ClearFields(); // Xóa các trường nhập
                MessageBox.Show("Sản phẩm đã được thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void ClearFields() // Hàm xóa các trường nhập
        {
            txtM.Clear();      // Xóa textbox mã sản phẩm
            txtT.Clear();     // Xóa textbox tên sản phẩm
            dateTimePicker1.Value = DateTime.Now; // Đặt lại ngày nhập
            cmbL.SelectedIndex = -1; // Đặt lại giá trị ComboBox loại sản phẩm

        }

    }

}
