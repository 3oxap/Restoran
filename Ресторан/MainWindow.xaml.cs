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
           
            var q= бД.Авторизация(Логин.Text, Пароль.Text);
            вход = q;
            if (вход == true)
            {
                tab.SelectedIndex = -1;
                БлюдаGrid.ItemsSource = бД.Таблица_Блюда().Tables[0].DefaultView;
                ЗаказGrid.ItemsSource = бД.Таблица_Заказ().Tables[0].DefaultView;
                КлиентыGrid.ItemsSource = бД.Таблица_Клиенты().Tables[0].DefaultView;
                МестаGrid.ItemsSource = бД.Таблица_Места().Tables[0].DefaultView;
            }
            else
            {
                tab.SelectedIndex = 4;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            вход = false;
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
    }
}