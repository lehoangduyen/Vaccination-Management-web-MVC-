namespace Covid19_Vaccination_Infogate_MVC.Models
{
    public class Certificate
    {
        //Constructor
        public Certificate()
        {
            Citizen = new Citizen();
            Dose = -1;
            CertType = -1;
        }

        //Getter, Setter
        public Citizen Citizen { get ; set ; }
        public int Dose { get  ; set  ; }
        public int CertType { get ; set ; }
    }
}
