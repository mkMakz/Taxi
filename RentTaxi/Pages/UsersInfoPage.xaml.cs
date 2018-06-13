using RenTaxi.LIB;
using RenTaxi.LIB.AdminModule;
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

namespace RentTaxi.Pages
{
    /// <summary>
    /// Interaction logic for UsersInfoPage.xaml
    /// </summary>
    public partial class UsersInfoPage : Page
    {
        public List<Tbl_User> users { get; set; }
        public UsersInfoPage()
        {
            InitializeComponent();

            ServicesXml sx = new ServicesXml();
            users = sx.getUser();

            foreach (Tbl_User item in users)
            {
                Expander exp = new Expander();
                exp.Header = item.UserName;

                MainGridInfo.Children.Add(exp);
            }
        }
    }
}
