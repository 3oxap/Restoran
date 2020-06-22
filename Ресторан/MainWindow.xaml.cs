using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;


namespace Ресторан
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        БД бД;
        bool вход;

        private void Button_Click_1(object sender, RoutedEventArgs e)//выход из программы
        {
            Application.Current.Shutdown();
        }

        private void Grid_MouseDown_1(object sender, MouseButtonEventArgs e)//движение формы
        {
            DragMove();
        }
        
        private void Window_Loaded(object sender, RoutedEventArgs e)//загрузка формы
        {
            бД = new БД();
            бД.Подключение();
           

        }
       
        private void tab_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (вход == true)
            {
               
            }
            else
            {
                tab.SelectedIndex = 4;
            }



        }//переключение между вкладок

     

       

      

      
      

        private void Button_Click(object sender, RoutedEventArgs e)//авторизация
        {
            
            var q= бД.Авторизация(Логин.Text, Пароль.Password);
            вход = q;
            if (вход == true)
            {
                this.Width = 800; this.Height = 450;
                ZBOX.Items.Clear();
                tab.SelectedIndex = -1;
                БлюдаGrid.ItemsSource = бД.Таблица_Блюда().Tables[0].DefaultView;
                ЗаказGrid.ItemsSource = бД.Таблица_Заказ().Tables[0].DefaultView;
                КлиентыGrid.ItemsSource = бД.Таблица_Клиенты().Tables[0].DefaultView;
                МестаGrid.ItemsSource = бД.Таблица_Места().Tables[0].DefaultView;

                string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Зохар\Ресторан.mdf;Integrated Security=True;Connect Timeout=30";
                SqlDataReader reader;
                SqlConnection connection;
                SqlCommand sqlCommand;

                connection = new SqlConnection(connectionString);
               
                sqlCommand = new SqlCommand("SELECT ФИО FROM Клиент", connection);
                connection.Open();
                reader = sqlCommand.ExecuteReader();
                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        string name = reader.GetString(0);
                        ZBOX.Items.Add(name);
                        

                    }
                }
                reader.Close();



            }
            else
            {
                tab.SelectedIndex = 4;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Width = 387; this.Height = 227;
            вход = false;
            Логин.Text = null;
            Пароль.Password= null;
            if (вход == true)
            {
                tab.SelectedIndex = -1;
            }
            else
            {
                tab.SelectedIndex = 4;
            }
        }//выход из программы

        private void Button_Click_3(object sender, RoutedEventArgs e)//поиск в таблице блюда
        {

            БлюдаGrid.ItemsSource = бД.Запрос_Блюда(НазваниеБлюда.Text, КатегорияБлюда.Text);
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            БлюдаGrid.ItemsSource = бД.Таблица_Блюда().Tables[0].DefaultView;
        }//обновление таблицы блюда

        private void Button_Click_5(object sender, RoutedEventArgs e)//поиск в таблице клиенты
        {
            КлиентыGrid.ItemsSource = бД.Запрос_Клиенты(ФИО.Text);
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)//обновление таблицы клиенты
        {
            КлиентыGrid.ItemsSource = бД.Таблица_Клиенты().Tables[0].DefaultView;
        }

        private void tab3_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)//обновление таблицы клиенты
        {
            МестаGrid.ItemsSource = бД.Таблица_Места().Tables[0].DefaultView;
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)//добавление заказа
        {
            ЗаказGrid.ItemsSource = бД.Создание_Заказа(ZBOX.Text,Convert.ToInt32(ЗМесто.Text), ЗБлюда.Text).Tables;
            ЗаказGrid.ItemsSource = бД.Таблица_Заказ().Tables[0].DefaultView;
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)//сохранения заказа(отменено)
        {
          

          


        }

        private void Button_Click_9(object sender, RoutedEventArgs e)//редактирование заказа
        {
            бД.Редактирование_заказа(Convert.ToInt32(ID.Text), ЗБлюда.Text);
            ЗаказGrid.ItemsSource = бД.Таблица_Заказ().Tables[0].DefaultView;

        }

        private void Обновить_Click(object sender, RoutedEventArgs e)
        {
            ZBOX.Items.Clear();
            ЗаказGrid.ItemsSource = бД.Таблица_Заказ().Tables[0].DefaultView;
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Зохар\Ресторан.mdf;Integrated Security=True;Connect Timeout=30";
            SqlDataReader reader;
            SqlConnection connection;
            SqlCommand sqlCommand;

            connection = new SqlConnection(connectionString);

            sqlCommand = new SqlCommand("SELECT ФИО FROM Клиент", connection);
            connection.Open();
            reader = sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string name = reader.GetString(0);
                    ZBOX.Items.Add(name);


                }
            }
            reader.Close();
        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            Клиенты клиенты = new Клиенты();
            клиенты.Show();
        }

        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
            ДобавлениеБлюда добавление = new ДобавлениеБлюда();
            добавление.Show();
           

        }

        private void Button_Click_12(object sender, RoutedEventArgs e)
        {
            //PrintDialog printDialog = new PrintDialog();
            //if(printDialog.ShowDialog()==true)
            //{
            //    printDialog.PrintVisual(ЗаказGrid, "Печать");
            //}
          
            Печать печать = new Печать(Convert.ToInt32(ID.Text));
            печать.Show();

            //MessageBox.Show(бД.Рассчёт_суммы(Convert.ToInt32(ID.Text)).ToString());



        }
    }
}