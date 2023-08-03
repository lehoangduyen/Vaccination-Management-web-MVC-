namespace Covid19_Vaccination_Infogate_MVC.Models
{
    public class Vaccine
    {
        //Constructor
        public Vaccine()
        {
            Id = "";
            Name = "";
            Technology = "";
            Country = "";
        }

        //Getter, Setter
        public string Id { get; set; }
        public string Name { get; set; }
        public string Technology { get; set; }
        public string Country { get; set; }
    }
}
