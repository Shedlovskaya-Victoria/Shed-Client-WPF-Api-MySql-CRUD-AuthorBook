using Shed_Client_WPF_Api_MySql_CRUD_AuthorBook.Helper;
using Shed_Client_WPF_Api_MySql_CRUD_AuthorBook.ServerDTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
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
    /// Логика взаимодействия для GanrePage.xaml
    /// </summary>
    public partial class GanrePage : Page, INotifyPropertyChanged
    {
        public string Search { get; set; }
        public ObservableCollection<GanreServerDTO> Ganries {  get; set; }
        public GanreServerDTO SelectedGanre { get; set; }
        public GanrePage()
        {
            InitializeComponent();
            DataContext = this;
            GetGanries();
        }
        protected void Signal([CallerMemberName] string prop = null) =>
           PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        public event PropertyChangedEventHandler? PropertyChanged;

        async void GetGanries()
        {
          Ganries = await Http.http().GetFromJsonAsync<ObservableCollection<GanreServerDTO>>("Ganre/GetAll");
          Signal(nameof(Ganries));
        }

        private void CreateNew(object sender, RoutedEventArgs e)
        {
            Navigation.GetInstance().currentPage = new EditGanre(null);
            GetGanries();
        }

        private void Edit(object sender, RoutedEventArgs e)
        {
            CheskNull();
            Navigation.GetInstance().currentPage = new EditGanre(SelectedGanre);
            GetGanries();
        }

        private void CheskNull()
        {
            if (SelectedGanre == null)
            {
                MessageBox.Show("Выбрите жанр!", "Ошибка",
                   MessageBoxButton.OK, MessageBoxImage.None);
                return;
            }
        }

        private async void Delete(object sender, RoutedEventArgs e)
        {
            CheskNull();
            try
            {
                var answ = await Http.http().PostAsJsonAsync<GanreServerDTO>("Ganre/Delete", SelectedGanre);
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            GetGanries();
        }
    }
}
