using System;

namespace Covid19_Vaccination_Infogate_MVC.Models
{
    public class Form
    { 
        //Constructor
        public Form()
        {
            Citizen = new Citizen();
            Choice = "";
            Id = -1;
        }

        //Getter,Setter
        public Citizen Citizen { get ; set ; }
        public string FilledDate { get ; set ; }
        public string Choice { get ; set ; }
        public int Id { get ; set ; }
    }
}
