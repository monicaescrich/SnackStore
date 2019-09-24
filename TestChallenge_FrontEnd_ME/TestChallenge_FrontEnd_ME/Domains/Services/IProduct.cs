using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestChallenge_FrontEnd_ME.Models;

namespace TestChallenge_FrontEnd_ME.Domains.Services
{
    public interface IProduct
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task<IEnumerable<Product>> GetPaginatedResult(int currentPage, int pageSize = 10);
        Task<int> GetCount();
    }
}
