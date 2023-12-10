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

namespace ЗдоровьеТут.WindowADD
{
    /// <summary>
    /// Логика взаимодействия для WindowADDKatalog.xaml
    /// </summary>
    public partial class WindowADDKatalog : Window
    {
        public WindowADDKatalog()
        {
            InitializeComponent();
        }

        private void Button_ClickADD(object sender, RoutedEventArgs e)
        {
            Товар prodObj = new Товар()
            {
                Наименование = TextBoxNameAD.Text,
                Количество_на_складе = Convert.ToInt32(TextBoxNumber2.Text),
                Цена = Convert.ToInt32(TextBoxPrice.Text),
                Изображение = null,
            };
            АптекаEntities.GetContext().Товар.Add(prodObj);
            try
            {
                АптекаEntities.GetContext().SaveChanges();
                MessageBox.Show("Данные успешно добавлены");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return;
            }
            
        }

        private void Button_ClickCAN(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
