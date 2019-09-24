using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestChallenge_FrontEnd_ME.Models;
using TestChallenge_FrontEnd_ME.Services;

namespace TestChallenge_FrontEnd_ME.Pages
{
    public class IndexModel : PageModel
    {
        public IEnumerable<Product> Products { get; set; }
        ProductService _ps = new ProductService();

        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;
        public int Count { get; set; }
        public int PageSize { get; set; } = 9;

        public int TotalPages => (int)Math.Ceiling(decimal.Divide(Count, PageSize));

        public async Task OnGetAsync()
        {
            Products = await _ps.GetPaginatedResult(CurrentPage, PageSize);
            Count = await _ps.GetCount();

        }
    }
}