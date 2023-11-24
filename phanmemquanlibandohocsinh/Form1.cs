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
    public partial class Form1 : Form
    {
        db conn = new db();
        public bool isExit = true;
        public event EventHandler logout;
        public Form1()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            THONGKE tk = new THONGKE();
            tk.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            QUANLISANPHAM sp = new QUANLISANPHAM();
            sp.ShowDialog();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            QUANLIHOADON hd = new QUANLIHOADON();
            hd.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            QUANLILOAISANPHAM dm = new QUANLILOAISANPHAM();
            dm.ShowDialog();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            LAPHOADON lhd = new LAPHOADON();
            lhd.ShowDialog();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (isExit)
                Application.Exit();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isExit)
            {
                if (MessageBox.Show("Bạn có thật sự muốn thoát chương trình ?", "Thông báo ", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
                {
                    e.Cancel = true;
                }
            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label2.Text = " Log-in: "+dangnhap.Name_USER;
            load();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            logout(this, new EventArgs());
        }

        void load()
        {
            string cmnd = "select * from v_sanphambanchay  where YEAR([ngay]) = YEAR(GETDATE()) AND MONTH([ngay]) = MONTH(GETDATE())";
            DataTable dt = conn.readdata(cmnd);

            if (dt != null)
            {
                dataGridView1.DataSource = dt;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    DataGridViewRow row = dataGridView1.Rows[i];

                }
            }
            dataGridView1.ClearSelection();
        }

    }
}

