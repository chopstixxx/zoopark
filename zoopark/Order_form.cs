using Aspose.Pdf;
using Aspose.Pdf.Text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.DataFormats;

namespace zoopark
{
    public partial class Order_form : Form
    {

        private Catalog_form catalogForm;
        private DataTable orderDataTable;
        int user_id;


        public bool index_change = false;
        int final_price = 0;
        public Order_form(DataTable dataTable, Catalog_form catalogForm, int u_id)
        {
            InitializeComponent();
            dataGridView1.DataSource = dataTable;
            this.catalogForm = catalogForm;
            this.orderDataTable = dataTable;
            user_id = u_id;
        }
        private void Order_btn_Click(object sender, EventArgs e)
        {          
            if (!index_change)
            {
                MessageBox.Show("Выберите пункт выдачи!");
                return;
            }


            string pickup_point = Convert.ToString(comboBox1.SelectedItem);

            int delivery_days = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                string stock_count = row.Cells["stock_count"].Value.ToString();
                int stock_count_ = Convert.ToInt32(stock_count);
                if (stock_count_ >= 3)
                {
                    delivery_days = 3;
                }
                else
                {
                    delivery_days = 6;

                }

            }


            DB dB = new DB();
           int order_num = dB.Order_create(user_id, delivery_days, final_price, pickup_point);


            Order order = new Order();
            order.Order_to_pdf(order_num, pickup_point, final_price, dataGridView1 );

          

            orderDataTable.Clear();
            Back_to_catalog();
           





        }

        
        private void Order_form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Order_form_Load(object sender, EventArgs e)
        {

            Form_style style = new Form_style();
            style.Set_style(dataGridView1);

            Final_price_count();


            comboBox1.Items.Add("Ул. Ворошилова, дом 45");
            comboBox1.Items.Add("Ул. Героев Сибиряков, дом 35");
            comboBox1.Items.Add("Ул. Московский проспект, дом 33");



        }

        public void Final_price_count()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {


                // Получаем значение ячейки
                string price = row.Cells["price"].Value.ToString();
                string count = row.Cells["Количество"].Value.ToString();
                final_price += Convert.ToInt32(price) * Convert.ToInt32(count);




            }
            Price_label.Text = string.Format("Итого: {0}₽", final_price);
        }
        private void back_btn_Click(object sender, EventArgs e)
        {
            Back_to_catalog();        
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
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Количество")
            {

                e.Value = $"{e.Value} шт.";
                e.FormattingApplied = true;
            }
        }

        private void remove_position_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Удаляем выделенные строки из DataTable
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    DataRowView dataRowView = (DataRowView)row.DataBoundItem;
                    DataRow rowToDelete = dataRowView.Row;
                    orderDataTable.Rows.Remove(rowToDelete);
                }
                final_price = 0;
                Final_price_count();
                // Обновляем итоговую цену
            }
            if (dataGridView1.Rows.Count < 1)
            {
                catalogForm.orderDataTable = orderDataTable;
                catalogForm.Show();
                this.Hide();
            }



        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            index_change = true;
        }

        public void Back_to_catalog()
        {

            catalogForm.orderDataTable = orderDataTable;
            catalogForm.Show();
            this.Hide();
        }
    }
}
