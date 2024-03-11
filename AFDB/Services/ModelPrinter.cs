
using AFDB.Models;

namespace AFDB.Services
{
    public static class ModelPrinter
    {
        public static void PrintPerson(Person Person) 
        {
            Console.WriteLine("ID: " + Person.Id);
            Console.WriteLine(Person.Firstname + " " + Person.Lastname);
            Console.WriteLine(Person.Gender);
            Console.WriteLine("birth: " + Person.Birthdate);
            Console.WriteLine("email: " + Person.Email);
            Console.WriteLine("phone: " + Person.Phone);
            Console.WriteLine("description: " + Person.Description);
            Console.WriteLine("Country: " + Person.Country + " " + Person.City);
            Console.WriteLine("Adress: " + Person.Street + " " + Person.House + "-" + Person.Apartment);
        }

        public static void PrintMembershipFee(Membershipfee membershipfee)
        {
            Console.WriteLine("------------ID: " + membershipfee.Id);
            Console.WriteLine("Person id: " + membershipfee.Personid);
            Console.WriteLine("Suma: " + membershipfee.Amount);
            Console.WriteLine("Mokejimo data: " + membershipfee.Paymentdate);
            Console.WriteLine("Aprašymas" + membershipfee.Description);
        }
    }
}
