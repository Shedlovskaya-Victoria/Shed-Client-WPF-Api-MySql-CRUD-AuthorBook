using Shed_Client_WPF_Api_MySql_CRUD_AuthorBook.Helper;
using Shed_Client_WPF_Api_MySql_CRUD_AuthorBook.ServerDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
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
    /// Логика взаимодействия для EditGanre.xaml
    /// </summary>
    public partial class EditGanre : Page
    {
        public GanreServerDTO Ganre { get; private set; }
        bool edit = false;
        public EditGanre(GanreServerDTO edit)
        {
            InitializeComponent();
            DataContext = this;
            if(edit != null )
            {
                Ganre = edit;
               this.edit = true;
            }
            else
            {
                Ganre = new GanreServerDTO();
            }
        }

        private async void Save(object sender, RoutedEventArgs e)
        {
            CheskNull();
            HttpResponseMessage answ;
            if(edit)
            {
                answ = await EditResp();
            }
            else
            {
                answ = await CreateResp();
            }
            Http.CheskHttp(answ);

            GoBack();
        }
        private async Task<HttpResponseMessage> CreateResp()
        {
            return await Http.http().PostAsJsonAsync<GanreServerDTO>("Ganre/Create", Ganre);
        }

        private async Task<HttpResponseMessage> EditResp()
        {
            return await Http.http().PostAsJsonAsync<GanreServerDTO>("Ganre/Edit", Ganre);
        }

        private void CheskNull()
        {
            if(Ganre.Name == null)
            {
                MessageBox.Show("Заполните название жанра!", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.None);
                return;
            }
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            GoBack();
        }
        void GoBack()
        {
            Navigation.GetInstance().currentPage = new GanrePage();
        }
    }
}
