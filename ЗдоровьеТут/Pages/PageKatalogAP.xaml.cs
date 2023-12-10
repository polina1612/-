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
using ЗдоровьеТут.Model;

namespace ЗдоровьеТут.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageZakazAP.xaml
    /// </summary>
    public partial class PageKatalogAP : Page
    {

        public PageKatalogAP()
        {
            InitializeComponent();
            ProductsListView.ItemsSource = АптекаEntities.GetContext().Товар.ToList();
        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            ProductsListView.ItemsSource = АптекаEntities.GetContext().Товар.Where(x => x.Наименование.Contains(Search.Text)).ToList();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var current = (Товар)ProductsListView.SelectedItem;
            BasketClass.addProduct((int)current.ID);
        }


       
       
    }
}
