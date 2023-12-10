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
    /// Логика взаимодействия для PagePolzovately.xaml
    /// </summary>
    public partial class PagePolzovately : Page
    {
        public static АптекаEntities DataEntitiesPolzovatel { get; set; }
        public ObservableCollection<Пользователь> ListPolzovatel { get; set; }
        public PagePolzovately()
        {
            InitializeComponent();
            DataEntitiesPolzovatel = new АптекаEntities();
            ListPolzovatel = new ObservableCollection<Пользователь>();
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
            var polzovatels = DataEntitiesPolzovatel.Пользователь;
            var queryPolzovatel = from Пользователь in polzovatels
                                  orderby Пользователь.ФИО
                                 select Пользователь;
            foreach (Пользователь pac in queryPolzovatel)
            {
                ListPolzovatel.Add(pac);
            }
            DataGridEmployee.ItemsSource = ListPolzovatel;
        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            DataGridEmployee.ItemsSource = АптекаEntities.GetContext().Пользователь.Where(x => x.ФИО.Contains(Search.Text)).ToList();
        }

       

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Сохранить", "-", MessageBoxButton.YesNo) == MessageBoxResult.No)
            {

            }
            else
            {
                DataEntitiesPolzovatel.SaveChanges();
                DataGridEmployee.IsReadOnly = true;
            }
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            Пользователь pac = DataGridEmployee.SelectedItem as Пользователь;
            if (pac != null)
            {
                MessageBoxResult result = MessageBox.Show("Удалить", "-", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    DataEntitiesPolzovatel.Пользователь.Remove(pac);
                    DataGridEmployee.SelectedIndex = DataGridEmployee.SelectedIndex == 0 ? 1 : DataGridEmployee.SelectedIndex - 1;
                    ListPolzovatel.Remove(pac);
                    DataEntitiesPolzovatel.SaveChanges();
                }
            }
            else
            {
                MessageBox.Show("Выберите строку для удаления", "-", MessageBoxButton.OK);
            }
        }
    }
}
