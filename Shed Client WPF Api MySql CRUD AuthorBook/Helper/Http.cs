using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Shed_Client_WPF_Api_MySql_CRUD_AuthorBook.Helper
{
    public static class Http
    {
        private static HttpClient Instance { get; set; } 
        public static HttpClient http()
        {
            if (Instance == null)
            {
                Instance = new HttpClient();
                Instance.BaseAddress = new Uri("https://localhost:7200/api/");
            }
            return Instance;
        }
        public static async void CheskHttp(HttpResponseMessage answ)
        {

            if (answ.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                MessageBox.Show(await answ.Content.ReadAsStringAsync(),
               "Ошибка отправку данных",
               MessageBoxButton.OK, MessageBoxImage.None);
            }
        }
    }
}
