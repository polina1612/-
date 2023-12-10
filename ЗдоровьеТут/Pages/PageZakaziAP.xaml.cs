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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ЗдоровьеТут.Model;

namespace ЗдоровьеТут.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageZakaziAP.xaml
    /// </summary>
    public partial class PageZakaziAP : Page
    {
        public PageZakaziAP()
        {
            InitializeComponent();
            userOrders.ItemsSource = АптекаEntities.GetContext().Заказ.Where(x => x.ID_пользователя == DataTransfer.userID).ToList();
        }
        
    }
}
