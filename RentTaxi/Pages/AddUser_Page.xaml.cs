using RenTaxi.LIB;
using RenTaxi.LIB.AdminModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace RentTaxi.Pages
{
    /// <summary>
    /// Interaction logic for AddUser_Page.xaml
    /// </summary>
    public partial class AddUser_Page : Page
    {
        Random rand = new Random();
        public AddUser_Page()
        {
            InitializeComponent();
        }

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            string temp = "";
            ServicesXml sx = new ServicesXml();
            Tbl_User tuser = new Tbl_User();
            tuser.UserId = rand.Next();
            tuser.UserName = string.Format("{0}{1}",
                tbFName.Text, tbLName.Text.Substring(0, 1));
            tuser.Password = rand.Next().ToString();
            tuser.DateOfBirthday = (DateTime)dpDoB.SelectedDate;
            tuser.Gender = (Gender)(lbGender.SelectedIndex);

            if (!sx.AddUser(tuser, out temp))
            {
                errorMesage.Foreground = new SolidColorBrush(Colors.Red);
                errorMesage.Content = temp;
            }
            else
            {
                errorMesage.Foreground = new SolidColorBrush(Colors.Green);
                errorMesage.Content = temp;
                Thread.Sleep(3000);
                AdminWindow.mf.Source = new Uri("Pages/ListUsersPage.xaml", UriKind.RelativeOrAbsolute);
            }
        }
    }
}
