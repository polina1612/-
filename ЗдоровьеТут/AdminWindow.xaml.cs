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
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
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

        private void Button_Click_KatalAD(object sender, RoutedEventArgs e)
        {
            FrameOne.Content = new PageKatalog();
        }

        private void Button_Click_ZakAD(object sender, RoutedEventArgs e)
        {
            FrameOne.Content = new PageZakaz();
        }

        private void Button_Click_PolzAD(object sender, RoutedEventArgs e)
        {
            FrameOne.Content = new PagePolzovately();
        }

        private void Button_Click_VihodAD(object sender, RoutedEventArgs e)
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
