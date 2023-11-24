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
    public partial class THONGKE : Form
    {
        db conn = new db();
        public THONGKE()
        {
            InitializeComponent();
            load();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void load()
        {
            string cmnd = "select * from v_thongke ";
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

        private void button1_Click(object sender, EventArgs e)
        {
            string dt1 = dateTimePicker1.Value.ToString("yyyy'/'MM'/'dd");
            string dt2 = dateTimePicker2.Value.ToString("yyyy'/'MM'/'dd");
            string cmnd = "select * from v_thongke where ngay >= '" + dt1 + "' AND ngay <= '" + dt2 + "' ";
            DataTable dt = conn.readdata(cmnd);

            if (dt != null)
            {
                dataGridView1.DataSource = dt;
                double tong = 0.00;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    DataGridViewRow row = dataGridView1.Rows[i];
                    int tt = Convert.ToInt32(row.Cells[3].Value);
                    tong += tt;
                }
            }
            dataGridView1.ClearSelection();
        }

        private void THONGKE_Load(object sender, EventArgs e)
        {

        }
    }
}
