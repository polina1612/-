using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ЗдоровьеТут.ApplicationData;
using ЗдоровьеТут.Model;

namespace ЗдоровьеТут
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int tries;

        public MainWindow()
        {
            InitializeComponent();
            //AppConnect.modelOdb = new АптекаEntities();
        }

        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            RegWindow regwindow = new RegWindow();
            regwindow.Show();
            this.Close();
        }

        private void Button_Click_Vhod(object sender, RoutedEventArgs e)
        {
            if (TextBoxLogin.Text == "" || PasswordBoxPass.Password == "")
            {

                MessageBox.Show("Введите данные для входа", "Внимание");
                return;
            }
            Пользователь userData = new Пользователь();
            userData = АптекаEntities.GetContext().Пользователь.FirstOrDefault(x => x.НомерТелефона == TextBoxLogin.Text && x.Пароль == PasswordBoxPass.Password);
            
            if(tries>=3 && userData == null)
            {
                DateTime date = DateTime.Now;
                MessageBox.Show($"Вы ввели неверные данные болше трёх раз. Система заблокированна на {10} секунд ", "Внимание");
                while (date.AddSeconds(10)> DateTime.Now)
                {
                    TextBoxLogin.IsEnabled = false;
                    PasswordBoxPass.IsEnabled = false;
                    ButtonVhod.IsEnabled = false;
                    
                }
                TextBoxLogin.IsEnabled = true;
                PasswordBoxPass.IsEnabled = true;
                ButtonVhod.IsEnabled = true;
                return;
            }
            if (userData == null)
            {
                MessageBox.Show("Ошибка ввода данных!", "-", MessageBoxButton.OK);
                tries++;
                return;
            }
            DataTransfer.userID = userData.ID;
            DataTransfer.number = userData.НомерТелефона;
            DataTransfer.password =userData.Пароль;
            DataTransfer.fio = userData.ФИО;

            DataTransfer.role = userData.Роль;

            if(userData.Роль == "Администратор")
            {
                MessageBox.Show("Здравствуйте, Администратор " + userData.ФИО + "!", "-", MessageBoxButton.OK);
                AdminWindow adminwindow = new AdminWindow();
                adminwindow.Show();
                this.Close();
            }
            else
                if(userData.Роль == "Пользователь")
            {
                MessageBox.Show("Здравствуйте, " + userData.ФИО + "!", "-", MessageBoxButton.OK);
                AutPWindow autpwindow = new AutPWindow();
                autpwindow.Show();
                this.Close();
            }
        }

        private void Button_Click_NoAut(object sender, RoutedEventArgs e)
        {
            PWindow pwindow = new PWindow();
            pwindow.Show();
            this.Close();
        }
    }
}
