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
    /// Логика взаимодействия для Клиенты.xaml
    /// </summary>
    public partial class Клиенты : Window
    {
        public Клиенты()
        {
            InitializeComponent();
        }
        БД бД;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                бД = new БД();
                бД.Добавление_клиента(ФИО.Text, Convert.ToInt32(Номер.Text));
                Close();
            }
            catch(Exception)
            {

            }
        }
    }
}
