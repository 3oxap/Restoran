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
       

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Grid_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            бД = new БД();
            бД.Подключение();
         
        }

        private void tab_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //tab.SelectedIndex = 4;
            //делается проверка если true, то открывается доступ к дргуим вкладкам
        }

        private void TabItem_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            бД = new БД();
            БлюдаGrid.ItemsSource = бД.Таблица_Блюда().Tables[0].DefaultView;
        }

        private void tab1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            бД = new БД();
            ЗаказGrid.ItemsSource = бД.Таблица_Заказ().Tables[0].DefaultView;
        }

        private void tab2_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            бД = new БД();
            КлиентыGrid.ItemsSource = бД.Таблица_Клиенты().Tables[0].DefaultView;
        }

        private void tab3_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            бД = new БД();
            МестаGrid.ItemsSource = бД.Таблица_Места().Tables[0].DefaultView;
        }
    }
}