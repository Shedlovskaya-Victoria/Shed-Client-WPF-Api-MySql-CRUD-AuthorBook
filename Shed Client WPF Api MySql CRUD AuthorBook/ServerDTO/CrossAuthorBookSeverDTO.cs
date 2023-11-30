using System.Collections.ObjectModel;

namespace Shed_Client_WPF_Api_MySql_CRUD_AuthorBook.ServerDTO
{
    public class CrossAuthorBookSeverDTO
    {
        public int Id { get; set; }

        public int IdAuthhor { get; set; }

        public int IdBook { get; set; }
        public AuthorServerDTO Authors { get; set; } = new AuthorServerDTO();
        public BookServerDTO Books { get; set; } = new BookServerDTO();

       
    }
}
