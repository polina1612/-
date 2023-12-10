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
using System.Windows.Shapes;
using ЗдоровьеТут.ApplicationData;

namespace ЗдоровьеТут
{
    /// <summary>
    /// Логика взаимодействия для RegWindow.xaml
    /// </summary>
    public partial class RegWindow : Window
    {
        public RegWindow()
        {
            InitializeComponent();
        }

        private void Button_Aut_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainwindow = new MainWindow();
            mainwindow.Show();
            this.Close();
        }
       
        private void Button_Click_Regist(object sender, RoutedEventArgs e)
        {
            if (TextBoxLogin2.Text == "" || TextBoxLogin2.Text == "" || TextBoxName.Text == "" || PasswordBoxPassword2.Password == "" || PasswordBoxPassword3.Password == "")
            {
                
                MessageBox.Show("Введите данные для регистрации", "Внимание");
                return;
            }
            Пользователь userObj = new Пользователь()
                {
                    НомерТелефона = TextBoxLogin2.Text,
                    ФИО = TextBoxName.Text,
                    Пароль = PasswordBoxPassword2.Password,
                    Роль ="Пользователь",
                };
            АптекаEntities.GetContext().Пользователь.Add(userObj);
            try
            {
                АптекаEntities.GetContext().SaveChanges();
                MessageBox.Show("Успешная регистрация");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
        }

        private void PasswordBoxPassword3_PasswordChanged(object sender, RoutedEventArgs e)
        {
           

            if (PasswordBoxPassword3.Password != PasswordBoxPassword2.Password)
            {
                btnReg.IsEnabled = false;
                PasswordBoxPassword3.Background = Brushes.LightCoral; ;
                PasswordBoxPassword3.BorderBrush = Brushes.Red;
            }
            else
            {
                btnReg.IsEnabled = true;
                PasswordBoxPassword3.Background = Brushes.LightGreen; ;
                PasswordBoxPassword3.BorderBrush = Brushes.Green;
            }
        }
    }
}
