using System;
using System.Reflection.Metadata;

namespace Covid19_Vaccination_Infogate_MVC.Models
{
    public class New
    {
        private string id;
        private Organization org = new Organization();
        private string tittle;
        private string publishdate;
        private byte[]? image;
        private string content;


        //Constructor
        public New()
        {
            id = "";
            Org = new Organization();
            tittle = "";
            content = "";
        }

        //Getter, Setter
        public string ID { get; set ; }
        public Organization Org { get ; set; }
        public string Tittle { get; set; }
        public string PublishDate { get; set; }
        public byte[] Image { get ; set ; }
        public string Content { get ; set ; }
    }
}
