using Shed_Client_WPF_Api_MySql_CRUD_AuthorBook.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Shed_Client_WPF_Api_MySql_CRUD_AuthorBook.Helper
{
    public class Navigation : Base
    {
         static Navigation instance;

        public static Navigation GetInstance()
        { 
            if (instance == null)
                instance = new Navigation();
            return instance;
        }

        private Page currentPage1;


        public Page currentPage { 
            get => currentPage1;
            set
            {
                currentPage1 = value;
                Signal();
            }
        }
        protected Navigation()
        {
            currentPage = new Home();
        }
    }
}
