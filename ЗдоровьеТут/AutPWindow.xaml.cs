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
    /// Логика взаимодействия для AutPWindow.xaml
    /// </summary>
    public partial class AutPWindow : Window
    {
        public AutPWindow()
        {
            InitializeComponent();
            if(DataTransfer.userID != 0)
            {
                userName.Content = DataTransfer.fio;
            }
            else
            {
                userName.Content = "Неавторизированный пользователь";
            }
        }

        private void Button_Click_KatalogAP(object sender, RoutedEventArgs e)
        {
            FrameThree.Content = new PageKatalogAP();
        }

        private void Button_Click_KorzinaAP(object sender, RoutedEventArgs e)
        {
            FrameThree.Content = new PageKorzinaAP();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_ZakaziAP(object sender, RoutedEventArgs e)
        {
            FrameThree.Content = new PageZakaziAP();
        }

        private void Button_Click_VihodAP(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Действительно выйти?", "-", MessageBoxButton.YesNo) == MessageBoxResult.No)
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
