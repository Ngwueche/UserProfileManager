using System.ComponentModel.DataAnnotations;

namespace UserProfileManager.Model
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string MaritalStatus { get; set; }
        public DateTime DOB { get; set; }
        public int DayOfBirth => DOB.Day;
        public int MonthOfBirth => DOB.Month;
        public int YearOfBirth => DOB.Year;

    }
}
