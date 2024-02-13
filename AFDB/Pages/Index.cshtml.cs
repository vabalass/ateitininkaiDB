using AFDB.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AFDB.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public IndexModel(ILogger<IndexModel> logger, AteitininkaiDbContext context)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}
