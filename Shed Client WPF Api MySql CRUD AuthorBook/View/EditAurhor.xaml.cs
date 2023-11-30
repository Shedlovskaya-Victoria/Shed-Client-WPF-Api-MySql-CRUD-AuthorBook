using Shed_Client_WPF_Api_MySql_CRUD_AuthorBook.Helper;
using Shed_Client_WPF_Api_MySql_CRUD_AuthorBook.ServerDTO;
using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для EditAurhor.xaml
    /// </summary>
    public partial class EditAurhor : Page, INotifyPropertyChanged
    {
        private AuthorServerDTO newAuthor;

        protected void Signal([CallerMemberName] string prop = null) =>
           PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        public AuthorServerDTO NewAuthor { 
            get => newAuthor;
            set
            {
                newAuthor = value;
                Signal();
            }
        }
        bool edit = false;
        public EditAurhor(AuthorServerDTO editAuth)
        {
            InitializeComponent();
            if(editAuth == null )
            {
                NewAuthor = new AuthorServerDTO();
            }
            else
            {
                NewAuthor = editAuth;
                edit = true;
            }
            DataContext = this;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void Exit(object sender, RoutedEventArgs e)
        {
            GoBack();
        }
        void CheskNull()
        {
            if (NewAuthor.Fio == null | NewAuthor.Experience == null)
            {
                MessageBox.Show("Заполните ФИО и Опыт!", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.None);
                return;
            }
        }
        private async void Save(object sender, RoutedEventArgs e)
        {
            CheskNull();
            try
            {
                HttpResponseMessage answ;
                if (edit)
                {
                   answ = await EditResp();
                }
                else
                {
                    answ = await CreateResp();
                }
                Http.CheskHttp(answ);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", 
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            GoBack();
        }
        async Task<HttpResponseMessage> EditResp()
        {
           return await Http.http().PostAsJsonAsync<AuthorServerDTO>("Authors/Edit", NewAuthor);
        }
        async Task<HttpResponseMessage> CreateResp()
        {
            return await Http.http().PostAsJsonAsync<AuthorServerDTO>("Authors/Create", NewAuthor);
        }
        void GoBack()
        {
            Navigation.GetInstance().currentPage = new AuthorsPage();
        }
    }
}
