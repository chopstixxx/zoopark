using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zoopark
{
    public class Form_style
    {
        public void Set_style(DataGridView dataGrid)
        {
            // Проверка наличия столбца изображения
            bool hasImageColumn = dataGrid.Columns.Cast<DataGridViewColumn>().Any(column => column.Name == "Изображение");

            if (!hasImageColumn)
            {
                DataGridViewImageColumn imgColumn = new DataGridViewImageColumn();
                imgColumn.Name = "Изображение";
                dataGrid.Columns.Insert(0, imgColumn);
            }





            dataGrid.Columns[1].Visible = false; // это айди
            dataGrid.Columns[2].Visible = false; // это путь к изображению
            dataGrid.Columns[8].Visible = false; // это количество в наличии

            dataGrid.Columns[3].HeaderText = "Название";
            dataGrid.Columns[4].HeaderText = "Описание";
            dataGrid.Columns[5].HeaderText = "Производитель";
            dataGrid.Columns[6].HeaderText = "Цена";
            dataGrid.Columns[7].HeaderText = "Размер скидки";


            foreach (DataGridViewRow row in dataGrid.Rows)
            {
               
                if (row.Cells["img_path"].Value != null)
                {
                    // Получаем значение ячейки
                    string img_path = row.Cells["img_path"].Value.ToString();

                    Image image = new Bitmap(new Bitmap(img_path), new Size(100, 100));
                      dataGrid.Rows[row.Index].Cells["Изображение"].Value = image;        
                    
                }
            }

        }

    }
}
