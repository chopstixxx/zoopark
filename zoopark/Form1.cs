using document_oborot;
using System.Data;

namespace zoopark
{
    public partial class Catalog_form : Form
    {
        int user_id;
        public DataTable orderDataTable = new DataTable(); // Создаем DataTable
        public Catalog_form(int u_id)
        {
            InitializeComponent();

            user_id = u_id;

        }

        private void Catalog_form_Load(object sender, EventArgs e)
        {


            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridView1.MultiSelect = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;






            DB dB = new DB();
            dB.Goods_load(dataGridView1);


            Form_style style = new Form_style();

            style.Set_style(dataGridView1);




            orderDataTable = ((DataTable)dataGridView1.DataSource).Clone();

            DataColumn quantityColumn = new DataColumn("Количество", typeof(int));
            quantityColumn.DefaultValue = 1;
            orderDataTable.Columns.Add(quantityColumn);
            orderDataTable.PrimaryKey = new DataColumn[] { orderDataTable.Columns["id"] }; // Замените "ID" на ваш уникальный идентификатор товара




        }

        private void добавитьКЗаказуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection rows = dataGridView1.SelectedRows;

            foreach (DataGridViewRow row in rows)
            {
                DataRow newRow = ((DataRowView)row.DataBoundItem).Row;
                DataRow existingRow = orderDataTable.Rows.Find(newRow["id"]); // Поиск по уникальному идентификатору товара

                if (existingRow != null)
                {
                    existingRow["Количество"] = (int)existingRow["Количество"] + 1; // Увеличение количества на 1
                }
                else
                {
                    DataRow newRowCopy = orderDataTable.NewRow();
                    newRowCopy.ItemArray = newRow.ItemArray;
                    orderDataTable.Rows.Add(newRowCopy);
                }
            }
            Order_check_btn.Visible = true;

        }

        private void Auth_btn_Click(object sender, EventArgs e)
        {
            Auth_form form = new Auth_form();
            this.Hide();
            form.Show();
        }

        private void Order_check_btn_Click(object sender, EventArgs e)
        {

            Order_form form = new Order_form(orderDataTable, this, user_id);
            this.Hide();
            form.Show();
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



        private void Catalog_form_Activated(object sender, EventArgs e)
        {
            DB dB = new DB();
            if (dB.Role_check(user_id) == 4)
            {
                admin_form form = new admin_form();
                this.Hide();
                form.Show();
            }









            if (orderDataTable.Rows.Count > 0)
            {

                Order_check_btn.Visible = true;


            }
            else
            {
                Order_check_btn.Visible = false; // Если нет строк, делаем кнопку невидимой
            }



        }

        private void Catalog_form_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void Catalog_form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
    }
}