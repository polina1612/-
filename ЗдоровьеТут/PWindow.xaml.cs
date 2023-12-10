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
using ЗдоровьеТут.Model;
using ЗдоровьеТут.Pages;

namespace ЗдоровьеТут
{
    /// <summary>
    /// Логика взаимодействия для PWindow.xaml
    /// </summary>
    public partial class PWindow : Window
    {
        public PWindow()
        {
            InitializeComponent();
            if (DataTransfer.userID != 0)
            {
                userName.Content = DataTransfer.fio;
            }
            else
            {
                userName.Content = "Неавторизированный пользователь";
            }
        }

        private void Button_Click_KatalP(object sender, RoutedEventArgs e)
        {
            FrameFour.Content = new PageKatalogAP();
        }

        private void Button_Click_Au(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Button_Click_KorzinaP(object sender, RoutedEventArgs e)
        {
            FrameFour.Content = new PageKorzinaAP();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_VihodP(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Войти в учетную запись?", "-", MessageBoxButton.YesNo) == MessageBoxResult.No)
            {

            }
            else
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
        }
    }
}
