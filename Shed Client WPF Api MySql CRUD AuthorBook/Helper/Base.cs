using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Shed_Client_WPF_Api_MySql_CRUD_AuthorBook.Helper
{
     public class Base : INotifyPropertyChanged
    {
       public  event PropertyChangedEventHandler? PropertyChanged;

        protected void Signal([CallerMemberName] string prop = null) => 
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}
