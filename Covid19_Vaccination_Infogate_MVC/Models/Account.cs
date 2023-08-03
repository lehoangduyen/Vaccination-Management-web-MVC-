namespace Covid19_Vaccination_Infogate_MVC.Models
{
    public class Account
    {
        //Constructor
        public Account()
        {
            Username = "";
            Password = "";
            Role = -1;
            Status = -1;
        }

        //Getter, Setter
        public string Username { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }
        public int Status { get; set; }

        /*public int MyProperty {
            get 
            {
                *//*logic code*//*
                return MyProperty;
            } 
            set
            {
                *//*logic code*//*
                MyProperty = value;
            }
        }*/
    }
}
