using AFDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AFDB.Pages.FilesPages
{
    public class _DownloadButtonModel : PageModel
    {
        public _DownloadButtonModel(IEnumerable<Person> people)
        { 

        }
        public void OnGet()
        {
        }
    }
}
