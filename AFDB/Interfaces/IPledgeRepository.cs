using AFDB.Models;

namespace AFDB.Interfaces
{
    public interface IPledgeRepository
    {
        IEnumerable<Pledge> GetAllPledges();
        public void AddPledgeWithPerson(Pledge pledge, Person person);
        public void AddPledge(Pledge pledge);
        void DeletePledge(Pledge pledgeToDelete);
    }
}
