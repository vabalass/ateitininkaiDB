using AFDB.Models;
using Microsoft.AspNetCore.Mvc;

namespace AFDB.Interfaces
{
    public interface IMembershipFeesServiceCSV
    {
        IActionResult DownloadMemvershipFeesFullCSV(IEnumerable<Membershipfeefull> fees);
        IActionResult DownloadMemvershipFeesFileReadCSV(IEnumerable<Membershipfeefull> fees);
        IEnumerable<Membershipfeefull> generateRandomMembershipFeeFullList(int numberofFees);
        IEnumerable<Membershipfeefull> ReadMembershipFeesCSV(Stream csvStream);
    }
}
