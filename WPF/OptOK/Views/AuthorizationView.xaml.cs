using OptOK.Models.Entities;
using OptOK.Views;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OptOK
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		int attempts = 0;
		public MainWindow()
		{
			Bitmap img = OptOK.Properties.Resources.noproduct;
			ImageConverter converter = new ImageConverter();
			Helper.NoImage = (byte[])converter.ConvertTo(img, typeof(byte[]))!;


			InitializeComponent();
			Bitmap logo = OptOK.Properties.Resources.logo;
			var handle = logo.GetHbitmap();
			ImageSource isc = Imaging.CreateBitmapSourceFromHBitmap(handle, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
			imgIcon.Source = isc;
			Helper.context = new OptOKDbWpfContext();
			textBlockUserName.Text = "fvkbcamhlj52@gmail.com";
			passwordBoxUserPassword.Password = "RSbvHv";


		}


		private void btnLogIn_Click(object sender, RoutedEventArgs e)
		{
			string login = textBlockUserName.Text;
			string pass = passwordBoxUserPassword.Password;

			if (attempts > 1)
			{
				CaptchaWindow cv = new CaptchaWindow();
				this.Hide();
				cv.ShowDialog();
				this.Show();
			}


			User? usr = Helper.context.Users.Include(u => u.Role).Where(u => u.Login == login && u.Password == pass).FirstOrDefault();
			if (usr == null)
			{
				tbFail.Text = "Неправильный логин или пароль!";
				attempts++;
				return;
			}

			tbFail.Text = "";
			MessageBox.Show($"Добро пожаловать, {usr.Firstname} {usr.Patronymic}\n Роль: {usr.Role.RoleName}", "Приветствие");
			Helper.UserName = $"{usr.Surename} {usr.Firstname} {usr.Patronymic}";
			
			Helper.UserRole = usr.Role.RoleName;
			MainView mv = new MainView();
			this.Hide();
			mv.ShowDialog();
			this.Show();


		}

        private void btnLogAsGuest_Click(object sender, RoutedEventArgs e)
        {
            Helper.UserRole = "Гость";
			Helper.UserName = "";

            tbFail.Text = "";
			MessageBox.Show($"Добро пожаловать!\n Роль: Гость", "Приветствие");

			MainView mv = new MainView();
            this.Hide();
            mv.ShowDialog();
            this.Show();
        }
	}
}
