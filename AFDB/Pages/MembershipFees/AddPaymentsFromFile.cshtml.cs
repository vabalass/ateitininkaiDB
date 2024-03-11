using AFDB.Data;
using AFDB.Interfaces;
using AFDB.Models;
using AFDB.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AFDB.Pages.MembershipFees
{
    public class AddPaymentsFromFileModel : PageModel
    {
        private readonly IMembershipFeesServiceCSV _serviceCSV;
        private readonly IMembershipFeeRepository _membershipfeeRepository;
        private readonly IPeopleRepository _peopleRepository;
        private readonly MembershipFeeSimpleService _membershipFeeSimpleService;
        public IEnumerable<Membershipfeefull> Fees;
        [BindProperty]
        public IFormFile CsvFile { get; set; }
        public AddPaymentsFromFileModel(IMembershipFeesServiceCSV serviceCSV, IMembershipFeeRepository membershipFeeRepository, IPeopleRepository peopleRepository)
        {
            _serviceCSV = serviceCSV;
            _membershipfeeRepository = membershipFeeRepository;
            _membershipFeeSimpleService = new MembershipFeeSimpleService();
            _peopleRepository = peopleRepository;
        }
        public ActionResult OnPostDownloadExample()
        {
            return (ActionResult)_serviceCSV.DownloadMemvershipFeesFileReadCSV(_serviceCSV.generateRandomMembershipFeeFullList(3));
        }

        public IActionResult OnPostReadFile()
        {
            try
            {
                if (CsvFile != null)
                {
                    Fees = _serviceCSV.ReadMembershipFeesCSV(CsvFile.OpenReadStream());
                }

                var test = _peopleRepository.SearchForPeopleWithFee(Fees);
                Fees = test;
                MembershipFeesStorage.SetMembershipFees(Fees);
                return Page();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return Page();
            }
        }

        public ActionResult OnPostAddFeesToDB()
        {
            Console.WriteLine("Bandom!!");
            try
            {
                Fees = MembershipFeesStorage.GetMembershipFees();
                if (Fees != null && Fees.Any())
                {
                    try
                    {
                        var filteredFees = _membershipFeeSimpleService.RemoveFeesWithoutPersonId(Fees);
                        var FeesWithPersonId = _membershipFeeSimpleService.convertFromFullToDefault(filteredFees);
                        _membershipfeeRepository.AddMembershipFees(FeesWithPersonId);
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError(string.Empty, ex.Message);
                    }
                    return RedirectToPage("/MembershipFees/MembershipFees");
                }
                else
                {
                    return Page();
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return Page();
            }
        }
        public void OnGet()
        {
        }
    }
}
