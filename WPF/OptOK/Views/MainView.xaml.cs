using OptOK.Views.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Drawing.Drawing2D;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Reflection.Metadata;
using System.Windows.Interop;

namespace OptOK.Views
{
    /// <summary>
    /// Логика взаимодействия для MainVIew.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public CataloguePage cataloguePage;
        public AddProductPage addProductPage;
        public OrderPage orderPage;
        public DisplayOrdersPage displayOrdersPage;


        public MainView()
        {
            InitializeComponent();

            cataloguePage = new CataloguePage(this);
            addProductPage = new AddProductPage();
            orderPage = new OrderPage(this);
            displayOrdersPage = new DisplayOrdersPage();




            //imgAddProduct.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.createProduct.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());

            if (Helper.UserRole == "Администратор")
            {
                btnCart.Visibility = Visibility.Hidden;
                btnCart.Click -= ButtonCart_Click;
            }
            else if (Helper.UserRole == "Клиент")
            {
                btnOrdersPage.Visibility = Visibility.Hidden;
                btnOrdersPage.Click -= btnOrdersPage_Click;

                btnCreateProduct.Visibility = Visibility.Hidden;
                btnCreateProduct.Click -= btnCreateProduct_Click;
            }
            else if (Helper.UserRole == "Гость")
            {
                btnOrdersPage.Visibility = Visibility.Hidden;
                btnOrdersPage.Click -= btnOrdersPage_Click;

                btnCreateProduct.Visibility = Visibility.Hidden;
                btnCreateProduct.Click -= btnCreateProduct_Click;

                btnCart.Visibility = Visibility.Hidden;
                btnCart.Click -= btnCreateProduct_Click;
            }
            ButtonCatalogue_Click(null!, null!);
        }

        private void ButtonAccount_Click(object sender, RoutedEventArgs e)
		{
           
        }

		private void ButtonCart_Click(object sender, RoutedEventArgs e)
		{
			_NavigationFrame.Navigate(orderPage);
		}

        private void ButtonCatalogue_Click(object sender, RoutedEventArgs e)
        {
			_NavigationFrame.Navigate(cataloguePage);
		}

		private void btnCreateProduct_Click(object sender, RoutedEventArgs e)
		{
            _NavigationFrame.Navigate(addProductPage);
        }

		private void btnExit_Click(object sender, RoutedEventArgs e)
		{
            this.Close();
		}

		private void btnOrdersPage_Click(object sender, RoutedEventArgs e)
		{
            _NavigationFrame.Navigate(displayOrdersPage);
        }
    }
}
