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
    /// Логика взаимодействия для PageKatalog.xaml
    /// </summary>
    public partial class PageKatalog : Page
    {
        public static АптекаEntities DataEntitiesKatalog { get; set; }
        public ObservableCollection<Товар> ListKatalog { get; set; }
        public PageKatalog()
        {
            InitializeComponent();
            DataEntitiesKatalog = new АптекаEntities();
            ListKatalog = new ObservableCollection<Товар>();
        }

        private void DataGridEmployee_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            GetPolzovatel();
            DataGridEmployee.SelectedIndex = 0;
        }
        private void GetPolzovatel()
        {
            var katalogs = DataEntitiesKatalog.Товар;
            var queryKatalog = from Товар in katalogs
                               orderby Товар.Наименование
                                  select Товар;
            foreach (Товар pac in queryKatalog)
            {
                ListKatalog.Add(pac);
            }
            DataGridEmployee.ItemsSource = ListKatalog;
        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            DataGridEmployee.ItemsSource = АптекаEntities.GetContext().Товар.Where(x => x.Наименование.Contains(Search.Text)).ToList();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            WindowADD.WindowADDKatalog windowADDKatalog = new WindowADD.WindowADDKatalog();
            windowADDKatalog.Show();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Редактировать", "-", MessageBoxButton.YesNo) == MessageBoxResult.No)
            {

            }
            else
            {
                DataGridEmployee.IsReadOnly = false;
                DataGridEmployee.BeginEdit();
            }
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Сохранить", "-", MessageBoxButton.YesNo) == MessageBoxResult.No)
            {

            }
            else
            {
                DataEntitiesKatalog.SaveChanges();
                DataGridEmployee.IsReadOnly = true;
            }
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            Товар pac = DataGridEmployee.SelectedItem as Товар;
            if (pac != null)
            {
                MessageBoxResult result = MessageBox.Show("Удалить", "-", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    DataEntitiesKatalog.Товар.Remove(pac);
                    DataGridEmployee.SelectedIndex = DataGridEmployee.SelectedIndex == 0 ? 1 : DataGridEmployee.SelectedIndex - 1;
                    ListKatalog.Remove(pac);
                    DataEntitiesKatalog.SaveChanges();
                }
            }
            else
            {
                MessageBox.Show("Выберите строку для удаления", "-", MessageBoxButton.OK);
            }
        }
    }
}