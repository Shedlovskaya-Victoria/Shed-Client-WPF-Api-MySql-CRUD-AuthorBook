using Shed_Client_WPF_Api_MySql_CRUD_AuthorBook.Helper;
using Shed_Client_WPF_Api_MySql_CRUD_AuthorBook.ServerDTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
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
    /// Логика взаимодействия для Authors.xaml
    /// </summary>
    public partial class AuthorsPage : Page, INotifyPropertyChanged
    {
        private ObservableCollection<AuthorServerDTO> authors;

        public string Search { get; set; } 
        public AuthorServerDTO SelectedAuthors { get; set; }
        public ObservableCollection<AuthorServerDTO> Authors 
        { 
            get => authors;
            set
            {
                authors = value;
                Signal()
 ;            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void Signal([CallerMemberName] string prop = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        public AuthorsPage()
        {
            InitializeComponent();
            DataContext = this;
            GetAuthors();
            SelectedAuthors = new AuthorServerDTO();

        }
        async void GetAuthors()
        {
            try
            {
              //  HttpClient client = new HttpClient();
               // client.BaseAddress = new Uri("https://localhost:7200/api/");
                Authors = await Http.http().GetFromJsonAsync<ObservableCollection<AuthorServerDTO>>("Authors/GetAll");
                Signal(nameof(Authors));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void CreateNew(object sender, RoutedEventArgs e)
        {
            Navigation.GetInstance().currentPage = new EditAurhor(null);
            GetAuthors();
        }

        private void Edit(object sender, RoutedEventArgs e)
        {
            TestSelected();
            Navigation.GetInstance().currentPage = new EditAurhor(SelectedAuthors);
            GetAuthors();

        }
        void TestSelected()
        {
            if (SelectedAuthors == null)
            {
                MessageBox.Show("Выберите запись!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.None);
                return;
            }
        }
        private async void Delete(object sender, RoutedEventArgs e)
        {
            TestSelected();
            try
            {
              var answ1 = await Http.http().PostAsJsonAsync<AuthorServerDTO>("Authors/Delete", SelectedAuthors);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            GetAuthors();
        }
    }
}
