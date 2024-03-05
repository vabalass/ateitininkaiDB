using AFDB.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AFDB.Pages.People
{
    public class DeletePersonModel : PageModel
    {
        private readonly IPeopleRepository _peopleRepository;

        public DeletePersonModel(IPeopleRepository peopleRepository)
        {
            _peopleRepository = peopleRepository;
        }
        public IActionResult OnGet(int id)
        {
            Console.WriteLine("esu");
            try
            {
                _peopleRepository.DeletePerson(id);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return RedirectToPage("/People/People");
        }
    }
}
