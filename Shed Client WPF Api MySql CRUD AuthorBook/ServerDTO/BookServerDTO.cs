using System.Collections.ObjectModel;

namespace Shed_Client_WPF_Api_MySql_CRUD_AuthorBook.ServerDTO
{
    public partial class BookServerDTO
    {

        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public int IdGenre { get; set; }

        public string? Description { get; set; }
        public GanreServerDTO GanreServer { get; set; } = new GanreServerDTO();

    }
    
}
