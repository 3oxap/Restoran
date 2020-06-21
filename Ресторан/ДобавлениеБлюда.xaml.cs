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
using System.Windows.Shapes;

namespace Ресторан
{
    /// <summary>
    /// Логика взаимодействия для ДобавлениеБлюда.xaml
    /// </summary>
    public partial class ДобавлениеБлюда : Window
    {
        public ДобавлениеБлюда()
        {
            InitializeComponent();
        }
        БД бД;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            бД = new БД();
            бД.Добавление_Блюда(Название.Text, Масса.Text, Convert.ToInt32(Сумма.Text), Категория.Text);
            бД.Таблица_Блюда();
            Close();
        }
    }
}
