using Shed_Client_WPF_Api_MySql_CRUD_AuthorBook.Helper;
using Shed_Client_WPF_Api_MySql_CRUD_AuthorBook.View;
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

namespace Shed_Client_WPF_Api_MySql_CRUD_AuthorBook
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = Navigation.GetInstance();
        }

        private void GoToAuthors(object sender, RoutedEventArgs e)
        {
            Navigation.GetInstance().currentPage = new AuthorsPage();
        }

        private void GoToBooks(object sender, RoutedEventArgs e)
        {
            Navigation.GetInstance().currentPage = new Home();
        }

        private void GoToGanries(object sender, RoutedEventArgs e)
        {
            Navigation.GetInstance().currentPage = new GanrePage();
        }
    }
}
