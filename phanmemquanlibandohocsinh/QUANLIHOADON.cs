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
    public partial class QUANLIHOADON : Form
    {
        db conn = new db();
        public QUANLIHOADON()
        {
            InitializeComponent();
            load();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void QUANLIHOADON_Load(object sender, EventArgs e)
        {

        }
        public void load()
        {
            string cmnd = "select * from v_hoadon ";
            DataTable dt = conn.readdata(cmnd);

            if (dt != null)
            {
                dataGridView1.DataSource = dt;

            }
            dataGridView1.ClearSelection();
            label4.Text = string.Format("Tổng cộng: {0} hóa đơn.", dataGridView1.Rows.Count);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string dt1 = dateTimePicker1.Value.ToString("yyyy'/'MM'/'dd");
            string dt2 = dateTimePicker2.Value.ToString("yyyy'/'MM'/'dd");
            string cmnd = "select * from v_hoadon where [NGÀY LẬP] >= '" + dt1 + "' AND [NGÀY LẬP] <= '" + dt2 + "'";
            DataTable dt = conn.readdata(cmnd);

            if (dt != null)
            {
                dataGridView1.DataSource = dt;

            }
            dataGridView1.ClearSelection();
            label4.Text = string.Format("Tổng cộng: {0} hóa đơn.", dataGridView1.Rows.Count);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LAPHOADON lhd = new LAPHOADON();
            lhd.ShowDialog();
        }

   
        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                string c1 = selectedRow.Cells[0].Value.ToString();
                string c2 = selectedRow.Cells[1].Value.ToString();
                string c6 = selectedRow.Cells[2].Value.ToString();
                string c3 = selectedRow.Cells[3].Value.ToString();
                string c4 = selectedRow.Cells[4].Value.ToString();
                string c5 = selectedRow.Cells[5].Value.ToString();

                label14.Text = c2;
                label8.Text = c5;
                label9.Text = c6;
                label12.Text = c3;
                label10.Text = c4;


                string cmnd = "select * from v_cthd where SHD =" + c1;
                DataTable dt = conn.readdata(cmnd);

                if (dt != null)
                {
                    dataGridView2.DataSource = dt;

                }
                dataGridView2.ClearSelection();



            }
        }

    }
}
