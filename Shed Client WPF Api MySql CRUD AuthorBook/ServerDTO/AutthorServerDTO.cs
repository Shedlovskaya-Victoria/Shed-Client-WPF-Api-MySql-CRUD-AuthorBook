namespace Shed_Client_WPF_Api_MySql_CRUD_AuthorBook.ServerDTO
{
    public partial class AuthorServerDTO
    {
        public int Id { get; set; }

        public string Fio { get; set; } = null!;

        public int? Age { get; set; }

        public string Experience { get; set; } = null!;

    }
}
