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
    public partial class capnhatsanpham : Form
    {
        public string id;
        db conn = new db();
        QUANLISANPHAM ql;
        public capnhatsanpham(string id,QUANLISANPHAM ql)
        {
         
            InitializeComponent();
            this.id = id;
            this.ql = ql;
            dodulieu1();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (id == "")
            {
                them();
            }
            else
            {
                sua();
            }
            ql.load();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void capnhatsanpham_Load(object sender, EventArgs e)
        {
            dodulieu1();
            if (id != "") 
            { dodulieu(id); }
           
        }
        private void dodulieu1()
        {
            string cmd = "select * from loai ";
            DataTable dt = conn.readdata(cmd);
            if (dt != null)
            {
                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "ten";
                comboBox1.ValueMember = "ma";
            }

        }
        private void dodulieu(string id)
        {

            string cmnd = "select * from sanpham where ma = " + id;
            DataTable dt = conn.readdata(cmnd);
            if (dt != null)
            {
                textBox1.Text = dt.Rows[0]["ma"].ToString();
                textBox2.Text = dt.Rows[0]["sanpham"].ToString();
                comboBox1.SelectedValue = dt.Rows[0]["loai"];
                textBox4.Text = dt.Rows[0]["mau"].ToString();
                textBox5.Text = dt.Rows[0]["size"].ToString();
                textBox6.Text = dt.Rows[0]["gia"].ToString();
                textBox7.Text = dt.Rows[0]["soluong"].ToString();
            }
        }

        private void them()
        {
            string cmd = "SP_them_sanpham N'" + textBox2.Text + "','" + comboBox1.SelectedValue + "',N'" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "'";

            if (conn.exedata(cmd) == true)
            {
                MessageBox.Show("Đã thêm ");
            }
            else
            {
                MessageBox.Show("Không thể thêm");
            }

            this.Close();
        }

        private void sua()
        {
            string cmd = "SP_sua_sanpham '" + textBox1.Text + "',N'" + textBox2.Text + "','" + comboBox1.SelectedValue + "',N'" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "'";

            if (conn.exedata(cmd) == true)
            {
                MessageBox.Show("Đã sửa");
                this.Close();
            }
            else
            {
                MessageBox.Show("Không thể sửa");
            }
        }
    }
}
