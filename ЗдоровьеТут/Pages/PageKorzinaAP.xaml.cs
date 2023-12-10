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
    /// Логика взаимодействия для PageKorzinaAP.xaml
    /// </summary>
    public partial class PageKorzinaAP : Page
    {
        private List<Товар> basketItems = new List<Товар>();
        int productID;
        public PageKorzinaAP()
        {
            InitializeComponent();
            Delivery.ItemsSource = АптекаEntities.GetContext().Пункт_Выдачи.ToList();
            basketItems = new List<Товар>();
            foreach (int id in BasketClass.getBasket())
            {
                basketItems.Add(АптекаEntities.GetContext().Товар.Find(id));
            }
            BasketListView.ItemsSource = basketItems;
            updateResultSum();
        }

        private void updateResultSum()
        {
            resultSum.Content = $"Итого:{basketItems.Sum(product => product.Цена)}";
        }

        private void MakeOrder_Click(object sender, RoutedEventArgs e)
        {
            
            if (DataTransfer.userID != 0)
            {
                if (MessageBox.Show($"Вы точно хотите оформить заказ", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    if (Delivery.Text != null)
                    {
                        Заказ orderData = new Заказ();

                        int deliveryID = int.Parse(Delivery.SelectedValue.ToString());

                        orderData.ID_пользователя = DataTransfer.userID;

                        orderData.ID_пункта_выдачи = deliveryID;

                        orderData.Статус_заказа = 2;

                        АптекаEntities.GetContext().Заказ.Add(orderData);

                        foreach (int id in BasketClass.getBasket())
                        {
                            Заказ_Товар orderGoodData = new Заказ_Товар();

                            Товар productID = new Товар();

                            productID = АптекаEntities.GetContext().Товар.Where(u => u.ID == id).FirstOrDefault();

                            orderGoodData.ID_заказа = orderData.ID;

                            orderGoodData.ID_товара = productID.ID;

                            АптекаEntities.GetContext().Заказ_Товар.Add(orderGoodData);
                        }
                        try
                        {
                            АптекаEntities.GetContext().SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                        MessageBox.Show("Заказ оформлен!");
                    }
                    else
                    {
                        MessageBox.Show("Выберите пункт выдачи!");
                        return;
                    }
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, авторизуйтесь, чтобы оформить заказ!");
                return;
            }

        }

        private void ClearBasket_Click(object sender, RoutedEventArgs e)
        {
            System.ComponentModel.IEditableCollectionView items = BasketListView.Items;
            Товар selectedItem = BasketListView.SelectedItems[0] as Товар;
            BasketClass.Delete((int)selectedItem.ID);
            items.Remove(BasketListView.SelectedItem);
            updateResultSum();
        }
    }
}
