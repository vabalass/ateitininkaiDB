using AFDB.Data;
using AFDB.Interfaces;
using AFDB.Models;
using AFDB.OthetModels;
using AFDB.Services;
using AFDB.Services.CSVServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AFDB.Pages.MembershipFees
{
    public class MembershipFeesModel : PageModel
    {
        private readonly IMembershipFeeRepository _membershipFeeRepository;
        private readonly IMembershipFeesServiceCSV _serviceCSV;
        private readonly MembershipFeeSimpleService _membershipFeeSimpleService;
        public IEnumerable<Membershipfeefull> Membershipfeesfull;
        [BindProperty]
        public SearchFilters Filter { get; set; }
        public MembershipFeesModel(IMembershipFeeRepository membershipFeeRepository, IMembershipFeesServiceCSV serviceCSV)
        {
            _membershipFeeRepository = membershipFeeRepository;
            _serviceCSV = serviceCSV;
            _membershipFeeSimpleService = new MembershipFeeSimpleService();
            Membershipfeesfull = _membershipFeeRepository.GetAllMembershipFeesFull();
        }
        public ActionResult OnPostDownloadFile()
        {
            var filteredFees = MembershipFeesStorage.GetMembershipFees();
            return (ActionResult)_serviceCSV.DownloadMemvershipFeesFullCSV(filteredFees);
        }
        public void OnPostFilterFees()
        {
            var after = _membershipFeeSimpleService.Filter(Membershipfeesfull, Filter);
            Membershipfeesfull = after;
            MembershipFeesStorage.SetMembershipFees(Membershipfeesfull);
        }
        public void OnGet()
        {
        }
    }
}
