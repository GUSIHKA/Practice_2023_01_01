﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using OptOK.Models.Entities;
using OptOK.Services;
using OptOK.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.IO;
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

namespace OptOK.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для AdminProductPage.xaml
    /// </summary>
    public partial class AdminProductPage : Page
    {



        byte[] byteImage;
        bool imageSet = false;
        Product product;



        public AdminProductPage(int productId)
        {
            InitializeComponent();

            product = Helper.context.Products.Find(productId)!;

            List<Category> cats = Helper.context.Categories.ToList();
            cbCategory.ItemsSource = cats;
            cbCategory.SelectedValuePath = "Id";
            cbCategory.DisplayMemberPath = "CategoryName";
            cbCategory.SelectedValue = product.CategoryId;

            byte[]? pic = Helper.context.ProductPictures.Where(pp => pp.ProductId == product.Id).FirstOrDefault()?.Picture;

            ProductViewModel pvm = new ProductViewModel();
            pvm.Product = product;
            pvm.ProductPicture = pic!;

            ProductStackPanel.DataContext = pvm;
            tbProductCost.Text = pvm.Price;


            List<ProductCharacteristic> productChars = Helper.context.ProductCharacteristics
                                                    .Where(pch => pch.ProductId == product.Id)
                                                    .ToList();

            foreach (ProductCharacteristic chars in productChars)
            {
                chars.Characteristic = Helper.context.Characteristics.Find(chars.CharacteristicId)!;
                lvChars.Items.Add(chars);
            }
        }













        public void ButtonChangePicture_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.webp;*.tiff;*.jfif;";
            if (ofd.ShowDialog() == true)
            {
                string filePath = ofd.FileName;
                BitmapImage bmp = new BitmapImage(new Uri(filePath));

                JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(bmp));
                using (MemoryStream ms = new MemoryStream())
                {
                    encoder.Save(ms);
                    byteImage = ms.ToArray();
                }
                imageProduct.Source = bmp as ImageSource;
                imageSet = true;
            }
        }

        private void ButtonGetBack_Click(object sender, EventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void ButtonDeleteProduct_Click(object sender, RoutedEventArgs e)
        {

            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Вы уверены что хотите удалить всю информацию об этом товаре?", "Удаление", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {

#pragma warning disable CS1030 // Директива #warning
#warning Лучше бы on cascade delete

                Helper.context.Products.Remove(product);
#pragma warning restore CS1030 // Директива #warning
            }
            Helper.context.SaveChanges();
            MessageBox.Show("Товар успешно удален");
            this.NavigationService.GoBack();

        }

        

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            decimal cost;
            if (!Decimal.TryParse(tbProductCost.Text, out cost))
            {
                MessageBox.Show("Неправильно указана цена!", "Ошибка");
                return;
            }
            int discount;
            if (!int.TryParse(tbDiscount.Text, out discount))
            {
                MessageBox.Show("Неправильно указана скидка!", "Ошибка");
                return;
            }
            int maxDiscount;
            if (!int.TryParse(tbMaxDiscount.Text, out maxDiscount))
            {
                MessageBox.Show("Неправильно указана максимальная скидка!", "Ошибка");
                return;
            }
            if (maxDiscount < discount)
            {
                MessageBox.Show("Указанная скидка больше указанной максимальной скидки!", "Ошибка");
                return;
            }

            product.CategoryId = (int)cbCategory.SelectedValue;
            product.Price = cost;
            //Helper.context.Products.Add(product);
            if (imageSet)
            {
                ProductPicture pp = new ProductPicture();
                pp.Picture = byteImage;
                product.ProductPictures.Add(pp);
            }
            Helper.context.SaveChanges();
            MessageBox.Show("Товар успешно изменён");



            //Изменяй картинку
            //Изменяй id категории 
            //Потом только saveChanges

        }


    }
}
