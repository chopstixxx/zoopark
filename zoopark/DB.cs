using Aspose.Pdf.Operators;
using Microsoft.VisualBasic.Logging;
using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace zoopark
{
    public class DB
    {
        NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;Port=5432;Database=zoo_db;User Id=postgres;Password=123");


        public NpgsqlConnection GetConn()
        {
            return conn;
        }
        public void Goods_load(DataGridView dataGrid)
        {
            

            using (conn)
            {
                conn.Open();

                using (NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("SELECT * FROM product", conn))
                {

                    DataTable dt = new DataTable();
                    dataAdapter.Fill(dt);
                    dataGrid.DataSource = dt;
                   

                }
                

            }
           
        }
       

        public int Order_create(int user_id, int del_days, int final_price, string pickup_point)
        {
            using(conn)
            {
                conn.Open();
                using(NpgsqlCommand cmd = new NpgsqlCommand($"INSERT INTO orders (user_id, delivery_days, status, final_price, pick_up_point) VALUES (@user_id,@del_days,@status,@final_price,@pk_point) RETURNING id",conn))
                {
                    cmd.Parameters.Add("@user_id", NpgsqlDbType.Integer).Value = user_id;
                    cmd.Parameters.Add("@del_days", NpgsqlDbType.Integer).Value = del_days;
                    cmd.Parameters.Add("@status", NpgsqlDbType.Varchar).Value = "Новый";
                    cmd.Parameters.Add("@final_price", NpgsqlDbType.Integer).Value = final_price;
                    cmd.Parameters.Add("@pk_point", NpgsqlDbType.Varchar).Value = pickup_point;



                    try
                    {
                        int order_id = (int)cmd.ExecuteScalar();
                        MessageBox.Show("Заказ успешно создан!");
                        return order_id;

                    }
                    catch (Exception ex) 
                    {
                        MessageBox.Show(ex.Message);
                        return -1;
                    }
                }
                
            }

        }
        public void Order_products_create(int order_id, int proudct_id, int count)
        {

            using (conn)
            {
                conn.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand($"INSERT INTO order_products (order_id, product_id, count) VALUES (@order_id,@product_id,@count) RETURNING id", conn))
                {
                    cmd.Parameters.Add("@order_id", NpgsqlDbType.Integer).Value = order_id;
                    cmd.Parameters.Add("@product_id", NpgsqlDbType.Integer).Value = proudct_id;
                    cmd.Parameters.Add("@count", NpgsqlDbType.Integer).Value = count;


                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);                      
                    }
                }

            }
        }
        public int Role_check(int u_id)
        {
            using(conn)
            {
                conn.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT role_id FROM users WHERE id = @id",conn))
                {
                    cmd.Parameters.Add("@id", NpgsqlDbType.Integer).Value = u_id;
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int role_id = reader.GetInt32(reader.GetOrdinal("role_id"));

                            return role_id;
                          
                        }
                         return 0;
                    }



                }




            }
        }
        public void Goods_remove(int id)
        {
            using(conn)
            {
                conn.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand("DELETE FROM product WHERE id = @id", conn))
                {
                    cmd.Parameters.Add("@id", NpgsqlDbType.Integer).Value = id;


                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Товар успешно удалён!");

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }


                }

            }
        }
        public void Goods_update(int id, string name, string desc, string manuf, int price, int disc_size)
        {
            using (conn)
            {
                conn.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand("UPDATE product SET name = @name, description = @description, manufacturer = @manufacturer, price = @price, discount_size = @discount_size WHERE id = @id", conn))
                {
                    cmd.Parameters.Add("@id", NpgsqlDbType.Integer).Value = id;
                    cmd.Parameters.Add("@name", NpgsqlDbType.Text).Value = name;
                    cmd.Parameters.Add("@description", NpgsqlDbType.Text).Value = desc;
                    cmd.Parameters.Add("@manufacturer", NpgsqlDbType.Text).Value = manuf;
                    cmd.Parameters.Add("@price", NpgsqlDbType.Integer).Value = price;
                    cmd.Parameters.Add("@discount_size", NpgsqlDbType.Integer).Value = disc_size;




                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Товар успешно обновлён!");

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }


                }

            }
        }

        public void Goods_add(string path, string name, string desc, string manufacturer,int price, int disc_size, int stock)
        {
            using (conn)
            {
                conn.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO product (img_path, name, description, manufacturer, price, discount_size, stock_count) VALUES (@path,@name,@desc,@manu,@price,@disc_size,@stock)", conn))
                {
                    cmd.Parameters.Add("@path", NpgsqlDbType.Text).Value = path;
                    cmd.Parameters.Add("@name", NpgsqlDbType.Text).Value = name;
                    cmd.Parameters.Add("@desc", NpgsqlDbType.Text).Value = desc;
                    cmd.Parameters.Add("@manu", NpgsqlDbType.Text).Value = manufacturer;
                    cmd.Parameters.Add("@price", NpgsqlDbType.Integer).Value = price;

                    cmd.Parameters.Add("@disc_size", NpgsqlDbType.Integer).Value = disc_size;
                    cmd.Parameters.Add("@stock", NpgsqlDbType.Integer).Value = stock;

                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Товар успешно добавлен!");
                       
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }


                }

            }
        }


    }
}
