using Aspose.Pdf;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zoopark
{
    public partial class admin_form : Form
    {
        public admin_form()
        {
            InitializeComponent();


        }

        private void admin_form_Load(object sender, EventArgs e)
        {


            Goods_load();


        }

        public void Goods_load()
        {


            DB dB = new DB();
            dB.Goods_load(dataGridView1);

            Form_style style = new Form_style();
            style.Set_style(dataGridView1);

        }
        private void admin_form_Activated(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "price")
            {

                e.Value = $"{e.Value}₽";
                e.FormattingApplied = true;
            }

            if (dataGridView1.Columns[e.ColumnIndex].Name == "discount_size")
            {

                e.Value = $"{e.Value}%";
                e.FormattingApplied = true;
            }
        }

        private void Goods_delete_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            db.Goods_remove((int)dataGridView1.CurrentRow.Cells[1].Value);
            Goods_load();
        }

        private void admin_form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DB dB = new DB();
            int id = (int)dataGridView1.CurrentRow.Cells[1].Value;
            string name = (string)dataGridView1.CurrentRow.Cells[3].Value;
            string desc = (string)dataGridView1.CurrentRow.Cells[4].Value;

            string manuf = (string)dataGridView1.CurrentRow.Cells[5].Value;
            int price = (int)dataGridView1.CurrentRow.Cells[6].Value;
            int disc_size = (int)dataGridView1.CurrentRow.Cells[7].Value;

            dB.Goods_update(id, name, desc, manuf, price, disc_size);

            Goods_load();

        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            Add_form form = new Add_form();
            this.Hide();
            form.Show();
        }
    }
}
