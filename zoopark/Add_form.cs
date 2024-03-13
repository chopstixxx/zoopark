using System;
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
    public partial class Add_form : Form
    {
        public Add_form()
        {
            InitializeComponent();
        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            try
            {
                Convert.ToString(textBox1.Text);
            }
            catch
            {
                MessageBox.Show("Неправильный формат названия!");
                return;
            }
            try
            {
                Convert.ToString(textBox2.Text);
            }
            catch
            {
                MessageBox.Show("Неправильный формат описания!");
                return;
            }
            try
            {
                Convert.ToString(textBox3.Text);
            }
            catch
            {
                MessageBox.Show("Неправильный формат производителя!");
                return;
            }
            try
            {
                Convert.ToInt32(textBox4.Text);
            }
            catch
            {
                MessageBox.Show("Неправильный формат цены!");
                return;
            }
            try
            {
                Convert.ToInt32(textBox5.Text);
            }
            catch
            {
                MessageBox.Show("Неправильный формат скидки!");
                return;
            }
            try
            {
                Convert.ToInt32(textBox6.Text);
            }
            catch
            {
                MessageBox.Show("Неправильный формат количества!");
                return;
            }

            DB dB = new DB();
            dB.Goods_add("images/product2.png", textBox1.Text, textBox2.Text, textBox3.Text, Convert.ToInt32(textBox4.Text), Convert.ToInt32(textBox5.Text), Convert.ToInt32(textBox6.Text));
        }

        private void Add_form_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            admin_form form = new admin_form();
            this.Hide();
            form.Show();
        }
    }
}
