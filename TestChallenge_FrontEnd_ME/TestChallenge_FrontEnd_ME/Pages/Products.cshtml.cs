using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestChallenge_FrontEnd_ME.Domains.Services;
using TestChallenge_FrontEnd_ME.Models;
using TestChallenge_FrontEnd_ME.Services;

namespace TestChallenge_FrontEnd_ME.Pages
{
    public class IndexModel : PageModel
    {
        public IEnumerable<Product> Products { get; set; }

       ProductService _ps = new ProductService();

        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 0;
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public int Count { get; set; }
        public int PageSize { get; set; } = 9;

        public int TotalPages => (int)Math.Ceiling(decimal.Divide(Count, PageSize));

        public async Task OnGetAsync()
        {
            Count = await _ps.GetCount();
            if (!string.IsNullOrEmpty(SearchString))
            {
                Products = await _ps.ListProductsByName(CurrentPage,SearchString,PageSize);
                
            }
            else
            {
                Products = await _ps.GetPaginatedResult(CurrentPage, PageSize);
            }
        }
    }
}