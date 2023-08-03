using System;
namespace Covid19_Vaccination_Infogate_MVC.Models
{
    public class Injection
    {
        //Constructor
        public Injection()
        {
            Citizen = new Citizen();
            InjNO = -1;
            Sched = new Schedule();
            DoseType = "";
        }

        //Getter, setter
        public Citizen Citizen { get ; set; }
        public int InjNO { get ; set ; }
        public Schedule Sched { get ; set; }
        public string DoseType { get; set; }
    }
}
