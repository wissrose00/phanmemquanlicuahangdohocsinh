using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace phanmemquanlibandohocsinh
{
    public partial class LAPHOADON : Form
    {
        db conn = new db();
        private bool cochon = false;
        private bool cochon1 = false;
        public LAPHOADON()
        {
            InitializeComponent();
          
        }

        private void LAPHOADON_Load(object sender, EventArgs e)
        {
            load();
        }
        public void load()
        {
            string cmnd = "select * from v_sanpham";
            DataTable dt = conn.readdata(cmnd);

            if (dt != null)
            {
                dataGridView1.DataSource = dt;

            }
            dataGridView1.ClearSelection();
         
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Add(selectedDataGridView1Row.Cells[0].Value,
                          selectedDataGridView1Row.Cells[1].Value, textBox4.Text, selectedDataGridView1Row.Cells[5].Value, (int.Parse(selectedDataGridView1Row.Cells[5].Value.ToString()) * int.Parse(textBox4.Text))
                          );
            dataGridView2.ClearSelection();
            dataGridView1.ClearSelection();
            total();
            cochon = false;
           
        }
        public DataGridViewRow selectedDataGridView1Row { get; set; }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var selectedRow = dataGridView1.SelectedRows[0];

       
            selectedDataGridView1Row = selectedRow; 
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cochon1 = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (cochon1)
            {
                int selectedRowIndex = dataGridView2.CurrentCell.RowIndex;

                dataGridView2.Rows.RemoveAt(selectedRowIndex);
                dataGridView2.ClearSelection();
                total();
                cochon1 = false;

            }
        }

        void total()
        {

            int slt = 0;
            double tong = 0.00;
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                DataGridViewRow row = dataGridView2.Rows[i];
                int tt = Convert.ToInt32(row.Cells[4].Value);
                int sl = Convert.ToInt32(row.Cells[2].Value);
                tong += tt;
                slt += sl;
            }

            // Hiển thị tổng số lượng
            label7.Text = slt.ToString();
            label5.Text = tong.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            thanhtoan(dangnhap.ID_USER, textBox2.Text, textBox3.Text, label5.Text);
          
        }
        private void thanhtoan(string nhanvien, string khach, string sdt, string tongtien)
        {
            string cmnd = "sp_ThemHoaDon '" + nhanvien + "',N'" + khach + "','" + sdt + "','" + tongtien + "'";
            DataTable dt = conn.readdata(cmnd);
            string a = "";
            if (dt != null)
            {
                a = dt.Rows[0][0].ToString();
                for (int i = 0; i < dataGridView2.RowCount; i++)
                {
                    string cm = "sp_ThemHoaDonCT '" + a + "','" + dataGridView2.Rows[i].Cells[0].Value.ToString() + "'," + dataGridView2.Rows[i].Cells[2].Value.ToString() + ",'" + dataGridView2.Rows[i].Cells[4].Value.ToString() + "'";
                    bool y = conn.exedata(cm);
                }
                dataGridView2.Rows.Clear();
                MessageBox.Show("Thanh toán thành công số tiền " + label5.Text);
                textBox2.Text = textBox3.Text = label5.Text = label7.Text = "";
                dataGridView2.Rows.Clear();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            timkiem();
        }
        void timkiem()
        {
            string cmnd = "select * from v_sanpham where [TÊN SP] like N'%" + textBox1.Text + "%'";
            DataTable dt = conn.readdata(cmnd);

            if (dt != null)
            {
                dataGridView1.DataSource = dt;

            }
            dataGridView1.ClearSelection();
            
        }



    }

  

}
