using OptOK.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OptOK.ViewModels
{
    public class ProductViewModel
    {
        public Visibility buttonVisible { get; set; } = Visibility.Visible;
        public Product Product { get; set; } = null!;

        public byte[]? ProductPicture { get; set; }

		public string Category { get; set; } = null!;
        public int Position { get; set; }

        public string Price
        {
            get
            {
                return Product.Price.ToString("0.####");
            }
        }
		public double CostWithDiscount
		{
			get
			{
				double priceWithoutDiscount = (double)Product.Price;
				double discountAmount = (double)Product.Price * (Product.Discount / 100.0);
				double priceWithDiscount = priceWithoutDiscount - discountAmount;
				return priceWithDiscount;

			}
		}
	}
}
