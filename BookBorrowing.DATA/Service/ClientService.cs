using BookBorrowing.DATA.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBorrowing.DATA.Service
{
    public class ClientService
    {
        public RepositoryClient _RepositoryClient { get; set; }

        public ClientService()
        {
            _RepositoryClient = new RepositoryClient();
        }
    }
}
