using System;

namespace Covid19_Vaccination_Infogate_MVC.Models
{
    public class Schedule
    {
        public Schedule()
        {
            Id = "";
            OnDate = "";
            Org = new Organization();
            Vaccine = new Vaccine();
            Serial = "";
            LimitDay = 0;
            LimitNoon = 0;
            LimitNight = 0;
            DayRegistered = 0;
            NoonRegistered = 0;
            NightRegistered = 0;
        }

        public string Id { get; set; }
        public Organization Org { get; set; }
        public string OnDate { get; set; }
        public Vaccine Vaccine { get; set; }
        public string Serial { get; set; }
        public int LimitDay { get; set; }
        public int LimitNoon { get; set; }
        public int LimitNight { get; set; }
        public int DayRegistered { get; set; }
        public int NoonRegistered { get; set; }
        public int NightRegistered { get; set; }
    }
}
