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
    /// Логика взаимодействия для Печать.xaml
    /// </summary>
    public partial class Печать : Window
    {
        int id = 0;
        public Печать(int id)
        {
            InitializeComponent();
            this.id = id;
        }
        БД бД;

       
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            бД = new БД();
            string[] vs = бД.название_блюд(id).Split(new char[] { ' ', ',' });
            for (int i=0;i< бД.количесво_блюд(id);i++)
            {
               
                    Чек.Items.Add("Блюда "+vs[i]+" Цена "+бД.сумму_блюда(id)[i]);
                
            }
            Чек.Items.Add("Итого " + бД.Рассчёт_суммы(id));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                printDialog.PrintVisual(Чек, "Печать");
            }
        }
    }
}
