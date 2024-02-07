using AFDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AFDB.Pages.People
{
    public class CreatePersonModel : PageModel
    {
        [BindProperty]
        public Person Person { get; set; }

        public CreatePersonModel() 
        {
            Person = new Person();
        }
        public void OnPost()
        {
            Console.WriteLine(Person.Email);
            Console.WriteLine(Person.Firstname);
        }
        public void OnGet()
        {
        }
    }
}
