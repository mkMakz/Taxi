using RenTaxi.LIB;
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
using System.Windows.Shapes;

namespace RentTaxi
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public static Frame mf;
        public AdminWindow()
        {
            InitializeComponent();
            mf = mainFrame;
        }

        private void miAddUser_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Source = 
                new Uri("Pages/AddUser_Page.xaml",
                UriKind.RelativeOrAbsolute);
        }

        private void userInfo_Click(object sender, RoutedEventArgs e)
        {
            //ServicesXml sx = new ServicesXml();
            //sx.getUser();

            mainFrame.Source =
                new Uri("Pages/UsersInfoPage.xaml",
                UriKind.RelativeOrAbsolute);
        }
    }
}
