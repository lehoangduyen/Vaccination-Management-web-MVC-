namespace Covid19_Vaccination_Infogate_MVC.Models
{
    public class Organization
    {
        //Constructor
        public Organization()
        {
            Id = "";
            Name = "";
            ProvinceName = "";
            DistrictName = "";
            TownName = "";
            Street = "";
        }

        //Getter, Setter
        public string Id { get; set; }
        public string Name { get; set; }
        public string ProvinceName { get; set; }
        public string DistrictName { get; set; }
        public string TownName { get; set; }
        public string Street { get; set; }
    }
}
