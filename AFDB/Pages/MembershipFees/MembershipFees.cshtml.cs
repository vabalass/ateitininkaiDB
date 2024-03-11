using AFDB.Interfaces;
using AFDB.Models;
using AFDB.Services;
using AFDB.Services.CSVServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AFDB.Pages.MembershipFees
{
    public class MembershipFeesModel : PageModel
    {
        private readonly IMembershipFeeRepository _membershipFeeRepository;
        private readonly IServiceCSV _serviceCSV;
        public IEnumerable<Membershipfeefull> Membershipfeesfull;
        public MembershipFeesModel(IMembershipFeeRepository membershipFeeRepository, IServiceCSV serviceCSV)
        {
            _membershipFeeRepository = membershipFeeRepository;
            _serviceCSV = serviceCSV;
            Membershipfeesfull = _membershipFeeRepository.GetAllMembershipFeesFull();
        }
        public ActionResult OnPostDownloadFile()
        {
            return (ActionResult) _serviceCSV.DownloadMemvershipFeesFullCSV(Membershipfeesfull);
        }
        public void OnGet()
        {
        }
    }
}
