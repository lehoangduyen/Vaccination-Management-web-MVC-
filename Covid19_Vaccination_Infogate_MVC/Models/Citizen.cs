using System;
using System.Reflection.Metadata;

namespace Covid19_Vaccination_Infogate_MVC.Models
{
    public class Citizen
    {
        private int gender;

        //Constructor
        public Citizen()
        {
        }

        //Getter, setter
        public string Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string FullName() { return (LastName + ' ' + FirstName); }
        public string Birthday { get; set; }

        public string Gender(int value = -1)
        {
            if (value == -1)
            {
                switch (gender)
                {
                    case 0:
                        return "Nữ";
                    case 1:
                        return "Nam";
                    default:
                        return "Khác";
                }
            }
            else if (value == -2)
            {
                return gender.ToString();
            }
            else
            {
                gender = value;
            }
            return "";
        }
        public string HomeTown { get; set; }
        public string ProvinceName { get; set; }
        public string DistrictName { get; set; }
        public string TownName { get; set; }
        public string Street { get; set; }
        public string Phone { get; set; }
        public string? Email { get; set; }
        public string? Guadian { get; set; }
        public byte[]? Avatar { get; set; }



    }
}
