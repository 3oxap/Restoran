using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Data.Linq;

namespace Ресторан
{
    class БД
    {
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Зохар\Ресторан.mdf;Integrated Security=True;Connect Timeout=30";

        SqlConnection connection;
        SqlDataAdapter adapter;
        DataSet dataSet;
        DataContext dataContext;

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
        public bool Авторизация(string Лог, string Пар)
        {
          
            Подключение();

            dataContext = new DataContext(connection);
            Table<Сотрудники> сотрудникиs = dataContext.GetTable<Сотрудники>();
            //var q = сотрудникиs.Where(i => i.Логин == Лог && i.Пароль == Пар);
            var q = сотрудникиs.Any(i => i.Логин == Лог && i.Пароль == Пар);
            return q;
        }

        public IQueryable<Блюда> Запрос_Блюда(string Название, string Категория)
        {
            Подключение();
            dataContext = new DataContext(connection);
            Table<Блюда> блюдаs = dataContext.GetTable<Блюда>();
            var q = блюдаs.Where(i => i.Название_блюда == Название || i.Категория == Категория);
            
            return q;
        }//поиск Блюда

        public IQueryable<Клиент> Запрос_Клиенты(string ФИО)
        {

            dataContext = new DataContext(connection);
            Table<Клиент> клиентs = dataContext.GetTable<Клиент>();
            var q = клиентs.Where(i => i.ФИО == ФИО);
            return q;
        }
    }
}
