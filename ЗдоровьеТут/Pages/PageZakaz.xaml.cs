using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace ЗдоровьеТут.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageZakaz.xaml
    /// </summary>
    public partial class PageZakaz : Page
    {
        public static АптекаEntities DataEntitiesZakaz { get; set; }
        public ObservableCollection<Заказ> ListZakaz { get; set; }
        public PageZakaz()
        {
            InitializeComponent();
            DataEntitiesZakaz = new АптекаEntities();
            ListZakaz = new ObservableCollection<Заказ>();
        }

        private void DataGridEmployee_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            GetZakaz();
            DataGridEmployee.SelectedIndex = 0;
        }
        private void GetZakaz()
        {
            var zakazs = DataEntitiesZakaz.Заказ;
            var queryZakaz = from Заказ in zakazs
                               orderby Заказ.ID
                               select Заказ;
            foreach (Заказ pac in queryZakaz)
            {
                ListZakaz.Add(pac);
            }
            DataGridEmployee.ItemsSource = ListZakaz;
        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {

        }
    }
}
