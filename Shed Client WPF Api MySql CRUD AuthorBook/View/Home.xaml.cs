using Shed_Client_WPF_Api_MySql_CRUD_AuthorBook.ServerDTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
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

namespace Shed_Client_WPF_Api_MySql_CRUD_AuthorBook.View
{
    /// <summary>
    /// Логика взаимодействия для Home.xaml
    /// </summary>
    public partial class Home : Page, INotifyPropertyChanged
    {
        private ObservableCollection<BookServerDTO> books;

        public string Search {  get; set; }
        public BookServerDTO SelectedBook {  get; set; }
        public ObservableCollection<BookServerDTO> Books { 
            get => books;
            set
            {
                books = value;
                Signal();
            }
        }
        public Home()
        {
            InitializeComponent();
            DataContext = this;
        }
        void GetBooks()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("");
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void Signal([CallerMemberName] string prop = null) =>
          PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

        private void CreateNew(object sender, RoutedEventArgs e)
        {

        }

        private void Edit(object sender, RoutedEventArgs e)
        {

        }

        private void Delete(object sender, RoutedEventArgs e)
        {

        }
    }
}
