using Aspose.Pdf;
using Aspose.Pdf.Text;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zoopark
{
    public class Order
    {    
        public void Order_to_pdf(int order_num, string pickup_point, int final_price ,DataGridView data)
        {

            Document document = new Document();

            Page page = document.Pages.Add();

            var contractTitle = new TextFragment($"Заказ №{order_num}");
            contractTitle.TextState.Font = FontRepository.FindFont("Times New Roman");
            contractTitle.TextState.FontSize = 16;
            contractTitle.HorizontalAlignment = Aspose.Pdf.HorizontalAlignment.Center;
            contractTitle.TextState.FontStyle = FontStyles.Bold;
            page.Paragraphs.Add(contractTitle);


            string cur_date = DateTime.Now.ToString("dd.MM.yyyy");
            var date = new TextFragment($"Г. Воронеж {cur_date}\n\n" + "Состав заказа:");
            date.TextState.Font = FontRepository.FindFont("Times New Roman");
            date.TextState.FontSize = 14;
            page.Paragraphs.Add(date);



            int pos_num = 1;
            foreach (DataGridViewRow row in data.Rows)
            {
                string name = row.Cells["name"].Value.ToString();
                string description = row.Cells["description"].Value.ToString();
                string manufacturer = row.Cells["manufacturer"].Value.ToString();
                string price = row.Cells["price"].Value.ToString();
                string discount_size = row.Cells["discount_size"].Value.ToString();
                int count = Convert.ToInt32(row.Cells["Количество"].Value);



                int product_id = Convert.ToInt32(row.Cells["id"].Value);

                DB db = new DB();
                db.Order_products_create(order_num, product_id, count);



                var order_positions = $"● Позиция №{pos_num}\n"
               + $"Название: {name}\n"
               + $"Описание: {description}\n"
               + $"Производитель: {manufacturer}\n"
               + $"Цена: {price}₽\n"
               + $"Размер скидки: {discount_size}%\n"
               + $"Количество: {count} шт.\n";

                var order = new TextFragment(order_positions);
                order.TextState.Font = FontRepository.FindFont("Times New Roman");
                order.TextState.FontSize = 14;
                page.Paragraphs.Add(order);

                pos_num++;
            }

            var f_price_text = $"Итого: {final_price}₽\n";

            var f_price = new TextFragment(f_price_text);
            f_price.TextState.Font = FontRepository.FindFont("Times New Roman");
            f_price.TextState.FontSize = 14;
            f_price.TextState.FontStyle = FontStyles.Bold;
            page.Paragraphs.Add(f_price);

            var delivery_text = $"Пункт выдачи: {pickup_point}";

            var delivery = new TextFragment(delivery_text);
            delivery.TextState.Font = FontRepository.FindFont("Times New Roman");
            delivery.TextState.FontSize = 14;
            page.Paragraphs.Add(delivery);


            Random rand = new Random();
            int randomNumber = rand.Next(100, 1000);
            var num_text = $"Код получения: {randomNumber}";

            var num = new TextFragment(num_text);
            num.TextState.Font = FontRepository.FindFont("Times New Roman");
            num.TextState.FontSize = 16;
            num.TextState.FontStyle = FontStyles.Bold;
            page.Paragraphs.Add(num);



            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "PDF Files|*.pdf";
            saveFileDialog1.Title = "Save PDF File";
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != "")
            {
                document.Save(saveFileDialog1.FileName);
            }


        }

    }
}
