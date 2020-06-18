using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Ресторан
{
    class БД
    {
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Зохар\Ресторан.mdf;Integrated Security=True;Connect Timeout=30";

        SqlConnection connection;
        SqlDataAdapter adapter;
        DataSet dataSet;
        DataTable dataTable;


        public void Подключение()
        {
                connection = new SqlConnection(connectionString);
          
        }

        public DataSet Таблица_Блюда()
        {
                Подключение();
                dataSet = new DataSet();
                connection.Open();
                adapter = new SqlDataAdapter("SELECT * FROM Блюда", connection);
                adapter.Fill(dataSet);
                connection.Close();
                return dataSet;
        }
        public DataSet Таблица_Клиенты()
        {
            Подключение();
            dataSet = new DataSet();
            connection.Open();
            adapter = new SqlDataAdapter("SELECT * FROM Клиент", connection);
            adapter.Fill(dataSet);
            connection.Close();
            return dataSet;
        }
        public DataSet Таблица_Заказ()
        {
            Подключение();
            dataSet = new DataSet();
            connection.Open();
            adapter = new SqlDataAdapter("SELECT * FROM Заказ", connection);
            adapter.Fill(dataSet);
            connection.Close();
            return dataSet;
        }
        public DataSet Таблица_Места()
        {
            Подключение();
            dataSet = new DataSet();
            connection.Open();
            adapter = new SqlDataAdapter("SELECT * FROM Места", connection);
            adapter.Fill(dataSet);
            connection.Close();
            return dataSet;
        }
        public DataSet Таблица_Сотрудники()
        {
            Подключение();
            dataSet = new DataSet();
            connection.Open();
            adapter = new SqlDataAdapter("SELECT * FROM Сотрудники", connection);
            adapter.Fill(dataSet);
            connection.Close();
            return dataSet;
        }
    }
}
