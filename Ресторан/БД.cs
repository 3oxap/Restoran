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
        SqlDataReader reader;
        SqlCommand sqlCommand;
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


        public DataSet Создание_Заказа(string ФИО, int Место, string Блюда)
        {
            Подключение();
            dataSet = new DataSet();
            connection.Open();
            adapter = new SqlDataAdapter($"INSERT INTO Заказ(ФИО, Места, Блюда) VALUES (N'{ФИО}',{Место},N'{Блюда}')", connection);
            adapter.Fill(dataSet);
            connection.Close();

           



            return dataSet;

        }

        public object Редактирование_заказа(int ID, string Блюда)
        {
            Подключение();
            connection.Open();
            dataSet = new DataSet();

            adapter = new SqlDataAdapter($"SELECT Блюда FROM Заказ WHERE ID={ID}", connection);
            adapter.Fill(dataSet);

            string данные = null;

            foreach (DataTable data in dataSet.Tables)
            {
                foreach (DataRow row in data.Rows)
                {
                    var q = row.ItemArray;
                    foreach (object s in q)
                    {
                        данные = s.ToString();


                    }
                }
            }

            adapter = new SqlDataAdapter($"UPDATE Заказ SET [Блюда]='{данные + " " + Блюда}' WHERE ID ={ID}", connection);
            adapter.Fill(dataSet);

            return 0;

        }


        public void Добавление_клиента(string фио, int телефон)
        {
            Подключение();
            connection.Open();
            dataSet = new DataSet();

            adapter = new SqlDataAdapter($"INSERT INTO Клиент(ФИО, [Номер телефона]) VALUES (N'{фио}',{телефон})", connection);
            adapter.Fill(dataSet);
            connection.Close();
            
        }

        public DataSet dataSetFIO()
        {

            Подключение();
            connection.Open();
            dataSet = new DataSet();

            adapter = new SqlDataAdapter($"SELECT ФИО FROM Клиент", connection);
            adapter.Fill(dataSet);
            return dataSet;
        }

        public void Добавление_Блюда(string Название,string Масса,int Сумма,string Категория)
        {
            Подключение();

            connection.Open();
            dataSet = new DataSet();
            adapter = new SqlDataAdapter($"INSERT INTO Блюда ([Название блюда],[Масса ингридиентов(граммы)],[Сумма(Руб BY)],[Категория]  ) VALUES (N'{Название}',N'{Масса}',{Сумма},N'{Категория}')", connection);
            adapter.Fill(dataSet);
            connection.Close();
            
            
        }
    }
}
